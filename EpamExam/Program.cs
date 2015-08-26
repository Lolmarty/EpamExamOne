using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace EpamExam
{
    class Program
    {
        private IWebDriver driver;
        static void Main(string[] args)
        {
            //Start chrome and navigate to target page
            IWebDriver driver = new ChromeDriver();
            //IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://rozetka.com.ua/notebooks/c80004/filter/");

            //Create corresponding PO
            RozetkaFilterHome homepage = new RozetkaFilterHome(driver);

            //Intialize selected criteria container
            Dictionary<Enum, List<Enum>> selected_criteria_set;

            Utilities.SelectRandomCriteriaSet(homepage.FilterEnumToCheckboxDictionary, out selected_criteria_set);

            foreach (Enum key in selected_criteria_set.Keys)
            {
                Console.Write(key.ToString() + ": ");
                foreach (Enum item in selected_criteria_set[key])
                {
                    Console.Write(item.ToString()+", ");
                }
                Console.WriteLine();
            }

            //Preload routine
            ReadOnlyCollection<IWebElement> goods;
            homepage.PreloadGoods(out goods);

            CheckCriteria(driver, goods[0], selected_criteria_set);
            
            Thread.Sleep(5000);
        }

        [SetUp]
        public void TestSetup()
        {
            //Start chrome and navigate to target page
            driver = new ChromeDriver();
            //IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(RozetkaFilterHome.UrlAddress);
        }

        [Test]
        public void TestFilters()
        {
            //Create corresponding PO
            RozetkaFilterHome homepage = new RozetkaFilterHome(driver);

            //Intialize selected criteria container
            Dictionary<Enum, List<Enum>> selected_criteria_set;

            Utilities.SelectRandomCriteriaSet(homepage.FilterEnumToCheckboxDictionary, out selected_criteria_set);

            //Preload routine
            ReadOnlyCollection<IWebElement> goods;
            homepage.PreloadGoods(out goods);
            foreach (IWebElement item in goods)
            {
                CheckCriteria(driver, item, selected_criteria_set);    
            }
            
        }

        [TearDown]
        public void TestTeardown()
        {
            driver.Close();
        }

        /// <summary>
        /// Implements the test logic for checking if selected goods fulfill selected criteria
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="item"></param>
        /// <param name="selected_criteria_set"></param>
        public static void CheckCriteria(IWebDriver driver, IWebElement item, Dictionary<Enum, List<Enum>> selected_criteria_set)
        {
            //this is done so that we can get to a link that shall be opened in a new tab
            IWebElement link_item = item.FindElement(By.ClassName("g-i-tile-i-title")); 
            link_item = link_item.FindElement(By.TagName("a"));

            //and it shall be opened in a new tab
            link_item.OpenLinkInNewTab(driver);

            //and we navigate to that new tab which is to the right
            driver.SwitchTabRight(); 

            //Initialize the POM for the properties of the good
            GoodTitlePage good_title_page = new GoodTitlePage(driver);
            GoodPropertiesPage good_properties_page = good_title_page.OpenAllPropertiesPage(driver);

            //we assume that goods properties match the criteria
            bool properties_match = true;

            //We break up the properties page into property-name-property-value pairs by a classname
            ReadOnlyCollection<IWebElement> property_pairs =
                good_properties_page.contProperties.FindElements(By.ClassName("pp-characteristics-tab-i"));

            //And turn it into a dictionary
            Dictionary<string, string> title_value_pairs = new Dictionary<string, string>();
            foreach (IWebElement property_pair in property_pairs)
            {
                string title = property_pair.FindElement(By.ClassName("pp-characteristics-tab-i-title")).Text;
                string value = property_pair.FindElement(By.ClassName("pp-characteristics-tab-i-field")).Text;

                //by shoving title and value in it
                title_value_pairs.Add(title, value);
            }

            //now for EACH criterion (cojunction)
            foreach (Filters key in selected_criteria_set.Keys)
            {
                //if there was no such selected option that products values could fulfill then local_match is false and so is properties match from now on
                properties_match = properties_match && AssertProperties(good_properties_page.txGoodTitle.Text, key, title_value_pairs, selected_criteria_set);
            }

            //finally we check if the properties did indeed match, that is if properties_match is true
            Assert.IsTrue(properties_match);
            
            //Lastly close current tab
            driver.CloseCurrentTab();
        }

        /// <summary>
        /// Checks if a value contains any of the single keywords indexed by keys
        /// </summary>
        /// <param name="value"></param>
        /// <param name="keys"></param>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public static bool Contains(string value, List<Enum> keys, Dictionary<Enum, string> keywords)
        {
            //Initially we think that value doesn't contain any of the keywords
            bool contains = false;

            //So we go over all the indexes
            foreach (Enum index in keys)
            {
                //And if the keyword at an index is in the value
                contains = contains || value.Contains(keywords[index]);
                //then String.Contains returns true and therefore contains becomes true as well
            }
            return contains;
        }
        /// <summary>
        /// Checks if a value contains any of the sets of keywords indexed by keys
        /// </summary>
        /// <param name="value"></param>
        /// <param name="keys"></param>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public static bool ContainsAnd(string value, List<Enum> keys, Dictionary<Enum, string[]> keywords)
        {
            //Initially we think that value doesn't contain any of the keywords
            bool contains = false;

            //So we go over all the indexes
            foreach (Enum index in keys)
            {
                //but this time we need for EACH keyword in the any subset to be present
                bool local_contains = true;  //and we assume that it is so

                //so we go through the subset
                foreach (string keyword in keywords[index])
                {
                    //And if the keyword is NOT in the value
                    local_contains = local_contains && value.Contains(keyword);
                    //then String.Contains returns false and therefore local_contains becomes false
                }

                //but if the keywords are present then local_contains is true
                contains = contains || local_contains;
                //so that contains also becomes true
            }
            return contains;
        }
        /// <summary>
        /// Checks if a value contains any of the keywords in sets indexed by keys
        /// </summary>
        /// <param name="value"></param>
        /// <param name="keys"></param>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public static bool ContainsOr(string value, List<Enum> keys, Dictionary<Enum, string[]> keywords)  //TODO think about logic of this one, maybe also check that no other keywords are in
        {
            //Initially we think that value doesn't contain any of the keywords
            bool contains = false;

            //So we go over all the indexes
            foreach (Enum index in keys)
            {
                //and through the subset
                foreach (string keyword in keywords[index])
                {
                    //And if the keyword is in the value
                    contains = contains || value.Contains(keyword);
                    //then String.Contains returns true and therefore contains becomes true
                }
            }
            return contains;
        }
        /// <summary>
        /// Checks if a value is in any of the ranges indexed by keys
        /// </summary>
        /// <param name="value"></param>
        /// <param name="keys"></param>
        /// <param name="ranges"></param>
        /// <param name="capture_seq"></param>
        /// <returns></returns>
        public static bool InRange(string value, List<Enum> keys, Dictionary<Enum, Range> ranges, string capture_seq)
        {
            Regex capturer = new Regex(capture_seq);
            
            //we look for it in the given string
            Match match = capturer.Match(value);
            
            //if anything is found we
            if (match.Success)
            {
                //assume that our value is not in any of the ranges
                bool in_range = false;

                //parse the value depending on locale
                double target_value = 0;
                try
                {
                    target_value = Double.Parse(match.Groups[1].Captures[0].Value.Replace(".", ","));
                }
                catch (FormatException)
                {
                    target_value = Double.Parse(match.Groups[1].Captures[0].Value.Replace(",", "."));
                }
                
                //look through the given ranges
                foreach (Enum index in keys)
                {
                    //and if any one of them has the value
                    in_range = in_range || ranges[index].Has(target_value);
                    //in_range becomes true
                }
                return in_range;
            }
            return false;
        }
        /// <summary>
        /// Checks if a value converted from miliunits if needed is in any of the ranges indexed by keys 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="keys"></param>
        /// <param name="ranges"></param>
        /// <param name="miliunit_capture_seq"></param>
        /// <param name="unit_capture_seq"></param>
        /// <returns></returns>
        public static bool InRangeConvertThousand(string value, List<Enum> keys, Dictionary<Enum, Range> ranges, string miliunit_capture_seq, string unit_capture_seq)
        {
            Regex gb_capturer = new Regex(miliunit_capture_seq);
            
            //we look for it in the given string
            Match gb_match = gb_capturer.Match(value);


            double target_value;
            //if anything is found we
            if (gb_match.Success)
            {
                //parse the value
                target_value = Double.Parse(gb_match.Groups[1].Captures[0].Value) / 1000;
                //and (since it's in miliunits) divide it by 1000 so that now it is in same units as the values in ranges

            }
            else  //we found nothing
            {
                //We try to capture this time the value in units, not miliunits like last time
                Regex tb_capturer = new Regex(unit_capture_seq);

                //we look for it again
                Match tb_match = tb_capturer.Match(value);

                //and if we find something
                if (tb_match.Success)
                {
                    //parse the value
                    target_value = Double.Parse(tb_match.Groups[1].Captures[0].Value);

                }
                else return false;  //and if not we bail
            }

            //now that we have assigned our target value we
            //assume that our value is not in any of the ranges
            bool in_range = false;

            //look through the given ranges
            foreach (Enum index in keys)
            {
                //and if any one of them has the value
                in_range = in_range || ranges[index].Has(target_value);
                //in_range becomes true
            }
            return in_range;
        }

        /// <summary>
        /// Checks if any value in title_value_pairs contains any of the single keywords indexed by selected_criteria_indexes
        /// </summary>
        /// <param name="property_name"></param>
        /// <param name="selected_criteria_indexes"></param>
        /// <param name="keywords"></param>
        /// <param name="title_value_pairs"></param>
        /// <param name="criteria_keyword_pairs_list"></param>
        /// <returns></returns>
        public static bool AssertPropertiesContains(string property_name, List<Enum> selected_criteria_indexes, Dictionary<Enum, string> keywords, Dictionary<string, string> title_value_pairs, string[] criteria_keyword_pairs_list)
        {
            bool local_match = false;
            string options;
            foreach (string title in criteria_keyword_pairs_list)
            {
                string value = title_value_pairs[title];
                local_match = local_match || Contains(value, selected_criteria_indexes, keywords);
            }
            options = String.Join(",", selected_criteria_indexes.Select(index => keywords[index].ToString()).ToList());
            Assert.IsTrue(local_match, "property " + property_name + " does not match the criteria. selected options were " + options);
            return local_match;
        }
        /// <summary>
        /// Checks if any value in title_value_pairs contains any of the keywords in sets indexed by selected_criteria_indexes
        /// </summary>
        /// <param name="property_name"></param>
        /// <param name="selected_criteria_indexes"></param>
        /// <param name="keywords"></param>
        /// <param name="title_value_pairs"></param>
        /// <param name="criteria_keyword_pairs_list"></param>
        /// <returns></returns>
        public static bool AssertPropertiesContainsOr(string property_name, List<Enum> selected_criteria_indexes, Dictionary<Enum, string[]> keywords, Dictionary<string, string> title_value_pairs, string[] criteria_keyword_pairs_list)
        {
            bool local_match = false;
            string options;
            foreach (string title in criteria_keyword_pairs_list)
            {
                string value = title_value_pairs[title];
                local_match = local_match || ContainsOr(value, selected_criteria_indexes, keywords);
            }
            options = String.Join(",", selected_criteria_indexes.Select(index => String.Join(",", keywords[index])).ToList());
            Assert.IsTrue(local_match, "property " + property_name + " does not match the criteria. selected options were " + options);
            return local_match;
        }
        /// <summary>
        /// Checks if any value in title_value_pairs contains any of the sets of keywords indexed by selected_criteria_indexes
        /// </summary>
        /// <param name="property_name"></param>
        /// <param name="selected_criteria_indexes"></param>
        /// <param name="keywords"></param>
        /// <param name="title_value_pairs"></param>
        /// <param name="criteria_keyword_pairs_list"></param>
        /// <returns></returns>
        public static bool AssertPropertiesContainsAnd(string property_name, List<Enum> selected_criteria_indexes, Dictionary<Enum, string[]> keywords, Dictionary<string, string> title_value_pairs, string[] criteria_keyword_pairs_list)
        {
            bool local_match = false;
            string options;
            foreach (string title in criteria_keyword_pairs_list)
            {
                string value = title_value_pairs[title];
                local_match = local_match || ContainsAnd(value, selected_criteria_indexes, keywords);
            }
            options = String.Join(",", selected_criteria_indexes.Select(index => String.Join(",", keywords[index])).ToList());
            Assert.IsTrue(local_match, "property " + property_name + " does not match the criteria. selected options were " + options);
            return local_match;
        }
        /// <summary>
        /// Checks if any value in title_value_pairs is in any of the ranges indexed by selected_criteria_indexes
        /// </summary>
        /// <param name="property_name"></param>
        /// <param name="selected_criteria_indexes"></param>
        /// <param name="ranges"></param>
        /// <param name="capture_seq"></param>
        /// <param name="title_value_pairs"></param>
        /// <param name="criteria_keyword_pairs_list"></param>
        /// <returns></returns>
        public static bool AssertPropertiesInRange(string property_name, List<Enum> selected_criteria_indexes, Dictionary<Enum, Range> ranges, string capture_seq, Dictionary<string, string> title_value_pairs, string[] criteria_keyword_pairs_list)
        {
            bool local_match = false;
            string options;
            foreach (string title in criteria_keyword_pairs_list)
            {
                //and if a value that contains one of the options is found local_match equals to true
                string value = title_value_pairs[title];
                local_match = local_match || InRange(value, selected_criteria_indexes, ranges, capture_seq);
            }
            options = String.Join(",", selected_criteria_indexes.Select(index => ranges[index].ToString()).ToList());
            Assert.IsTrue(local_match,
                "property " + property_name + " does not match the criteria. selected options were " + options);
            return local_match;
        }
        /// <summary>
        /// Checks if any value in title_value_pairs converted from miliunits if needed is in any of the ranges indexed by selected_criteria_indexes 
        /// </summary>
        /// <param name="property_name"></param>
        /// <param name="selected_criteria_indexes"></param>
        /// <param name="ranges"></param>
        /// <param name="miliunit_capture_seq"></param>
        /// <param name="unit_capture_seq"></param>
        /// <param name="title_value_pairs"></param>
        /// <param name="criteria_keyword_pairs_list"></param>
        /// <returns></returns>
        public static bool AssertPropertiesInRangeConvertThousand(string property_name, List<Enum> selected_criteria_indexes, Dictionary<Enum, Range> ranges, string miliunit_capture_seq, string unit_capture_seq, Dictionary<string, string> title_value_pairs, string[] criteria_keyword_pairs_list)
        {
            bool local_match = false;
            string options;
            foreach (string title in criteria_keyword_pairs_list)
            {
                //and if a value that contains one of the options is found local_match equals to true
                string value = title_value_pairs[title];
                local_match = local_match || InRangeConvertThousand(value, selected_criteria_indexes, ranges, miliunit_capture_seq, unit_capture_seq);
            }
            options = String.Join(",", selected_criteria_indexes.Select(index => ranges[index].ToString()).ToList());
            Assert.IsTrue(local_match,
                "property " + property_name + " does not match the criteria. selected options were " + options);
            return local_match;
        }

        /// <summary>
        /// Checks if any value in title_value_pairs fulfills the criteria in selected_criteria_set
        /// </summary>
        /// <param name="product_name"></param>
        /// <param name="key"></param>
        /// <param name="title_value_pairs"></param>
        /// <param name="selected_criteria_set"></param>
        /// <returns></returns>
        public static bool AssertProperties(string product_name, Filters key, Dictionary<string, string> title_value_pairs, Dictionary<Enum, List<Enum>> selected_criteria_set)
        {
            //we assume that our product does not fulfill any of the options
            bool local_match = false;

            //for error messaging
            string options;

            switch (key)
            {
                //if we're checking the producers (manufacturer's) name we look at the header of the table.
                case Filters.Producer:
                    {
                        local_match = local_match || Contains(product_name, selected_criteria_set[key], PropertyKeywordContainer.ProducerEnumDict);
                        options = String.Join(",", selected_criteria_set[key].Select(index => PropertyKeywordContainer.ProducerEnumDict[index]).ToList());
                        Assert.IsTrue(local_match, "property Producer does not match the criteria. selected options were " + options);
                        break;
                    }
                //in all other situations we look at the table-now-dictionary 

                //and so we seek in ANY (disjunction) of the title-value pairs ANY (disjunction) of the options
                case Filters.ScreenDiag:
                    {
                        local_match = local_match || AssertPropertiesInRange("ScreenDiagonal", selected_criteria_set[key],
                            PropertyKeywordContainer.ScreenDiagEnumDict, PropertyKeywordContainer.ScreenDiagCapruteSeq, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.ScreenResol:
                    {
                        local_match = local_match || AssertPropertiesContainsOr("ScreenResolution", selected_criteria_set[key],
                            PropertyKeywordContainer.ScreenResolEnumDict, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.ScreenType:
                    {
                        local_match = local_match || AssertPropertiesContainsOr("ScreenType", selected_criteria_set[key],
                            PropertyKeywordContainer.ScreenTypeEnumDict, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.ScreenCover:
                    {
                        local_match = local_match || AssertPropertiesContainsOr("ScreenCover", selected_criteria_set[key],
                            PropertyKeywordContainer.ScreenCoverEnumDict, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.ScreenSensor:
                    {
                        local_match = local_match || AssertPropertiesContainsOr("ScreenSensor", selected_criteria_set[key],
                            PropertyKeywordContainer.ScreenSensorEnumDict, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.Processor:
                    {
                        local_match = local_match || AssertPropertiesContainsOr("Processor", selected_criteria_set[key],
                            PropertyKeywordContainer.ProcessorEnumDict, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.RAM:
                    {
                        local_match = local_match || AssertPropertiesInRange("RAM", selected_criteria_set[key],
                            PropertyKeywordContainer.RAMEnumDict, PropertyKeywordContainer.RAMCapruteSeq, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.GPUType:
                    {
                        local_match = local_match || AssertPropertiesContainsOr("GPUType", selected_criteria_set[key],
                            PropertyKeywordContainer.GPUTypeEnumDict, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.GPUMemoryCapacity:
                    {
                        local_match = local_match || AssertPropertiesInRange("GPUMemoryCapacity", selected_criteria_set[key],
                            PropertyKeywordContainer.GPUMemoryCapacityEnumDict, PropertyKeywordContainer.GPUMemoryCapacityCapruteSeq, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.StorageType:
                    {
                        local_match = local_match || AssertPropertiesContainsAnd("StorageType", selected_criteria_set[key],
                            PropertyKeywordContainer.StorageTypeEnumDict, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.StorageVolume:
                    {
                        local_match = local_match || AssertPropertiesInRangeConvertThousand("StorageVolume", selected_criteria_set[key],
                            PropertyKeywordContainer.StorageVolumeEnumDict,
                            PropertyKeywordContainer.StorageVolumeGigabyteCapruteSeq,
                            PropertyKeywordContainer.StorageVolumeTerabyteCapruteSeq, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.OpticalDrive:
                    {
                        local_match = local_match || AssertPropertiesContainsOr("OpticalDrive", selected_criteria_set[key],
                            PropertyKeywordContainer.OpticalDriveEnumDict, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.OS:
                    {
                        local_match = local_match || AssertPropertiesContainsOr("OS", selected_criteria_set[key],
                            PropertyKeywordContainer.OSEnumDict, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.UAKeys:
                    {
                        local_match = local_match || AssertPropertiesContainsOr("UAKeys", selected_criteria_set[key],
                            PropertyKeywordContainer.UAKeysEnumDict, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.Weight:
                    {
                        local_match = local_match || AssertPropertiesInRange("Weight", selected_criteria_set[key],
                            PropertyKeywordContainer.WeightEnumDict, PropertyKeywordContainer.WeightCapruteSeq, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                case Filters.Color:
                    {
                        local_match = local_match || AssertPropertiesContainsOr("Color", selected_criteria_set[key],
                            PropertyKeywordContainer.ColorEnumDict, title_value_pairs,
                            PropertyKeywordContainer.FilterKeywordPairs[key]);
                        break;
                    }
                default:
                    local_match = true;  // there are criteria which really aren't testable. named criteria
                    break;

            }
            return local_match;
        }
    }
}

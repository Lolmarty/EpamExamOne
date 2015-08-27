using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace EpamExam
{
    public static class Utilities
    {
        public const int LoadingTimeout = 6000;
        const int Tries = 100;
        const int CriteriaCount = 20;
        const int OptionCount = 1;
        const string GoodsClassName = "g-i-tile-catalog";
        private const int GoodsTestedCount = 100;

        private const string BodyTag = "body";

        /// <summary>
        /// Switches focus of the WebDriver to the currently selected tab
        /// </summary>
        /// <param name="driver"></param>
        public static void SwitchFocus(this IWebDriver driver)
        {
            Thread.Sleep(LoadingTimeout);
            string current_window = driver.WindowHandles.Last();  //get the window
            driver.SwitchTo().Window(current_window);  //tell the driver to look at it
        }

        /// <summary>
        /// Switches to the next tab to the right from the current one and
        /// Switches focus of the WebDriver to the selected tab
        /// </summary>
        /// <param name="driver"></param>
        public static void SwitchTabRight(this IWebDriver driver)
        {
            driver.FindElement(By.TagName(BodyTag)).SendKeys(Keys.Control + Keys.Tab);  
            driver.SwitchFocus();  //to switch focus to current tab, otherwise the driver will be left behind
        }

        /// <summary>
        /// Switches to the next tab to the left from the current one and
        /// Switches focus of the WebDriver to the selected tab
        /// </summary>
        /// <param name="driver"></param>
        public static void SwitchTabLeft(this IWebDriver driver)
        {
            driver.FindElement(By.TagName(BodyTag)).SendKeys(Keys.Control + Keys.Shift + Keys.Tab); 
            driver.SwitchFocus();  //to switch focus to current tab
        }

        /// <summary>
        /// Closes current tab
        /// Switches focus of the WebDriver to the previously selected tab
        /// </summary>
        /// <param name="driver"></param>
        public static void CloseCurrentTab(this IWebDriver driver)
        {
            driver.FindElement(By.TagName(BodyTag)).SendKeys(Keys.Control + 'w');
            driver.SwitchFocus();
        }

        /// <summary>
        /// Tries to click an element and if any error occures returns false
        /// Else returns true
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool TrySelect(this IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (System.Reflection.TargetInvocationException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// This method opens a link in a new tab 
        /// </summary>
        /// <param name="element"></param>
        public static void OpenLinkInNewTab(this IWebElement element, IWebDriver driver)
        {
            element.SendKeys(Keys.Control + Keys.Return);
        }
        
        /// <summary>
        /// Generates a list of OptionCount options from the elements in criteria_in_filter
        /// </summary>
        /// <param name="criteria_in_filter"></param>
        /// <param name="selected_options_list"></param>
        public static void SelectRandomOptions(Dictionary<Enum, IWebElement> criteria_in_filter, out List<Enum> selected_options_list)
        {
            selected_options_list = new List<Enum>();

            Random gen = new Random();
            
            bool selected = false;
            int tries = Tries;
            int options_count = OptionCount;
            int selected_criterion = gen.Next(criteria_in_filter.Keys.Count);
            Enum key = criteria_in_filter.Keys.ToList()[selected_criterion];  

            while (options_count > 0 && tries > 0) 
            {
                selected = criteria_in_filter[key].TrySelect();

                if (selected)
                {
                    options_count--;
                    selected_options_list.Add(key);
                }

                do  
                {
                    selected_criterion = gen.Next(criteria_in_filter.Keys.Count);
                    key = criteria_in_filter.Keys.ToList()[selected_criterion];
                    tries--;
                } while (selected_options_list.Contains(key) && tries > 0);  

                tries--;
            }
        }
        
        /// <summary>
        /// Generates a set of CriteriaCount criteria from the elements in filters
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="selected_criteria_set"></param>
        public static void SelectRandomCriteriaSet(Dictionary<Enum, Dictionary<Enum, IWebElement>> filters,
            out Dictionary<Enum, List<Enum>> selected_criteria_set)
        {
            selected_criteria_set = new Dictionary<Enum, List<Enum>>();

            Random gen = new Random();

            int tries = Tries;
            int filter_count = CriteriaCount;
            int selected_filter = gen.Next(filters.Keys.Count);
            Enum key = filters.Keys.ToList()[selected_filter];

            while (filter_count > 0 && tries > 0)  
            {
                List<Enum> selected_options_list;

                SelectRandomOptions(filters[key],out selected_options_list);
                
                if (selected_options_list.Count > 0) 
                {
                    selected_criteria_set.Add(key, selected_options_list);
                    filter_count--;
                }  
                
                do 
                {
                    selected_filter = gen.Next(filters.Keys.Count);
                    key = filters.Keys.ToList()[selected_filter];
                    tries--;
                } while (selected_criteria_set.Keys.Contains(key) && tries > 0); 

                tries--;
            }
        }

        /// <summary>
        /// Method for preloading all goods on one page and create a collection of them ready for later usage
        /// </summary>
        /// <param name="homepage"></param>
        /// <param name="goods"></param>
        public static void PreloadGoods(this RozetkaFilterHome homepage, out ReadOnlyCollection<IWebElement> goods)
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(LoadingTimeout);
                    homepage.MoreGoodsPane.Click();
                    //Find (implicitly) the loader element and press it
                }
                catch (System.Reflection.TargetInvocationException)
                {
                    break;  
                    //If the element isn't found this either means 
                    //that we've reached the limit or we are too slow. 
                    //in either case, we stop
                }
                catch (NoSuchElementException)
                {
                    break;
                }
                goods = homepage.contGoods.FindElements(By.ClassName(GoodsClassName)); 
                if (goods.Count > GoodsTestedCount) break;
            }
            goods = homepage.contGoods.FindElements(By.ClassName(GoodsClassName)); 
        }
    
        /// <summary>
        /// Method for switching to the properties tab of the good
        /// </summary>
        /// <param name="good_title_page"></param>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static GoodPropertiesPage OpenAllPropertiesPage(this GoodTitlePage good_title_page, IWebDriver driver)
        {
            good_title_page.lnkAllProperties.Click(); 
            Thread.Sleep(LoadingTimeout); 
            return new GoodPropertiesPage(driver); 
        }        
    }
}

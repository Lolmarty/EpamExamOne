using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EpamExam
{
    public class GoodPropertiesPage
    {
        public GoodPropertiesPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //properties container
        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab_content\"]/div/div/div[2]/dl")]
        public IWebElement contProperties { get; set; }

        //title of the good 
        [FindsBy(How = How.XPath, Using = "//*[@id=\"tab_content\"]/div/div/div[2]/h2")]
        public IWebElement txGoodTitle { get; set; }

    }
}

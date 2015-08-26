using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EpamExam
{
    public class GoodTitlePage
    {
        public GoodTitlePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.XPath, Using="//*[@id=\"tabs\"]/li[2]/a")]
        public IWebElement lnkAllProperties { get; set; }
    }
}

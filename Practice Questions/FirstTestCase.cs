using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Practice_Questions
{
    class FirstTestCase
    {
        public static void InitSelenium()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.demoqa.com";
        }
    }
}

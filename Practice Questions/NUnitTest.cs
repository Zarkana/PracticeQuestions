using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace Practice_Questions
{
    [TestFixture]
    class NUnitTest
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void OpenAppTest()
        {
            driver.Url = "https://www.allsides.com/unbiased-balanced-news";
            string url = driver.PageSource;

            //IWebElement element = driver.FindElement(By.Id(""));
            //element = driver.FindElement(By.Name(""));
            //IWebElement parent = driver.FindElement(By.ClassName("main-story"));
            //IWebElement child = parent.FindElement(By.Id("first-article"));

            List<int> test = new List<int>();
            LinkedList<int> test2 = new LinkedList<int>();


            IList<IWebElement> elements = driver.FindElements(By.CssSelector(".story-title a"));            

            int i = 1;
            string topStories = "";
            foreach(IWebElement e in elements)
            {
                topStories += i + ": " + e.Text + " ";
                i++;
            }
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }

    }
}

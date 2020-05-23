using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWD.tests
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        private string baseURL;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost:5000";
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Closeup()
        {
            driver.Close();
            driver.Quit();
        }
    }
}

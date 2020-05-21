using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWD
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement LoginName => driver.FindElement(By.XPath("//input[ @name =\"Name\"]"));
        private IWebElement LoginPassword => driver.FindElement(By.XPath("//input[ @name =\"Password\"]"));
        private IWebElement LoginBtn => driver.FindElement(By.CssSelector(".btn"));

        public MainPage Login(string name, string password)
        {
            new Actions(driver).Click(LoginName).SendKeys(name).SendKeys(Keys.Tab).Build().Perform();
            new Actions(driver).SendKeys(password).SendKeys(Keys.Enter).Build().Perform();
            return new MainPage(driver);

        }
        public Boolean isElementPresent(string ElementName)
        {
            Thread.Sleep(1000);
            try
            {
                return driver.FindElement(By.XPath($"//input[ @name =\"{ElementName}\"]")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}

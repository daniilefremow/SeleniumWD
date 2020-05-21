using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWD
{
    class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement HomePageTitle => driver.FindElement(By.XPath("//h2"));
        private IWebElement AllProductsBtn => driver.FindElement(By.XPath("//ul//a[@href=\"/Product\"]"));
        private IWebElement LogoutBtn => driver.FindElement(By.XPath("//*[contains(a,\"Logout\")]"));


        public string GetHomePageTitle()
        {
            return HomePageTitle.Text;
        }
        public AllProducts OpenProducts()
        {
           AllProductsBtn.Click();
           return new AllProducts(driver);
        }
        public LoginPage Logout()
        {
            new Actions(driver).Click(LogoutBtn).Build().Perform();
        //  LogoutBtn.Click();
            return new LoginPage(driver);
        }
    }
}

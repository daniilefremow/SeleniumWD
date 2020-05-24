using OpenQA.Selenium;
using SeleniumWD.business_object;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWD
{
    class AllProductsPage
    {
        private IWebDriver driver;

        public AllProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ALLProductsTitle => driver.FindElement(By.XPath("//h2"));
        private IWebElement CreateProductBtn => driver.FindElement(By.CssSelector(".btn"));

        public ProductEditingPage OpenProductCreator()
        {
            CreateProductBtn.Click();
            return new ProductEditingPage(driver);
        }
        public ProductInfoPage OpenProduct(Products products)
        {
            driver.FindElement(By.XPath($"//td[a=\"{products.ProductName}\"]/descendant::*")).Click();
            return new ProductInfoPage(driver);
        }
        public string GetAllProductsTitle()
        {
            return ALLProductsTitle.Text;
        }
        public void Product_Del(Products products)
        {
            driver.FindElement(By.XPath($"//td[a=\"{products.ProductName}\"]/following-sibling::*[10]/a")).Click();
            driver.SwitchTo().Alert().Accept();
        }

        public Boolean isProductPresent(Products products)
        {
            Thread.Sleep(1000);
            try
            {
                return driver.FindElement(By.XPath($"//td[a=\"{products.ProductName}\"]/descendant::*")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


    }
}

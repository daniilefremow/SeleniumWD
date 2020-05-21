﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWD
{
    class AllProducts
    {
        private IWebDriver driver;

        public AllProducts(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ALLProductsTitle => driver.FindElement(By.XPath("//h2"));
        private IWebElement CreateProductBtn => driver.FindElement(By.CssSelector(".btn"));
        private IWebElement Product_Chai => driver.FindElement(By.XPath("//td[a=\"Chai\"]/descendant::*"));
        private IWebElement Product_Truffles_DelBtn => driver.FindElement(By.XPath("//td[a=\"Truffles\"]/following-sibling::*[10]/a"));

        public ProductEditingPage OpenProductCreator()
        {
            CreateProductBtn.Click();
            return new ProductEditingPage(driver);
        }
        public ProductEditingPage OpenProduct_Chai()
        {
            Product_Chai.Click();
            return new ProductEditingPage(driver);
        }
        public string GetAllProductsTitle()
        {
            return ALLProductsTitle.Text;
        }
        public void Product_Truffles_Del()
        {
            Product_Truffles_DelBtn.Click();
            driver.SwitchTo().Alert().Accept();
        }

        public Boolean isProductPresent(string ProductName)
        {
            Thread.Sleep(1000);
            try
            {
                return driver.FindElement(By.XPath($"//td[a=\"{ProductName}\"]/descendant::*")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


    }
}
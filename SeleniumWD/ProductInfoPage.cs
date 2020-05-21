using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWD
{
    class ProductInfoPage
    {
        private IWebDriver driver;
        public ProductInfoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ProductId => driver.FindElement(By.CssSelector("#ProductId"));
        private IWebElement ProductName => driver.FindElement(By.CssSelector("#ProductName"));
        private IWebElement Category => driver.FindElement(By.XPath("//select[@id=\"CategoryId\"]/descendant::option[@selected]"));
        private IWebElement Supplier => driver.FindElement(By.XPath("//select[@id=\"SupplierId\"]/descendant::option[@selected]"));
        private IWebElement UnitPrice => driver.FindElement(By.CssSelector("#UnitPrice"));
        private IWebElement QuantityPerUnit => driver.FindElement(By.CssSelector("#QuantityPerUnit"));
        private IWebElement UnitsInStock => driver.FindElement(By.CssSelector("#UnitsInStock"));
        private IWebElement UnitsOnOrder => driver.FindElement(By.CssSelector("#UnitsOnOrder"));
        private IWebElement ReorderLevel => driver.FindElement(By.CssSelector("#ReorderLevel"));

        public string GetProductId()
        {
            return ProductId.GetAttribute("value");
        }
        public string GetProductName()
        {
            return ProductName.GetAttribute("value");
        }
        public string GetCategory()
        {
            return Category.Text;
        }
        public string GetSupplier()
        {
            return Supplier.Text;
        }
        public string GetUnitPrice()
        {
            return UnitPrice.GetAttribute("value");
        }
        public string GetQuantityPerUnit()
        {
            return QuantityPerUnit.GetAttribute("value");
        }
        public string GetUnitsInStock()
        {
            return UnitsInStock.GetAttribute("value");
        }
        public string GetUnitsOnOrder()
        {
            return UnitsOnOrder.GetAttribute("value");
        }
        public string GetReorderLevel()
        {
            return ReorderLevel.GetAttribute("value");
        }
    }
}

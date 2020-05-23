using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWD.business_object;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWD
{
    class ProductEditingPage
    {
        private IWebDriver driver;

        public ProductEditingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ProductName => driver.FindElement(By.CssSelector("#ProductName"));
        private IWebElement Category => driver.FindElement(By.CssSelector("#CategoryId"));
        private IWebElement Supplier => driver.FindElement(By.CssSelector("#SupplierId"));
        private IWebElement UnitPrice => driver.FindElement(By.CssSelector("#UnitPrice"));
        private IWebElement QuantityPerUnit => driver.FindElement(By.CssSelector("#QuantityPerUnit"));
        private IWebElement UnitsInStock => driver.FindElement(By.CssSelector("#UnitsInStock"));
        private IWebElement UnitsOnOrder => driver.FindElement(By.CssSelector("#UnitsOnOrder"));
        private IWebElement ReorderLevel => driver.FindElement(By.CssSelector("#ReorderLevel"));
        private IWebElement ConfirmBtn => driver.FindElement(By.CssSelector(".btn"));

        public void SetProductName(Products products)
        {
            this.ProductName.SendKeys(products.ProductName);
        }
        public void SetCategory(Products products)
        {
            SelectElement select1 = new SelectElement(this.Category);
            select1.SelectByText("Condiments");
            this.Category.SendKeys(products.Category);
        }
        public void SetSupplier(Products products)
        {
            SelectElement select1 = new SelectElement(this.Supplier);
            select1.SelectByText("Norske Meierier");
            this.Supplier.SendKeys(products.Supplier);
        }
        public void SetUnitPrice(Products products)
        {
            this.UnitPrice.SendKeys(products.UnitPrice);
        }
        public void SetQuantityPerUnit(Products products)
        {
            this.QuantityPerUnit.SendKeys(products.QuantityPerUnit);
        }
        public void SetUnitsInStock(Products products)
        {
            this.UnitsInStock.SendKeys(products.UnitsInStock);
        }
        public void SetUnitsOnOrder(Products products)
        {
            this.UnitsOnOrder.SendKeys(products.UnitsOnOrder);
        }
        public void SetReorderLevel(Products products)
        {
            this.ReorderLevel.SendKeys(products.ReorderLevel);
        }
        public AllProductsPage CreateConfirmation()
        {
            ConfirmBtn.Click();
            return new AllProductsPage(driver);
        }
        

    }
}

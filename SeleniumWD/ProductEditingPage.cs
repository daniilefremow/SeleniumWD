using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        private IWebElement ProductId => driver.FindElement(By.CssSelector("#ProductId"));
        private IWebElement ProductName => driver.FindElement(By.CssSelector("#ProductName"));
        private IWebElement Category => driver.FindElement(By.CssSelector("#CategoryId"));
        private IWebElement Supplier => driver.FindElement(By.CssSelector("#SupplierId"));
        private IWebElement UnitPrice => driver.FindElement(By.CssSelector("#UnitPrice"));
        private IWebElement QuantityPerUnit => driver.FindElement(By.CssSelector("#QuantityPerUnit"));
        private IWebElement UnitsInStock => driver.FindElement(By.CssSelector("#UnitsInStock"));
        private IWebElement UnitsOnOrder => driver.FindElement(By.CssSelector("#UnitsOnOrder"));
        private IWebElement ReorderLevel => driver.FindElement(By.CssSelector("#ReorderLevel"));
        private IWebElement ConfirmBtn => driver.FindElement(By.CssSelector(".btn"));

        public void SetProductName(string ProductName)
        {
            this.ProductName.SendKeys(ProductName);
        }
        public void SetCategory(string Category)
        {
            SelectElement select1 = new SelectElement(this.Category);
            select1.SelectByText("Condiments");
            this.Category.SendKeys(Category);
        }
        public void SetSupplier(string Supplier)
        {
            SelectElement select1 = new SelectElement(this.Supplier);
            select1.SelectByText("Norske Meierier");
            this.Supplier.SendKeys(Supplier);
        }
        public void SetUnitPrice(string UnitPrice)
        {
            this.UnitPrice.SendKeys(UnitPrice);
        }
        public void SetQuantityPerUnit(string QuantityPerUnit)
        {
            this.QuantityPerUnit.SendKeys(QuantityPerUnit);
        }
        public void SetUnitsInStock(string UnitsInStock)
        {
            this.UnitsInStock.SendKeys(UnitsInStock);
        }
        public void SetUnitsOnOrder(string UnitsOnOrder)
        {
            this.UnitsOnOrder.SendKeys(UnitsOnOrder);
        }
        public void SetReorderLevel(string ReorderLevel)
        {
            this.ReorderLevel.SendKeys(ReorderLevel);
        }
        public AllProducts CreateConfirmation()
        {
            ConfirmBtn.Click();
            return new AllProducts(driver);
        }
        

    }
}

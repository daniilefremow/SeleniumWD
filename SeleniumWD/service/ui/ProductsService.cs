using OpenQA.Selenium;
using SeleniumWD.business_object;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWD.service.ui
{
    class ProductsService
    {
        public static AllProductsPage CreateProduct(Products products, IWebDriver driver)
        {
            MainPage mainPage = new MainPage(driver);
            AllProductsPage allProductsPage = mainPage.OpenProducts();
            ProductEditingPage productEditingPage = allProductsPage.OpenProductCreator();
            productEditingPage.SetProductName(products);
            productEditingPage.SetCategory(products);
            productEditingPage.SetSupplier(products);
            productEditingPage.SetUnitPrice(products);
            productEditingPage.SetQuantityPerUnit(products);
            productEditingPage.SetUnitsInStock(products);
            productEditingPage.SetUnitsOnOrder(products);
            productEditingPage.SetReorderLevel(products);
            return productEditingPage.CreateConfirmation();
        }

        public static ProductInfoPage OpenProduct(Products products, IWebDriver driver)
        {
            MainPage mainPage = new MainPage(driver);
            AllProductsPage allProductsPage = mainPage.OpenProducts();
            return allProductsPage.OpenProduct_Chai();
        }
    }
}

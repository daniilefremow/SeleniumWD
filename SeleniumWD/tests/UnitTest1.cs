using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumWD.business_object;
using SeleniumWD.service.ui;
using SeleniumWD.tests;
using System;
using System.Reflection.Metadata;
using System.Threading;

namespace SeleniumWD
{
    public class Tests : BaseTest
    {
        private LoginPage loginPage;
        private MainPage mainPage;
        private AllProductsPage allProductsPage;
        private ProductInfoPage productInfoPage;
        private Products sweets = new Products("Sweets", "Condiments", "Norske Meierier", "90", "3", "120", "40", "5");
        private Products chai = new Products("1", "Chai", "Beverages", "Exotic Liquids", "18,0000", "10 boxes x 20 bags", "39", "0", "10");
        private Products truffles = new Products("Truffles", "Condiments", "Norske Meierier", "90", "3", "120", "40", "5");
        private UsersInfo user1 = new UsersInfo("user", "user");

        [Test]
        public void Login_test()
        {
            mainPage = Autorisation.Login(user1, driver);
            Assert.AreEqual("Home page",mainPage.GetHomePageTitle());
        }

        [Test]
        public void AddProduct_Test()
        {
            mainPage = Autorisation.Login(user1, driver);
            allProductsPage = ProductsService.CreateProduct(sweets, driver);
            Assert.AreNotEqual(allProductsPage.GetAllProductsTitle(),"Product editing");
        }

        [Test]
        public void Check_Test()
        {
            mainPage = Autorisation.Login(user1, driver);
            productInfoPage = ProductsService.OpenProduct(chai, driver);
            Assert.AreEqual(chai.ProductId, productInfoPage.GetProductId());
            Assert.AreEqual(chai.ProductName, productInfoPage.GetProductName());
            Assert.AreEqual(chai.Category, productInfoPage.GetCategory());
            Assert.AreEqual(chai.Supplier, productInfoPage.GetSupplier());
            Assert.AreEqual(chai.UnitPrice, productInfoPage.GetUnitPrice());
            Assert.AreEqual(chai.QuantityPerUnit, productInfoPage.GetQuantityPerUnit());
            Assert.AreEqual(chai.UnitsInStock, productInfoPage.GetUnitsInStock());
            Assert.AreEqual(chai.UnitsOnOrder, productInfoPage.GetUnitsOnOrder());
            Assert.AreEqual(chai.ReorderLevel, productInfoPage.GetReorderLevel());
        }

        [Test]
        public void Delete_test()
        {
            mainPage = Autorisation.Login(user1, driver);
            allProductsPage = ProductsService.CreateProduct(truffles, driver);
            allProductsPage.Product_Del(truffles);
            Assert.AreEqual(false,allProductsPage.isProductPresent(truffles));
        }

        [Test]
        public void Logout_test()
        {
            mainPage = Autorisation.Login(user1, driver);
            loginPage = mainPage.Logout();
            Assert.AreEqual(loginPage.isElementPresent("Name"), true);
            Assert.AreEqual(loginPage.isElementPresent("Password"), true);

        }

    }
    
}
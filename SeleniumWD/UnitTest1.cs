using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection.Metadata;
using System.Threading;

namespace SeleniumWD
{
    public class Tests
    {
        private static IWebDriver driver;
        private string baseURL;
        private LoginPage loginPage;
        private MainPage mainPage;
        private AllProducts allProducts;
        private ProductEditingPage productEditingPage;
        private ProductInfoPage productInfoPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost:5000";
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void Login_test()
        {
            loginPage = new LoginPage(driver);
            mainPage = new MainPage(driver);
            loginPage.Login("user","user");
            Assert.AreEqual("Home page",mainPage.GetHomePageTitle());
        }

        [Test]
        public void AddProduct_Test()
        {
            loginPage = new LoginPage(driver);
            mainPage = new MainPage(driver);
            allProducts = new AllProducts(driver);
            productEditingPage = new ProductEditingPage(driver);
            loginPage.Login("user", "user");
            mainPage.OpenProducts();
            allProducts.OpenProductCreator();
            productEditingPage.SetProductName("Sweets");
            productEditingPage.SetCategory ("Condiments");
            productEditingPage.SetSupplier("Norske Meierier");
            productEditingPage.SetUnitPrice("90");
            productEditingPage.SetQuantityPerUnit("3");
            productEditingPage.SetUnitsInStock("120");
            productEditingPage.SetUnitsOnOrder("40");
            productEditingPage.SetReorderLevel("5");
            productEditingPage.CreateConfirmation();
            Assert.AreNotEqual(allProducts.GetAllProductsTitle(),"Product editing");
        }

        [Test]
        public void Check_Test()
        {
            loginPage = new LoginPage(driver);
            mainPage = new MainPage(driver);
            allProducts = new AllProducts(driver);
            productInfoPage = new ProductInfoPage(driver);
            loginPage.Login("user", "user");
            mainPage.OpenProducts();
            allProducts.OpenProduct_Chai();
            Assert.AreEqual("1", productInfoPage.GetProductId());
            Assert.AreEqual("Chai", productInfoPage.GetProductName());
            Assert.AreEqual("Beverages", productInfoPage.GetCategory());
            Assert.AreEqual("Exotic Liquids", productInfoPage.GetSupplier());
            Assert.AreEqual("18,0000", productInfoPage.GetUnitPrice());
            Assert.AreEqual("10 boxes x 20 bags", productInfoPage.GetQuantityPerUnit());
            Assert.AreEqual("39", productInfoPage.GetUnitsInStock());
            Assert.AreEqual("0", productInfoPage.GetUnitsOnOrder());
            Assert.AreEqual("10", productInfoPage.GetReorderLevel());
        }

        [Test]
        public void Delete_test()
        {
            loginPage = new LoginPage(driver);
            mainPage = new MainPage(driver);
            allProducts = new AllProducts(driver);
            productEditingPage = new ProductEditingPage(driver);
            loginPage.Login("user", "user");
            mainPage.OpenProducts();
            allProducts.OpenProductCreator();
            productEditingPage.SetProductName("Truffles");
            productEditingPage.SetCategory("Condiments");
            productEditingPage.SetSupplier("Norske Meierier");
            productEditingPage.SetUnitPrice("90");
            productEditingPage.SetQuantityPerUnit("3");
            productEditingPage.SetUnitsInStock("120");
            productEditingPage.SetUnitsOnOrder("40");
            productEditingPage.SetReorderLevel("5");
            productEditingPage.CreateConfirmation();
            allProducts.Product_Truffles_Del();
            Assert.AreEqual(false,allProducts.isProductPresent("Truffles"));
        }

        [Test]
        public void Logout_test()
        {
            loginPage = new LoginPage(driver);
            mainPage = new MainPage(driver);
            loginPage.Login("user", "user");
            mainPage.Logout();
            Assert.AreEqual(loginPage.isElementPresent("Name"), true);
            Assert.AreEqual(loginPage.isElementPresent("Password"), true);

        }

        [TearDown]
        public void Closeup()
        {
            driver.Close();
            driver.Quit();
        }

    }
    
}
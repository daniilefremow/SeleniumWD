using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWD.business_object;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumWD.step_definition
{
    [Binding]
    class AddProduct_Steps
    {
        private IWebDriver driver;

        [Given(@"I open ""(.*)"" url")]
        public void GivenIOpenUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = url;
        }

        [When(@"I enter the Name - ""(.*)"" and the Password - ""(.*)""")]
        public void WhenIEnterNameAndPassword(string name, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login(new UsersInfo(name, password));
        }

        [When(@"I click on the login confirmation button")]
        public void WhenIClickOnLoginConfirmationBtn()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginBtnClick();
        }

        [When(@"I open All Products page")]
        public void WhenIOpenAllProductsPage()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.OpenProducts();
        }

        [When(@"I click on the Add product button")]
        public void WhenIClickOnAddProductBtn()
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            allProductsPage.OpenProductCreator();
        }

        [When(@"I enter the Product Name - ""(.*)""")]
        public void WhenIEnterProductName(string product_name)
        {
            ProductEditingPage productEditingPage = new ProductEditingPage(driver);
            productEditingPage.SetProductName(new Products(product_name, null, null, null, null, null, null, null));
        }

        [When(@"I choose the Category - ""(.*)""")]
        public void WhenIChooseCategory(string category)
        {
            ProductEditingPage productEditingPage = new ProductEditingPage(driver);
            productEditingPage.SetCategory(new Products(null, category, null, null, null, null, null, null));
        }

        [When(@"I choose the Supplier - ""(.*)""")]
        public void WhenIChooseSupplier(string supplier)
        {
            ProductEditingPage productEditingPage = new ProductEditingPage(driver);
            productEditingPage.SetSupplier(new Products(null, null, supplier, null, null, null, null, null));
        }

        [When(@"I enter the Unit Price - ""(.*)""")]
        public void WhenIEnterUnitPrice(string unit_price)
        {
            ProductEditingPage productEditingPage = new ProductEditingPage(driver);
            productEditingPage.SetUnitPrice(new Products(null, null, null, unit_price, null, null, null, null));
        }

        [When(@"I enter the Quantity per Unit - ""(.*)""")]
        public void WhenIEnterQuantityPerUnit(string quantity)
        {
            ProductEditingPage productEditingPage = new ProductEditingPage(driver);
            productEditingPage.SetQuantityPerUnit(new Products(null, null, null, null, quantity, null, null, null));

        }

        [When(@"I enter the Units in Stock - ""(.*)""")]
        public void WhenIEnterUnitsInStock(string in_stock)
        {
            ProductEditingPage productEditingPage = new ProductEditingPage(driver);
            productEditingPage.SetUnitsInStock(new Products(null, null, null, null, null, in_stock, null, null));

        }

        [When(@"I enter the Units on Order - ""(.*)""")]
        public void WhenIEnterUnitsOnOrder(string on_order)
        {
            ProductEditingPage productEditingPage = new ProductEditingPage(driver);
            productEditingPage.SetUnitsOnOrder(new Products(null, null, null, null, null, null, on_order, null));

        }

        [When(@"I enter the Reorder Level - ""(.*)""")]
        public void WhenIEnterReorderLevel(string reorder_level)
        {
            ProductEditingPage productEditingPage = new ProductEditingPage(driver);
            productEditingPage.SetReorderLevel(new Products(null, null, null, null, null, null, null, reorder_level));

        }

        [When(@"I click on the Add product confirmation button")]
        public void WhenIClickOnAddProdutConfirmationBtn()
        {
            ProductEditingPage productEditingPage = new ProductEditingPage(driver);
            productEditingPage.CreateConfirmation();

        }

        [Then(@"The product ""(.*)"" should be presented")]
        public void ThenNewProductShouldBePresented(string product_name)
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            Assert.AreEqual(true, allProductsPage.isProductPresent(new Products(product_name, null, null, null, null, null, null, null)));

        }
        
    }
}

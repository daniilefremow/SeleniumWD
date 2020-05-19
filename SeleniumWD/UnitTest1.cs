using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumWD
{
    public class Tests
    {
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void Login_test()
        {
            driver.FindElement(By.XPath("//input[ @name =\"Name\"]")).SendKeys("user");
            driver.FindElement(By.XPath("//input[ @name =\"Password\"]")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            Assert.AreEqual("Home page", driver.FindElement(By.XPath("//h2")).Text);
        }

        [Test]
        public void AddProduct_Test()
        {
            driver.FindElement(By.XPath("//input[ @name =\"Name\"]")).SendKeys("user");
            driver.FindElement(By.XPath("//input[ @name =\"Password\"]")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.XPath("//ul//a[@href=\"/Product\"]")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector("#ProductName")).SendKeys("Sweets");
            SelectElement select1 = new SelectElement(driver.FindElement(By.CssSelector("#CategoryId")));
            select1.SelectByText("Condiments");
            SelectElement select2 = new SelectElement(driver.FindElement(By.CssSelector("#SupplierId")));
            select2.SelectByText("Norske Meierier");
            driver.FindElement(By.CssSelector("#UnitPrice")).SendKeys("90");
            driver.FindElement(By.CssSelector("#QuantityPerUnit")).SendKeys("3");
            driver.FindElement(By.CssSelector("#UnitsInStock")).SendKeys("120");
            driver.FindElement(By.CssSelector("#UnitsOnOrder")).SendKeys("40");
            driver.FindElement(By.CssSelector("#ReorderLevel")).SendKeys("5");
            driver.FindElement(By.CssSelector(".btn")).Click();
            Assert.AreEqual(isElementPresent(By.XPath("//div[h2=\"Product editing\"]")),false);
        }

        [Test]
        public void Check_Test()
        {
            driver.FindElement(By.XPath("//input[ @name =\"Name\"]")).SendKeys("user");
            driver.FindElement(By.XPath("//input[ @name =\"Password\"]")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.XPath("//ul//a[@href=\"/Product\"]")).Click();
            driver.FindElement(By.XPath("//td[a=\"Chai\"]/descendant::*")).Click();
            Assert.AreEqual("1", driver.FindElement(By.CssSelector("#ProductId")).GetAttribute("value"));
            Assert.AreEqual("Chai", driver.FindElement(By.CssSelector("#ProductName")).GetAttribute("value"));
            Assert.AreEqual("Beverages", driver.FindElement(By.XPath("//select[@id=\"CategoryId\"]/descendant::option[@selected]")).Text);
            Assert.AreEqual("Exotic Liquids", driver.FindElement(By.XPath("//select[@id=\"SupplierId\"]/descendant::option[@selected]")).Text);
            Assert.AreEqual("18,0000", driver.FindElement(By.CssSelector("#UnitPrice")).GetAttribute("value"));
            Assert.AreEqual("10 boxes x 20 bags", driver.FindElement(By.CssSelector("#QuantityPerUnit")).GetAttribute("value"));
            Assert.AreEqual("39", driver.FindElement(By.CssSelector("#UnitsInStock")).GetAttribute("value"));
            Assert.AreEqual("0", driver.FindElement(By.CssSelector("#UnitsOnOrder")).GetAttribute("value"));
            Assert.AreEqual("10", driver.FindElement(By.CssSelector("#ReorderLevel")).GetAttribute("value"));
        }

        [Test]
        public void Delete_test()
        {
            driver.FindElement(By.XPath("//input[ @name =\"Name\"]")).SendKeys("user");
            driver.FindElement(By.XPath("//input[ @name =\"Password\"]")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.XPath("//ul//a[@href=\"/Product\"]")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector("#ProductName")).SendKeys("Truffells");
            SelectElement select1 = new SelectElement(driver.FindElement(By.CssSelector("#CategoryId")));
            select1.SelectByText("Condiments");
            SelectElement select2 = new SelectElement(driver.FindElement(By.CssSelector("#SupplierId")));
            select2.SelectByText("Norske Meierier");
            driver.FindElement(By.CssSelector("#UnitPrice")).SendKeys("90");
            driver.FindElement(By.CssSelector("#QuantityPerUnit")).SendKeys("3");
            driver.FindElement(By.CssSelector("#UnitsInStock")).SendKeys("120");
            driver.FindElement(By.CssSelector("#UnitsOnOrder")).SendKeys("40");
            driver.FindElement(By.CssSelector("#ReorderLevel")).SendKeys("5");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.XPath("//td[a=\"Truffells\"]/following-sibling::*[10]/a")).Click();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(500);
            Assert.AreEqual(false,isElementPresent(By.XPath("//td[a=\"Truffells\"]")));
        }

        [Test]
        public void Logout_test()
        {
            driver.FindElement(By.XPath("//input[ @name =\"Name\"]")).SendKeys("user");
            driver.FindElement(By.XPath("//input[ @name =\"Password\"]")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.XPath("//*[contains(a,\"Logout\")]")).Click();
            Assert.AreEqual(isElementPresent(By.CssSelector("label[for= \"Name\"]")), true);
            Assert.AreEqual(isElementPresent(By.CssSelector("label[for= \"Password\"]")), true);

        }

        [TearDown]
        public void Closeup()
        {
            driver.Close();
            driver.Quit();
        }
        public static Boolean isElementPresent(By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
    
}
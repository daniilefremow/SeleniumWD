using OpenQA.Selenium;
using SeleniumWD.business_object;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWD.service.ui
{
    class Autorisation
    {
        public static MainPage Login(UsersInfo usersInfo, IWebDriver driver)
        {
            LoginPage loginPage = new LoginPage(driver);
            return loginPage.Login(usersInfo);
        }
    }
}

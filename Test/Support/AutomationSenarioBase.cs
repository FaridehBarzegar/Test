using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data;
using Test.Pages;

namespace Test.Support
{
    public class AutomationSenarioBase
    {
        public IWebDriver  driver;

        [SetUp]
        public void Setup( )
        {
            driver = new ChromeDriver( );
            driver.Manage( ).Window.Maximize( );
            driver.Navigate( ).GoToUrl( BaseCartableData.Url );
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login_SucceedLoadPage( );
            loginPage.Login_Succeed( LoginData.userNameAdmin, LoginData.passwordAdmin );
            ShellPage shellPage = new ShellPage(driver);
            shellPage.ShellPageLoad( );
            shellPage.OpenOfficeAutomation( );
            
        }
        [TearDown]
        public void CloseDriver( )
        {
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.Logout_Succeed( );
            driver.Close();
            driver.Quit( );
            driver.Dispose( );
            
        }
    }
}

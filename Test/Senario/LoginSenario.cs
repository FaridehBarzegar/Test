
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Pages;
using Test.Support;
using Test.Data;



using NUnit.Framework;
using OfficeOpenXml;
using System.Reflection;
using OpenQA.Selenium.DevTools.V111.Database;

namespace Test.Senario
{
    public class LoginSenario:TestBase
    {
        [Test]
        public void LoadLoginPage( )
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginLoadPage( );
        }
       // [Test,TestCaseSource (typeof(LoginData),nameof(LoginData.ReadExcell))]
        [Test,TestCaseSource( typeof( LoginData ), nameof( LoginData.roots ))]
        public void LoginSucceed(UserLogin userLogin)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginLoadPage( );
            loginPage.LoginSucceed( userLogin );
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.LogoutSucceed( );

        }
    }
}

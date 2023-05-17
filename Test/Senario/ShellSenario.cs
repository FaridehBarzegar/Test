using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data;
using Test.Pages;
using Test.Support;


namespace Test.Senario
{
    public class ShellSenario : TestBase
    {
        [Test]
        public void ShellLoadPage( )
        {
            LoginPage loginPage= new LoginPage(driver);
            loginPage.LoginSucceed( LoginData.userLoginAhmadi );
            ShellPage shellPage = new ShellPage(driver);
            shellPage.ShellLoadPage();
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.LogoutSucceed( );
        }

        [Test]
        public void ShellOpenOfficeAutomation( )
        {
            LoginPage loginPage= new LoginPage( driver );
            loginPage.LoginSucceed( LoginData.userLoginAhmadi );
            ShellPage shellPage = new ShellPage( driver );
            shellPage.ShellLoadPage( );
            shellPage.OpenOfficeAutomation( );
            CartablePage cartablePage = new CartablePage( driver );
            cartablePage.CartableLoaded( );
            cartablePage.CartableBackToShell( );
            LogoutPage logoutPage = new LogoutPage( driver );
            logoutPage.LogoutSucceed( );
        }
    }
}

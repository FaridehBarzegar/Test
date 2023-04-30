using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Pages;
using Test.Support;


namespace Test.Senario
{
    public class ShellSenario : TestBase
    {
        [Test,Order(1)]

        public void LoadShell( )
        {
            LoginPage loginPage= new LoginPage(driver);
            loginPage.Login_Succeed( "ahmadi", "1" );
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( 5 );
            ShellPage shellPage = new ShellPage(driver);
            shellPage.ShellPageLoad( );
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.Logout_Succeed( );
        }

        [Test,Order(2)]
        public void OpenSucceedOfficeAutomation( )
        {
            LoginPage loginPage= new LoginPage(driver);
            loginPage.Login_Succeed( "ahmadi", "1" );
            ShellPage shellPage = new ShellPage(driver);
            shellPage.ShellPageLoad( );
            shellPage.OpenOfficeAutomation( );
            CartablePage cartablePage = new CartablePage(driver);
            cartablePage.CardtableLoaded( );
            cartablePage.BackToShell( );
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.Logout_Succeed( );
        }
        //  [Test]
        //public void LogOut( )
        //{
        //    LoginPage loginPage= new LoginPage(driver);
        //    loginPage.Login_SucceedLoadPage( );
        //    loginPage.Login_Succeed( "administrator", "1" );

        //    ShellPage shellPage = new ShellPage(driver);
        //    shellPage.ShellPageLoad( );
        //    //answer question
        //    shellPage.LogOut( );
        //}
    }
}

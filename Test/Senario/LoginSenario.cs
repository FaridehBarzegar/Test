
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Pages;
using Test.Support;
using  Test.Data;

namespace Test.Senario
{
    public class LoginSenario:TestBase
    {

        [Test]
        public void LoadLoginPage( )
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login_SucceedLoadPage( );
        }
        
        [Test]
        public void LoginSucceed( )
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login_SucceedLoadPage( );
            loginPage.Login_Succeed( LoginData.userNameAdmin, LoginData.passwordAdmin );
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( 5 );
            string m_txtShellHeader = driver.FindElement(By.ClassName("top-Payvast-Title")).Text;
            StringAssert.AreEqualIgnoringCase( "سازمان الکترونیک پیوست", m_txtShellHeader );
            LogoutPage logoutPage = new LogoutPage(driver);
            logoutPage.Logout_Succeed( );

        }
    }
}

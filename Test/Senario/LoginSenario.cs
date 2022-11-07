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
    public class LoginSenario:TestBase
    {

        [Test]
        public void LoginLoadPage( )
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login_SucceedLoadPage( );

        }
        
        [Test]
        public void LoginSucceed( )
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login_Succeed( "administrator", "1" );
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( 5 );
            string m_txtShellHeader = driver.FindElement(By.ClassName("top-Payvast-Title")).Text;
            StringAssert.AreEqualIgnoringCase( "سازمان الکترونیک پیوست", m_txtShellHeader );
        }
    }
}

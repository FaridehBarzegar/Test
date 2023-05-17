using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data;

namespace Test.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private IWebElement m_Txtusername => driver.FindElement( By.Name( "Username" ));
        private IWebElement m_Txtpassword => driver.FindElement( By.Id( "Password" ));
        private IWebElement m_Btnlogin => driver.FindElement( By.Id( "login-button" ));
        private IWebElement m_LinkForgotPassword => driver.FindElement( By.Id( "ForgetPasword_link" ));
        private IWebElement m_LabelVersionNumber => driver.FindElement( By.LinkText( "1.000.00 : ویرایش" ));
        private IWebElement m_LabelEnglishLanguage => driver.FindElement( By.LinkText( "English" ));
        private IWebElement m_LabelPersianLanguage => driver.FindElement( By.LinkText( "فارسی" ));
        public LoginPage( IWebDriver driver )
        {
            this.driver = driver;
        }

        public void LoginLoadPage( )
        {
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( 15 );
            Assert.AreEqual( true, m_Txtusername.Displayed );
            Assert.AreEqual( true, m_Txtpassword.Displayed );
            Assert.AreEqual( true, m_Btnlogin.Displayed );
            Assert.AreEqual( "رمز عبور را فراموش کرده ام", m_LinkForgotPassword.Text );
            Assert.AreEqual( "1.000.00 : ویرایش", m_LabelVersionNumber.Text );
            Assert.AreEqual( "فارسی", m_LabelPersianLanguage.Text );
            Assert.AreEqual( "English", m_LabelEnglishLanguage.Text );
        }
        public void LoginSucceed( UserLogin userLogin )
        {
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( 5 );
            m_Txtusername.SendKeys( userLogin.userName );
            m_Txtpassword.SendKeys( userLogin.password );
            m_Btnlogin.Click( );
            try
            {
                driver.SwitchTo( ).Alert( ).Accept( );
            }
            catch ( NoAlertPresentException ex )
            {
                string m_txtShellHeader = driver.FindElement(By.ClassName("top-Payvast-Title")).Text;
                StringAssert.AreEqualIgnoringCase( "سازمان الکترونیک پیوست", m_txtShellHeader );
            }
        }
    }
}

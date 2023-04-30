using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Test.Pages
{
    public class LoginPage
    {
        public IWebDriver driver;
        public LoginPage( IWebDriver driver )
        {
            this.driver = driver;
        //    Login_SucceedLoadPage( );
        }
       // private static bool m_IsLogedIn;
        //public bool IsLogedIn
        //{
        //    get
        //    {
        //        if ( !m_IsLogedIn )
        //            Login_Succeed( "administrator", "1" );
        //        return m_IsLogedIn;
        //    }
        //}
        public IWebElement m_Txtusername => driver.FindElement( By.Name( "Username" ));
        private IWebElement m_Txtpassword => driver.FindElement( By.Id( "Password" ));
        private IWebElement m_Btnlogin => driver.FindElement( By.Id( "login-button" ));
        private IWebElement m_LinkForgotPassword => driver.FindElement( By.Id( "ForgetPasword_link" ));
        private IWebElement m_LabelVersionNumber => driver.FindElement( By.LinkText( "1.000.00 : ویرایش" ));
        private IWebElement m_LabelEnglishLanguage => driver.FindElement( By.LinkText( "English" ));
        private IWebElement m_LabelPersianLanguage => driver.FindElement( By.LinkText( "فارسی" ));

        public void Login_SucceedLoadPage( )
        {
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( 5 );
            Assert.AreEqual( true, m_Txtusername.Displayed );
            Assert.AreEqual( true, m_Txtpassword.Displayed );
            Assert.AreEqual( true, m_Btnlogin.Displayed );
            Assert.AreEqual( "رمز عبور را فراموش کرده ام", m_LinkForgotPassword.Text );
            Assert.AreEqual( "1.000.00 : ویرایش", m_LabelVersionNumber.Text );
            Assert.AreEqual( "فارسی", m_LabelPersianLanguage.Text );
            Assert.AreEqual( "English", m_LabelEnglishLanguage.Text );
        }
        public void Login_Succeed( string username, string password )
        {
            driver.Manage( ).Timeouts( ).PageLoad = TimeSpan.FromSeconds( 5 );
            m_Txtusername.SendKeys( username );
            m_Txtpassword.SendKeys( password );
            m_Btnlogin.Click( );
        }
    }
}

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
        public LoginPage(IWebDriver driver )
        {
            this.driver = driver;
        }

        public IWebElement Txtusername          =>driver.FindElement(By.Name( "Username" ) );
        public IWebElement Txtpassword          =>driver.FindElement(By.Id( "Password" ) );
        public IWebElement Btnlogin             =>driver.FindElement(By.Id( "login-button" ) );
        public IWebElement LinkForgotPassword   =>driver.FindElement(By.Id( "ForgetPasword_link" ));
        public IWebElement LabelVersionNumber   =>driver.FindElement(By.LinkText( "1.000.00 : ویرایش" ));
        public IWebElement LabelEnglishLanguage =>driver.FindElement(By.LinkText( "English" ) );
        public IWebElement LabelPersianLanguage =>driver.FindElement(By.LinkText( "فارسی" ) );

        public void Login_SucceedLoadPage( )
        {
            bool txtUserName     = Txtusername.Displayed;
            bool txtPssword      = Txtpassword.Displayed;
            bool btnLogin        = Btnlogin.Displayed;
            bool forgotPassword  = LinkForgotPassword.Displayed;
            bool versionNumber   = LabelVersionNumber.Displayed;
            bool englishLanguage = LabelEnglishLanguage.Displayed;
            bool persianLanguage = LabelPersianLanguage.Displayed;
        }
        public void Login_Succeed( string username, string password )
        {
            Txtusername.SendKeys( username );
            Txtpassword.SendKeys( password );
            Btnlogin.Click( );
        }









































































































    }
}

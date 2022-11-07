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

        public IWebElement Txtusername =>driver.FindElement(By.Name( "Username" ) );
        public IWebElement Txtpassword =>driver.FindElement(By.Id( "Password" ) );
        public IWebElement Btnlogin =>driver.FindElement(By.Id( "login-button" ) );

        public void Login( string username, string password )
        {
            Txtusername.SendKeys( username );
            Txtpassword.SendKeys( password );
            Btnlogin.Click( );
        }









































































































    }
}

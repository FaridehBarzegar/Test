using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Pages
{

    public class ShellPage
    {
        public IWebDriver driver;
        public ShellPage( IWebDriver driver )
        {
            this.driver = driver;
        }

        public IWebElement BtnOfficeAutomation =>driver.FindElement(By.Id( "OfficeAutomation" ) );
        public IWebElement BtnCalender =>driver.FindElement(By.Id( "Calendar" ) );
        public IWebElement BtnLogOut =>driver.FindElement(By.LinkText( "خروج" ) );
        

        public void OpenOfficeAutomation(  )
        {
            BtnOfficeAutomation.Click();
           
        }
        public void LogOut( )
        {
            BtnLogOut.Click();
        }









































































































    }
}

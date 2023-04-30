﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Pages
{
    public class LogoutPage
    {
        private IWebElement m_BtnExit => driver.FindElement( By.XPath( "//a[contains(.,'خروج')]" ) );
        private IWebDriver driver;
        public LogoutPage(IWebDriver driver )
        {
            this.driver = driver;
        }
        public void Logout_Succeed( )
        {
            driver.Manage( ).Timeouts( ).ImplicitWait = TimeSpan.FromSeconds( 5 );
            m_BtnExit.Click();
       }

    }
}
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
//using OpenQA.Selenium.DevTools.V105.DOM;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SeleniumExtras.WaitHelpers;
using Test.Public;

namespace Test.Pages
{

    public class CartablePage
    {
        private IWebDriver driver;
        private IWebElement m_BtnNewMemorandom           => driver.FindElement( By.Id( "38153e8e-0e5e-4ad8-bc84-fa9e810023d2" ) );
        private IWebElement m_RowCartable                => driver.FindElement( By.CssSelector( "#-\\32 147479068" ) );
        private IWebElement m_BtnNewOutgoingLetter       => driver.FindElement( By.Id( "2bc68c0a-45b6-445d-910f-0813389ba951" ) );
        private IWebElement m_BtnNewInternalLetter       => driver.FindElement( By.Id( "e6b0b89c-f8b3-40ca-8c13-935a9032c662" ) );
        private IWebElement m_BtnNewEform                => driver.FindElement( By.Id( "43fa13dd-cb8f-4daf-be7a-c3712435c10b" ) );
        private IWebElement m_BtnInboxCartable           => driver.FindElement( By.XPath( "//dt[@class='item empty  selected']//span[@class='title']" ) );
        private IWebElement m_BtnRefresh                 => driver.FindElement( By.Id( "7d7b23e0-7b19-4e61-a50b-44c3ac6a6d74" ) );
        private IWebElement m_BtnbeingProcessingCartable => driver.FindElement( By.PartialLinkText( "در دست اقدام" ) );
        private IWebElement m_BtnFollowUpCartable       => driver.FindElement(  By.XPath( "//span[.='پیگیری ها']" ) );
        private IWebElement m_Btnexpandservices         => driver.FindElement(  By.Id( "expand-services" ) );
        private IWebElement m_BtnSetting                => driver.FindElement(  By.Id( "setting-button" ) );
        private IWebElement m_BtnBackToShell            => driver.FindElement(  By.CssSelector( "[alt='ليست برنامه‌ها']" ) );
        private WebDriverWait webDriverWait;

        public CartablePage( IWebDriver driver )
        {
            this.driver = driver;
                    
        }
        public void CartableLoaded( )
        {
            driver.ImplicitWaitFor( 15 );
            IWebElement m_BtnNewOutgoingLetter1= WaitManagement.WaitForLoadAnElementById( driver , 7,"2bc68c0a-45b6-445d-910f-0813389ba951" );
            IWebElement m_BtnNewMemorandom= WaitManagement.WaitForLoadAnElementById( driver , 7,"38153e8e-0e5e-4ad8-bc84-fa9e810023d2" );
            Assert.AreEqual( "جاری", m_BtnInboxCartable.Text );
            Assert.AreEqual( "پیگیری ها", m_BtnFollowUpCartable.Text );
            Assert.AreEqual( true, m_BtnbeingProcessingCartable.Displayed );            
            Assert.AreEqual( "نامه صادره جدید", m_BtnNewOutgoingLetter1.Text );
            Assert.AreEqual( "نامه داخلی جدید", m_BtnNewInternalLetter.Text );
            Assert.AreEqual( "یادداشت اداری جدید", m_BtnNewMemorandom.Text );
            Assert.AreEqual( "فرم جدید", m_BtnNewEform.Text );
            Assert.AreEqual( "به روز رسانی", m_BtnRefresh.Text );
            Assert.AreEqual(true, m_BtnBackToShell.Displayed );
            Assert.AreEqual(true, m_Btnexpandservices.Displayed );
            //var x = m_BtnSetting.GetAttribute( "data-title" );
            //var aTag = m_BtnSetting.FindElement( By.TagName( "a" ) );
            //var titlte = aTag.GetAttribute("data-title");
        }

        public void CartableOpenFollowUp(  )
        {
            m_BtnFollowUpCartable.Click( );
            driver.ImplicitWaitFor( 15 );
        }

        public void CartableBackToShell( )
        {
            driver.ImplicitWaitFor( 5 );
            m_BtnBackToShell.Click( );
            ShellPage shellPage = new ShellPage(driver);
            shellPage.ShellLoadPage( );
        }

        public void CartableOpenCreateMemorandom( )
        {
           m_BtnNewMemorandom.Click( );
           driver.ImplicitWaitFor( 5 );
        }

        public void CartableOpenDraft( )
        {
            driver.ImplicitWaitFor( 5 );
            m_Btnexpandservices.Click( );
            driver.FindElement( By.Id( "draft-link" ) ).Click( );
            driver.ImplicitWaitFor( 5 );
        }
    }
}



using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using Test.Data.Objects;
using Test.Public;
using Test.Tools;

namespace Test.Pages
{
	public static class FormBatchAcceptPage
    {
        internal static void ClickOnStartBathAccept( )
        {
            Driver.Instance.FindElement(By.Id("start")).Click();
            Driver.Instance.ImplicitWaitFor("Batch Accept Opration");
        }

        internal static void VerifyBathAcceptOprationDone( )
        {
            WebDriverWait webDriverWait;
            webDriverWait = new WebDriverWait( Driver.Instance , TimeSpan.FromSeconds( ConstItems.WaitTimeoutDefault ) );
            var inprogressState =  webDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated( By.Id( "inprogress-state" ) ) );
            IWebElement btnDisableStart = Driver.Instance.WaitForLoadAnElementById("start","start button in batch accept form window");
            IWebElement btnDisableStop = Driver.Instance.WaitForLoadAnElementById("stop" , "stop button in batch accept form window");
            bool btnstartenable = btnDisableStart.Enabled;
            bool btnstopenable = btnDisableStop.Enabled;
            string batcAcceptActions = "batchacceptcommand.jpg";
            string filePath = @$"C:\Users\Administrator\source\repos\Test\Test\Data\img\{batcAcceptActions}";

            IWebElement FormBatchAcceptAtions = Driver.Instance.FindElement(By.CssSelector(".actions"));
            Bitmap bmpPageScreenshot = Driver.Instance.TakeIWebElementScreenShot(FormBatchAcceptAtions);

            if( !File.Exists( filePath ) )
            {
                bmpPageScreenshot.Save( filePath );
            }

            Bitmap bmpFormImage = new Bitmap(filePath);
            bool result = Utility.CompareBitmapImages(bmpFormImage, bmpPageScreenshot);
            ErrorDetector.Detect();
            Assert.That( result , Is.True );
            // Assert.That( inprogressState.Displayed , Is.EqualTo(false) );
            Assert.That( btnstartenable , Is.EqualTo( false ) );
            Assert.That( btnstopenable , Is.EqualTo( false ) );
        }

        internal static void VerifyFormBatchAcceptPageLoad( Form form )
        {
            IWebElement title = Driver.Instance.FindElement(By.Id("title-section"));
            IWebElement description = Driver.Instance.FindElement(By.XPath("//span[@class='text']"));
            IWebElement btnStart = Driver.Instance.FindElement(By.Id("start"));
            IWebElement btnStop = Driver.Instance.FindElement(By.XPath("//button[@id='stop']"));
            IWebElement btnClose = Driver.Instance.FindElement(By.Id("close"));
            IWebElement formsList = Driver.Instance.FindElement(By.Id("eforms-section"));
            Driver.Instance.FindElement( By.XPath( "//div[@id='eforms-section']/div[1]//div[@class='toggle-icon']" ) ).Click();
            IWebElement fullName = Driver.Instance.FindElement(By.XPath($"//div[@class='bottom-section']//div[.='{form.FullName}']"));
            IWebElement personnelCode = Driver.Instance.FindElement(By.XPath($"//div[@class='bottom-section']//div[.='{form.PersonnelCode}']"));
            ErrorDetector.Detect();
            //IWebElement FormTitle = Driver.Instance.FindElement(By.XPath($"//*[contains(text() , '{Form.FormTitle}']"));
            Assert.That( description.Text , Is.EqualTo( "فرم های انتخاب شده در این مرحله پس از تعیین وضعیت و تایید، طبق روال تعریف شده به گردش در می آیند.\r\nدر صورتی که شرایط انجام کار فراهم نباشد، امکان ادامه کار در کارتابل وجود دارد." ) );
            Assert.That( btnStart.Text , Is.EqualTo( "شروع" ) );
            Assert.That( btnStop.Text , Is.EqualTo( "توقف" ) );
            Assert.That( btnClose.Text , Is.EqualTo( "بستن" ) );
            Assert.That( formsList.Displayed , Is.EqualTo( true ) );
            Assert.That( fullName.Text , Is.EqualTo( form.FullName ) );
            Assert.That( personnelCode.Text , Is.EqualTo( form.PersonnelCode ) );

        }
    }
}

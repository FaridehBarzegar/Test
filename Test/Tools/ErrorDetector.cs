using Aspose.Cells.Drawing;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Tools;

namespace Test.Public
{
	public static class ErrorDetector
    {
        public static void Detect( )
        {

            try
            {
                IWebElement errorDialog = Driver.Instance.FindElement(By.XPath("//p[contains(text(),'Exception Type:')]"));
                //System.Diagnostics.Debug.WriteLine("20");
                if( errorDialog != null )
                {
                    string errorMessage = errorDialog.Text;
                    Driver.Instance.FindElement( By.XPath( "//button[.='تایید']" ) ).Click();
                    Driver.Instance.Navigate().Refresh();
                    Driver.Instance.ImplicitWaitFor( "Closing Error Dialog" );
                    Assert.Fail( errorMessage );
                }
            }
            catch( OpenQA.Selenium.NoSuchElementException exp )
            {
            }
        }
    }
}

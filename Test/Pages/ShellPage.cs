using OpenQA.Selenium;
using Test.Public;
using Test.Tools;

namespace Test.Pages
{

	public static class ShellPage
    {
        internal static void VerifyShellPageLoad(IWebDriver driver )
        {
            try
            {
                driver.FindElement( By.CssSelector(".confirmActiveButton")).Click();
            }
            catch( Exception ) { }
            finally
            {
                Driver.Instance.ImplicitWaitFor("Load Shell Page");
                IWebElement btnOfficeAutomation  =  driver.FindElement(By.Id("OfficeAutomation" ));
                IWebElement btnCalender          =  driver.FindElement(By.Id("Calendar"));
                IWebElement btnPersonelInbox     =  driver.FindElement(By.Id("PersonalInbox" ));
                IWebElement btnPeople            =  driver.FindElement(By.Id("People" ));
                IWebElement btnNote              =  driver.FindElement(By.Id("Note"));
                IWebElement btnBulletinBoard     =  driver.FindElement(By.Id("BulletinBoard"));
                IWebElement btnUserProperties    =  driver.FindElement(By.Id("anchor-userTitle"));
                IWebElement btnExit              =  driver.FindElement(By.LinkText ("خروج" ));
                ErrorDetector.Detect();
                Assert.That( btnOfficeAutomation.Displayed , Is.EqualTo( true ) );
                Assert.That( btnCalender.Displayed , Is.EqualTo( true ) );
                Assert.That( btnPersonelInbox.Displayed , Is.EqualTo( true ) );
                Assert.That( btnPeople.Displayed , Is.EqualTo( true ) );
                Assert.That( btnNote.Displayed , Is.EqualTo( true ) );
                Assert.That( btnBulletinBoard.Displayed , Is.EqualTo( true ) );
                //Assert.That( m_BtnChengePassword.Displayed , Is.EqualTo( true ) );
                Assert.That( btnUserProperties.Displayed , Is.EqualTo( true ) );
                Assert.That( btnExit.Displayed , Is.EqualTo( true ) );
            }
        }

        internal static void  ClickOnOfficeAutomation( )
        {
            IWebElement btnOfficeAutomation =  Driver.Instance.WaitForLoadAnElementById( "OfficeAutomation" ,"OfficeAutomation in Shell");
            btnOfficeAutomation.Click();
            Driver.Instance.ImplicitWaitFor("cartable Load");
        }

        internal static void ClickOnExit( )
        {
            IWebElement btnExit =  Driver.Instance.WaitForLoadAnElementByLinkText( "خروج" ,"SignOut in in Shell");
            btnExit.Click();
            IWebElement txtUserName= Driver.Instance.WaitForLoadAnElementById("Username","UserName in Login Page");
            ErrorDetector.Detect();
            Assert.That(txtUserName.Displayed,Is.EqualTo(true));
        }
    }
}

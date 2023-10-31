using OpenQA.Selenium;
using Payvast.OATest.Data.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;
using Test.Public;
using Test.Tools;

namespace Test.Pages
{
	internal class LetterPage
    {
        internal static void ChooseReciverFromContactGroup( PositionAndContactGroup group )
        {
            Driver.Instance.FindElement(By.Id("ReceiverContacts_text")).SendKeys(group.SearckKeyContact);
            Driver.Instance.WaitForLoadAnElementByXPath($"//div[.='{group.ContactGroupTitle}']","Result Of Object Piker").Click();
        }

        internal static void VerifyLoadCreationPage( )
        {
            IWebElement txtSender = Driver.Instance.WaitForLoadAnElementById("SenderPosition_text","Sender Field in Creation Letter Page");
            IWebElement txtReciver = Driver.Instance.WaitForLoadAnElementById("ReceiverContacts_text","Reciver Field in Creation Letter Page");
            IWebElement txtTranscriptReciver = Driver.Instance.WaitForLoadAnElementById("TranscriptItems_0_TranscriptTo_text","Transcript Reciver Field in Creation Letter Page");
            IWebElement btnAddTranscript = Driver.Instance.WaitForLoadAnElementById("add","Button add Transcript in Creation Letter Page");
            IWebElement txtResonTranscript = Driver.Instance.WaitForLoadAnElementById("TranscriptItems_0__TranscriptReason","Transcript Reson Field in Creation Letter Page");
            //IWebElement txtCategory = Driver.Instance.WaitForLoadAnElementById("CategoryText","Category in Creation Letter Page");
            //IWebElement selectContentTemplate = Driver.Instance.WaitForLoadAnElementById("ContentTemplateText","Content Template in Creation Letter Page");
            IWebElement lnkAnchorArchive = Driver.Instance.WaitForLoadAnElementById("anchorArchive","anchorArchive Link in Creation Letter Page");
            IWebElement lnkanchorProperties = Driver.Instance.WaitForLoadAnElementById("anchorProperties","anchorProperties in Creation Letter Page");
            string CreationLetterPage = "DiscreptionCreationLetterPage.jpg";
            string filePath = @$"C:\Users\Administrator\source\repos\Test\Test\Data\img\{CreationLetterPage}";
            IWebElement creationLetterPage = Driver.Instance.WaitForLoadAnElementById( "description-sections-wrapper" , "Discreption Memorandom Creation Page" );
            Bitmap bmpPageScreenshot = Driver.Instance.TakeIWebElementScreenShot(creationLetterPage);

            if( !File.Exists( filePath ) )
            {
                bmpPageScreenshot.Save( filePath );
            }

            Bitmap bmpCreationLetterPageImage = new Bitmap(filePath);
            bool result = Utility.CompareBitmapImages(bmpCreationLetterPageImage, bmpPageScreenshot);
            ErrorDetector.Detect();
            Assert.That(txtSender.Displayed,Is.EqualTo(true));
            Assert.That(txtReciver.Displayed,Is.EqualTo(true));
            Assert.That(txtTranscriptReciver.Displayed,Is.EqualTo(true));
            Assert.That(btnAddTranscript.Displayed,Is.EqualTo(true));
            Assert.That(txtResonTranscript.Displayed,Is.EqualTo(true));
            //Assert.That(txtCategory.Displayed,Is.EqualTo(true));
            //Assert.That(selectContentTemplate.Displayed,Is.EqualTo(true));
            Assert.That(lnkAnchorArchive.Displayed,Is.EqualTo(true));
            Assert.That(lnkanchorProperties.Displayed,Is.EqualTo(true));
            Assert.That( result , Is.True );
        }

        internal static void VerifyShowContactReciverGroupMember( PositionAndContactGroup group )
        {
            string [] reciverMembers = group.ContactFullName.Split("|");
            for(int i = 0; i < reciverMembers.Length; i++ )
               
            {
                IWebElement contactReciverMember =Driver.Instance.FindElement( By.XPath( $"//span[contains(text(),'{reciverMembers[i]}')]"));
                ErrorDetector.Detect();
                Assert.That(contactReciverMember.Displayed,Is.EqualTo(true));
            }
        }
    }
}

using OpenQA.Selenium;
using Payvast.OATest.Data.Objects;
using Test.Public;
using Test.Tools;

namespace Payvast.OATest.Pages;
internal class PositionContactGroupPage
{
	internal static void AddNewMemberToContactGroup( PositionAndContactGroup group )
	{
		string[] members =group.ContactMember.Split("|");
		for( int i = 0; i < members.Length; i++ )
		{
			Driver.Instance.FindElement( By.Id( "newMember_text" ) ).SendKeys( group.SearchKeyText );
			Driver.Instance.WaitForLoadAnElementByXPath( $"//div[.='{members[ i ].ToString( )}']", "Result of object piker" ).Click( );
			Driver.Instance.ImplicitWaitFor( "Select Position Of Object Piker" );
		}
	}

	internal static void AddNewMemberToPositionGroup( PositionAndContactGroup group )
	{
		string[] members =group.PositionMember.Split("|");
		for( int i = 0; i < members.Length; i++ )
		{
			Driver.Instance.FindElement( By.Id( "newMember_text" ) ).SendKeys( group.SearchKeyText );
			Driver.Instance.WaitForLoadAnElementByXPath( $"//div[.='{members[ i ].ToString( )}']", "Result of object piker" ).Click( );
			Driver.Instance.ImplicitWaitFor( "Select Position Of Object Piker" );
		}
	}

	internal static void ClickOnAddMember( )
	{
		Driver.Instance.FindElement( By.Id( "add-position" ) ).Click( );

	}

	internal static void ClickOnContactGroups( )
	{
		Driver.Instance.FindElement( By.CssSelector( "[href='javascript:psg.ui.layout.load( \"/oa/Settings/ContactGroup\" );void(0);']" ) ).Click( );
		Driver.Instance.ImplicitWaitFor( "Contact Group" );
	}


	internal static void ClickOnOrgnizationPositionGroup( )
	{
		Driver.Instance.FindElement( By.XPath( "//a[.='گروه پست های سازمانیتنظیم گروه‌ها و لیست افراد آن‌ها']" ) ).Click( );
		Driver.Instance.ImplicitWaitFor( " Position Group" );
	}

	

	internal static void FillGroupTitle( string positionGroupTitle )
	{
		IWebElement addNewGroup = Driver.Instance.FindElement(By.Id("new-group-link"));
		addNewGroup.Click( );
		Driver.Instance.FindElement( By.Id( "new-group-name" ) ).SendKeys( positionGroupTitle );
		Driver.Instance.FindElement( By.Id( "newMember_text" ) ).Click( );
		//  IWebElement elementNotification = Driver.Instance.WaitForLoadAnElementByCssSelector(".notify-elm .messageTitle","");
		//  IWebElement notify = elementNotification.FindElement(By.XPath("//div/p[text()='نام گروه تكراري است.']"));
		// if(notify.Displayed)
		// {
		//     Driver.Instance.FindElement(By.Id("new-group-name")).SendKeys(positionGroupTitle+'2');
		// }
		Driver.Instance.FindElement( By.Id( "newMember_text" ) ).Click( );
	}

	internal static void VerifyAddMembersGroup( )
	{
		//IWebElement message =Driver.Instance.WaitForLoadAnElementByCssSelector(".notify-elm","Notification Add Group Position Send");
		//ask about this
		IWebElement saveMessage = Driver.Instance.WaitForLoadAnElementByXPath("//div/p[text() ='تغییرات جدید با موفقیت ثبت گردید.']","Notify Element");
		//IWebElement saveMessage = Driver.Instance.WaitForLoadAnElementByXPath("//div/p[contains(text() ,'تغییرات جدید با موفقیت ثبت گردید.')]","Notify Element");
		IWebElement lstMember=Driver.Instance.WaitForClickOnElementById("div-memberList","Member List");
		ErrorDetector.Detect( );
		//Assert.That( message.Displayed, Is.EqualTo( true ) );
		Assert.That( lstMember.Displayed, Is.EqualTo( true ) );
	}

	internal static void VerifyLoadContactGroup( )
	{
		IWebElement groups = Driver.Instance.FindElement(By.Id("div-top"));
		IWebElement favoriteList = Driver.Instance.FindElement(By.Id("div-personal"));
		IWebElement addNewPosition = Driver.Instance.FindElement(By.Id("newMember_objectPicker"));
		IWebElement positionsList = Driver.Instance.FindElement(By.Id("div-memberList"));
		ErrorDetector.Detect( );
		Assert.That( groups.Displayed, Is.EqualTo( true ) );
		Assert.That( favoriteList.Displayed, Is.EqualTo( true ) );
		Assert.That( addNewPosition.Displayed, Is.EqualTo( true ) );
		Assert.That( positionsList.Displayed, Is.EqualTo( true ) );
	}

	internal static void VerifyLoadPositiongroup( )
		{
			IWebElement groups = Driver.Instance.FindElement(By.Id("div-top"));
			IWebElement favoriteList = Driver.Instance.FindElement(By.Id("div-personal"));
			IWebElement addNewPosition = Driver.Instance.FindElement(By.Id("newMember_objectPicker"));
			IWebElement positionsList = Driver.Instance.FindElement(By.Id("div-memberList"));
			ErrorDetector.Detect( );
			Assert.That( groups.Displayed, Is.EqualTo( true ) );
			Assert.That( favoriteList.Displayed, Is.EqualTo( true ) );
			Assert.That( addNewPosition.Displayed, Is.EqualTo( true ) );
			Assert.That( positionsList.Displayed, Is.EqualTo( true ) );
		}
}

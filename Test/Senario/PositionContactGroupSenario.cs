using Payvast.OATest.Data.Objects;
using Payvast.OATest.Data.Reader;
using Payvast.OATest.Pages;
using Test.Pages;
using Test.Senario;
using Test.Tools.Senario;

namespace Payvast.OATest.Senario;

public class PositionContactGroupSenario : TestsBase
{
	/// <summary>
	/// نمایش صفحه گروه‌های پست سازمانی
	/// </summary>
	/// <param name="group"></param>
	[Test, TestCaseSource( typeof( PositionAndContactGroupData ), nameof( PositionAndContactGroupData.S_GroupsData ) )]
	[Order( 2000 )]
	public static void LoadOrgnizationPositionGroup( PositionAndContactGroup group )
	{
		ReasonSenario.LoadToolPage( group );
		PositionContactGroupPage.ClickOnOrgnizationPositionGroup( );
		PositionContactGroupPage.VerifyLoadPositiongroup( );
	}

	/// <summary>
	/// نمایش صفحه گروه ‌های طرف مکاتبه
	/// </summary>
	/// <param name="group"></param>
	[Test, TestCaseSource( typeof( PositionAndContactGroupData ), nameof( PositionAndContactGroupData.S_GroupsData ) )]
	[Order( 3000 )]
	public static void LoadContactGroups( PositionAndContactGroup group )
	{
		ReasonSenario.LoadToolPage( group );
		PositionContactGroupPage.ClickOnContactGroups( );
		PositionContactGroupPage.VerifyLoadContactGroup( );
	}

	/// <summary>
	/// /افزودن گروه پست سازمانی
	/// </summary>
	/// <param name="group"></param>
	[Test, TestCaseSource( typeof( PositionAndContactGroupData ), nameof( PositionAndContactGroupData.S_GroupsData ) )]
	[Order( 6000 )]
	public static void CreateOrgnizationPositionGroup( PositionAndContactGroup group )
	{
		LoadOrgnizationPositionGroup( group );
		PositionContactGroupPage.FillGroupTitle( group.PositionGroupTitle );
		PositionContactGroupPage.AddNewMemberToPositionGroup( group );
		PositionContactGroupPage.ClickOnAddMember( );
		PositionContactGroupPage.VerifyAddMembersGroup( );
		//  CartablePage.ClickOnInboxPanel();
		// CartablePage.VerifyLoadCartable();
		//CartablePage.ClickOnNewMemorandomCommand();
		// MemorandomPage.VerifyLoadCreationMemorandomPage();
		// MemorandomPage.ChooseReciverFromPositionGroup(tool);
		//ask about naming
		// MemorandomPage.VerifyChooseGroupMembersAsReciver(tool);
	}

	/// <summary>
	/// افزودن گروه طرف مکاتبه
	/// </summary>
	/// <param name="tool"></param>
	[Test, TestCaseSource( typeof( PositionAndContactGroupData ), nameof( PositionAndContactGroupData.S_GroupsData ) )]
	[Order( 7000 )]
	public static void CreateContactGroup( PositionAndContactGroup group )
	{
		LoadContactGroups( group );
		PositionContactGroupPage.FillGroupTitle( group.ContactGroupTitle );
		PositionContactGroupPage.AddNewMemberToContactGroup( group );
		PositionContactGroupPage.ClickOnAddMember( );
		PositionContactGroupPage.VerifyAddMembersGroup( );
		CartablePage.ClickOnInboxPanel( );
		CartablePage.VerifyLoadCartable( );
		CartablePage.ClickOnNewOutgoingLetterCommand( );
		LetterPage.VerifyLoadCreationPage( );
		LetterPage.ChooseReciverFromContactGroup( group );
		LetterPage.VerifyShowContactReciverGroupMember( group );
	}


}

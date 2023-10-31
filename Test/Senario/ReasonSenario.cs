using Payvast.OATest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;
using Test.Data.ReadData;
using Test.Pages;
using Test.Tools.Senario;

namespace Test.Senario
{
	public class ReasonSenario : SenarioTestBase
	{
		/// <summary>
		/// نمایش صفحه ابزار
		/// </summary>
		/// <param name="tool"></param>
		[Test, TestCaseSource( typeof( ReasonData ), nameof( ReasonData.S_ReasonData ) )]
		[Order( 1000 )]
		public static void LoadToolPage( BaseObject baseObject)
		{
			ShellSenario.CartableLoad( );
			ReasonPage.ClickOnTool( );
			ReasonPage.VerifyLoadToolPage( );
		}

		/// <summary>
		/// نمایش صفحه عبارات پرکاربرد
		/// </summary>
		/// <param name="tool"></param>
		[Test, TestCaseSource( typeof( ReasonData ), nameof( ReasonData.S_ReasonData ) )]
		[Order( 4000 )]
		public static void LoadReferReason( Reason tool )
		{
			LoadToolPage( tool );
			ReasonPage.ClickOnReferResonPanel( );
			ReasonPage.VerifyLoadReferReson( );
		}

		/// <summary>
		/// نمایش صفحه عملیات اتوماتیک و ماکرو
		/// </summary>
		/// <param name="tool"></param>
		[Test, TestCaseSource( typeof( ReasonData ), nameof( ReasonData.S_ReasonData ) )]
		[Order( 5000 )]
		public static void LoadAutomaticOpration( Reason tool )
		{
			LoadToolPage( tool );
			ReasonPage.ClickOnAutomaticOpration( );
			ReasonPage.VerifyLoadAutomaticOpration( );
		}

		/// <summary>
		/// نمایش صفحه تنظیمات شخصی
		/// </summary>
		/// <param name="tool"></param>
		[Test, TestCaseSource( typeof( ReasonData ), nameof( ReasonData.S_ReasonData ) )]
		[Order( 8000 )]
		public static void LoadPersonalSetting( Reason tool )
		{
			LoadToolPage( tool );
			ReasonPage.ClickOnPersonnelSetting( );
			ReasonPage.VerifyLoadPersonnelSetting( tool.UserLogin );
		}

		/// <summary>
		/// افزودن دستور ارجاع
		/// </summary>
		/// <param name="tool"></param>
		[Test, TestCaseSource( typeof( ReasonData ), nameof( ReasonData.S_ReasonData ) )]
		[Order( 9000 )]
		public static void CreateNewReferReason( Reason tool )
		{
			LoadReferReason( tool );
			ReasonPage.ClickOnNewLink( );
			ReasonPage.FillReferReason( tool.ReferReson );
			ReasonPage.VerifyAddReason( tool.ReferReson );
		}

		/// <summary>
		/// افزودن دستور اقدام
		/// </summary>
		/// <param name="tool"></param>
		[Test, TestCaseSource( typeof( ReasonData ), nameof( ReasonData.S_ReasonData ) )]
		[Order( 10000 )]
		public static void CreateNewActionReason( Reason tool )
		{
			LoadReferReason( tool );
			ReasonPage.ClickOnActionReasonPanel( );
			ReasonPage.ClickOnNewLink( );
			ReasonPage.FillReferReason( tool.ActionReason );
			ReasonPage.VerifyAddReason( tool.ActionReason );
		}

		/// <summary>
		/// افزودن متون آماده
		/// </summary>
		/// <param name="tool"></param>
		[Test, TestCaseSource( typeof( ReasonData ), nameof( ReasonData.S_ReasonData ) )]
		[Order( 11000 )]
		public static void CreateNewPreparedContent( Reason tool )
		{
			LoadReferReason( tool );
			ReasonPage.ClickOnPreparedContents( );
			ReasonPage.ClickOnNewLink( );
			ReasonPage.FillPreparedContentTitle( tool.PreparedContentTitle );
			ReasonPage.FillPreparedContentDiscreption( tool.PreparedContentDiscreption );
			ReasonPage.ClickOnConfirmButton( );
			ReasonPage.VerifyAddReason( tool.PreparedContentTitle );
			ReasonPage.ClickOnEditPreparedContentTitle( tool.PreparedContentTitle );
			ReasonPage.VerifyPreparedContentSave( tool.UserLogin, tool.PreparedContentTitle );
		}

	}
}

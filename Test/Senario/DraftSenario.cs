using Test.Data.Objects;
using Test.Data.ReadData;
using Test.Pages;
using Test.Tools.Senario;

namespace Test.Senario
{
	[TestFixture]
    public class DraftSenario:SenarioTestBase
    {
       /* [Test, TestCaseSource( typeof( MemorandomData ) , nameof( MemorandomData.S_MemorandomData ) )]
        public static void MemorandomDraftLoad( Memorandom memorandom )
        {
            CartableSenario.DraftLoad(memorandom );
            DraftPage draftPage = new DraftPage( WebDriver ) ;
            MemorandomDraftPage memorandomDraftPage = draftPage.ClickOnMemorandomDraftPanel( );
            memorandomDraftPage.EnsureMemorandomDraftPageReady( );
        }*/
    }
}

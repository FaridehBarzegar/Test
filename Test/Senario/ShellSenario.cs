using Test.Data;
using Test.Data.Objects;
using Test.Pages;
using Test.Tools.Senario;

namespace Test.Senario
{
	[TestFixture]
    public class ShellSenario : SenarioTestBase
    {
        [Test]
        public static void CartableLoad( )
        {
            ShellPage.ClickOnOfficeAutomation( );
            CartablePage.VerifyLoadCartable( );
        }
    }
}

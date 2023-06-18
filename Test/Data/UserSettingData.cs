using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;

namespace Test.Data
{
    public class UserSettingData
    {
        public static List<UserSetting> Settings = new List<UserSetting>( );

        public static string  FindRandomReferralCommandByUserName( string userName )
        {
            Settings = ReadUserSettingFromExcel( ).ToList( );
            IEnumerable<UserSetting> userSettings = new List<UserSetting>( );  
            UserSetting userSetting = Settings.FirstOrDefault( s=>s.userName == userName );
            List <string> referralCommands = new List<string>( );
            referralCommands = userSetting.referralCommands.Split("_").ToList( );
            int randomNum = new Random( ).Next( 0 , referralCommands.Count( ));
            return referralCommands[ randomNum ];
        }
        public static IEnumerable<UserSetting> ReadUserSettingFromExcel( )
        {
            Workbook workbook = new Workbook( "C:\\Users\\Administrator\\source\\repos\\Test\\Test\\Data\\Data.xlsx" );
            Worksheet worksheet = workbook.Worksheets["UserSetting"];
            int rowCount = worksheet.Cells.Rows.Count;
            for( int i = 0; i < rowCount; i++ )
            {
                Settings.Add( new UserSetting { 
                    userName         = worksheet.Cells[ i , 0 ].Value?.ToString( ).Trim( ),
                    referralCommands = worksheet.Cells[ i , 1 ].Value?.ToString( ).Trim( )
                    } );
            }
            return Settings;
           
        }
    }
}

using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;

namespace Test.Data
{
    public class ReadyTextData
    {
        public static List<ReadyText> readyTexts = new List<ReadyText>( );
        public static ReadyText FindReadyTextByUserName( string userlogin )
        {
            IEnumerable<ReadyText> texts = new List<ReadyText>( );
            texts = ReadReadyTextFromExcell( );
            IEnumerable<ReadyText> userTexts = texts.Where( t => t.userLogin == userlogin );
            int num = new Random( ).Next( 0, userTexts.Count( ));
            return userTexts.ToList( )[ num ];
        }

        public static IEnumerable<ReadyText> ReadReadyTextFromExcell( )
        {
            Workbook workbook = new Workbook( "C:\\Users\\Administrator\\source\\repos\\Test\\Test\\Data\\Data.xlsx" );
            Worksheet worksheet = workbook.Worksheets[ "ReadyText" ];
            int rowCount = worksheet.Cells.Rows.Count;
            //List<ReadyText> texts = new List<ReadyText>();
            for( int i = 1 ; i < rowCount ; i++ )
            {
                readyTexts.Add( new ReadyText
                {
                    userLogin = worksheet.Cells[ i, 0 ].Value?.ToString( ).Trim( ),
                    readyTextTitle = worksheet.Cells[ i, 1 ].Value?.ToString( ).Trim( ),
                    readyTextDiscription = worksheet.Cells[ i, 2 ].Value?.ToString( ).Trim( ),

                } );
            }
            return readyTexts;
        }
    }
}


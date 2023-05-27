using Aspose.Cells;
using  Test.Data.Object;

namespace Test.Data
{
    public static class MemorandomData
    {
        private static IEnumerable<Memorandom > s_memorandomData = new List<Memorandom>();
        public static IEnumerable<Memorandom> S_MemorandomData
        {
            get
            {
                if( !s_memorandomData.Any( ) )
                {
                    s_memorandomData = ReadMemorandomFromExcell();
                    s_memorandomData = GetRandomMemorandoms( );

                }
                return s_memorandomData;
            }
        }

        public static IEnumerable<Memorandom> GetRandomMemorandoms( int count = 2 )
        {
            List<Memorandom> memorandoms = new List<Memorandom>();
            for( int i = 0; i < count; i++ )
            {
                int num = new Random().Next( 0 ,(S_MemorandomData.Count()/2)-1 );
                memorandoms.Add( S_MemorandomData.ToArray( )[num] );
                int num2 = new Random().Next((S_MemorandomData.Count()/2)-1,S_MemorandomData.Count()-1);
                memorandoms.Add( S_MemorandomData.ToArray( )[num2] );
            }
            return memorandoms;
        }

        public static IEnumerable<Memorandom> ReadMemorandomFromExcell( )
        {
            Workbook workbook = new Workbook( "C:\\Users\\Administrator\\source\\repos\\Test\\Test\\Data\\Data.xlsx" );
            Worksheet worksheet = workbook.Worksheets["Memorandom"];
            int rowCount = worksheet.Cells.Rows.Count;
            List<Memorandom> memorandoms = new List<Memorandom>();
            for( int i = 1; i < rowCount; i++ )
            {
                memorandoms.Add(new Memorandom
                {
                         memorandomTitle          =  worksheet.Cells[ i, 0 ].Value?.ToString( ).Trim( ),
                         discreption              =  worksheet.Cells[ i, 1 ].Value?.ToString( ).Trim( ),
                         readyText                =  worksheet.Cells[ i, 2 ].Value?.ToString( ).Trim( ),
                         reciver                  =  worksheet.Cells[ i, 3 ].Value?.ToString( ).Trim( ),
                         userLoginCheckReciver    =  worksheet.Cells[ i, 4 ].Value?.ToString( ).Trim( ),
                         transcriptReciver        =  worksheet.Cells[ i, 5 ].Value?.ToString( ).Trim( ),
                         transcriptOrder          =  worksheet.Cells[ i, 6 ].Value?.ToString( ).Trim( ),
                         userLoginCheckTranscript =  worksheet.Cells[ i, 7 ].Value?.ToString( ).Trim( ),
                         transcriptReciver2       =  worksheet.Cells[ i, 8 ].Value?.ToString( ).Trim( ),
                         transcriptOrder2         =  worksheet.Cells[ i, 9 ].Value?.ToString( ).Trim( ),
                         userLoginCheckTranscipt2 =  worksheet.Cells[ i, 10 ].Value?.ToString( ).Trim( ),
                         semilarMemorandom        =  worksheet.Cells[ i, 11 ].Value?.ToString( ).Trim( ),
                         followUpCompanion        =  worksheet.Cells[ i, 12 ].Value?.ToString( ).Trim( ),
                         priority                 =  worksheet.Cells[ i, 13 ].Value?.ToString( ).Trim( ),
                         searchReciver            =  worksheet.Cells[ i, 14].Value?.ToString( ).Trim( ),
                         searchReciverResult      =  worksheet.Cells[ i, 15].Value?.ToString( ).Trim( ),
                         transcriptSearchReciver  =  worksheet.Cells[ i, 16].Value?.ToString( ).Trim( ),
                         transcriptSearchResult   =  worksheet.Cells[ i, 17].Value?.ToString( ).Trim( ),
                         transcriptSearchReciver2 =  worksheet.Cells[ i, 18].Value?.ToString( ).Trim( ),
                         transcriptSearchResult2  =  worksheet.Cells[ i, 19].Value?.ToString( ).Trim( ),
                         userLogin                =  worksheet.Cells[ i, 20].Value?.ToString( ).Trim( )
                 });
            }
                return memorandoms;
            }
        }
    }


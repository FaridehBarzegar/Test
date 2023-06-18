using Aspose.Cells;
using  Test.Data.Objects;

namespace Test.Data
{
    public static class MemorandomData
    {
        private static IEnumerable<Memorandom > s_memorandomData = new List<Memorandom>();
        public static IEnumerable<Memorandom> S_MemorandomData
        {
            get
            {
                if( !s_memorandomData.Any( ))
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
                         semilarMemorandom        =  worksheet.Cells[ i, 2 ].Value?.ToString( ).Trim( ),
                         followUpCompanion        =  worksheet.Cells[ i, 3 ].Value?.ToString( ).Trim( ),
                         priority                 =  worksheet.Cells[ i, 4 ].Value?.ToString( ).Trim( ),
                         fileAttachmentName       =  worksheet.Cells[ i, 5].Value?.ToString( ).Trim( )
                 });
            }
                return memorandoms;
            }
        }
    }


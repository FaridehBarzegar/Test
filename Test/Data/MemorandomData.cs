using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data
{
    public static class MemorandomData
    {
        public static IEnumerable<Memorandom[ ]> ReadMemorandomFromExcell( )
        {
            
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo existingFile = new FileInfo("C:\\Users\\Administrator\\source\\repos\\Test\\Test\\Data\\Data.xlsx");

            using ( ExcelPackage package = new ExcelPackage( existingFile ) )
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Memorandom"];
                int rowCount = worksheet.Dimension.End.Row;
                for ( int i = 2 ; i <= rowCount ; i++ )
                {
                    Memorandom[] memorandoms = new Memorandom[]
                    {
                        new Memorandom
                        {

                      memorandomTitle   =  worksheet.Cells[ i, 1 ].Value?.ToString( ).Trim(),
                      discreption       =  worksheet.Cells[ i, 2 ].Value?.ToString( ).Trim(),
                      reciver           = worksheet.Cells[ i, 3 ].Value?.ToString( ).Trim(),
                      transcriptReciver =  worksheet.Cells[ i, 4 ].Value?.ToString( ).Trim(),
                      transcriptOrder   = worksheet.Cells[ i, 5 ].Value?.ToString( ).Trim(),
                      transcriptReciver2 =  worksheet.Cells[ i, 6 ].Value?.ToString( ).Trim(),
                      transcriptOrder2 =  worksheet.Cells[ i, 7 ].Value?.ToString( ).Trim(),
                      semilarMemorandom = worksheet.Cells[ i, 8 ].Value?.ToString( ).Trim(),
                      followUpCompanion = worksheet.Cells[ i, 9 ].Value?.ToString( ).Trim(),
                      priority           =  worksheet.Cells[ i, 10 ].Value?.ToString( ).Trim(),
                      searchReciver      = worksheet.Cells[ i, 11].Value?.ToString( ).Trim(),
                      searchReciverResult = worksheet.Cells[ i, 12].Value?.ToString( ).Trim(),
                      userLogin = worksheet.Cells[ i, 13].Value?.ToString( ).Trim(),
                      transcriptSearchReciver = worksheet.Cells[ i, 14].Value?.ToString( ).Trim(),
                      transcriptSearchResult = worksheet.Cells[ i, 15].Value?.ToString( ).Trim(),
                      
                        }
                    };
                    yield return memorandoms;
                }
            }
        }
    }
}

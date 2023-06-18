using Aspose.Cells;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;

namespace Test.Data
{
    public class ObjectPikerData
    { 
        public static IEnumerable<ObjectPiker> s_reciverData = new List<ObjectPiker>();
        public static IEnumerable<ObjectPiker> S_ReciverData
        {
            get
                {
                if( !s_reciverData.Any( ))
                {
                    s_reciverData = ReadReciverDataesFromExcel( );
                }
                return s_reciverData;
                }
        }
        public static IEnumerable<ObjectPiker> GetRandomRecivers( int count = 1 )
        {
            List<ObjectPiker> results = new List<ObjectPiker>();
            for( int i= 0; i < count; i++ )
            {
              int num = new Random().Next( 0 ,S_ReciverData.Count()-1);
              results.Add( S_ReciverData.ToArray( )[ num ] );
            }
            return results;
        }
        
        public static IEnumerable<ObjectPiker> ReadReciverDataesFromExcel( )
        {
            Workbook workbook = new Workbook("C:\\Users\\Administrator\\source\\repos\\Test\\Test\\Data\\Data.xlsx" );
            Worksheet worksheet = workbook.Worksheets["ObjectPiker"];
            int rowCount = worksheet.Cells.MaxDataRow;
            List<ObjectPiker> objectPikerDatas = new List<ObjectPiker>( );
            for( int i = 1; i < rowCount; i++ )
            {
                objectPikerDatas.Add( new ObjectPiker
                {
                    userLogin                                      = worksheet.Cells[i,0].Value?.ToString().Trim(),
                    reciver                                        = worksheet.Cells[i,1].Value?.ToString().Trim(),
                    searchReciver                                  = worksheet.Cells[i,2].Value?.ToString().Trim(),
                    searchReciverResult                            = worksheet.Cells[i,3].Value?.ToString().Trim(),
                    reciverFromChart                               = worksheet.Cells[i,4].Value?.ToString().Trim(),
                    searchReciverFromChart                         = worksheet.Cells[i,5].Value?.ToString().Trim(),
                    searchResultReciverFromChart                   = worksheet.Cells[i,6].Value?.ToString().Trim(),
                    reciverFromPersonelList                        = worksheet.Cells[i,7].Value?.ToString().Trim(),
                    searchResultReciverFromPersonelList            = worksheet.Cells[i,8].Value?.ToString().Trim(),
                    transcriptReciver                              = worksheet.Cells[i,9].Value?.ToString().Trim(),
                    transcriptSearchReciver                        = worksheet.Cells[i,10].Value?.ToString().Trim(),
                    transcriptSearchResult                         = worksheet.Cells[i,11].Value?.ToString().Trim(),
                    transcriptReciverFromChart                     = worksheet.Cells[i,12].Value?.ToString().Trim(),
                    searchTranscriptReciverFromChart               = worksheet.Cells[i,13].Value?.ToString().Trim(),
                    searchResultTranscriptReciverFromChart         = worksheet.Cells[i,14].Value?.ToString().Trim(),
                    transcriptReciverFromPersonelList              = worksheet.Cells[i,15].Value?.ToString().Trim(),
                    searchResultTranscriptReciverFromPersonelList  = worksheet.Cells[i,16].Value?.ToString().Trim(),
                    transcriptOrder                                = worksheet.Cells[i,17].Value?.ToString().Trim(),
                    transcriptReciver2                             = worksheet.Cells[i,18].Value?.ToString().Trim(),
                    searchTranscriptReciver2                       = worksheet.Cells[i,19].Value?.ToString().Trim(),
                    searchResultTranscriptReciver2                 = worksheet.Cells[i,20].Value?.ToString().Trim(),
                    transcriptReciver2FromChart                    = worksheet.Cells[i,21].Value?.ToString().Trim(),
                    searchTranscriptReciver2FromChart              = worksheet.Cells[i,22].Value?.ToString().Trim(),
                    searchResultTranscriptReciver2FromChart        = worksheet.Cells[i,23].Value?.ToString().Trim(),
                    transcriptReciver2FromPersonelList             = worksheet.Cells[i,24].Value?.ToString().Trim(),
                    searchResultTranscriptReciver2FromPersonelList = worksheet.Cells[i,25].Value?.ToString().Trim(),
                    transcriptOrder2                               = worksheet.Cells[i,26].Value?.ToString().Trim(),
                });
            };
                return objectPikerDatas;
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace Test.Public
{
    public static class Utility
    {
        public static string ConvertDateToPersianDate( DateTime dateTime )
        {
            string hour;
            PersianCalendar persianCalendar = new PersianCalendar();
            if( persianCalendar.GetHour(dateTime) ==0 )
            {
                hour=  "12";
            }
            else if(persianCalendar.GetHour(dateTime) > 12 )
            {
                hour = (persianCalendar.GetHour(dateTime) - 12 ).ToString("00");
            }
            else
            {
                hour =  persianCalendar.GetHour(dateTime).ToString("00");
            }
            //string hour =
                //persianCalendar.GetHour(dateTime) ==0  ? (persianCalendar.GetHour(dateTime)==12).ToString() : persianCalendar.GetHour(dateTime).ToString("00") ;
               // or persianCalendar.GetHour(dateTime) >12 ? (persianCalendar.GetHour(dateTime) - 12 ).ToString("00") : persianCalendar.GetHour(dateTime).ToString("00");
            string persianDate =
                $"{persianCalendar.GetYear(dateTime)}" +
                $"/{persianCalendar.GetMonth(dateTime).ToString("00")}" +
                $"/{persianCalendar.GetDayOfMonth(dateTime).ToString("00")}" +
                $" {hour}:{persianCalendar.GetMinute(dateTime).ToString("00")}";
            return persianDate;
        }

        public static Bitmap TakeIWebElementScreenShot( this IWebDriver driver , IWebElement webElement )
        {
            System.Threading.Thread.Sleep(2000)   ;
            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
            var img = Image.FromStream(new MemoryStream(sc.AsByteArray)) as Bitmap;
            return img.Clone(new Rectangle(webElement.Location, webElement.Size), img.PixelFormat);
           // image.Save("C:\\Users\\Administrator\\source\\repos\\Test\\Test\\Data\\img\\Formcompletedcommand.jpg");
        }

        public static bool CompareBitmapImages( Bitmap bmpImage1 , Bitmap bmpImage2 )
        {
            Bitmap image = new Bitmap(bmpImage1);
            Bitmap bitmapScreen = new Bitmap(bmpImage2);

            for( int x = 0 ; x < image.Width ; x+=5 )
            {
                for( int y = 0 ; y < image.Height ; y+=5 )
                {
                    Color c = image.GetPixel(x, y);
                    Color cs = bitmapScreen.GetPixel(x, y);
                    if( c!= cs )
                    {
                        return false;
                    }
                    //image.SetPixel( x , y , Color.FromArgb( cs.A , cs.R , cs.G , cs.B ) );
                }
            }
            return true;

        }
    }
}

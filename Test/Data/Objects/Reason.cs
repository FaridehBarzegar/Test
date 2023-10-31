using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Objects
{
    public class Reason:BaseObject
    {
      

        public string ReferReson
        {
            get; set;
        }

        public string ActionReason
        {
            get; set;
        }

        public string PreparedContentTitle
        {
            get; set;
        }

        public string PreparedContentDiscreption
        {
            get; set;
        }
    }
}

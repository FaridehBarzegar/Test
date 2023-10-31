using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Objects;

namespace Payvast.OATest.Data.Objects;
public class PositionAndContactGroup:BaseObject
{
	  public string PositionGroupTitle
        {
            get; set;
        }

        public string PositionMember
        {
            get; set;
        }

        public string SearchKeyText
        {
            get; set;
        }

        public string ContactGroupTitle
        {
            get; set;
        }

        public string ContactMember
        {
            get; set;
        }

        public string SearckKeyContact
        {
            get; set;
        }

        public string ContactFullName
        {
            get; set;
        }
}

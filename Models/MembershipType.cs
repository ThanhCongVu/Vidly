using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        // these 2 values represent in the dropdown list of the Membershiptype
        public static readonly byte Unknown = 0; // when user has not selected a membershiptype
        public static readonly byte PayAsYouGo = 1; // when payasyougo is selected
    }
}
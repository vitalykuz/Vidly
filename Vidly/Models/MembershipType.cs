using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        //each entity mush have a key, it will a primary key in database. By convention it must be named either id or type+id
        public byte Id { get; set; } //membership type Id
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}
﻿/*
 * Business rules for membership types:
 * https://www.udemy.com/the-complete-aspnet-mvc-5-course/learn/v4/t/lecture/4873034?start=0
 */


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        //each entity mush have a key, it will be a primary key in database. By convention it must be named either id or type+id
        public byte Id { get; set; } //membership type Id
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        //[Required]
        [StringLength(255)]
        public string Name { get; set; }

        /* we need to use static fields (Unknown and payAsYouGo) in order to get rid off magic numbers in Min18YearsIfAMember 
           I provided the full list of all Membership Types just for reference. These are not used anywhere in code. 
        */
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte Quaterly = 3;
        public static readonly byte Annual = 4;
    }
}
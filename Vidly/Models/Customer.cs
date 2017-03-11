using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        //primary key
        public int Id { get; set; }

        //if you want to make a property not nullable in database, add required. Now name cant be null and the lenth = 255
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        //by convention (name of the class+id?), the framework recognises this property as foreign key.
        public byte MembershipTypeId { get; set; }

        public DateTime? Birthday { get; set; }
    }
}
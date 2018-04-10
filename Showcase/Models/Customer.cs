using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Showcase.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Invalid Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubsribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}
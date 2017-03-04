using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter customer's surname.")]
        [StringLength(255)]
        public string Surname { get; set; }

        public bool IsSubscribedToNewsletter  { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Min18YearsIfAMember]
        [DisplayFormat(DataFormatString = "{dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthdate { get; set; }
        

    }
}
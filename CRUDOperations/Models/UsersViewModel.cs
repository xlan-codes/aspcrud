using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUDOperations.Models
{
    public class UsersViewModel
    {
        public Int64 UserId { get; set; }
        [Required(ErrorMessage="Please Enter First Name")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }        
        
        
        [Required(ErrorMessage="Please Enter Last Name")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }        
        

        [Required(ErrorMessage="Please Enter Birthplace")]
        [Display(Name="Birthplace")]
        public string Birthplace { get; set; }        

        [Required(ErrorMessage= "Please Enter Birthdate")]
        [Display(Name= "Birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> Birthdate { get; set; }        
        
        [Required(ErrorMessage= "Please Enter Phone")]
        [Display(Name= "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]

        public string Phone { get; set; }

        [Required(ErrorMessage = "Please Enter Gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Employed")]
        [Display(Name = "Employed")]
        public bool Employed { get; set; }


        [Required(ErrorMessage = "Please Enter Martial Status")]
        [Display(Name = "Martial Status")]
        public string MartialStatus { get; set; }


       public string toString(string format)
        {
            return ((DateTime)this.Birthdate).ToString(format);
        }

    }
}
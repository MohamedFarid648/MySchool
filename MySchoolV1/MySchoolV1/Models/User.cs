using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolV1.Models
{
    public class User
    {

        public int ID { get; set; }

        [StringLength(50, MinimumLength = 7)]//Name must be between 7 and 50 characters
        [Required(ErrorMessage = "Enter Student Name Please ^_^")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Enter a valid Name please ^_^")]
        public string Name { get; set; }


        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Enter a valid Email please ^_^")]
        [Required(ErrorMessage = "Enter Student Email Please ^_^")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 7)]//Password must be between 7 and 50 characters
        [Required(ErrorMessage = "Enter Student Password Please ^_^")]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]

        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter Student Gender Please ^_^")]
        public string Gender { get; set; }

        [Display(Name = "Born in:")]
        [Required(ErrorMessage = "Enter Student Birth Date Please ^_^")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [CustomRangeDateValidation("01/01/1998")]//it  works well,it accepts any date between 01/01/1998and  CurrentMonth/CurrentDay/CurrentYear
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Enter Student Address Please ^_^")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Student Phone Number Please ^_^")]
        [DataType(DataType.PhoneNumber)]
        //[Phone]
        [Display(Name = "Phone Number")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Enter a valid Phone please ^_^")]
        public int PhoneNumber { get; set; }

        [Display(Name = "User Type")]
        public int UserTypeID { get; set; }



        public static string returnUserName(int UserID)
        {
            DBContextClass db = new DBContextClass();
            User user = db.Users.Single(u => u.ID == UserID);
            return user.Name;

        }


    }



}

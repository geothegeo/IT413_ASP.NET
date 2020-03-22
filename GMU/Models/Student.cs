using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GMU.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Please enter your last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your middle name.")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please enter your first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your SSN.")]
        [Range(0, 1000000000, ErrorMessage = "That is an invalid SSN!")]
        [Display(Name = "Social Security Number")]
        [System.Web.Mvc.Remote("DoesSSNExist", "Students", ErrorMessage = "SSN already exists")]
        public int SSN { get; set; }
        [Required(ErrorMessage = "Please enter your email address.")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Please enter home phone number.")]
        [Display(Name = "Home Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string HomePhone { get; set; }
        [Required(ErrorMessage = "Please enter cell phone number.")]
        [Display(Name = "Cell Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string CellPhone { get; set; }
        [Required(ErrorMessage = "Please enter street address.")]
        [Display(Name = "Street Address")]
        public string AddrStreet { get; set; }
        [Required(ErrorMessage = "Please enter the city.")]
        [Display(Name = "City")]
        public string AddrCity { get; set; }
        [Required(ErrorMessage = "Please enter the state.")]
        [Display(Name = "State")]
        public string AddrState { get; set; }
        [Required(ErrorMessage = "Please enter the zipcode.")]
        [Display(Name = "Zipcode")]
        [Range(0, 100000, ErrorMessage = "Your SAT score should be between 0 and 800")]
        public int AddrZipcode { get; set; }
        [Required(ErrorMessage = "Please enter your date of birth.")]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please select your gender.")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter the name of your high school.")]
        [Display(Name = "High School Name")]
        public string HSName { get; set; }
        [Required(ErrorMessage = "Please enter your graduation date.")]
        [Display(Name = "Graduation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime GradDate { get; set; }
        [Required(ErrorMessage = "Please enter your GPA.")]
        [Display(Name = "GPA")]
        [Range(0, 4.0, ErrorMessage = "Your GPA should be between 0.0 and 4.0")]
        public decimal GPA { get; set; }
        [Required(ErrorMessage = "Please enter your SAT Math score.")]
        [Display(Name = "SAT Math Score")]
        [Range(0, 800, ErrorMessage = "Your SAT score should be between 0 and 800")]
        public int SATMath { get; set; }
        [Required(ErrorMessage = "Please enter your SAT Verval score.")]
        [Display(Name = "SAT Verbal Score")]
        [Range(0, 800, ErrorMessage = "Your SAT score should be between 0 and 800")]
        public int SATVerbal { get; set; }
        [Required(ErrorMessage = "Please enter your major of interest.")]
        [Display(Name = "Major Interest")]
        public Major MajorInterest { get; set; }
        [Required(ErrorMessage = "Please select the semester you are enrolling in.")]
        [Display(Name = "Enrollment Semester")]
        public Semester EnrollSemester { get; set; }
        [Required(ErrorMessage = "Please select the year you are enrolling in.")]
        [Display(Name = "Enrollment Year")]
        public int EnrollYear { get; set; }
        [Required]
        [Display(Name = "Enrollment Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime EnrollTime { get; set; }
        [Required(ErrorMessage = "Please select an appropriate decision.")]
        [Display(Name = "Decision")]
        public Decision Decision { get; set; }
    }

    public enum Major
    {
        Biology,
        Chemistry,
        Astrology,
        Geology,
        Physics
    }

    public enum Semester
    {
        Fall,
        Spring,
        Summer
    }

    public enum Decision
    {
        Undecided,
        Admit,
        Reject,
        WaitList
    }
}

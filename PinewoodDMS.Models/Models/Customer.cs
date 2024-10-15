using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodDMS.Models.Models
{
    public class Customer
    {

        [Key]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
           ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string Telephone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your house Number")]
        [StringLength(5)]
        [Display(Name = "House Number")]
        public string HouseNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(100)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; } = string.Empty;

        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(50)]
        public required string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your post code")]
        [Display(Name = "Post code")]
        [StringLength(10, MinimumLength = 5)]
        public required string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your country")]
        [StringLength(50)]
        public string Country { get; set; } = string.Empty;

        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }



    }
}

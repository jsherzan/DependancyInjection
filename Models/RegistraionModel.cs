using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Validation.Models
{
    public class RegistraionModel
    {
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 60 characters.")]
        [Required(ErrorMessage = "Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [RegularExpression(@"^[1-9]\d{2}-\d{3}-\d{4}", ErrorMessage = "Please enter a valid phone number in ###-###-#### format.")]
        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid email.")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Range(13,100, ErrorMessage = "Please enter a valid age between 13 and 100.")]
        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Contact Preference is required.")]
        public int ContactPreference { get; set; }

        public List<SelectListItem> ContactPreferences { get; set; }

    }
}

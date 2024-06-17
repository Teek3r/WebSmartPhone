using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSmartPhone.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Username không được trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password không được trống")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ComfirmPassword không được trống")]
        [Compare("Password", ErrorMessage = "Password và Confirm Password phải giống nhau")]
        public string ComfirmPassword { get; set; }
        [Required(ErrorMessage = "Email không được trống")]
        [EmailAddress(ErrorMessage = "Định dạng không đúng")]
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
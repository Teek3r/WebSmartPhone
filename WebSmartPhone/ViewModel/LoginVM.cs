﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSmartPhone.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username không được trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password không được trống")]
        public string Password { get; set; }
    }
}
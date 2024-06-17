using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSmartPhone.Models
{
    public class Cart
    {
        [Key]
        public int IdCart { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}
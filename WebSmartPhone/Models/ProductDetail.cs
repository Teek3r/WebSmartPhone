using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebSmartPhone.Models
{
    public class ProductDetail
    {
        [Key]
        public int DetailId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public virtual Product Product { get; set; }

    }
}
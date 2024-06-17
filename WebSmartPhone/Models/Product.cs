using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebSmartPhone.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img_URL { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}đ")]
        public int Price { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }   
    }
}
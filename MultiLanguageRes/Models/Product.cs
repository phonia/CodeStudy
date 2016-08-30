using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MultiLanguageRes.Resources;

namespace MultiLanguageRes.Models
{
    public class Product
    {
        [Required(ErrorMessageResourceType = typeof(Lang), ErrorMessageResourceName = "Name")]
        public String Name { get; set; }

        [Required(ErrorMessageResourceType=typeof(Lang),ErrorMessageResourceName="Amount")]
        public int Amount { get; set; }
    }
}
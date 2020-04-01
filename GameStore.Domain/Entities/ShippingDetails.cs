using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace GameStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Type your name!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address fiels is required!")]
        [Display(Name = "The first address")]
        public string Line1 { get; set; }

        [Display(Name = "The second address")]
        public string Line2 { get; set; }

        [Display(Name = "The third address")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
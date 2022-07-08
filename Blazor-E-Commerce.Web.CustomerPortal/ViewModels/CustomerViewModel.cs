using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.Web.CustomerPortal.ViewModels
{
    public class CustomerViewModel
    {
        [Required]
        public string CustomerName { get; set; } = null!;

        [Required]
        public string CustomerAddress { get; set; } = null!;

        [Required]
        public string CustomerCity { get; set; } = null!;

        [Required]
        public string CustomerStateProvince { get; set; } = null!;

        [Required]
        public string CustomerCountry { get; set; } = null!;
    }
}
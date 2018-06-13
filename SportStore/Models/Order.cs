using Microsoft.AspNetCore.Mvc.ModelBinding;
using SportStore.Models.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartItem> Lines { get; set; }

        [Required(ErrorMessage = "Prosze podac imie i nazwisko")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Prosze podac pierwszy wiersz adresu")]
        [Display(Name="Proszę podać dokładny adres")]
        public string Line1 { get; set; }
        [Display(Name = "Proszę podać dokładny adres cd")]
        public string Line2 { get; set; }
        [Display(Name = "Proszę podać dokładny adres cd")]
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Prosze podac nazwe miasta")]
        public string City { get; set; }
        [Required(ErrorMessage = "Prosze podac nazwe weojewodztwa")]
        public string State { get; set; }

        public string Zip { get; set; }
        [Required(ErrorMessage = "Prosze podac pnazwe kraju")]
        public string Country { get; set; }

        public string GiftWrap { get; set; }

        //public bool Shipped { get; set; }
    }
}

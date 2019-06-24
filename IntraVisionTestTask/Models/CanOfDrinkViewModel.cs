using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntraVisionTestTask.Models
{
    public class CanOfDrinkViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Цена")]
        [Required]
        public int Price { get; set; }
        [Display(Name = "Количество")]
        [Required]
        public int Count { get; set; }
        [Display(Name = "Название")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Изображение")]
        public string ImageName { get; set; }
        [Display(Name = "Изображение")]
        public HttpPostedFileBase Image { get; set; }
    }
}
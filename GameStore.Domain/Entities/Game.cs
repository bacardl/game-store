using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GameStore.Domain.Entities
{
    public class Game
    {
        [HiddenInput(DisplayValue = false)]
        public int GameId { get; set; }

        [Display(Name = "Name of a game")]
        [Required(ErrorMessage = "Please, type a name of the game.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please, type a description of the game.")]
        public string Description { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please, specify a category for the game.")]
        public string Category { get; set; }


        [Display(Name = "Price($)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please, specify the positive value.")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}

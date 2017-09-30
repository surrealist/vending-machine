using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace VendingMachines.Models {
  public class Product {

    public int Id { get; set; }

    [Required(ErrorMessage ="กรุณากรอกชื่อ")]
    [StringLength(30)]
    [Remote("CheckDuplicateName", "Products")]
    public string Name { get; set; }

    [Range(1, 999)]
    public decimal Price { get; set; }

    [StringLength(500)]
    public string PictureUrl { get; set; }

    public bool IsFeatured { get; set; }

    public double? WeightGrams { get; set; }

    [Required]
    public string CreatedBy { get; set; }
  }
}

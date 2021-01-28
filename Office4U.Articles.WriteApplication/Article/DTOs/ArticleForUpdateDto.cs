using System.ComponentModel.DataAnnotations;

namespace Office4U.Articles.WriteApplication.Article.DTOs
{
    public class ArticleForUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string SupplierId { get; set; }

        [Required]
        [MaxLength(150)]
        public string SupplierReference { get; set; }
        [Required]
        public string Name1 { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
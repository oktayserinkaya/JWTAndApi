using System.ComponentModel.DataAnnotations;

namespace JWTAndApi.Models
{
    /// <summary>
    /// Kitap
    /// </summary>
    public class Book
    {
        /// <summary>
        /// ID Bilgisi
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Kitap Adı
        /// </summary>
        [MaxLength(120, ErrorMessage = "120 Karakter Sınırını Geçtiniz!...")]
        [MinLength(2, ErrorMessage = "En Az 2 Karakter Girmelisiniz!...")]
        [Required(ErrorMessage = "Bu Alan Zorunludur!...")]
        public required string Title { get; set; }

        /// <summary>
        /// Kitap Açıklaması
        /// </summary>
        [MaxLength(120, ErrorMessage = "120 Karakter Sınırını Geçtiniz!...")]
        [MinLength(4, ErrorMessage = "En Az 4 Karakter Girmelisiniz!...")]
        [Required(ErrorMessage = "Bu Alan Zorunludur!...")]
        public required string Description { get; set; }

        /// <summary>
        /// Yazar Adı
        /// </summary>
        [MaxLength(120, ErrorMessage = "120 Karakter Sınırını Geçtiniz!...")]
        [MinLength(4, ErrorMessage = "En Az 4 Karakter Girmelisiniz!...")]
        [Required(ErrorMessage = "Bu Alan Zorunludur!...")]
        public required string AuthorName { get; set; }
    }
}

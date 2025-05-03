using System.ComponentModel.DataAnnotations;
using JWTAndApi.CustomAttributes;

namespace JWTAndApi.DTO
{
    public class UpdateBookDto
    {
        /// <summary>
        /// ID Bilgisi
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Kitap Adı
        /// </summary>
        [NotNullAndMaxLength(120)]
        [NotNullAndMinLength(2)]
        public string? Title { get; set; }

        /// <summary>
        /// Kitap Açıklaması
        /// </summary>
        [NotNullAndMaxLength(120)]
        [NotNullAndMinLength(4)]
        public string? Description { get; set; }

        /// <summary>
        /// Yazar Adı
        /// </summary>
        [NotNullAndMaxLength(120)]
        [NotNullAndMinLength(4)]
        public string? AuthorName { get; set; }
    }
}

using JWTAndApi.DTO;
using JWTAndApi.Interfaces;
using JWTAndApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors("MyPolicy")]
    public class BooksController(IBookService bookService) : ControllerBase
    {
        /*
         * API Status Code
         * Bir http isteğinin sonucunu belirtmek için sunucu tarafından döndürülen 3 haneli sayılardır.
         * 
         * 1xx - Bilgilendirici
         * 100 => Continue
         * 101 => Switching Protocol
         * 
         * 2xx - Başarılı
         * 200 => OK : istek başarılı
         * 201 => Created : yeni bir kaynak oluşturuldu
         * 204 => No Content : İşlem başarılı ama dönecek veri yok
         * 
         * 3xx - Yönlendirme
         * 301 => Moved Permanently : Kaynak taşındı
         * 302 => Found : Geçici olarak başka yere yönlendirildi
         * 304 => Not Modified
         * 
         * 4xx - İstemci Hataları
         * 400 => Bad Request : Geçersiz istek
         * 401 => Unauthorized : Kimlik doğrulama hatası
         * 403 => Forbidden : Yetkin yok
         * 404 => Not Found : Kaynak bulunamadı
         * 409 => Conflict : Çakışma var
         * 
         * 5xx - Sunucu Hataları
         * 500 => Internal Server Error : Sunucuda bilinmeyen hata
         * 502 => Bad Gateway : Geçersiz yanıt alındı
         * 503 => Service Unavailable : Servis geçici olarak kullanılamıyor
         * 504 => Gateway Timeout : Sunucu zaman aşımına uğradı
         */

        private readonly IBookService _bookService = bookService;

        /// <summary>
        /// Bütün kitapları getirir
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetAllBooks();
            //return Ok(books);
            return StatusCode(200, books);
        }

        /// <summary>
        /// Id sini verdiğin kitabı getirir
        /// </summary>
        /// <param name="id">Kitabın ID Bilgisi</param>
        /// <returns></returns>
        [HttpGet("GetBookById")]
        public async Task<IActionResult> GetBookById(int id) //FromRoute olursa annotation bölümüne de link eklemem lazım
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                //return NotFound("Kitap Bulunamadı!...");
                return StatusCode(404, "Böyle bir kitap bulunamadı");
            }
            //return Ok(book);
            return StatusCode(200, book);
        }

        /*
         * FromHeader : Token gibi verileri gelen isteğin header bilgilerinden alır
         * FromBody : Http isteğinin gövdesinden(body) veri alır
         * FromForm : Html içerisindeki bir formdan veri alır
         * FromQuery : GetBookById?Id=1 şeklinde alınan id parametresi buna örnektir
         * FromRoute : GetBookById/1 şeklinde alınan id parametresi buna örnektir
         */

        /// <summary>
        /// Yeni Kitap Ekler
        /// </summary>
        /// <param name="book">Kitap Parametreleri</param>
        /// <returns></returns>
        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook([FromForm] CreateBookDto model)
        {
            if (!ModelState.IsValid)
                return StatusCode(400, "İstek Hatası!...");

            var book = new Book
            {
                Title = model.Title,
                Description = model.Description,
                AuthorName = model.AuthorName
            };

            var result = await _bookService.CreateBook(book);
            return result ? StatusCode(200, "Kitap Başarıyla Eklendi!...") : StatusCode(500, "Kitap Eklenemedi!...");
        }

        /// <summary>
        /// Kitap günceller
        /// </summary>
        /// <param name="model">kitap property leri</param>
        /// <returns></returns>
        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromForm] UpdateBookDto model)
        {
            if (!ModelState.IsValid)
                return StatusCode(400, "Hatalı istek");

            var book = await _bookService.GetBookById(model.Id);

            if (book == null)
                return StatusCode(404, "Kitap bulunaması");

            if (!string.IsNullOrEmpty(model.Title))
                book.Title = model.Title;

            if (!string.IsNullOrEmpty(model.Description))
                book.Description = model.Description;

            if (!string.IsNullOrEmpty(model.AuthorName))
                book.AuthorName = model.AuthorName;

            var result = await _bookService.UpdateBook(book);
            return result ? StatusCode(200, "Kitap güncellendi") : StatusCode(500, "kitap güncellenemedi");
        }

        /// <summary>
        /// Kitap siler
        /// </summary>
        /// <param name="id">Kitabın ID bilgisi</param>
        /// <returns></returns>
        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
                return StatusCode(404, "Böyle bir kitap bulunamadı");

            var result = await _bookService.DeleteBook(book);
            return result ? StatusCode(200, "Kitap Başarıyla silindi") : StatusCode(500, "Kitap silinemedi");
        }
    }
}
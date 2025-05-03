using JWTAndApi.Context;
using JWTAndApi.Interfaces;
using JWTAndApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAndApi.Services
{
    public class BookService(AppDbContext context) : IBookService
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> CreateBook(Book book)
        {
            await _context.Books.AddAsync(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateBook(Book book)
        {
            _context.Books.Update(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Book>> GetAllBooks()
            => await _context.Books.ToListAsync();

        public async Task<Book?> GetBookById(int id)
            => await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
    }
}

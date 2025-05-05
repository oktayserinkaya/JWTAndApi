using JWTAndApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWTAndApi.SeedData
{
    public class BookSeedData : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData
            (
                new Book { Id = 1, Title = "Yüzüklerin Efendisi", Description = "Orta Dünya'da geçen epik bir macera.", AuthorName = "J.R.R. Tolkien" },
                new Book { Id = 2, Title = "Harry Potter ve Felsefe Taşı", Description = "Bir büyücünün büyü dünyasındaki ilk yılı.", AuthorName = "J.K. Rowling" },
                new Book { Id = 3, Title = "Suç ve Ceza", Description = "Bir adamın suçluluk psikolojisiyle yüzleşmesi.", AuthorName = "Fyodor Dostoyevski" },
                new Book { Id = 4, Title = "1984", Description = "Baskıcı bir rejimde bireysel özgürlük mücadelesi.", AuthorName = "George Orwell" },
                new Book { Id = 5, Title = "Hayvan Çiftliği", Description = "Siyasi alegoriyle yazılmış kısa bir roman.", AuthorName = "George Orwell" },
                new Book { Id = 6, Title = "Sefiller", Description = "Toplumsal adaletin ve kefaretin öyküsü.", AuthorName = "Victor Hugo" },
                new Book { Id = 7, Title = "Karamazov Kardeşler", Description = "Aile bağları ve felsefi sorgulamalar.", AuthorName = "Fyodor Dostoyevski" },
                new Book { Id = 8, Title = "Simyacı", Description = "Bir gencin kişisel menkıbesini arayışı.", AuthorName = "Paulo Coelho" },
                new Book { Id = 9, Title = "Uçurtma Avcısı", Description = "İhanet ve bağışlamanın etkileyici hikayesi.", AuthorName = "Khaled Hosseini" },
                new Book { Id = 10, Title = "Bülbülü Öldürmek", Description = "Irkçılıkla mücadele eden bir avukatın öyküsü.", AuthorName = "Harper Lee" },
                new Book { Id = 11, Title = "Körlük", Description = "Toplumun çöküşüne dair distopik bir roman.", AuthorName = "José Saramago" },
                new Book { Id = 12, Title = "Cesur Yeni Dünya", Description = "Gelecekteki teknoloji kontrolü üzerine.", AuthorName = "Aldous Huxley" },
                new Book { Id = 13, Title = "Beyaz Diş", Description = "Bir kurdun hayatta kalma mücadelesi.", AuthorName = "Jack London" },
                new Book { Id = 14, Title = "Vadideki Zambak", Description = "Aşk ve fedakârlığın klasik öyküsü.", AuthorName = "Honoré de Balzac" },
                new Book { Id = 15, Title = "Martin Eden", Description = "Bir yazarın yükseliş ve düşüş hikayesi.", AuthorName = "Jack London" },
                new Book { Id = 16, Title = "Dava", Description = "Bir adamın anlam veremediği bir suçlamayla mücadelesi.", AuthorName = "Franz Kafka" },
                new Book { Id = 17, Title = "Satranç", Description = "Bir satranç dahisinin psikolojik portresi.", AuthorName = "Stefan Zweig" },
                new Book { Id = 18, Title = "İnsan Neyle Yaşar?", Description = "İnsani değerler üzerine kısa hikayeler.", AuthorName = "Lev Tolstoy" },
                new Book { Id = 19, Title = "Anna Karenina", Description = "Toplumsal normlar ve kişisel trajedi.", AuthorName = "Lev Tolstoy" },
                new Book { Id = 20, Title = "Denemeler", Description = "Felsefi ve kişisel düşünceler koleksiyonu.", AuthorName = "Montaigne" }
            );
        }
    }
}

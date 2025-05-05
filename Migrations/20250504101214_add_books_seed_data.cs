using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JWTAndApi.Migrations
{
    /// <inheritdoc />
    public partial class add_books_seed_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "J.R.R. Tolkien", "Orta Dünya'da geçen epik bir macera.", "Yüzüklerin Efendisi" },
                    { 2, "J.K. Rowling", "Bir büyücünün büyü dünyasındaki ilk yılı.", "Harry Potter ve Felsefe Taşı" },
                    { 3, "Fyodor Dostoyevski", "Bir adamın suçluluk psikolojisiyle yüzleşmesi.", "Suç ve Ceza" },
                    { 4, "George Orwell", "Baskıcı bir rejimde bireysel özgürlük mücadelesi.", "1984" },
                    { 5, "George Orwell", "Siyasi alegoriyle yazılmış kısa bir roman.", "Hayvan Çiftliği" },
                    { 6, "Victor Hugo", "Toplumsal adaletin ve kefaretin öyküsü.", "Sefiller" },
                    { 7, "Fyodor Dostoyevski", "Aile bağları ve felsefi sorgulamalar.", "Karamazov Kardeşler" },
                    { 8, "Paulo Coelho", "Bir gencin kişisel menkıbesini arayışı.", "Simyacı" },
                    { 9, "Khaled Hosseini", "İhanet ve bağışlamanın etkileyici hikayesi.", "Uçurtma Avcısı" },
                    { 10, "Harper Lee", "Irkçılıkla mücadele eden bir avukatın öyküsü.", "Bülbülü Öldürmek" },
                    { 11, "José Saramago", "Toplumun çöküşüne dair distopik bir roman.", "Körlük" },
                    { 12, "Aldous Huxley", "Gelecekteki teknoloji kontrolü üzerine.", "Cesur Yeni Dünya" },
                    { 13, "Jack London", "Bir kurdun hayatta kalma mücadelesi.", "Beyaz Diş" },
                    { 14, "Honoré de Balzac", "Aşk ve fedakârlığın klasik öyküsü.", "Vadideki Zambak" },
                    { 15, "Jack London", "Bir yazarın yükseliş ve düşüş hikayesi.", "Martin Eden" },
                    { 16, "Franz Kafka", "Bir adamın anlam veremediği bir suçlamayla mücadelesi.", "Dava" },
                    { 17, "Stefan Zweig", "Bir satranç dahisinin psikolojik portresi.", "Satranç" },
                    { 18, "Lev Tolstoy", "İnsani değerler üzerine kısa hikayeler.", "İnsan Neyle Yaşar?" },
                    { 19, "Lev Tolstoy", "Toplumsal normlar ve kişisel trajedi.", "Anna Karenina" },
                    { 20, "Montaigne", "Felsefi ve kişisel düşünceler koleksiyonu.", "Denemeler" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}

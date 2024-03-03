using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class ProductSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductName", "Price" },
                values: new object[] { 1, 17000m, "Computer"});

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductName", "Price" },
                values: new object[] { 2, 17000m, "Keyboard" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductName", "Price" },
                values: new object[] { 3, 17000m, "Computer" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductName", "Price" },
                values: new object[] { 4, 17000m, "Computer" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductName", "Price" },
                values: new object[] { 5, 17000m, "Computer" });
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductName" },
                values: new object[] { 1, 17000m, "Computer" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductName" },
                values: new object[] { 2, 1000m, "Keyboard" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductName" },
                values: new object[] { 3, 500m, "Mouse" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductName" },
                values: new object[] { 4, 7000m, "Monitor" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductName" },
                values: new object[] { 5, 1500m, "Deck" });
        }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "Product",
            keyColumn: "Id",
            keyValues: new object[]
            {
                    1, 2 /* Silmek istediğiniz diğer ürünlerin Id'leri */
            });
    }
}
}

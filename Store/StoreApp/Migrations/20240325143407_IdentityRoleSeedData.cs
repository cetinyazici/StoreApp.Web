using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class IdentityRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31d187aa-7844-48bf-b2d7-bc9657b4d9d0", "c0817fc7-c359-40cc-9411-6936fd8e60ec", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7eb7eebb-8742-4817-a19a-1a87c12d95cf", "0326bb04-bb5f-4406-a420-4313629adc6d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd4eedd9-1df9-476f-bd19-ab7ad0c3c873", "d6cbe746-ecc3-430a-8a8c-9353626d752c", "Editor", "EDITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31d187aa-7844-48bf-b2d7-bc9657b4d9d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7eb7eebb-8742-4817-a19a-1a87c12d95cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd4eedd9-1df9-476f-bd19-ab7ad0c3c873");
        }
    }
}

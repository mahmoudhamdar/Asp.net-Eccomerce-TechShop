using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76b58d9a-ad64-4cf5-94ed-a082f0fb026f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "CompanyId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0b0e70e8-0092-44df-9709-75462e947a4c", 0, "Beirut", null, "8f718a9d-3b03-4328-88d1-ab72db92df40", "User", null, false, false, null, null, null, null, null, false, "14a3de10-dcc4-41a0-bde6-11ba27e4feae", false, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "ImgUrl",
                value: "\\images\\product\\download.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "ImgUrl",
                value: "\\images\\product\\download (1).jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "ImgUrl",
                value: "\\images\\product\\https___hybrismediaprod.blob.core.windows.net_sys-master-phoenix-images-container_h61_h66_9705254158366_huntsman-v3-pro-mini-2-500x500.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "ImgUrl",
                value: "\\images\\product\\krakens.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "ImgUrl",
                value: "\\images\\product\\https___hybrismediaprod.blob.core.windows.net_sys-master-phoenix-images-container_h8f_h57_9640099217438_blackwidow-v4-black-x-500x500.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "ImgUrl",
                value: "\\images\\product\\https___hybrismediaprod.blob.core.windows.net_sys-master-phoenix-images-container_hf7_h5a_9640099119134_blackwidow-v4-75-black-2-500x500.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7,
                column: "ImgUrl",
                value: "\\images\\product\\headphones.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8,
                column: "ImgUrl",
                value: "\\images\\product\\Hyper_mouse.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b0e70e8-0092-44df-9709-75462e947a4c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "CompanyId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "76b58d9a-ad64-4cf5-94ed-a082f0fb026f", 0, "Beirut", null, "1d50228e-d045-4aca-a9c8-4b2514d7cd56", "User", null, false, false, null, null, null, null, null, false, "38430201-6e7d-4fa1-ae00-d95f2b2cdbd5", false, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "ImgUrl",
                value: "download.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "ImgUrl",
                value: "download (1).jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "ImgUrl",
                value: "https___hybrismediaprod.blob.core.windows.net_sys-master-phoenix-images-container_h61_h66_9705254158366_huntsman-v3-pro-mini-2-500x500.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "ImgUrl",
                value: "krakens.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "ImgUrl",
                value: "https___hybrismediaprod.blob.core.windows.net_sys-master-phoenix-images-container_h8f_h57_9640099217438_blackwidow-v4-black-x-500x500.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "ImgUrl",
                value: "https___hybrismediaprod.blob.core.windows.net_sys-master-phoenix-images-container_hf7_h5a_9640099119134_blackwidow-v4-75-black-2-500x500.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7,
                column: "ImgUrl",
                value: "headphones.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8,
                column: "ImgUrl",
                value: "Hyper_mouse.jpg");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Andeanpm.Server.Data.Migrations
{
    public partial class OperationsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Module = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(7977));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 15,
                column: "Module",
                value: "TechnicalReports");

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 16,
                column: "Module",
                value: "TechnicalReports");

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(8011));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 17, 24, 55, 973, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.InsertData(
                table: "Operation",
                columns: new[] { "Id", "ImageLink", "Module" },
                values: new object[,]
                {
                    { 1, "assets/operations/cl_1_big.jpg", "CachiLaguna" },
                    { 2, "assets/operations/cl_gallery01.jpg", "CachiLaguna" },
                    { 3, "assets/operations/cl_gallery02.jpg", "CachiLaguna" },
                    { 4, "assets/operations/cl_gallery03.jpg", "CachiLaguna" },
                    { 5, "assets/operations/cl_gallery04.jpg", "CachiLaguna" },
                    { 6, "assets/operations/sb_gallery01.jpg", "CerroRicoDeposits" },
                    { 7, "assets/operations/sb_gallery02.jpg", "CerroRicoDeposits" },
                    { 8, "assets/operations/sb_gallery03.jpg", "CerroRicoDeposits" },
                    { 9, "assets/operations/sb_gallery04.jpg", "CerroRicoDeposits" },
                    { 10, "assets/operations/sb_1_big.jpg", "CerroRicoDeposits" },
                    { 11, "assets/operations/sb_2_big.jpg", "CerroRicoDeposits" },
                    { 12, "assets/operations/sb_3_big.jpg", "CerroRicoDeposits" },
                    { 13, "assets/operations/ea_gallery01.jpg", "ElAsiento" },
                    { 14, "assets/operations/ea_gallery02.jpg", "ElAsiento" },
                    { 15, "assets/operations/ea_gallery03.jpg", "ElAsiento" },
                    { 16, "assets/operations/ea_gallery04.jpg", "ElAsiento" },
                    { 17, "assets/operations/ea_1_big.jpg", "ElAsiento" },
                    { 18, "assets/operations/ea_2_big.jpg", "ElAsiento" },
                    { 19, "assets/operations/ea_3_big.jpg", "ElAsiento" }
                });

            migrationBuilder.InsertData(
                table: "Operation",
                columns: new[] { "Id", "ImageLink", "Module" },
                values: new object[,]
                {
                    { 20, "assets/operations/tp_gallery01.jpg", "TatasiPortugalete" },
                    { 21, "assets/operations/tp_gallery02.jpg", "TatasiPortugalete" },
                    { 22, "assets/operations/tp_gallery03.jpg", "TatasiPortugalete" },
                    { 23, "assets/operations/tp_gallery04.jpg", "TatasiPortugalete" },
                    { 24, "assets/operations/tp_1_big.jpg", "TatasiPortugalete" },
                    { 25, "assets/operations/tp_2_big.jpg", "TatasiPortugalete" },
                    { 26, "assets/operations/tp_3_big.jpg", "TatasiPortugalete" },
                    { 27, "assets/operations/mt_gallery01.jpg", "Monserrat" },
                    { 28, "assets/operations/mt_gallery02.jpg", "Monserrat" },
                    { 29, "assets/operations/mt_gallery03.jpg", "Monserrat" },
                    { 30, "assets/operations/mt_gallery04.jpg", "Monserrat" },
                    { 31, "assets/operations/mt_1_big.jpg", "Monserrat" },
                    { 32, "assets/operations/mt_2_big.jpg", "Monserrat" },
                    { 33, "assets/operations/mt_3_big.jpg", "Monserrat" },
                    { 34, "assets/operations/sp_gallery01.jpg", "SanPablo" },
                    { 35, "assets/operations/sp_gallery02.jpg", "SanPablo" },
                    { 36, "assets/operations/sp_gallery03.jpg", "SanPablo" },
                    { 37, "assets/operations/sp_gallery04.jpg", "SanPablo" },
                    { 38, "assets/operations/sp_1_big.jpg", "SanPablo" },
                    { 39, "assets/operations/sp_2_big.jpg", "SanPablo" },
                    { 40, "assets/operations/sp_3_big.jpg", "SanPablo" },
                    { 41, "assets/operations/rb_gallery01.jpg", "RioBlanco" },
                    { 42, "assets/operations/rb_gallery02.jpg", "RioBlanco" },
                    { 43, "assets/operations/rb_gallery03.jpg", "RioBlanco" },
                    { 44, "assets/operations/rb_gallery04.jpg", "RioBlanco" },
                    { 45, "assets/operations/rb_1_big.jpg", "RioBlanco" },
                    { 46, "assets/operations/rb_2_big.jpg", "RioBlanco" },
                    { 47, "assets/operations/rb_3_big.jpg", "RioBlanco" },
                    { 48, "assets/operations/rb_4_big.jpg", "RioBlanco" },
                    { 49, "assets/operations/rb_5_big.jpg", "RioBlanco" },
                    { 50, "assets/operations/rb_6_big.jpg", "RioBlanco" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 30, 17, 24, 55, 974, DateTimeKind.Local).AddTicks(2320), new byte[] { 253, 1, 186, 189, 1, 172, 72, 140, 6, 80, 26, 221, 67, 1, 190, 76, 110, 25, 22, 181, 42, 204, 85, 216, 85, 132, 64, 195, 99, 236, 243, 170, 27, 36, 217, 24, 69, 60, 15, 42, 189, 56, 107, 51, 11, 23, 178, 156, 164, 141, 48, 101, 131, 138, 140, 248, 98, 116, 92, 80, 200, 155, 123, 37 }, new byte[] { 67, 160, 102, 105, 144, 94, 13, 143, 249, 28, 177, 41, 174, 250, 138, 182, 235, 158, 88, 14, 59, 145, 97, 153, 4, 249, 34, 14, 166, 237, 177, 201, 244, 95, 196, 68, 223, 168, 166, 2, 11, 208, 1, 252, 87, 70, 80, 8, 88, 157, 45, 3, 131, 97, 216, 90, 145, 27, 25, 120, 55, 5, 116, 86, 15, 206, 26, 119, 18, 93, 99, 128, 193, 198, 131, 111, 166, 153, 241, 184, 191, 53, 147, 195, 146, 13, 93, 126, 133, 158, 199, 193, 179, 132, 57, 255, 246, 211, 63, 73, 165, 190, 186, 202, 8, 172, 202, 74, 22, 139, 130, 245, 58, 7, 128, 10, 196, 43, 54, 160, 249, 110, 179, 230, 138, 142, 237, 164 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(424));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(431));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(434));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(449));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(461));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(464));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 15,
                column: "Module",
                value: "TecnicalReports");

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 16,
                column: "Module",
                value: "TecnicalReports");

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(485));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "InvestorReports",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateCreate",
                value: new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(1222), new byte[] { 115, 78, 93, 6, 39, 147, 137, 53, 115, 168, 57, 167, 162, 172, 219, 66, 134, 66, 246, 114, 180, 150, 253, 100, 136, 162, 177, 30, 164, 5, 70, 147, 26, 177, 188, 124, 127, 103, 244, 165, 89, 102, 245, 23, 248, 47, 40, 97, 147, 17, 99, 188, 30, 88, 251, 154, 127, 251, 167, 228, 129, 186, 172, 235 }, new byte[] { 120, 74, 25, 12, 112, 227, 110, 180, 70, 63, 132, 2, 143, 239, 221, 37, 62, 247, 204, 177, 29, 138, 32, 117, 128, 49, 118, 28, 135, 154, 111, 36, 123, 146, 101, 104, 32, 172, 16, 53, 133, 181, 144, 87, 144, 251, 17, 12, 82, 237, 150, 25, 206, 11, 89, 228, 192, 100, 28, 167, 145, 234, 182, 19, 210, 149, 105, 28, 137, 235, 216, 52, 102, 37, 148, 78, 212, 38, 193, 162, 201, 129, 81, 28, 238, 223, 246, 190, 160, 250, 151, 99, 232, 140, 92, 225, 63, 86, 109, 216, 134, 129, 188, 27, 57, 88, 204, 121, 163, 48, 128, 175, 130, 47, 216, 188, 198, 94, 54, 51, 64, 231, 223, 206, 108, 168, 41, 228 } });
        }
    }
}

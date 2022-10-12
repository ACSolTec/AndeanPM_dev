using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Andeanpm.Server.Data.Migrations
{
    public partial class InvestorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestorReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Module = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestorReports", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "InvestorReports",
                columns: new[] { "Id", "DateCreate", "Module", "SubTitle", "Title", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(424), "FinancialReports", "Financial Statements", "FOR THE YEARS ENDED DECEMBER 31, 2020 AND 2019", "assets/investors/FinancialReports/1254688 BC Ltd FY2020 Financial Statements.pdf" },
                    { 2, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(428), "FinancialReports", "MD&A", "YEAR ENDED DECEMBER 31, 2020", "assets/investors/FinancialReports/1254688 BC Ltd FY2020 MD&A.pdf" },
                    { 3, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(431), "FinancialReports", "Financial Statements", "FOR THE THREE MONTHS ENDED MARCH 31, 2021 AND 2020", "assets/investors/FinancialReports/FY2021 Q1 APM FS.pd" },
                    { 4, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(434), "FinancialReports", "MD&A", "FIRST QUARTER REPORT MARCH 31, 2021", "assets/investors/FinancialReports/FY2021 Q1 APM MDA.pdf" },
                    { 5, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(437), "FinancialReports", "Financial Statements", "FOR THE THREE AND SIX MONTHS ENDED JUNE 30, 2021 AND 2020", "assets/investors/FinancialReports/FY2021 Q2 APM FS.pdf" },
                    { 6, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(440), "FinancialReports", "MD&A", "SECOND QUARTER REPORT JUNE 30, 2021", "assets/investors/FinancialReports/FY2021 Q2 APM MDA.pdf" },
                    { 7, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(443), "FinancialReports", "Financial Statements", "FOR THE THREE AND NINE MONTHS ENDED SEPTEMBER 30, 2021 AND 2020", "assets/investors/FinancialReports/FY2021 Q3 APM FS.pdf" },
                    { 8, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(446), "FinancialReports", "MD&A", "THIRD QUARTER REPORT SEPTEMBER 30, 2021", "assets/investors/FinancialReports/FY2021 Q3 APM MDA.pdf" },
                    { 9, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(449), "FinancialReports", "Financial Statements", "FOR THE YEARS ENDED DECEMBER 31, 2021 AND 2020", "assets/investors/FinancialReports/FY2021 Q4 YE APM FS.pdf" },
                    { 10, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(452), "FinancialReports", "MD&A", "FOR THE YEAR ENDED DECEMBER 31, 2021", "assets/investors/FinancialReports/FY2021 Q4 APM MDA.pdf" },
                    { 11, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(455), "FinancialReports", "Financial Statements", "FOR THE THREE MONTHS ENDED MARCH 31, 2022 AND 2021", "assets/investors/FinancialReports/APM FS Q1 2022-Final.pdf" },
                    { 12, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(458), "FinancialReports", "MD&A", "FIRST QUARTER REPORT MARCH 31, 2022", "assets/investors/FinancialReports/APM MDA Q1 2022-Final.pdf" },
                    { 13, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(461), "FinancialReports", "Financial Statements", "FOR THE THREE AND SIX MONTHS ENDED JUNE 30, 2022 AND 2021", "assets/investors/FinancialReports/APM FS Q2 2022 Financial Statements.pdf" },
                    { 14, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(464), "FinancialReports", "MD&A", "SECOND QUARTER REPORT JUNE 30, 2022", "assets/investors/FinancialReports/APM MDA Q2 2022 Management Dissc Analysis.pdf.pdf" },
                    { 15, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TechnicalReports", "PDF", "Bolivia Properties Technical Report", "assets/investors/TechnicalReports/TR_Bolivia.pdf" },
                    { 16, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "TechnicalReports", "PDF", "San Bartolome Technical Report 2022", "assets/investors/TechnicalReports/San Bartolome Technical Report 2022.pdf" },
                    { 17, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(473), "Sustainability", "PDF", "SUSTAINABILITY FRAMEWORK 2021", "assets/investors/Sustainability/SUSTAINABILITY FRAMEWORK AndeanPM.PDF" },
                    { 18, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(476), "AGSM", "PDF", "Financial Statement request form", "assets/investors/AGSM/Financial Statement Request Form.pdf" },
                    { 19, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(479), "AGSM", "PDF", "Notice And Access Notification", "assets/investors/AGSM/Notice and Access Notification.pdf" },
                    { 20, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(482), "AGSM", "PDF", "Voting Instruction Form", "assets/investors/AGSM/Voting Instruction Form.pdf" },
                    { 21, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(485), "AGSM", "PDF", "Form of Proxy", "assets/investors/AGSM/Form of Proxy.pdf" },
                    { 22, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(488), "AGSM", "PDF", "Information Circular", "assets/investors/AGSM/Information Circular.pdf" },
                    { 23, new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(491), "AGSM", "PDF", "Meeting Notice", "assets/investors/AGSM/Meeting_Notice.pdf" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 30, 11, 16, 35, 760, DateTimeKind.Local).AddTicks(1222), new byte[] { 115, 78, 93, 6, 39, 147, 137, 53, 115, 168, 57, 167, 162, 172, 219, 66, 134, 66, 246, 114, 180, 150, 253, 100, 136, 162, 177, 30, 164, 5, 70, 147, 26, 177, 188, 124, 127, 103, 244, 165, 89, 102, 245, 23, 248, 47, 40, 97, 147, 17, 99, 188, 30, 88, 251, 154, 127, 251, 167, 228, 129, 186, 172, 235 }, new byte[] { 120, 74, 25, 12, 112, 227, 110, 180, 70, 63, 132, 2, 143, 239, 221, 37, 62, 247, 204, 177, 29, 138, 32, 117, 128, 49, 118, 28, 135, 154, 111, 36, 123, 146, 101, 104, 32, 172, 16, 53, 133, 181, 144, 87, 144, 251, 17, 12, 82, 237, 150, 25, 206, 11, 89, 228, 192, 100, 28, 167, 145, 234, 182, 19, 210, 149, 105, 28, 137, 235, 216, 52, 102, 37, 148, 78, 212, 38, 193, 162, 201, 129, 81, 28, 238, 223, 246, 190, 160, 250, 151, 99, 232, 140, 92, 225, 63, 86, 109, 216, 134, 129, 188, 27, 57, 88, 204, 121, 163, 48, 128, 175, 130, 47, 216, 188, 198, 94, 54, 51, 64, 231, 223, 206, 108, 168, 41, 228 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestorReports");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 9, 27, 10, 59, 13, 994, DateTimeKind.Local).AddTicks(1131), new byte[] { 123, 250, 31, 165, 226, 189, 161, 46, 113, 9, 177, 52, 107, 70, 229, 38, 197, 249, 211, 168, 192, 10, 115, 209, 118, 86, 206, 135, 54, 83, 71, 216, 74, 165, 52, 60, 61, 136, 180, 84, 243, 217, 74, 186, 195, 39, 83, 212, 97, 133, 209, 125, 35, 37, 60, 169, 171, 211, 126, 179, 189, 125, 99, 238 }, new byte[] { 187, 48, 80, 113, 76, 183, 101, 60, 62, 84, 195, 159, 25, 33, 109, 27, 197, 31, 2, 117, 206, 248, 84, 224, 168, 126, 121, 176, 59, 157, 234, 204, 212, 153, 43, 103, 80, 210, 171, 57, 187, 178, 205, 230, 154, 197, 118, 5, 213, 249, 211, 75, 189, 208, 247, 216, 21, 71, 23, 117, 7, 201, 56, 106, 9, 43, 93, 58, 26, 213, 87, 153, 109, 41, 145, 193, 46, 203, 102, 197, 89, 201, 84, 36, 53, 137, 94, 84, 68, 202, 120, 26, 255, 227, 122, 238, 128, 95, 246, 30, 175, 100, 56, 160, 159, 58, 73, 198, 247, 147, 10, 228, 70, 27, 91, 21, 242, 76, 167, 13, 162, 66, 70, 46, 147, 140, 187, 170 } });
        }
    }
}

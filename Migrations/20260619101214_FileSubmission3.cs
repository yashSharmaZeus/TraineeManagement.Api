using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineeManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class FileSubmission3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OriginalFilName",
                table: "SubmissionFileMetaData",
                type: "Varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "GeneratedStorageName",
                table: "SubmissionFileMetaData",
                type: "Varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                table: "SubmissionFileMetaData",
                type: "Varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2026, 6, 19, 10, 12, 14, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 19, 10, 12, 14, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OriginalFilName",
                table: "SubmissionFileMetaData",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "GeneratedStorageName",
                table: "SubmissionFileMetaData",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                table: "SubmissionFileMetaData",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(20)");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2026, 6, 19, 10, 7, 57, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 19, 10, 7, 57, 0, DateTimeKind.Unspecified) });
        }
    }
}

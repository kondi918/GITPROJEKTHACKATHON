using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class hackyeahv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "QuestionText",
                table: "Answers",
                newName: "AnswerText");

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "AnswerText",
                table: "Answers",
                newName: "QuestionText");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Answers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

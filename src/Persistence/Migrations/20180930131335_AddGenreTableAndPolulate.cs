using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Persistence.Entities;

namespace Persistence.Migrations
{
    public partial class AddGenreTableAndPolulate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the lookup table
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    GenreName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            // Populate the table with enum values
            foreach (Genre genre in Enum.GetValues(typeof(Genre)))
            {
                migrationBuilder.Sql("INSERT INTO " +
                    "Genre" +
                    " SELECT " + (int)genre + ", '" + genre.ToString() + "'");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

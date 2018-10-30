using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class TestCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("clients", table => new
            {
                Id = table.Column<int>(),
                Name = table.Column<string>(maxLength: 255, nullable: false),
                Surname = table.Column<string>(maxLength: 255, nullable: false),
                Email = table.Column<string>(maxLength: 255, nullable: false),
                Password = table.Column<string>(maxLength: 255, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime")
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

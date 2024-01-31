using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createeee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SommarHusLists",
                newName: "SommarHusId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "SommarHusLists",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleQuantity",
                table: "SommarHusLists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ArticleName",
                table: "SommarHusLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "FamilyArticleList",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleQuantity",
                table: "FamilyArticleList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ArticleName",
                table: "FamilyArticleList",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("047425eb-15a5-4310-9d25-e281ab036868"), "$2a$11$u8vPjCaoiL6ljfnLI3vhAOLrStsZXC6BJ/V9MXCFO9x3cbspCCKgq", "Sandra" },
                    { new Guid("047425eb-15a5-4310-9d25-e281ab036869"), "$2a$11$akwWEK20OoZimDJhCRDgUeb6tLgUS/RZ5tN.xVEEmh8E2kC74iUrm", "Mohamed" },
                    { new Guid("047425eb-15a5-4310-9d25-e281ab036870"), "$2a$11$mcTHDqzWGO1xThBx3sv0gOPzBd54GmR8ak79ZyzLJvY5/ppydfgOO", "Felix" },
                    { new Guid("047425eb-15a5-4310-9d25-e281ab036871"), "$2a$11$Eo3NgMUIAwSlVVSBVH7gw.xJWnV09SITzdbdti6o0SPYfVFIwCFgW", "Kamphol" },
                    { new Guid("047425eb-15a5-4310-9d25-e281ab036872"), "$2a$11$MjStOR2g24BbVfF0MddnJeV5N0f1lZDy/AqBd7Wo0xbXj.Mzu1n/2", "Louis" },
                    { new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), "$2a$11$f2hCeEnyg1iOsIL1j6/mQ.Iv1wiMO9Rbf2W/CvCDTvK4L9ECbshs.", "Bojan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("047425eb-15a5-4310-9d25-e281ab036868"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("047425eb-15a5-4310-9d25-e281ab036869"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("047425eb-15a5-4310-9d25-e281ab036870"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("047425eb-15a5-4310-9d25-e281ab036871"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("047425eb-15a5-4310-9d25-e281ab036872"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("08260479-52a0-4c0e-a588-274101a2c3be"));

            migrationBuilder.RenameColumn(
                name: "SommarHusId",
                table: "SommarHusLists",
                newName: "Id");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "SommarHusLists",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArticleQuantity",
                table: "SommarHusLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleName",
                table: "SommarHusLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "FamilyArticleList",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArticleQuantity",
                table: "FamilyArticleList",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleName",
                table: "FamilyArticleList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

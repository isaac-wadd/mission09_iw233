using Microsoft.EntityFrameworkCore.Migrations;

namespace bookApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryID = table.Column<ushort>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "classifications",
                columns: table => new
                {
                    classificationID = table.Column<ushort>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    classificationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classifications", x => x.classificationID);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    bookID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: false),
                    author = table.Column<string>(nullable: false),
                    publisher = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(nullable: false),
                    classificationID = table.Column<ushort>(nullable: false),
                    categoryID = table.Column<ushort>(nullable: false),
                    pageCount = table.Column<ushort>(nullable: false),
                    price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.bookID);
                    table.ForeignKey(
                        name: "FK_books_categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "categories",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_classifications_classificationID",
                        column: x => x.classificationID,
                        principalTable: "classifications",
                        principalColumn: "classificationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { (ushort)1, "action" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { (ushort)2, "biography" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { (ushort)3, "business" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { (ushort)4, "christian" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { (ushort)5, "classic" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { (ushort)6, "health" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { (ushort)7, "historical" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { (ushort)8, "self-help" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { (ushort)9, "thriller" });

            migrationBuilder.InsertData(
                table: "classifications",
                columns: new[] { "classificationID", "classificationName" },
                values: new object[] { (ushort)1, "fiction" });

            migrationBuilder.InsertData(
                table: "classifications",
                columns: new[] { "classificationID", "classificationName" },
                values: new object[] { (ushort)2, "non-fiction" });

            migrationBuilder.CreateIndex(
                name: "IX_books_categoryID",
                table: "books",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_books_classificationID",
                table: "books",
                column: "classificationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "classifications");
        }
    }
}

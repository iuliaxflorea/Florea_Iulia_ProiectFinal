using Microsoft.EntityFrameworkCore.Migrations;

namespace Florea_Iulia_ProiectFinal.Migrations
{
    public partial class BookCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreID",
                table: "Camera",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CameraCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CameraCategory_Camera_CameraID",
                        column: x => x.CameraID,
                        principalTable: "Camera",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CameraCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camera_StoreID",
                table: "Camera",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_CameraCategory_CameraID",
                table: "CameraCategory",
                column: "CameraID");

            migrationBuilder.CreateIndex(
                name: "IX_CameraCategory_CategoryID",
                table: "CameraCategory",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Camera_Store_StoreID",
                table: "Camera",
                column: "StoreID",
                principalTable: "Store",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Camera_Store_StoreID",
                table: "Camera");

            migrationBuilder.DropTable(
                name: "CameraCategory");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Camera_StoreID",
                table: "Camera");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "Camera");
        }
    }
}

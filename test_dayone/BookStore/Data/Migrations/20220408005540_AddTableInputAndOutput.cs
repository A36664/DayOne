using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class AddTableInputAndOutput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Input_Books_BookId",
                table: "Input");

            migrationBuilder.DropForeignKey(
                name: "FK_OutPut_Books_BookId",
                table: "OutPut");

            migrationBuilder.DropTable(
                name: "BookViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutPut",
                table: "OutPut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Input",
                table: "Input");

            migrationBuilder.RenameTable(
                name: "OutPut",
                newName: "OutPuts");

            migrationBuilder.RenameTable(
                name: "Input",
                newName: "Inputs");

            migrationBuilder.RenameIndex(
                name: "IX_OutPut_BookId",
                table: "OutPuts",
                newName: "IX_OutPuts_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Input_BookId",
                table: "Inputs",
                newName: "IX_Inputs_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutPuts",
                table: "OutPuts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inputs",
                table: "Inputs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inputs_Books_BookId",
                table: "Inputs",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutPuts_Books_BookId",
                table: "OutPuts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inputs_Books_BookId",
                table: "Inputs");

            migrationBuilder.DropForeignKey(
                name: "FK_OutPuts_Books_BookId",
                table: "OutPuts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutPuts",
                table: "OutPuts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inputs",
                table: "Inputs");

            migrationBuilder.RenameTable(
                name: "OutPuts",
                newName: "OutPut");

            migrationBuilder.RenameTable(
                name: "Inputs",
                newName: "Input");

            migrationBuilder.RenameIndex(
                name: "IX_OutPuts_BookId",
                table: "OutPut",
                newName: "IX_OutPut_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Inputs_BookId",
                table: "Input",
                newName: "IX_Input_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutPut",
                table: "OutPut",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Input",
                table: "Input",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BookViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookViewModel", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Input_Books_BookId",
                table: "Input",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutPut_Books_BookId",
                table: "OutPut",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

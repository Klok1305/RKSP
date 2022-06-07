using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class MyNewAwesomeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "author_shop");

            migrationBuilder.DropColumn(
                name: "cost2display",
                table: "shops");

            migrationBuilder.DropColumn(
                name: "genre",
                table: "authors");

            migrationBuilder.RenameColumn(
                name: "author",
                table: "books",
                newName: "genre");

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "shops",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "book_shop",
                columns: table => new
                {
                    books_id = table.Column<int>(type: "integer", nullable: false),
                    shops_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_shop", x => new { x.books_id, x.shops_id });
                    table.ForeignKey(
                        name: "fk_book_shop_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_shop_shops_shops_id",
                        column: x => x.shops_id,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    goods = table.Column<string>(type: "text", nullable: false),
                    cost = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "book_order",
                columns: table => new
                {
                    books_id = table.Column<int>(type: "integer", nullable: false),
                    orders_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_order", x => new { x.books_id, x.orders_id });
                    table.ForeignKey(
                        name: "fk_book_order_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_order_orders_orders_id",
                        column: x => x.orders_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_shop",
                columns: table => new
                {
                    orders_id = table.Column<int>(type: "integer", nullable: false),
                    shops_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_shop", x => new { x.orders_id, x.shops_id });
                    table.ForeignKey(
                        name: "fk_order_shop_orders_orders_id",
                        column: x => x.orders_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_shop_shops_shops_id",
                        column: x => x.shops_id,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_user",
                columns: table => new
                {
                    orders_id = table.Column<int>(type: "integer", nullable: false),
                    users_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_user", x => new { x.orders_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_order_user_orders_orders_id",
                        column: x => x.orders_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_user_users_users_id",
                        column: x => x.users_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_book_order_orders_id",
                table: "book_order",
                column: "orders_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_shop_shops_id",
                table: "book_shop",
                column: "shops_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_shop_shops_id",
                table: "order_shop",
                column: "shops_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_user_users_id",
                table: "order_user",
                column: "users_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_order");

            migrationBuilder.DropTable(
                name: "book_shop");

            migrationBuilder.DropTable(
                name: "order_shop");

            migrationBuilder.DropTable(
                name: "order_user");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropColumn(
                name: "location",
                table: "shops");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "books",
                newName: "author");

            migrationBuilder.AddColumn<int>(
                name: "cost2display",
                table: "shops",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "genre",
                table: "authors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "author_shop",
                columns: table => new
                {
                    authors_id = table.Column<int>(type: "integer", nullable: false),
                    shops_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_author_shop", x => new { x.authors_id, x.shops_id });
                    table.ForeignKey(
                        name: "fk_author_shop_authors_authors_id",
                        column: x => x.authors_id,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_author_shop_shops_shops_id",
                        column: x => x.shops_id,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_author_shop_shops_id",
                table: "author_shop",
                column: "shops_id");
        }
    }
}

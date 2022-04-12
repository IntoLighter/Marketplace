using Domain.Marketplace;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Data.Migrations
{
    public partial class AddShopDomains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUri = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUri = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductInDish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    DishId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInDish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInDish_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInDish_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInDish_DishId",
                table: "ProductInDish",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInDish_ProductId",
                table: "ProductInDish",
                column: "ProductId");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "ImageUri", "Weight" },
                values: new object[,]
                {

                    {
                        "Творог рассыпчатый Правильный Творог 12%",
                        "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-86/639/649/784/145/5/100029005055b0.jpg",
                        400
                    },
                    {
                        "Яйцо куриное Окское отборное С0, 10 шт",
                        "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-58/158/760/010/131/625/100027306359b0.jpg",
                        200
                    },
                    {
                        "Мед Пчелиная аптека с шиповником",
                        "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-17/133/294/212/191/710/100030681008b0.jpg",
                        250
                    },
                    {"Бананы", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/108/037/391/812/519/7/100028181159b0.jpg", 1000},
                    {"Мука пшеничная Саша+Маша в/с хлебопекарная", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/168771979/100024893470b0.jpg", 2000},
                    {"Ванилин 1000гр пакет SpicExpert", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/12/75/82/13/94/11/20/600002472227b0.png", 1000},
                    {"Масло растительное Almador Extra virgin смесь подсолнечного и оливковое 0,79 л", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/369/106/105/315/195/0/100028177601b0.jpg", 790},
                    {"Кокосовые сливки Real Thai 95% мякоти жирность 20-22% ж/б  400 мл", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/16934851023/600000614476b0.jpeg", 400},
                    {"Молоко домик в деревне деревенское отборное пастер цельное 3.5-4.5% питьевое 930 мл", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/212/974/522/652/111/1/100026605246b0.jpg", 930},
                    {"Клубника Турция", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/152/369/750/310/149/100030785929b0.jpg", 350},
                    {" Сахар Rioba свекловичный белый песок 900 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-91/861/155/311/114/18/100030147290b0.jpg", 900},
                    {"Крахмал кукурузный Гарнец высший сорт 400 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1633903/100023383356b0.jpg", 400},
                    {"Мясо кальмара Сухогруз сушено-вяленое филе 50 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/14/42/88/41/43/52/5/100026647315b0.jpg", 50},
                    {"Горошек зеленый Bizim Tarla консервированный 325 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-92/610/381/119/123/6/100030281268b0.jpg", 325},
                    {"Крабовые палочки Vici из сурими замороженные 500 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/328/406/139/108/191/100029485998b0.jpg", 500},
                    {"Огурец гладкий Зеленый стандарт 600 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/185/081/638/108/184/1/100029480938b0.jpg", 600},
                    {"Лук зеленый Зеленый Сад 100 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/184/245/568/108/184/0/100029480866b0.jpg",100 },
                    {"Майонез Лента на перепелиных яйцах 67%", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/197/724/401/571/216/49/100028804800b0.jpg", 200}
                });
            
            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new string[] { "Name", "ImageUri", "Weight", "Category" },
                values: new object[,] { {"Запеканка из творогов и бананов", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/101/763/673/110/121/77/100029362732b0.jpg", 200, Convert.ToInt32(DishCategory.Dessert)},
                                        {"Клубничное мороженое", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-15/631/216/225/175/6/100024893640b1.jpg", 70, Convert.ToInt32(DishCategory.Dessert)},
                                        {"Салат из кальмаров и крабовых палочек", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/101/939/728/393/015/12/100029362905b0.jpg", 170, Convert.ToInt32(DishCategory.Dessert)}}
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInDish");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

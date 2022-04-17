using Domain.Marketplace;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    {"Сахар Rioba свекловичный белый песок 900 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-91/861/155/311/114/18/100030147290b0.jpg", 900},
                    {"Крахмал кукурузный Гарнец высший сорт 400 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1633903/100023383356b0.jpg", 400},
                    {"Мясо кальмара Сухогруз сушено-вяленое филе 50 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/14/42/88/41/43/52/5/100026647315b0.jpg", 50},
                    {"Горошек зеленый Bizim Tarla консервированный 325 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-92/610/381/119/123/6/100030281268b0.jpg", 325},
                    {"Крабовые палочки Vici из сурими замороженные 500 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/328/406/139/108/191/100029485998b0.jpg", 500},
                    {"Огурец гладкий Зеленый стандарт 600 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/185/081/638/108/184/1/100029480938b0.jpg", 600},
                    {"Лук зеленый Зеленый Сад 100 г", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/184/245/568/108/184/0/100029480866b0.jpg",100 },
                    {"Майонез Лента на перепелиных яйцах 67%", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/197/724/401/571/216/49/100028804800b0.jpg", 200},
                    {"Дрожжи сухие активные  Coobra Basic T48", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-51/257/644/931/021/56/600003716396b0.jpeg", 120},
                    {"Масло шиповника нерафинированное Масляный Король постные продукты", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1726159/100023423689b0.jpg", 250},
                    {"Масло сливочное Тысяча Озёр 82,5 %", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/213/248/888/161/820/30/100026605539b0.jpg", 180},
                    {"Разрыхлитель Магнит для теста", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/136/302/267/212/817/56/100029996365b0.jpg", 10},
                    {"Майонез Лента на перепелиных яйцах 67%", "", 200},
                    {"Майонез Лента на перепелиных яйцах 67%", "", 200},
                    {"Майонез Лента на перепелиных яйцах 67%", "", 200},
                    {"Майонез Лента на перепелиных яйцах 67%", "", 200},
                    {"Майонез Лента на перепелиных яйцах 67%", "", 200},
                    {"Майонез Лента на перепелиных яйцах 67%", "", 200},
                    {"Майонез Лента на перепелиных яйцах 67%", "", 200},
                    {"Майонез Лента на перепелиных яйцах 67%", "", 200},
                    {"Майонез Лента на перепелиных яйцах 67%", "", 200},
                    {"Майонез Лента на перепелиных яйцах 67%", "", 200},
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

        }
    }
}

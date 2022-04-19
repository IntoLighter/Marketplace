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
                    {"Творог рассыпчатый Правильный Творог 12%", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-86/639/649/784/145/5/100029005055b0.jpg", 400},
                    {"Яйцо куриное Лето С1 10 шт", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/116/822/757/732/315/25/100028184399b0.jpg", 600},
                    {"Мед Пчелиная аптека с золотым корнем", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-17/382/039/452/191/657/100030680429b0.jpg", 250},
                    {"Бананы ,  1кг", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/108/037/391/812/519/7/100028181159b0.jpg", 1000},
                    {"Мука Экстра пшеничная высший сорт", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1577204414/100023890139b0.jpg", 2000},
                    {"Ванилин 1000гр пакет SpicExpert", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/12/75/82/13/94/11/20/600002472227b0.png", 1000},
                    {"Сахарная пудра Haas классическая", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1483987414/100024355105b0.jpg", 80},
                    {"Масло Растительное «Афродита», 250 мл, Дом кедра", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-86/697/878/123/018/4/100030155430b0.png", 250},
                    {"Сливки Haas взбитые, со вкусом клубники 45 мл", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/324/562/139/108/185/8/100029485547b0.jpg", 45},
                    {"Молоко домик в деревне деревенское отборное пастер цельное 3.5-4.5% питьевое 930 мл", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/212/974/522/652/111/1/100026605246b0.jpg", 930},
                    {"Клубника Турция", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/152/369/750/310/149/100030785929b0.jpg", 1000},
                    {"Сахар Невский тростниковый в стиках", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/101/564/148/291/718/35/100029317494b0.jpg", 5},
                    {"Крахмал кукурузный Гарнец высший сорт", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1633903/100023383356b0.jpg", 400},
                    {"Мясо кальмара Сухогруз сушено-вяленое филе", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/14/42/88/41/43/52/5/100026647315b0.jpg", 50},
                    {"Горошек зеленый Sunfeel консервированный 4,25 л", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/917/994/606/310/152/4/100030791135b0.jpg", 4250},
                    {"Крабовые палочки Русское море снежный краб охлажденные", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/21/32/89/94/41/51/9/100026650661b0.jpg", 200},
                    {"Огурцы гладкие", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/425/478/365/323/152/4/100028179519b0.jpg", 300},
                    {"Лук зеленый Зеленый Сад", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/184/245/568/108/184/0/100029480866b0.jpg", 100},
                    {"Соль поваренная пищевая Соль Руси экстра выварочная йодированная", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1724237/100023389687b0.jpg", 500},
                    {"Перец белый молотый 1000гр пакет SpicExpert", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/211/207/633/791/616/5/600002354427b0.jpeg", 1000},
                    {"Майонез Лента на перепелиных яйцах 67%", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/197/724/401/571/216/49/100028804800b0.jpg", 460},
                    {"Оливки Liberitas фаршированные тунцом", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/13/18/37/66/20/46/600001290590b0.jpeg", 240},
                    {"Лимонный сок - заправка GALAXY 250 мл", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/194/073/769/731/175/8/600005817585b0.jpeg", 250},
                    {"Петрушка свежая Globus", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/184/991/304/108/184/0/100029480907b0.jpg", 100}
                    
                });
            
            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new string[] { "Name", "ImageUri", "Weight", "Category" },
                values: new object[,]
                { 
                    {"Запеканка из творога и бананов", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/101/763/673/110/121/77/100029362732b0.jpg", 200, Convert.ToInt32(DishCategory.Dessert)},
                    {"Клубничное мороженое", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/185/927/261/671/216/21/100028800481b0.jpg", 500, Convert.ToInt32(DishCategory.Dessert)},
                    {"Салат из кальмаров и крабовых палочек", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/101/939/728/393/015/12/100029362905b0.jpg", 170, Convert.ToInt32(DishCategory.Salad)},
                    {"Салат из тунца и огурцов", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/304/093/484/415/950/100028418961b0.jpg", 160, Convert.ToInt32(DishCategory.Salad)}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

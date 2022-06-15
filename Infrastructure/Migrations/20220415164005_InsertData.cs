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
                    {"Яйцо куриное деревенское Кукареку СО 10 шт", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-16/761/521/752/191/755/100030682986b0.jpg", 660},
                    {"Мед Пчелиная аптека с шиповником", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-17/133/294/212/191/710/100030681008b0.jpg", 250},
                    {"Бананы", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/108/037/391/812/519/7/100028181159b0.jpg", 1000},
                    {"Мука  пшеничная Makfa высший сорт", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-1/05/47/41/48/96/23/100023361373b0.jpg", 2000},
                    {"Ванилин Каждый день", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/148/769/571/612/282/212/100030123370b0.jpg", 10},
                    {"Сахарная пудра Haas классическая", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/1483987414/100024355105b0.jpg", 80},
                    {"Масло Благо подсолнечное рафинированное высший сорт", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-52/355/569/312/221/236/100027308408b0.jpg", 1000},
                    {"Сливки Брянский молочный комбинат 20% бзмж", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/131/113/404/351/217/43/100028189318b0.jpg", 500},
                    {"Молоко простоквашино пастер бзмж жир. 2.5 % юнимилк", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/21/34/24/17/45/51/5/100026605704b0.jpg", 930},
                    {"Клубника", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/168/382/011/248/163/100031277777b0.jpg", 200},
                    {"Сахар Невский тростниковый в стиках", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/101/564/148/291/718/35/100029317494b0.jpg", 5},
                    {"Крахмал кукурузный Гарнец высший сорт", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1633903/100023383356b0.jpg", 400},
                    {"Дрожжи Люкс экстра хлебопекарные прессованные", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/1540686414/100024355122b0.jpg", 100},
                    {"Масло сливочное Простоквашино 82 %", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/21/36/14/45/25/51/5/100026605920b0.jpg", 180},
                    {"Масло шиповника нерафинированное Масляный Король постные продукты", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1726159/100023423689b0.jpg", 250},
                    {"Разрыхлитель теста Dr.Oetker", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1601229/100023383343b0.jpg", 10},
                    {"Морковь", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-63/786/730/911/211/437/100029842236b0.jpg", 500},
                    {"Ванильный сахар Dr.Oetker с натуральной ванилью", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1484948/100023383406b0.jpg", 15},
                    {"Изюм Ваш выбор", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/1601229414/100024369343b0.jpg", 200},
                    {"Фундук очищенный сырой", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/-53/636/770/997/201/600004529498b0.jpeg", 500},
                    {"Соль поваренная пищевая Соль Руси экстра выварочная йодированная", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1724237/100023389687b0.jpg", 500},
                    {"Шоколад Коммунарка горький десертный 85 % какао", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/-56/919/253/010/251/943/100029556275b0.jpg", 85},
                    {"Вода питьевая Bonaqua негазированная пластик", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/187/978/657/351/619/14/100023689006b0.png", 500},
                    //24
                    {"Кальмар командорский филе б/кожи бореалис", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/13/61/02/57/61/12/100027310594b0.jpg", 500},
                    {"Горошек Брилево зеленый консервированный высший сорт", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/1694446429/100023889477b0.jpg", 480},
                    {"Крабовые палочки АШАН Красная птица Снежного краба", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/985/973/490/917/183/100029316358b0.jpg", 200},
                    {"Огурцы среднеплодные пупырчатые", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/170/354/546/391/719/13/100029320554b0.jpg", 300},
                    {"Лук зеленый Зеленый Сад", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/484/970/223/111/012/1/100029698165b0.jpg", 100},
                    {"Перец Моя цена черный молотый", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/-15/626/177/132/281/122/100030686867b0.png", 20},
                    {"Майонез Лента Провансаль 67%", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/197/659/630/271/216/49/100028804798b1.jpg", 460},
                    {"Филе куриное без кожи Куриное Царство охлажденное", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-65/997/799/711/211/439/100029841950b0.jpeg", 900},
                    {"Кукуруза Bonduelle молодая консервированная", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/1752106/100023621395b0.jpg", 340},
                    {"Фасоль красная Bioitalia", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1576243/100023660738b0.jpg", 400},
                    {"Лук репчатый красный 3 шт", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/194/778/263/871/216/42/100028803732b0.jpg", 270},
                    {"Перец Чили Artfruit красный", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-13/671/185/181/027/105/0/100029549671b0.jpg", 50},
                    {"Помидоры", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/104/035/722/451/111/51/100028504493b0.jpg", 300},
                    {"Петрушка Лето", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/991/717/283/104/134/2/100029280658b0.jpg", 50},
                    {"Лайм , Россия", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/184/565/141/691/718/32/100029325417b0.jpg", 100},
                    {"Оливковое масло Spainolli Pure", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/-16/828/599/552/191/738/100030682201b0.jpeg", 250},
                    {"Тортилья ВкусВилл Тортилья пшеничная паприка томат BIO", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/103/580/271/722/213/26/100029651803b0.png", 150},
                    {"Сметана Простоквашино 20% бзмж", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-14/632/270/677/118/26/100028813381b0.jpg", 300},
                    {"Укроп Свежая зелень", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/269/955/236/108/185/2/100029483807b0.jpg", 30},
                    {"Уксус СП Мирный бальзамический", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/1600268/100023424042b0.jpg", 250},
                    {"Тунец рубленый Fortuna в собственном соку", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/1599307/100023528741b0.jpg", 185},
                    {"Сок Sicilia лимона приправа", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/1514739414/100023889716b0.jpg", 115},
                    {"Какао Белый мишка  растворимое гранулированное с витамином C", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/65/97/53/51/55/14/100024355362b0.jpg", 375},
                    {"Уксус Takemura рисовый", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/166/254/644/412/017/17/100024369410b0.jpg", 215},
                    {"Лимоны Узбекистан", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/192/602/445/521/916/31/100030679335b0.jpg", 100},
                    {"Перец красный Kamis острый", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/1481104/100023389702b0.jpg", 20},
                    {"Кунжут Здороведа белый", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/1540686414/100024251822b0.jpg", 200},
                    {"Кинза ВкусВилл", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/110/158/584/710/111/928/100029365500b0.jpg", 50},
                    {"Кускус Окей", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/-14/754/398/721/071/711/100029464927b0.jpg", 500},
                    {"Мята свежая", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/449/394/851/716/152/4/100028919144b0.jpg", 100},
                    {"Томаты вяленые Cento Percento 100%", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/-12/049/110/509/221/49/600002367918b0.jpeg", 280},
                    {"Томаты консервированные с зеленью Астраханское изобилие", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/192/799/258/321/916/37/100030679577b0.jpg", 950},
                    {"Лук репчатый", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-15/848/476/869/822/46/100029253677b0.jpg", 500},
                    {"Шпинат Белая Дача", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-28/659/697/912/241/452/100030022047b0.jpg", 65},
                    {"Салат Корн", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/109/469/504/751/111/59/100028506142b0.jpg", 130},
                    {"Салат Руккола-Корн-Радиччио Metro Chef", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/107/320/773/141/510/3/100028424501b0.jpg", 125},
                    {"Сыр рассольный фета шонфельд бзмж жир. 55 % пл/стакан нак россия", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/213/245/236/331/718/16/100026605522b0.jpg", 150},
                    {"Базилик Лента", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-74/356/532/181/613/43/100029009958b0.jpg", 50},
                    //62
                    {"Шампиньоны", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/149/216/917/112/282/220/100030123825b0.jpg", 250},
                    {"Окорок свиной Слово мясника охлажденный", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/-12/962/074/071/221/133/100028990383b0.png", 1000},
                    {"Сыр твердый Стародубский Голландский ЗМЖ, 45%", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-53/513/757/310/212/048/100029557839b0.jpg", 300},
                    {"Стейк Мираторг Black Angus из мраморной говядины Минутка охлажденный", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/-4/97/58/37/07/93/0/100027309142b0.jpg", 190},
                    {"Сало Востряково Белорусское нарезка", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-11/168/520/197/121/510/100028789332b0.jpg", 100},
                    {"Чеснок Фермерский Чеснок Добрыня", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/292/234/099/108/185/3/100029484142b0.jpg", 120},
                    {"Приправа Индана Кумин зира", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/-42/423/625/571/215/30/100028792927b0.jpg", 15},
                    {"Кориандр в горшочке", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-88/677/065/881/017/19/100029004938b0.jpg", 30},
                    {"Фарш куриный Моссельпром Превосходный охлажденный", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/184/299/905/691/718/48/100029325156b0.jpg", 1000},
                    {"Хлеб белый Коломенский Нарезной", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/21/32/90/61/68/51/9/100026650668b0.jpg", 400},
                    {"Стейк говяжий Вкус Филе-миньон охлажденный", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/-10/391/585/461/251/255/100030350442b0.jpg", 300},
                    {"Сыр полутвердый Cheezzi Чеддер 45%", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/170/708/963/191/717/51/100029320903b0.jpg", 200},
                    {"Орегано Лето в лотке", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-51/097/707/210/212/051/100029558389b0.jpg", 50},
                    {"Мускатный орех Приправыч дробленый", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/95/20/71/56/65/14/100023389675b0.jpg", 10},
                    //76
                    {"Крыло куриное Межениновская птицефабрика охлажденное", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/-15/676/459/001/018/181/4/100029461274b0.jpg", 1000},
                    {"Лавровый лист свежий на ветках", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-12/127/747/751/125/112/7/100029888074b0.jpg", 167},
                    {"Картофель белый", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-63/977/681/611/211/435/100029842013b0.jpg", 500},
                    {"Семга Каждый день слабосоленая кусочки филе", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/930/592/982/917/184/1/100029314569b0.jpg", 100},
                    {"Кефир Маруся 3,5-4,5%", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-11/464/613/907/121/52/100028788215b0.jpg", 930},
                    {"Вода минеральная SanAtorio газированная пластик", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/18/80/71/00/94/51/4/100023689106b0.jpg", 1500},
                    {"Язык телячий Мираторг замороженный", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-14/066/383/443/221/420/100028157569b0.jpg", 1000},
                    {"Огурцы маринованные Кубань продукт", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/297/751/571/541/22/600003561503b0.jpeg", 680},
                    {"Айран Халалмилк 1% бзмж", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/125/666/936/831/520/3/100028187621b0.jpg", 1000},
                    {"Горчица Глобус острая классическая", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1598346/100023360740b0.jpg", 200},
                    {"Хрен Главпродукт с лимоном", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/194/141/216/971/216/38/100028803067b0.jpg", 170},
                    {"Телятина для бульона охлажденная", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/109/739/802/341/510/4/100028425061b0.jpg", 1000},
                    {"Лапша яичная Роллтон классическая", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/1717510/100023381580b0.jpg", 400},
                    {"Баклажаны", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/313/017/532/117/212/7/100029692106b0.jpg", 500},
                    {"Перец красный сладкий", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/304/306/057/112/912/36/100029935352b0.jpg", 300},
                    {"Тыква ВкусВилл очищенная", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/101/490/268/610/121/76/100029362449b0.jpg", 500},
                    {"Сыр твердый Пармезан 45% БЗМЖ", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-17/547/899/431/261/740/100030427833b0.jpg", 150},
                    {"Крем-сыр дорблю с голубой плесенью бзмж пл/ст плавит россия", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/213/266/378/311/151/940/100026605595b0.png", 80},
                    {"Мякоть мраморной говядины Праймбиф охлажденная", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/990/791/840/921/191/9/100029280556b0.jpg", 500},
                    {"Колбаса варено-копченая Бахрушинъ Сервелат ГОСТ", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-17/566/908/012/161/252/100030427619b0.jpg", 300},
                    {"Свинина копчено-вареная Микоян Крио", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/460/016/304/451/127/100031003624b0.jpg", 600},
                    {"Сосиски Дмитрогорский Продукт Молочные ГОСТ", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-52/260/334/210/118/4/100027308517b0.jpg", 450},
                    {"Огурцы соленые Кубань продукт", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/297/750/610/541/22/600003561502b0.jpeg", 680},
                    {"Томатная паста Лента оригинальная 25%", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-22/562/158/071/617/44/100028799745b0.jpg", 270},
                    {"Маслины Наш Лидер без косточек", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/-94/815/323/441/120/49/100031248999b0.jpg", 280},
                    //101
                    {"Треска замороженная филе", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/266/410/107/108/185/1/100029483457b0.jpg", 650},
                    {"Сухари панировочные для фарша Кубанская кухня цв.пл. 200г/3 шт", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-60/451/991/822/115/31/600005755507b0.jpeg", 200},
                    {"Форель стейк охлажденный", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-15/904/214/869/822/43/100029253064b0.jpg", 300},
                    {"Рис Агро-Альянс черный нешлифованный южная ночь экстра", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/-10/520/266/642/817/24/100023361657b0.png", 500},
                    {"Лосось Мурманский охлажденный филе", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-51/213/988/210/212/050/100029558208b0.jpg", 1000},
                    {"Уксус винный СП Мирный 6% натуральный", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/1665616414/100024368968b0.jpg", 250},
                    {"Йогурт бзмж натуральный жир. 3 % пл/б киржачский мз Россия", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-2/01/98/32/81/16/1/100026736927b0.jpg", 450},
                    {"Вермишель Фунчоза Takemura", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-78/527/598/811/252/31/600005127159b0.jpeg", 500},
                    {"Кальмары очищенные охлажденные", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/-51/279/912/810/212/050/100029558194b0.jpg", 1000},
                    {"Помидоры черри Новиков", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/372/086/166/315/195/1/100028177972b0.jpg", 250},
                    {"Капуста пекинская фермерская", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/234/118/585/101/515/26/100029482069b0.jpg", 880},
                    {"Корень имбиря", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/423/566/054/716/151/9/100028918454b0.jpg", 300},
                    {"Соус соевый Стебель Бамбука classic", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/1598346/100023423740b0.jpg", 280},
                    {"Соус Takemura Устричный Premium", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/324/709/172/108/185/8/100029485595b0.jpg", 270},
                    {"Соус Sen Soy рыбный", "https://main-cdn.sbermegamarket.ru/big2/hlr-system/1544530414/100024030226b0.jpg", 220},
                    {"Карп охлажденный непотрошеная", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/392/078/889/716/151/2/100028917126b0.jpg", 650},
                    {"Тесто Bontier фило замороженное", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/208/435/272/132/315/29/100028195391b0.jpg", 500},
                    {"Розмарин в боксе", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/178/472/497/791/718/52/100029323023b0.jpg", 30},
                    {"Сибас непотрошеный с головой охлажденный", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/211/825/391/831/520/7/100028196900b0.jpg", 350},
                    {"Лук порей Израиль", "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/152/333/232/310/111/8/100030785912b0.png", 400}
                    //121
                });
            
            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new string[] { "Name", "ImageUri", "Weight", "Category" },
                values: new object[,]
                {
                    {"Запеканка из творога и бананов", "https://academy.oetker.ru/upload/iblock/047/0470a421d264dc2dc1180f12f6d6b019.png", 500, Convert.ToInt32(DishCategory.Dessert)},
                    {"Клубничное мороженое", "https://prostokvashino.ru/upload/iblock/381/381020d6c61218e4e5efb1bf570e626b.jpeg", 200, Convert.ToInt32(DishCategory.Dessert)},
                    {"Булочки с сахаром", "https://static.1000.menu/img/content-v2/8a/8c/43270/bulochki-s-saxarom-iz-sdobnogo-drojjevogo-testa_1582100715_16_max.jpg", 500, Convert.ToInt32(DishCategory.Dessert)},
                    {"Морковный пирог", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQwhJc1iy35rSDabyOqFe329QJvaIfCKlJtmXRq53sodpG24PvTIpKvVRv99RoZwCWtoYQ&usqp=CAU", 500, Convert.ToInt32(DishCategory.Dessert)},
                    {"Печенье с фундуком", "https://alimero.ru/uploads/images/18/23/66/2018/08/19/79e2f1.jpg", 500, Convert.ToInt32(DishCategory.Dessert)},
                    {"Чак-чак", "https://www.maggi.ru/data/images/recept/img640x500/recept_8073_5h88.jpg", 500, Convert.ToInt32(DishCategory.Dessert)},

                    {"Салат из кальмаров и крабовых палочек", "https://static.1000.menu/img/content/37856/salat-kalmarami-i-krabovymi-palochkami-i-ogurcom_1566379520_1_max.jpg", 500, Convert.ToInt32(DishCategory.Salad)},
                    {"Мексиканский салат с запеченным куриным филе", "https://petelinka.ru/storage/images/recipe/preview/mexican-chicken-salad.jpg", 500, Convert.ToInt32(DishCategory.Salad)},
                    {"Огурцы в сметанном соусе", "https://hamov-hotov.ru/wp-content/uploads/2019/07/salat-iz-ogurcov-so-smetanoj.jpg", 250, Convert.ToInt32(DishCategory.Salad)},
                    {"Салат из тунца и огурцов", "https://img.povar.ru/main/56/76/c3/0d/salat_s_tuncom_i_ogurcom-54420.jpg", 250, Convert.ToInt32(DishCategory.Salad)},
                    {"Салат Азиатский с морковью", "https://www.maggi.ru/data/images/recept/img640x500/recept_6251_erty.jpg", 300, Convert.ToInt32(DishCategory.Salad)},
                    {"Салат с кускусом", "https://img.delo-vcusa.ru/2020/05/salat-tabule-s-kuskusom.jpg", 500, Convert.ToInt32(DishCategory.Salad)},

                    {"Паштет из куриной грудки и грибов", "https://petelinka.ru/storage/images/recipe/preview/7fd9be35630d487beba76d8a4540e786d14d7e33.jpg", 150, Convert.ToInt32(DishCategory.Meat)},
                    {"Рулет из свинины, сыра и грибов", "https://img-global.cpcdn.com/recipes/cf9d8ba60ec1be863df644b4fd9c6f6226212e8352a7850f0ea14d5063d36928/680x482cq70/miasnoi-ruliet-s-ghribami-i-syrom-%D0%BE%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D0%BE%D0%B5-%D1%84%D0%BE%D1%82%D0%BE-%D1%80%D0%B5%D1%86%D0%B5%D0%BF%D1%82%D0%B0.jpg", 150, Convert.ToInt32(DishCategory.Meat)},
                    {"Люля-кебаб из говядины на гриле", "https://img.povar.ru/main/f4/0d/cd/d3/liulya-kebab_iz_govyadini_na_shampurah-311369.jpg", 100, Convert.ToInt32(DishCategory.Meat)},
                    {"Пожарские котлеты", "https://hozoboz.com/wp-content/webpc-passthru.php?src=https://hozoboz.com/wp-content/uploads/2016/06/pozharskie-kotleti.jpg&nocache=1", 100, Convert.ToInt32(DishCategory.Meat)},
                    {"Филе миньон", "https://www.steakhome.ru/upload/iblock/9e7/9e79b1794548ae5efd1c7f2ec4606040.jpg", 50, Convert.ToInt32(DishCategory.Meat)},
                    {"Энчиладас с курицей", "https://www.gastronom.ru/binfiles/images/20160425/ba1af2fa.jpg", 250, Convert.ToInt32(DishCategory.Meat)},

                    {"Французский луковый суп", "https://www.gastronom.ru/binfiles/images/20180216/b7343f01.jpg", 250, Convert.ToInt32(DishCategory.Soup)},
                    {"Окрошка со слабосоленой семгой на кефире", "https://ampravda.ru/files/articles-2/75103/ei7rgaztybbf-640.jpg", 250, Convert.ToInt32(DishCategory.Soup)},
                    {"Окрошка на бульоне с грибами и отварным языком", "https://kulinarenok.ru/img/img_recept/23317/okroshka-s-yazykom.jpg", 500, Convert.ToInt32(DishCategory.Soup)},
                    {"Суп лагман из телятины", "https://vagonretseptov.ru/supy/lagman/lagman-iz-telyatiny/lagman-iz-telyatiny-ready0-w424h239w914h533.jpg", 350, Convert.ToInt32(DishCategory.Soup)},
                    {"Тыквенный крем-суп с голубым сыром", "https://e0.edimdoma.ru/data/recipes/0012/0650/120650-ed4_wide.jpg?1628774924", 300, Convert.ToInt32(DishCategory.Soup)},
                    {"Солянка по-домашнему", "https://kulinarissimo.com/uploads/img/full/4754bbd3b5ce0a7adc68c9e4460be84f.jpg", 500, Convert.ToInt32(DishCategory.Soup)},

                    {"Рыбная запеканка в духовке", "https://vseretsepti.ru/images/content-img/big/161014094924.jpg", 250, Convert.ToInt32(DishCategory.Fish)},
                    {"Сливочно-чесночная форель в фольге, запеченная в духовке", "https://fishingday.org/wp-content/uploads/2019/10/1-1-750x576.jpg", 300, Convert.ToInt32(DishCategory.Fish)},
                    {"Шаурма с лососем и тортильей", "https://img.povar.ru/uploads/99/9b/a9/c0/tortili_s_krasnoi_riboi-635889.JPG", 400, Convert.ToInt32(DishCategory.Fish)},
                    {"Фунчоза с тунцом", "https://img.povar.ru/uploads/12/4e/0a/10/funchoza_s_tuncom-665366.jpg", 500, Convert.ToInt32(DishCategory.Fish)},
                    {"Карп, запеченный с овощами в тесте", "https://zernograd.com/wp-content/uploads/2017/06/karp-na-podushke-iz-ovosei.jpg", 500, Convert.ToInt32(DishCategory.Fish)},
                    {"Сибас в паназиатском стиле", "https://lenta.gcdn.co/globalassets/recepty/s/---67/--.jpg?preset=medium", 300, Convert.ToInt32(DishCategory.Fish)}

                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

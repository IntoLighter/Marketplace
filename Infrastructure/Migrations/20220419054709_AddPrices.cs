using Microsoft.EntityFrameworkCore.Migrations;
using Domain.Marketplace;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Prices",
                columns: new string[] { "ProductId", "Shop", "Price" },
                values: new object[,]
                {
                    {1, Convert.ToInt32(Shop.Alley), 173},
                    {1, Convert.ToInt32(Shop.Lenta), 173},
                    {1, Convert.ToInt32(Shop.FixPrice), 108},

                    {2, Convert.ToInt32(Shop.Alley), 76},
                    {2, Convert.ToInt32(Shop.Lenta), 111},
                    {2, Convert.ToInt32(Shop.FixPrice), 140},

                    {3, Convert.ToInt32(Shop.Alley), 225},
                    {3, Convert.ToInt32(Shop.Lenta), 179},
                    {3, Convert.ToInt32(Shop.FixPrice), 188},

                    {4, Convert.ToInt32(Shop.Alley), 81},
                    {4, Convert.ToInt32(Shop.Lenta), 116},
                    {4, Convert.ToInt32(Shop.FixPrice), 64},

                    {5, Convert.ToInt32(Shop.Alley), 100},
                    {5, Convert.ToInt32(Shop.Lenta), 160},
                    {5, Convert.ToInt32(Shop.FixPrice), 228},

                    {6, Convert.ToInt32(Shop.Alley), 574},
                    {6, Convert.ToInt32(Shop.Lenta), 601},
                    {6, Convert.ToInt32(Shop.FixPrice), 784},

                    {7, Convert.ToInt32(Shop.Alley), 245},
                    {7, Convert.ToInt32(Shop.Lenta), 261},
                    {7, Convert.ToInt32(Shop.FixPrice), 310},

                    {8, Convert.ToInt32(Shop.Alley), 132},
                    {8, Convert.ToInt32(Shop.Lenta), 145},
                    {8, Convert.ToInt32(Shop.FixPrice), 196},

                    {9, Convert.ToInt32(Shop.Alley), 345},
                    {9, Convert.ToInt32(Shop.Lenta), 429},
                    {9, Convert.ToInt32(Shop.FixPrice), 224},

                    {10, Convert.ToInt32(Shop.Alley), 96},
                    {10, Convert.ToInt32(Shop.Lenta), 71},
                    {10, Convert.ToInt32(Shop.FixPrice), 78},

                    {11, Convert.ToInt32(Shop.Alley), 80},
                    {11, Convert.ToInt32(Shop.Lenta), 70},
                    {11, Convert.ToInt32(Shop.FixPrice), 64},

                    {12, Convert.ToInt32(Shop.Alley), 2},
                    {12, Convert.ToInt32(Shop.Lenta), 2},
                    {12, Convert.ToInt32(Shop.FixPrice), 1},

                    {13, Convert.ToInt32(Shop.Alley), 61},
                    {13, Convert.ToInt32(Shop.Lenta), 98},
                    {13, Convert.ToInt32(Shop.FixPrice), 118},

                    {14, Convert.ToInt32(Shop.Alley), 505},
                    {14, Convert.ToInt32(Shop.Lenta), 446},
                    {14, Convert.ToInt32(Shop.FixPrice), 658},

                    {15, Convert.ToInt32(Shop.Alley), 157},
                    {15, Convert.ToInt32(Shop.Lenta), 199},
                    {15, Convert.ToInt32(Shop.FixPrice), 105},

                    {16, Convert.ToInt32(Shop.Alley), 691},
                    {16, Convert.ToInt32(Shop.Lenta), 569},
                    {16, Convert.ToInt32(Shop.FixPrice), 664},

                    {17, Convert.ToInt32(Shop.Alley), 11},
                    {17, Convert.ToInt32(Shop.Lenta), 9},
                    {17, Convert.ToInt32(Shop.FixPrice), 8},

                    {18, Convert.ToInt32(Shop.Alley), 26},
                    {18, Convert.ToInt32(Shop.Lenta), 28},
                    {18, Convert.ToInt32(Shop.FixPrice), 20},

                    {19, Convert.ToInt32(Shop.Alley), 45},
                    {19, Convert.ToInt32(Shop.Lenta), 38},
                    {19, Convert.ToInt32(Shop.FixPrice), 37},

                    {20, Convert.ToInt32(Shop.Alley), 692},
                    {20, Convert.ToInt32(Shop.Lenta), 792},
                    {20, Convert.ToInt32(Shop.FixPrice), 544},

                    {21, Convert.ToInt32(Shop.Alley), 300},
                    {21, Convert.ToInt32(Shop.Lenta), 464},
                    {21, Convert.ToInt32(Shop.FixPrice), 341},

                    {22, Convert.ToInt32(Shop.Alley), 50},
                    {22, Convert.ToInt32(Shop.Lenta), 48},
                    {22, Convert.ToInt32(Shop.FixPrice), 61},

                    {23, Convert.ToInt32(Shop.Alley), 143},
                    {23, Convert.ToInt32(Shop.Lenta), 250},
                    {23, Convert.ToInt32(Shop.FixPrice), 244},

                    {24, Convert.ToInt32(Shop.Alley), 300},
                    {24, Convert.ToInt32(Shop.Lenta), 269},
                    {24, Convert.ToInt32(Shop.FixPrice), 317},
                    //DessertEnd
                    {25, Convert.ToInt32(Shop.Alley), 153},
                    {25, Convert.ToInt32(Shop.Lenta), 140},
                    {25, Convert.ToInt32(Shop.FixPrice), 119},

                    {26, Convert.ToInt32(Shop.Alley), 808},
                    {26, Convert.ToInt32(Shop.Lenta), 757},
                    {26, Convert.ToInt32(Shop.FixPrice), 1003},

                    {27, Convert.ToInt32(Shop.Alley), 132},
                    {27, Convert.ToInt32(Shop.Lenta), 150},
                    {27, Convert.ToInt32(Shop.FixPrice), 121},

                    {28, Convert.ToInt32(Shop.Alley), 50},
                    {28, Convert.ToInt32(Shop.Lenta), 45},
                    {28, Convert.ToInt32(Shop.FixPrice), 44},

                    {29, Convert.ToInt32(Shop.Alley), 91},
                    {29, Convert.ToInt32(Shop.Lenta), 69},
                    {29, Convert.ToInt32(Shop.FixPrice), 56},

                    {30, Convert.ToInt32(Shop.Alley), 332},
                    {30, Convert.ToInt32(Shop.Lenta), 332},
                    {30, Convert.ToInt32(Shop.FixPrice), 478},

                    {31, Convert.ToInt32(Shop.Alley), 107},
                    {31, Convert.ToInt32(Shop.Lenta), 95},
                    {31, Convert.ToInt32(Shop.FixPrice), 120},

                    {32, Convert.ToInt32(Shop.Alley), 396},
                    {32, Convert.ToInt32(Shop.Lenta), 353},
                    {32, Convert.ToInt32(Shop.FixPrice), 230},

                    {33, Convert.ToInt32(Shop.Alley), 387},
                    {33, Convert.ToInt32(Shop.Lenta), 485},
                    {33, Convert.ToInt32(Shop.FixPrice), 531},

                    {34, Convert.ToInt32(Shop.Alley), 178},
                    {34, Convert.ToInt32(Shop.Lenta), 176},
                    {34, Convert.ToInt32(Shop.FixPrice), 195},

                    {35, Convert.ToInt32(Shop.Alley), 69},
                    {35, Convert.ToInt32(Shop.Lenta), 73},
                    {35, Convert.ToInt32(Shop.FixPrice), 65},

                    {36, Convert.ToInt32(Shop.Alley), 255},
                    {36, Convert.ToInt32(Shop.Lenta), 225},
                    {36, Convert.ToInt32(Shop.FixPrice), 195},

                    {37, Convert.ToInt32(Shop.Alley), 24},
                    {37, Convert.ToInt32(Shop.Lenta), 42},
                    {37, Convert.ToInt32(Shop.FixPrice), 25},

                    {38, Convert.ToInt32(Shop.Alley), 31},
                    {38, Convert.ToInt32(Shop.Lenta), 45},
                    {38, Convert.ToInt32(Shop.FixPrice), 48},

                    {39, Convert.ToInt32(Shop.Alley), 77},
                    {39, Convert.ToInt32(Shop.Lenta), 80},
                    {39, Convert.ToInt32(Shop.FixPrice), 42},

                    {40, Convert.ToInt32(Shop.Alley), 577},
                    {40, Convert.ToInt32(Shop.Lenta), 615},
                    {40, Convert.ToInt32(Shop.FixPrice), 750},

                    {41, Convert.ToInt32(Shop.Alley), 69},
                    {41, Convert.ToInt32(Shop.Lenta), 65},
                    {41, Convert.ToInt32(Shop.FixPrice), 90},

                    {42, Convert.ToInt32(Shop.Alley), 129},
                    {42, Convert.ToInt32(Shop.Lenta), 99},
                    {42, Convert.ToInt32(Shop.FixPrice), 135},

                    {43, Convert.ToInt32(Shop.Alley), 35},
                    {43, Convert.ToInt32(Shop.Lenta), 33},
                    {43, Convert.ToInt32(Shop.FixPrice), 20},

                    {44, Convert.ToInt32(Shop.Alley), 997},
                    {44, Convert.ToInt32(Shop.Lenta), 675},
                    {44, Convert.ToInt32(Shop.FixPrice), 572},

                    {45, Convert.ToInt32(Shop.Alley), 396},
                    {45, Convert.ToInt32(Shop.Lenta), 360},
                    {45, Convert.ToInt32(Shop.FixPrice), 264},

                    {46, Convert.ToInt32(Shop.Alley), 192},
                    {46, Convert.ToInt32(Shop.Lenta), 233},
                    {46, Convert.ToInt32(Shop.FixPrice), 337},

                    {47, Convert.ToInt32(Shop.Alley), 139},
                    {47, Convert.ToInt32(Shop.Lenta), 100},
                    {47, Convert.ToInt32(Shop.FixPrice), 124},

                    {48, Convert.ToInt32(Shop.Alley), 551},
                    {48, Convert.ToInt32(Shop.Lenta), 623},
                    {48, Convert.ToInt32(Shop.FixPrice), 928},

                    {49, Convert.ToInt32(Shop.Alley), 47},
                    {49, Convert.ToInt32(Shop.Lenta), 37},
                    {49, Convert.ToInt32(Shop.FixPrice), 29},

                    {50, Convert.ToInt32(Shop.Alley), 545},
                    {50, Convert.ToInt32(Shop.Lenta), 518},
                    {50, Convert.ToInt32(Shop.FixPrice), 725},

                    {51, Convert.ToInt32(Shop.Alley), 248},
                    {51, Convert.ToInt32(Shop.Lenta), 387},
                    {51, Convert.ToInt32(Shop.FixPrice), 528},

                    {52, Convert.ToInt32(Shop.Alley), 91},
                    {52, Convert.ToInt32(Shop.Lenta), 67},
                    {52, Convert.ToInt32(Shop.FixPrice), 46},

                    {53, Convert.ToInt32(Shop.Alley), 433},
                    {53, Convert.ToInt32(Shop.Lenta), 449},
                    {53, Convert.ToInt32(Shop.FixPrice), 474},

                    {54, Convert.ToInt32(Shop.Alley), 187},
                    {54, Convert.ToInt32(Shop.Lenta), 243},
                    {54, Convert.ToInt32(Shop.FixPrice), 340},

                    {55, Convert.ToInt32(Shop.Alley), 955},
                    {55, Convert.ToInt32(Shop.Lenta), 670},
                    {55, Convert.ToInt32(Shop.FixPrice), 722},

                    {56, Convert.ToInt32(Shop.Alley), 100},
                    {56, Convert.ToInt32(Shop.Lenta), 119},
                    {56, Convert.ToInt32(Shop.FixPrice), 77},

                    {57, Convert.ToInt32(Shop.Alley), 16},
                    {57, Convert.ToInt32(Shop.Lenta), 19},
                    {57, Convert.ToInt32(Shop.FixPrice), 28},

                    {58, Convert.ToInt32(Shop.Alley), 226},
                    {58, Convert.ToInt32(Shop.Lenta), 169},
                    {58, Convert.ToInt32(Shop.FixPrice), 88},

                    {59, Convert.ToInt32(Shop.Alley), 127},
                    {59, Convert.ToInt32(Shop.Lenta), 250},
                    {59, Convert.ToInt32(Shop.FixPrice), 323},

                    {60, Convert.ToInt32(Shop.Alley), 233},
                    {60, Convert.ToInt32(Shop.Lenta), 199},
                    {60, Convert.ToInt32(Shop.FixPrice), 102},

                    {61, Convert.ToInt32(Shop.Alley), 193},
                    {61, Convert.ToInt32(Shop.Lenta), 138},
                    {61, Convert.ToInt32(Shop.FixPrice), 107},

                    {62, Convert.ToInt32(Shop.Alley), 189},
                    {62, Convert.ToInt32(Shop.Lenta), 169},
                    {62, Convert.ToInt32(Shop.FixPrice), 208},
                    //SaladEnd
                    {63, Convert.ToInt32(Shop.Alley), 42},
                    {63, Convert.ToInt32(Shop.Lenta), 80},
                    {63, Convert.ToInt32(Shop.FixPrice), 90},

                    {64, Convert.ToInt32(Shop.Alley), 3814},
                    {64, Convert.ToInt32(Shop.Lenta), 3509},
                    {64, Convert.ToInt32(Shop.FixPrice), 4813},

                    {65, Convert.ToInt32(Shop.Alley), 185},
                    {65, Convert.ToInt32(Shop.Lenta), 150},
                    {65, Convert.ToInt32(Shop.FixPrice), 185},

                    {66, Convert.ToInt32(Shop.Alley), 1454},
                    {66, Convert.ToInt32(Shop.Lenta), 2089},
                    {66, Convert.ToInt32(Shop.FixPrice), 2709},

                    {67, Convert.ToInt32(Shop.Alley), 147},
                    {67, Convert.ToInt32(Shop.Lenta), 100},
                    {67, Convert.ToInt32(Shop.FixPrice), 93},

                    {68, Convert.ToInt32(Shop.Alley), 87},
                    {68, Convert.ToInt32(Shop.Lenta), 117},
                    {68, Convert.ToInt32(Shop.FixPrice), 138},

                    {69, Convert.ToInt32(Shop.Alley), 475},
                    {69, Convert.ToInt32(Shop.Lenta), 366},
                    {69, Convert.ToInt32(Shop.FixPrice), 282},

                    {70, Convert.ToInt32(Shop.Alley), 123},
                    {70, Convert.ToInt32(Shop.Lenta), 99},
                    {70, Convert.ToInt32(Shop.FixPrice), 71},

                    {71, Convert.ToInt32(Shop.Alley), 149},
                    {71, Convert.ToInt32(Shop.Lenta), 250},
                    {71, Convert.ToInt32(Shop.FixPrice), 342},

                    {72, Convert.ToInt32(Shop.Alley), 59},
                    {72, Convert.ToInt32(Shop.Lenta), 49},
                    {72, Convert.ToInt32(Shop.FixPrice), 51},

                    {73, Convert.ToInt32(Shop.Alley), 839},
                    {73, Convert.ToInt32(Shop.Lenta), 819},
                    {73, Convert.ToInt32(Shop.FixPrice), 693},

                    {74, Convert.ToInt32(Shop.Alley), 85},
                    {74, Convert.ToInt32(Shop.Lenta), 160},
                    {74, Convert.ToInt32(Shop.FixPrice), 137},

                    {75, Convert.ToInt32(Shop.Alley), 105},
                    {75, Convert.ToInt32(Shop.Lenta), 139},
                    {75, Convert.ToInt32(Shop.FixPrice), 92},

                    {76, Convert.ToInt32(Shop.Alley), 25},
                    {76, Convert.ToInt32(Shop.Lenta), 26},
                    {76, Convert.ToInt32(Shop.FixPrice), 20},
                    //MeatEnd
                    {77, Convert.ToInt32(Shop.Alley), 897},
                    {77, Convert.ToInt32(Shop.Lenta), 1186},
                    {77, Convert.ToInt32(Shop.FixPrice), 1678},

                    {78, Convert.ToInt32(Shop.Alley), 143},
                    {78, Convert.ToInt32(Shop.Lenta), 110},
                    {78, Convert.ToInt32(Shop.FixPrice), 162},

                    {79, Convert.ToInt32(Shop.Alley), 21},
                    {79, Convert.ToInt32(Shop.Lenta), 20},
                    {79, Convert.ToInt32(Shop.FixPrice), 22},

                    {80, Convert.ToInt32(Shop.Alley), 326},
                    {80, Convert.ToInt32(Shop.Lenta), 250},
                    {80, Convert.ToInt32(Shop.FixPrice), 361},

                    {81, Convert.ToInt32(Shop.Alley), 52},
                    {81, Convert.ToInt32(Shop.Lenta), 93},
                    {81, Convert.ToInt32(Shop.FixPrice), 130},

                    {82, Convert.ToInt32(Shop.Alley), 148},
                    {82, Convert.ToInt32(Shop.Lenta), 100},
                    {82, Convert.ToInt32(Shop.FixPrice), 141},

                    {83, Convert.ToInt32(Shop.Alley), 1351},
                    {83, Convert.ToInt32(Shop.Lenta), 1919},
                    {83, Convert.ToInt32(Shop.FixPrice), 2523},

                    {84, Convert.ToInt32(Shop.Alley), 158},
                    {84, Convert.ToInt32(Shop.Lenta), 122},
                    {84, Convert.ToInt32(Shop.FixPrice), 76},

                    {85, Convert.ToInt32(Shop.Alley), 89},
                    {85, Convert.ToInt32(Shop.Lenta), 90},
                    {85, Convert.ToInt32(Shop.FixPrice), 77},

                    {86, Convert.ToInt32(Shop.Alley), 90},
                    {86, Convert.ToInt32(Shop.Lenta), 76},
                    {86, Convert.ToInt32(Shop.FixPrice), 89},

                    {87, Convert.ToInt32(Shop.Alley), 37},
                    {87, Convert.ToInt32(Shop.Lenta), 50},
                    {87, Convert.ToInt32(Shop.FixPrice), 46},

                    {88, Convert.ToInt32(Shop.Alley), 564},
                    {88, Convert.ToInt32(Shop.Lenta), 779},
                    {88, Convert.ToInt32(Shop.FixPrice), 819},

                    {89, Convert.ToInt32(Shop.Alley), 109},
                    {89, Convert.ToInt32(Shop.Lenta), 88},
                    {89, Convert.ToInt32(Shop.FixPrice), 105},

                    {90, Convert.ToInt32(Shop.Alley), 201},
                    {90, Convert.ToInt32(Shop.Lenta), 203},
                    {90, Convert.ToInt32(Shop.FixPrice), 268},

                    {91, Convert.ToInt32(Shop.Alley), 141},
                    {91, Convert.ToInt32(Shop.Lenta), 114},
                    {91, Convert.ToInt32(Shop.FixPrice), 113},

                    {92, Convert.ToInt32(Shop.Alley), 60},
                    {92, Convert.ToInt32(Shop.Lenta), 96},
                    {92, Convert.ToInt32(Shop.FixPrice), 109},

                    {93, Convert.ToInt32(Shop.Alley), 342},
                    {93, Convert.ToInt32(Shop.Lenta), 264},
                    {93, Convert.ToInt32(Shop.FixPrice), 344},

                    {94, Convert.ToInt32(Shop.Alley), 153},
                    {94, Convert.ToInt32(Shop.Lenta), 157},
                    {94, Convert.ToInt32(Shop.FixPrice), 157},

                    {95, Convert.ToInt32(Shop.Alley), 254},
                    {95, Convert.ToInt32(Shop.Lenta), 389},
                    {95, Convert.ToInt32(Shop.FixPrice), 381},

                    {96, Convert.ToInt32(Shop.Alley), 420},
                    {96, Convert.ToInt32(Shop.Lenta), 336},
                    {96, Convert.ToInt32(Shop.FixPrice), 409},

                    {97, Convert.ToInt32(Shop.Alley), 234},
                    {97, Convert.ToInt32(Shop.Lenta), 300},
                    {97, Convert.ToInt32(Shop.FixPrice), 287},

                    {98, Convert.ToInt32(Shop.Alley), 197},
                    {98, Convert.ToInt32(Shop.Lenta), 303},
                    {98, Convert.ToInt32(Shop.FixPrice), 189},

                    {99, Convert.ToInt32(Shop.Alley), 77},
                    {99, Convert.ToInt32(Shop.Lenta), 106},
                    {99, Convert.ToInt32(Shop.FixPrice), 155},

                    {100, Convert.ToInt32(Shop.Alley), 118},
                    {100, Convert.ToInt32(Shop.Lenta), 85},
                    {100, Convert.ToInt32(Shop.FixPrice), 60},

                    {101, Convert.ToInt32(Shop.Alley), 455},
                    {101, Convert.ToInt32(Shop.Lenta), 700},
                    {101, Convert.ToInt32(Shop.FixPrice), 678},
                    //SoupEnd
                    {102, Convert.ToInt32(Shop.Alley), 627},
                    {102, Convert.ToInt32(Shop.Lenta), 468},
                    {102, Convert.ToInt32(Shop.FixPrice), 238},

                    {103, Convert.ToInt32(Shop.Alley), 138},
                    {103, Convert.ToInt32(Shop.Lenta), 210},
                    {103, Convert.ToInt32(Shop.FixPrice), 182},

                    {104, Convert.ToInt32(Shop.Alley), 495},
                    {104, Convert.ToInt32(Shop.Lenta), 420},
                    {104, Convert.ToInt32(Shop.FixPrice), 414},

                    {105, Convert.ToInt32(Shop.Alley), 305},
                    {105, Convert.ToInt32(Shop.Lenta), 599},
                    {105, Convert.ToInt32(Shop.FixPrice), 432},

                    {106, Convert.ToInt32(Shop.Alley), 2088},
                    {106, Convert.ToInt32(Shop.Lenta), 1999},
                    {106, Convert.ToInt32(Shop.FixPrice), 1619},

                    {107, Convert.ToInt32(Shop.Alley), 711},
                    {107, Convert.ToInt32(Shop.Lenta), 504},
                    {107, Convert.ToInt32(Shop.FixPrice), 699},

                    {108, Convert.ToInt32(Shop.Alley), 78},
                    {108, Convert.ToInt32(Shop.Lenta), 91},
                    {108, Convert.ToInt32(Shop.FixPrice), 54},

                    {109, Convert.ToInt32(Shop.Alley), 362},
                    {109, Convert.ToInt32(Shop.Lenta), 299},
                    {109, Convert.ToInt32(Shop.FixPrice), 385},

                    {110, Convert.ToInt32(Shop.Alley), 505},
                    {110, Convert.ToInt32(Shop.Lenta), 420},
                    {110, Convert.ToInt32(Shop.FixPrice), 556},

                    {111, Convert.ToInt32(Shop.Alley), 147},
                    {111, Convert.ToInt32(Shop.Lenta), 120},
                    {111, Convert.ToInt32(Shop.FixPrice), 118},

                    {112, Convert.ToInt32(Shop.Alley), 391},
                    {112, Convert.ToInt32(Shop.Lenta), 278},
                    {112, Convert.ToInt32(Shop.FixPrice), 187},

                    {113, Convert.ToInt32(Shop.Alley), 141},
                    {113, Convert.ToInt32(Shop.Lenta), 124},
                    {113, Convert.ToInt32(Shop.FixPrice), 130},

                    {114, Convert.ToInt32(Shop.Alley), 166},
                    {114, Convert.ToInt32(Shop.Lenta), 329},
                    {114, Convert.ToInt32(Shop.FixPrice), 189},

                    {115, Convert.ToInt32(Shop.Alley), 1011},
                    {115, Convert.ToInt32(Shop.Lenta), 991},
                    {115, Convert.ToInt32(Shop.FixPrice), 1246},

                    {116, Convert.ToInt32(Shop.Alley), 601},
                    {116, Convert.ToInt32(Shop.Lenta), 1005},
                    {116, Convert.ToInt32(Shop.FixPrice), 1004},

                    {117, Convert.ToInt32(Shop.Alley), 377},
                    {117, Convert.ToInt32(Shop.Lenta), 337},
                    {117, Convert.ToInt32(Shop.FixPrice), 343},

                    {118, Convert.ToInt32(Shop.Alley), 94},
                    {118, Convert.ToInt32(Shop.Lenta), 134},
                    {118, Convert.ToInt32(Shop.FixPrice), 171},

                    {119, Convert.ToInt32(Shop.Alley), 56},
                    {119, Convert.ToInt32(Shop.Lenta), 90},
                    {119, Convert.ToInt32(Shop.FixPrice), 131},

                    {120, Convert.ToInt32(Shop.Alley), 434},
                    {120, Convert.ToInt32(Shop.Lenta), 298},
                    {120, Convert.ToInt32(Shop.FixPrice), 243},

                    {121, Convert.ToInt32(Shop.Alley), 152},
                    {121, Convert.ToInt32(Shop.Lenta), 165},
                    {121, Convert.ToInt32(Shop.FixPrice), 155}
                    //FishEnd
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

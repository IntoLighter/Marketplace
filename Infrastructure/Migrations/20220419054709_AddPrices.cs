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
                    {1, Convert.ToInt32(Shop.Alley), 177},
                    {1, Convert.ToInt32(Shop.Lenta), 173},
                    {1, Convert.ToInt32(Shop.FixPrice), 236},
            
                    {2, Convert.ToInt32(Shop.Alley), 121},
                    {2, Convert.ToInt32(Shop.Lenta), 115},
                    {2, Convert.ToInt32(Shop.FixPrice), 171},
            
                    {3, Convert.ToInt32(Shop.Alley), 197},
                    {3, Convert.ToInt32(Shop.Lenta), 179},
                    {3, Convert.ToInt32(Shop.FixPrice), 198},
            
                    {4, Convert.ToInt32(Shop.Alley), 81},
                    {4, Convert.ToInt32(Shop.Lenta), 80},
                    {4, Convert.ToInt32(Shop.FixPrice), 51},
            
                    {5, Convert.ToInt32(Shop.Alley), 140},
                    {5, Convert.ToInt32(Shop.Lenta), 100},
                    {5, Convert.ToInt32(Shop.FixPrice), 76},
            
                    {6, Convert.ToInt32(Shop.Alley), 852},
                    {6, Convert.ToInt32(Shop.Lenta), 601},
                    {6, Convert.ToInt32(Shop.FixPrice), 677},
            
                    {7, Convert.ToInt32(Shop.Alley), 16},
                    {7, Convert.ToInt32(Shop.Lenta), 26},
                    {7, Convert.ToInt32(Shop.FixPrice), 32},
            
                    {8, Convert.ToInt32(Shop.Alley), 250},
                    {8, Convert.ToInt32(Shop.Lenta), 409},
                    {8, Convert.ToInt32(Shop.FixPrice), 483},
            
                    {9, Convert.ToInt32(Shop.Alley), 61},
                    {9, Convert.ToInt32(Shop.Lenta), 54},
                    {9, Convert.ToInt32(Shop.FixPrice), 74},
            
                    {10, Convert.ToInt32(Shop.Alley), 69},
                    {10, Convert.ToInt32(Shop.Lenta), 90},
                    {10, Convert.ToInt32(Shop.FixPrice), 115},
            
                    {11, Convert.ToInt32(Shop.Alley), 141},
                    {11, Convert.ToInt32(Shop.Lenta), 270},
                    {11, Convert.ToInt32(Shop.FixPrice), 350},
            
                    {12, Convert.ToInt32(Shop.Alley), 1},
                    {12, Convert.ToInt32(Shop.Lenta), 2},
                    {12, Convert.ToInt32(Shop.FixPrice), 1},
            
                    {13, Convert.ToInt32(Shop.Alley), 95},
                    {13, Convert.ToInt32(Shop.Lenta), 98},
                    {13, Convert.ToInt32(Shop.FixPrice), 58},
            
                    {14, Convert.ToInt32(Shop.Alley), 127},
                    {14, Convert.ToInt32(Shop.Lenta), 140},
                    {14, Convert.ToInt32(Shop.FixPrice), 76},
            
                    {15, Convert.ToInt32(Shop.Alley), 699},
                    {15, Convert.ToInt32(Shop.Lenta), 757},
                    {15, Convert.ToInt32(Shop.FixPrice), 718},
            
                    {16, Convert.ToInt32(Shop.Alley), 87},
                    {16, Convert.ToInt32(Shop.Lenta), 150},
                    {16, Convert.ToInt32(Shop.FixPrice), 98},
            
                    {17, Convert.ToInt32(Shop.Alley), 33},
                    {17, Convert.ToInt32(Shop.Lenta), 33},
                    {17, Convert.ToInt32(Shop.FixPrice), 49},
            
                    {18, Convert.ToInt32(Shop.Alley), 73},
                    {18, Convert.ToInt32(Shop.Lenta), 60},
                    {18, Convert.ToInt32(Shop.FixPrice), 56},
            
                    {19, Convert.ToInt32(Shop.Alley), 49},
                    {19, Convert.ToInt32(Shop.Lenta), 39},
                    {19, Convert.ToInt32(Shop.FixPrice), 40},
            
                    {20, Convert.ToInt32(Shop.Alley), 971},
                    {20, Convert.ToInt32(Shop.Lenta), 914},
                    {20, Convert.ToInt32(Shop.FixPrice), 594},
            
                    {21, Convert.ToInt32(Shop.Alley), 81},
                    {21, Convert.ToInt32(Shop.Lenta), 95},
                    {21, Convert.ToInt32(Shop.FixPrice), 103},
            
                    {22, Convert.ToInt32(Shop.Alley), 118},
                    {22, Convert.ToInt32(Shop.Lenta), 200},
                    {22, Convert.ToInt32(Shop.FixPrice), 170},
            
                    {23, Convert.ToInt32(Shop.Alley), 209},
                    {23, Convert.ToInt32(Shop.Lenta), 280},
                    {23, Convert.ToInt32(Shop.FixPrice), 170},
            
                    {24, Convert.ToInt32(Shop.Alley), 79},
                    {24, Convert.ToInt32(Shop.Lenta), 54},
                    {24, Convert.ToInt32(Shop.FixPrice), 38}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Domain.Marketplace;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Search.Pages
{
    public class CatalogModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<Dish> Dishes { get; set; }
        public List<Product> Products { get; set; }
        public CatalogModel(AppDbContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            Products = _context.Products.ToList();
            Dishes = _context.Dishes.ToList();
        }
    }
}

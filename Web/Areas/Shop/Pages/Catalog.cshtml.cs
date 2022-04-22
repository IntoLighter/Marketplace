using System.Collections.Generic;
using System.Linq;
using Domain.Marketplace;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Shop.Pages
{
    public class CatalogModel : PageModel
    {
        private readonly IDbContext _context;
        public List<Dish> Dishes { get; set; }
        public List<Product> Products { get; set; }
        public List<IItem> Items { get; set; }

        [BindProperty(SupportsGet = true)]       //
        public string q { get; set; }            //
        public CatalogModel(IDbContext db)
        {
            _context = db;
            Products = _context.Products.ToList();
            Dishes = _context.Dishes.ToList();
        }
        public void OnGet()
        {
            Items = Dishes.Cast<IItem>().ToList();
            Items.AddRange(Products.Cast<IItem>().ToList());
        }
        public void OnPostProducts()
        {
            Items = Products.Cast<IItem>().ToList();
        }
        public void OnPostSoups()
        {
            Items = Dishes.Where(_ => _.Category == DishCategory.Soup).Cast<IItem>().ToList();
        }
        public void OnPostMeatDishes()
        {
            Items = Dishes.Where(_ => _.Category == DishCategory.Meat).Cast<IItem>().ToList();
        }
        public void OnPostFishDishes()
        {
            Items = Dishes.Where(_ => _.Category == DishCategory.Fish).Cast<IItem>().ToList();
        }
        public void OnPostSalads()
        {
            Items = Dishes.Where(_ => _.Category == DishCategory.Salad).Cast<IItem>().ToList();
        }
        public void OnPostDesserts()
        {
            Items = Dishes.Where(_ => _.Category == DishCategory.Dessert).Cast<IItem>().ToList();
        }
    }
}

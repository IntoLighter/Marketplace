using Domain.Marketplace;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Web.Areas.Shop.Pages;

public class CatalogModel : PageModel
{
    private readonly IDbContext _context;

    public CatalogModel(IDbContext db)
    {
        _context = db;
        Products = _context.Products.ToList();
        Dishes = _context.Dishes.Include(e => e.Products).ToList();
    }

    public List<Dish> Dishes { get; set; }
    public List<Product> Products { get; set; }
    public List<IItem> Items { get; set; } = null!;

    public void OnGet()
    {
        Items = Dishes.Cast<IItem>().ToList();
        Items.AddRange(Products.Cast<IItem>().ToList());
    }

    public void OnPost(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Items = Dishes.Cast<IItem>().ToList();
            Items.AddRange(Products.Cast<IItem>().ToList());
        }
        else
        {
            Items = Dishes.Where(e => e.Name.ToLower().Contains(name.ToLower()) ||
                                      e.Category.ToString()
                                          .Contains(name)).Cast<IItem>().ToList();
            Items.AddRange(Products.Where(e => e.Name.ToLower().Contains(name.ToLower())).Cast<IItem>().ToList());
        }
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

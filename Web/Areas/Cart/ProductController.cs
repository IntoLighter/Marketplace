using System.Security.Claims;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Cart;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Web.Areas.Cart;

[Area("Cart")]
[ApiController]
[Route("Areas/[area]/[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly IDbContext _context;
    private readonly IMapper _mapper;

    public ProductController(IDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [ValidateAntiForgeryToken]
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        return Ok(await _context.CartProducts.Include(e => e.Product).Where(e => e.UserId == GetUserId())
            .ProjectTo<CartVM>(_mapper.ConfigurationProvider).ToListAsync());
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Add(CartProduct cartProduct)
    {
        cartProduct.UserId = GetUserId();
        var cartProducts = _context.CartProducts;
        var containedProduct = await cartProducts.FindAsync(
            cartProduct.Id, cartProduct.ShopName, cartProduct.UserId);

        if (containedProduct == null)
        {
            cartProducts.Add(cartProduct);
        }
        else
        {
            containedProduct.Count = cartProduct.Count;
            if (containedProduct.Count == 0)
            {
                cartProducts.Remove(containedProduct);
            }
        }

        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Add), cartProduct);
    }

    [ValidateAntiForgeryToken]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id, string shopName)
    {
        var cartProducts = _context.CartProducts;
        var containedProduct = (await cartProducts.FindAsync(id, shopName, GetUserId()))!;

        containedProduct.Count--;
        if (containedProduct.Count == 0) cartProducts.Remove(containedProduct);

        await _context.SaveChangesAsync();
        return Ok();
    }

    [ValidateAntiForgeryToken]
    [HttpDelete]
    public async Task<IActionResult> DeleteCompletely(int id, string shopName)
    {
        var products = _context.CartProducts;
        products.Remove((await products.FindAsync(id, shopName, GetUserId()))!);
        await _context.SaveChangesAsync();
        return Ok();
    }

    private string GetUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}

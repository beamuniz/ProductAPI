using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController(ApiDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
    {
        return await context.Produtos.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Produto>> GetProduto(int id)
    {
        var produto = await context.Produtos.FindAsync(id);

        if (produto == null) return NotFound();

        return produto;
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> PostProduto([FromBody] Produto produto)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        context.Produtos.Add(produto);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Produto>> PutProduto(int id, [FromBody] Produto produto)
    {
        if (produto.Id != id) return BadRequest();

        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        context.Entry(produto).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProdutoExists(id)) return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Produto>> DeleteProduto(int id)
    {
        var produto = await context.Produtos.FindAsync(id);

        if (produto == null) return NotFound();

        context.Produtos.Remove(produto);
        await context.SaveChangesAsync();
        
        return NoContent();
    }

    private bool ProdutoExists(int id)
    {
        return context.Produtos.Any(e => e.Id == id);
    }
}
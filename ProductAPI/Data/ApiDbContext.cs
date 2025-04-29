using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Produto> Produtos { get; set; }
}
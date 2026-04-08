using Microsoft.EntityFrameworkCore;
using Photography_WebAPI.Models;
using System.Collections.Generic;

namespace Photography_WebAPI.Context
{
    public class AppDbContext : DbContext
    {
        //Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Sirve para modificar y consultar los registros de la tabla
        public DbSet<PhotographersModels> Photographers { get; set; }
        public DbSet<PhotosModels> Photos { get; set; }
        public DbSet<CategoriesModels> Categories { get; set; }
        public DbSet<TypeUsersModels> TypeUsers { get; set; }
    }
}

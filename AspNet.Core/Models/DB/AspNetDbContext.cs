using System;
using System.Data.Entity;
using System.Linq;

namespace AspNet.Core.Models.DB
{
    
    public class AspNetDbContext : DbContext
    {
        // Your context has been configured to use a 'AspNetDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AspNet.Core.Models.DB.AspNetDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AspNetDbContext' 
        // connection string in the application configuration file.
        public AspNetDbContext()
            : base("name=AspNetDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Dado> Dados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Dado>()
                .HasRequired(x => x.Cliente);

        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
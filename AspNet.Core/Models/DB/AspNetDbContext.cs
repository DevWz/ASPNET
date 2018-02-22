using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public virtual DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .HasOptional(x => x.Dado) // Dado opcional para Cliente
                .WithRequired(x => x.Cliente) // Cliente obrigatorio para Dado
                .WillCascadeOnDelete(); // Se Cliente for deletado, deleta todos Dados associados

            modelBuilder.Entity<Cliente>()
                .HasOptional(x => x.Endereco) // Endereco opcional para Cliente
                .WithRequired(x => x.Cliente) // Cliente obrigatorio para Endereco
                .WillCascadeOnDelete(); // Se Cliente for deletado, deleta todos Enderecos associado

            // Será utilizado na tabela Pedidos
            /*
            modelBuilder.Entity<Fone>()
                .HasRequired<Cliente>(x => x.Cliente) // Cliente obrigatorio para Fone
                .WithMany(x => x.Fones) // Multiplos registros permitidos
                .HasForeignKey<int>(x => x.IdCliente); // FK de Fone para Cliente
            */

            modelBuilder.Entity<Cliente>()
                .ToTable("Clientes");

            modelBuilder.Entity<Dado>()
                .ToTable("Dados");

            modelBuilder.Entity<Endereco>()
                .ToTable("Enderecos");

        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
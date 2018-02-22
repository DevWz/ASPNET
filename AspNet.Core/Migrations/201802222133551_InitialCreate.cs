namespace AspNet.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dados",
                c => new
                    {
                        IdCliente = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        Fone = c.String(),
                    })
                .PrimaryKey(t => t.IdCliente)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, cascadeDelete: true)
                .Index(t => t.IdCliente);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        IdCliente = c.Int(nullable: false),
                        Logradouro = c.String(),
                        N = c.String(),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        UF = c.String(),
                        CEP = c.String(),
                    })
                .PrimaryKey(t => t.IdCliente)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, cascadeDelete: true)
                .Index(t => t.IdCliente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enderecos", "IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.Dados", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Enderecos", new[] { "IdCliente" });
            DropIndex("dbo.Dados", new[] { "IdCliente" });
            DropTable("dbo.Enderecos");
            DropTable("dbo.Dados");
            DropTable("dbo.Clientes");
        }
    }
}

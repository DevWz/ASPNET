using AspNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Debug
{
    class Program
    {
        static void Main(string[] args)
        {

            AspNet.Core.Models.DB.AspNetDbContext manager = new Core.Models.DB.AspNetDbContext();

            // OK
            /*
            Cliente cliente = new Cliente()
            {
                Email = "mail@mail.com",
                Senha = "123"
            };
            */

            // EXCEPTION // Cliente obrigatorio para Dado
            /*
            Dado dado = new Dado()
            {
                Nome = "DevWz",
                CPF = "00000000000"
            };
            */

            // OK
            /*
            Cliente cliente = new Cliente()
            {
                Email = "mail@mail.com",
                Senha = "123",
                Dado = new Dado()
                {
                    Nome = "DevWz",
                    CPF = "00000000000"
                }
            };
            */

            // OK
            /*
            Dado dado = new Dado()
            {
                Cliente = manager.Clientes.SingleOrDefault(x => x.Id.Equals(1)),
                Nome = "DevWz",
                CPF = "000000000000"
            };
            */

            /*
            Dado dado = new Dado()
            {
                Cliente = new Cliente()
                {
                    Email = "mail@mail.com",
                    Senha = "123"
                },
                Nome = "DevWz",
                CPF = "00000000000"
            };
            */

            // EXCEPTION // Conflito de propriedades
            /*
            Dado dado = new Dado()
            {
                Cliente = new Cliente()
                {
                    Email = "mail@mail.com",
                    Senha = "123",
                    Dado = new Dado()
                    {
                        Nome = "AAAA",
                        CPF = "11111111111"
                    }
                },
                Nome = "DevWz",
                CPF = "00000000000"
            };
            */

            // OK
            /*
            Cliente cliente = new Cliente()
            {
                Email = "mail@mail.com",
                Senha = "123",
                Fones = new List<Fone>()
                {
                    new Fone() { N = "00000000" },
                    new Fone() { N = "11111111" }
                },
                Dado = new Dado()
                {
                    CPF = "00000000000",
                    Nome = "DevWz"
                }
            };
            */

            Cliente cliente = manager.Clientes.Single(x => x.Id.Equals(1));
            manager.Clientes.Remove(cliente);

            // manager.Clientes.Add(cliente);
            // manager.Dados.Add(dado);
            manager.SaveChanges();

        }
    }
}

using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.Context
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext() : base("ProjetoModeloDDD")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //Remove a criação de tabelas no plural
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //Não deleta em cascata qnd estiver uma relação de um para N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); //Não deleta em cascada qnd estiver uma relação de N para N

            //Qnd a propriedade tiver o final com id -> Será a chave primária da tabela
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "id")
                .Configure(p => p.IsKey());

            //Qnd a propriedade for string -> Utilize varchar no banco de dados
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Qnd a propriedade for string -> Utilize no banco varchar(100)
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //Aplicar as configurações na criação da tabela de cliente
            modelBuilder.Configurations.Add(new ClienteConfiguration());

            //Aplicar as configurações na criação da tabela de produto
            modelBuilder.Configurations.Add(new ProdutoConfiguration());


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}

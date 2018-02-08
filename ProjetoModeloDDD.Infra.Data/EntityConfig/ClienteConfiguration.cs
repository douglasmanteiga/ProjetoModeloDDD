using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            //-> Modelando a tabela do banco de dados com Entity Framework - Fluent API

            //ClienteID é chave
            HasKey(c => c.ClienteId);

            //O campo nome é obrigatório e seu tamanho máximo é 150
            Property(c => c.Nome).IsRequired().HasMaxLength(150);

            //O campo sobrenome é obrigatório e seu tamanho máximo é 150
            Property(c => c.Sobrenome).IsRequired().HasMaxLength(150);

            //O campo e-mail é obrigatório porém seu tamhno é 100, isso foi definido no OnModelCreating (DbContext)
            Property(c => c.Email).IsRequired();
        }
    }
}

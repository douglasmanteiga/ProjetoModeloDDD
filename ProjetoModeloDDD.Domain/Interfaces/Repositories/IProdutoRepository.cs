using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        //Alem do CRUD implementado pelo repositório base (IRepositoryBase), quero uma pesquisa especial
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}

using System;
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        //O CRUD da Classe IRepositoryBase já está implementado pela classe RepositoryBase<Produto>
        //Por este motivo essa classe não está dando erro para implementar o CRUD

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return db.Produtos.Where(p => p.Nome == nome);
        }
    }
}

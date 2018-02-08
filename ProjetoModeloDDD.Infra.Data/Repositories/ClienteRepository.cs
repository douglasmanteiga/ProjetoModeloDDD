using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        //O CRUD da Classe IRepositoryBase já está implementado pela classe RepositoryBase<Cliente>
        //Por este motivo essa classe não está dando erro para implementar o CRUD
    }
}

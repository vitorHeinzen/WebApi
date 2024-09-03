using System.Numerics;

namespace WebAPI.Model
{
    public interface IFornecedorRepository
    {
        void AddFornecedor(Fornecedor fornecedor);
        void DeleteFornecedor(int id);

        void UpdateFornecedor(int id, Fornecedor fornecedor);
        Fornecedor GetFornecedorId(int id);
        List<Fornecedor> GetFornecedores();

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Numerics;
using WebAPI.Model;

namespace WebAPI.Infraestrutura
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();  
        public void AddFornecedor(Fornecedor fornecedor)
        {
            //Adiciona e salva o fornecedor
            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();
        }

        public List<Fornecedor> GetFornecedores()
        {
            //retona uma lista de todos os fornecedores
            return _context.Fornecedores.ToList();  
        }

        public Fornecedor? GetFornecedorId(int id)
        {
            //busca o fornecedor pelo id
            return _context.Fornecedores.Find(id);
        }

        public void DeleteFornecedor(int id)
        {
            var fornecedor = _context.Fornecedores.Find(id);

            if (fornecedor == null)
            {
                throw new Exception("Fornecedor não encontrado.");
            }

            //deleta o fornecedor
            _context.Fornecedores.Remove(fornecedor);
            _context.SaveChanges();
        }

        public void UpdateFornecedor(int id, Fornecedor fornecedorAtualizado)
        {
            var fornecedorExistente = _context.Fornecedores.Find(id);

            if (fornecedorExistente == null)
            {
                throw new Exception("Fornecedor não encontrado.");
            }

            // Atualiza apenas os campos que foram fornecidos (não nulos)
            if (fornecedorAtualizado.nome != null)
            {
                fornecedorExistente.nome = fornecedorAtualizado.nome;
                _context.Entry(fornecedorExistente).Property(f => f.nome).IsModified = true;
            }

            if (fornecedorAtualizado.email != null)
            {
                fornecedorExistente.email = fornecedorAtualizado.email;
                _context.Entry(fornecedorExistente).Property(f => f.email).IsModified = true;
            }

            if (fornecedorAtualizado.cnpjcpf != null)
            {
                fornecedorExistente.cnpjcpf = fornecedorAtualizado.cnpjcpf;
                _context.Entry(fornecedorExistente).Property(f => f.cnpjcpf).IsModified = true;
            }

            // Salva as alterações no banco de dados
            _context.SaveChanges();
        }
    }
}

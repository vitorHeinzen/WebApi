using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    [Table("Fornecedores")] 
    public class Fornecedor
    {
        [Key]
        
        public int id { get; private set; }
        public string? nome { get; set; }   
        public string? email { get; set; }
        public string? cnpjcpf { get; set; }

        public Fornecedor(string nome, string email, string cnpjcpf)
        {
            this.nome = nome;
            this.email = email;
            this.cnpjcpf = cnpjcpf;
        }

        public Fornecedor()
        {
            //Criado apenas para a autenticação do token fixa User = UsuarioTeste password = 123456
            //lembrando que quando adicionar o token tem que adiconar a Bearer + "token"
        }
    }
}

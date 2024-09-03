using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using WebAPI.Model;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [ApiController]
    //definição da rota da api
    [Route("api/fornecedor")]
    public class FornecedorController : ControllerBase
    {
        //Criando o contrutudor da interface para que o sistema entenda que a interface implmente a classe
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        //metodo Post
        [Authorize]
        [HttpPost]
        public IActionResult Add(FornecedorVM fornecedorVM)
        {
            //criando o fornecedor
            var fornecedor = new Fornecedor(fornecedorVM.Nome, fornecedorVM.Email, fornecedorVM.CnpjCpf);

            _fornecedorRepository.AddFornecedor(fornecedor);

            return Ok("Fornecedor adicionado com sucesso");
        }

        //busca por id
        [Authorize]
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var fornecedor = _fornecedorRepository.GetFornecedorId(Id);

            if (fornecedor == null)
            {
                return NotFound(); // Retorna 404 se o fornecedor não for encontrado
            }

            return Ok(fornecedor);
        }

        //Busca todos os forncededores
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var fornecedor = _fornecedorRepository.GetFornecedores();

            return Ok(fornecedor);
        }

        //Excluir fornecedor
        [Authorize]
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _fornecedorRepository.DeleteFornecedor(Id);
            return Ok("");
        }

        //Atualiza o fornecedor
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, FornecedorVM fornecedorVM)
        {
            if (fornecedorVM == null)
            {
                return BadRequest("Dados do fornecedor são obrigatórios.");
            }

            var fornecedorExistente = _fornecedorRepository.GetFornecedorId(id);

            if (fornecedorExistente == null)
            {
                return NotFound("Fornecedor não encontrado.");
            }

            // Atualiza apenas os campos que foram fornecidos
            if (!string.IsNullOrEmpty(fornecedorVM.Nome))
            {
                fornecedorExistente.nome = fornecedorVM.Nome;
            }

            if (!string.IsNullOrEmpty(fornecedorVM.Email))
            {
                fornecedorExistente.email = fornecedorVM.Email;
            }

            if (!string.IsNullOrEmpty(fornecedorVM.CnpjCpf))
            {
                fornecedorExistente.cnpjcpf = fornecedorVM.CnpjCpf;
            }

            // Adicione outras verificações semelhantes para os campos que podem ser atualizados

            _fornecedorRepository.UpdateFornecedor(id, fornecedorExistente);
            return Ok("Fornecedor atualizado com sucesso.");
        }

    }
}

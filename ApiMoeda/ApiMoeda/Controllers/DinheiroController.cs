using ApiMoeda.Models;
using ApiMoeda.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoeda.Controllers
{
    [Route("api/[controller]")]
    public class DinheiroController : ControllerBase
    {
        private readonly IMoedasRepository _repository;

        public DinheiroController(IMoedasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("", Name = "obter")]
        public ActionResult Obter()
        {
            var item = _repository.Obter();

            if (item == null || item.Count < 1)
                return NoContent();
            /* 
             * Status Code correto para retornar quando não há conteúdo. 
             * Mas para sinalizar que não há "objeto a ser retornado" pode ser retornado 200 e uma mensagem para o usuário
             * Seguindo boas práticas decidi deixar o status code 204.
             * Para retornar 200 e uma mensagem o comentário abaixo serve.
             * return Ok(new { mensagem = "Não há mais moedas para retornar" });
             */


            var ultimoObjetoAdcionado = item.OrderByDescending(x => x.Id).FirstOrDefault();

            _repository.Excluir(ultimoObjetoAdcionado.Id);

            return Ok(ultimoObjetoAdcionado);
        }

        [HttpPost("", Name = "CadastarUm")]
        public ActionResult Cadastrar([FromBody] Dinheiro dinheiro)
        {
            _repository.Cadastrar(dinheiro);

            return Created($"/api/dinheiro", dinheiro);
        }

        [HttpPost("varios", Name = "CadastarVarios")]
        public ActionResult Cadastrar([FromBody] List<Dinheiro> dinheiros)
        {
            foreach (var dinheiro in dinheiros)
            {
                _repository.Cadastrar(dinheiro);
            }

            return Created($"/api/dinheiro", dinheiros);
        }

    }
}

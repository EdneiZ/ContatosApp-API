using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContatosApp.Api.Models;
using ContatosApp.Data.Entities;
using ContatosApp.Data.Repositories;

namespace ContatosApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        ///
        ///<summary>
        ///Método para cadastro de contato
        ///</summary>
        ///

        [HttpPost]
        public IActionResult Post(ContatoPostModel model)
        {
            try
            {
                var contato = new Contato
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Email = model.Email,
                    Telefone = model.Telefone,
                    DataHoraCadastro = DateTime.Now
                };
                var contatoRepository = new ContatoRepository();
                contatoRepository.Insert(contato);
                //HTTP 201 - CREATED
                return StatusCode(201, new { message = "Contato cadastrado com sucesso." });

            }
            catch (Exception e)
            {
                //HTTP 500 - INTERNAL SERVER ERROR
                return StatusCode(500, new { e.Message });

            }
        }
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }
        [HttpDelete]

        public IActionResult Delete()
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}

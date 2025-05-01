using System.ComponentModel.DataAnnotations;
using System.Data;
using ContatosApp.API.Models;
using ContatosApp.Data.Entities;
using ContatosApp.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContatosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        ///<summary>
        ///Método para cadastro de contato na Api
        ///</summary>
        ///
        [HttpPost]
        public IActionResult Post(ContatosPostModel model)
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

                //Http 201 Created
                return StatusCode(201, new { message = "Contato cadastro com sucesso." });

            }
            catch (Exception e)
            {
                //http 500 - internal server error
                return StatusCode(500, new { e.Message });
            }
        }
        [HttpGet("{id}")]

        public IActionResult GetId(Guid id)
        {
            try
            {
                var contatoRepository = new ContatoRepository();
                var contato = contatoRepository.GetById(id);

                if (contato != null)
                {
                    return StatusCode(200, contato); // http 200
                }
                else
                {
                    return NoContent(); // http 204
                }

            }
            catch (Exception e)
            {
                //HTTP 500 - INTERNAL SERVER ERROR
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut]
        public IActionResult Atualizar(ContatoPutModel model)
        {
            try
            {
                // consultar o contato no banco de dados através do ID
                var contatoRepository = new ContatoRepository();
                var contato = contatoRepository.GetById(model.Id.Value);

                //Verificar se o contato foi encontrado
                if (contato != null)
                {
                    contato.Nome = model.Nome;
                    contato.Email = model.Email;
                    contato.Telefone = model.Telefone;
                    //contato.Ativo = model.Ativo;

                    //atualizar no banco de dados

                    contatoRepository.Uptade(contato);
                    return StatusCode(200, new { message = "Contato Atualizado com sucesso" });
                }
                else
                {
                    return StatusCode(400, new { message = "Contato não encontrado" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var contatoRepository = new ContatoRepository();
                var contatos = contatoRepository.ListarTudo();
                //HTTP 200 - SELECT 
                return StatusCode(200, contatos);
            }
            catch (Exception e)
            {
                //HTTP 500 - INTERNAL SERVER ERROR
                return StatusCode(500, new { e.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //consultando o contato através do ID
                var contatoRepository = new ContatoRepository();
                var contato = contatoRepository.GetById(id);

                //verificando se o contato foi encontrado
                if (contato != null)
                {
                    //excluir o contato
                    contatoRepository.Delete(contato);
                    return StatusCode(200, new
                    {
                        message = "Contato excluído com sucesso.",
                        contato
                    });
                }
                else
                {
                    return StatusCode(400,new
                {
                message = "Contato não encontrado. Verifique o ID."
                });
                }
            }
            catch (Exception e)
            {
                //HTTP 500 - INTERNAL SERVER ERROR
                return StatusCode(500, new { e.Message });
            }
        }
    }
    }






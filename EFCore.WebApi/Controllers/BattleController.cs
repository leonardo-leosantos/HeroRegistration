using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Domain;
using EFCore.Repository;
using EFCore.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        private readonly IEFCoreRepository _repository;
        public BattleController(IEFCoreRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Battle
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var batalhas = await _repository.GetAllBatalhas();
                return Ok(batalhas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException.Message}");
            }
        }

        // GET: api/Battle/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var batalha = await _repository.GetBatalhaById(id, true);

                if (batalha != null)
                    return Ok(batalha);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException.Message}");
            }
            return BadRequest("Batalha não encontrada!");
        }

        // POST: api/Battle
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] List<Batalha> batalhasModel)
        {
            try
            {
                foreach (var batalha in batalhasModel)
                {
                    _repository.Add(batalha);
                }

                if(await _repository.SaveChangesAsync())
                    return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException.Message}");
            }

            return BadRequest("Algo deu errado durante a execução!");
        }

        // PUT: api/Battle/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Batalha batalhaModel)
        {
            try
            {
                var batalha = await _repository.GetBatalhaById(batalhaModel.Id);

                if (batalha != null)
                {
                    _repository.Update(batalha);

                    if (await _repository.SaveChangesAsync())
                        return Ok();
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException?.Message}");
            }

            return BadRequest("Algo deu errado durante a execução!");

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var batalha = await _repository.GetBatalhaById(id);

                if (batalha != null)
                {
                    _repository.Delete(batalha);

                    if (await _repository.SaveChangesAsync())
                        return Ok();
                }
                else
                    return Ok("Batalha não encontrada!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException?.Message}");
            }

            return BadRequest("Algo deu errado durante a execução!");
        }
    }
}

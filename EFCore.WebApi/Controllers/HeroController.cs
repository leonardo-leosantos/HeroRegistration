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
using Newtonsoft.Json;

namespace EFCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IEFCoreRepository _repository;
        public HeroController(IEFCoreRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Hero
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var herois = await _repository.GetAllHerois();
                return Ok(herois);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException.Message}");
            }
        }

        // GET: api/Hero/New.Guid()
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var heroi = await _repository.GetHeroiById(id);
                if (heroi != null)
                    return Ok(heroi);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException.Message}");
            }

            return BadRequest("Heroi não encontrada!");
        }

        // POST: api/Hero
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Heroi> heroisModel)
        {
            try
            {
                foreach (var heroi in heroisModel)
                {
                    _repository.Add(heroi);
                }

                if (await _repository.SaveChangesAsync())
                    return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException.Message}");
            }

            return BadRequest("Algo deu errado durante a execução!");
        }

        // PUT: api/Hero
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Heroi heroiModel)
        {
            try
            {
                var heroi = await _repository.GetHeroiById(heroiModel.Id);

                if (heroi != null)
                {
                    _repository.Update(heroiModel);

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
                var heroi = await _repository.GetHeroiById(id);

                if (heroi != null)
                {
                    _repository.Delete(heroi);

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
    }
}

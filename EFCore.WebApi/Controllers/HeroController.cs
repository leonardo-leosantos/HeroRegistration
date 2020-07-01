using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Domain;
using EFCore.Repository;
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
        private readonly HeroiContext _context;
        public HeroController(HeroiContext context)
        {
            _context = context;
        }

        // GET: api/Hero
        [HttpGet]
        public ActionResult Get()
        {
            try 
            {
                List<Heroi> herois = _context.Herois.ToList();

                //foreach (var heroi in herois)
                //{
                //    heroi.Armas = _context.Armas.Where(a => a.IdHeroi == heroi.Id).ToList();
                //    heroi.Identidade = _context.IdentidadesSecretas.FirstOrDefault(i => i.IdHeroi == heroi.Id);
                //    heroi.HeroiBatalhas = _context.HeroisBatalhas.Where(a => a.IdHeroi == heroi.Id).ToList();
                //}

                return Ok(herois);
            }
            catch (Exception ex) 
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException?.Message}");
            }
            
        }

        // GET: api/Hero/New.Guid()
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            try
            {
                Heroi heroi = _context.Herois.FirstOrDefault(h => h.Id == id);
                return Ok(heroi);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException.Message}");
            }
        }

        // POST: api/Hero
        [HttpPost]
        public ActionResult Post([FromBody] List<Heroi> heroisModel)
        {
            try
            {
                foreach (var heroi in heroisModel)
                {
                    _context.Herois.Add(heroi);
                }
                
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException.Message}");
            }
        }

        // PUT: api/Hero
        [HttpPut]
        public ActionResult Put([FromBody] Heroi heroiModel)
        {
            try
            {
                var heroi = _context.Herois.AsNoTracking().FirstOrDefault(x => x.Id == heroiModel.Id);

                if (heroi != null)
                {
                    _context.Herois.Update(heroiModel);
                    _context.SaveChanges();

                    return Ok();
                }

                return Ok("Heroi não encontrado!");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException?.Message}");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var heroi = _context.Herois.AsNoTracking().FirstOrDefault(h => h.Id == id);

                if (heroi != null)
                {
                    _context.Herois.Remove(heroi);
                    _context.SaveChanges();

                    return Ok();
                }
                return Ok("Heroi não encontrado!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException?.Message}");
            }
        }
    }
}

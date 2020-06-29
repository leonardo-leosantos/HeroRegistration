using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                return Ok(new Heroi());
            }
            catch (Exception ex) 
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException.Message}");
            }
            
        }

        // GET: api/Hero/New.Guid()
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(Guid id)
        {
            try
            {
                return Ok();
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
        public void Delete(int id)
        {
        }
    }
}

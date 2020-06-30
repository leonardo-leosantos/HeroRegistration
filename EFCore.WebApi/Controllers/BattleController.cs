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
    public class BattleController : ControllerBase
    {
        private readonly HeroiContext _context;
        public BattleController(HeroiContext context)
        {
            _context = context;
        }

        // GET: api/Battle
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                List<Batalha> batalhas = _context.Batalhas.ToList();
                return Ok(batalhas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException.Message}");
            }

        }

        // GET: api/Battle/5
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            try
            {
                Batalha batalha = _context.Batalhas.FirstOrDefault(b => b.Id == id);
                return Ok(batalha);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException.Message}");
            }
        }

        // POST: api/Battle
        [HttpPost]
        public ActionResult Post([FromBody] List<Batalha> batalhasModel)
        {
            try
            {
                foreach (var batalha in batalhasModel)
                {
                    _context.Batalhas.Add(batalha);
                }

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException.Message}");
            }

        }

        // PUT: api/Battle/5
        [HttpPut]
        public ActionResult Put([FromBody] Batalha batalhaModel)
        {
            try
            {
                var batalha = _context.Batalhas.AsNoTracking().FirstOrDefault(x => x.Id == batalhaModel.Id);

                if (batalha != null)
                {
                    _context.Batalhas.Update(batalhaModel);
                    _context.SaveChanges();

                    return Ok();
                }

                return Ok("Batalha não encontrada!");

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
                var batalha = _context.Batalhas.AsNoTracking().FirstOrDefault(h => h.Id == id);

                if (batalha != null)
                {
                    _context.Batalhas.Remove(batalha);
                    _context.SaveChanges();

                    return Ok();
                }
                return Ok("Batalha não encontrada!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException?.Message}");
            }
        }
    }
}

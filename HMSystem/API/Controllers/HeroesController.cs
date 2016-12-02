using System;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using HMS.Service.Business.Heros;
using HMS.Core.Domain;
using System.Collections.Generic;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{

    /// <summary>
    /// HeroesController
    /// </summary>
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class HeroesController : ApiController
    {
        private readonly IHeroService _heroService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="heroService"></param>
        public HeroesController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        /// <summary>
        /// Get all heroes or search heroes
        /// </summary>
        /// <param name="keyword">keyword to search</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string keyword = null)
        {
            var heroes = new List<Hero>();
            if (string.IsNullOrEmpty(keyword))
            {
                heroes = await _heroService.GetHeroes();
            }
            else
            {
                heroes = await _heroService.SearchAsync(keyword);
            }
            return Ok(heroes);
        }

        /// <summary>
        /// Create a hero
        /// </summary>
        /// <remarks>
        /// Note that the key is integer.
        ///  
        ///     POST 
        ///     {
        ///        "name": "name1"
        ///     }
        /// 
        /// </remarks>
        /// <param name="model">new hero</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HeroModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys.Where(key => ModelState[key].Errors.Count > 0))
                {
                    return BadRequest(ModelState[key].Errors[0].ErrorMessage);
                }
            }

            var newHero = new Hero
            {
                Name = model.Name
            };

            try
            {
                await _heroService.CreateAsync(newHero);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred when creating hero");
            }
            return Ok();
        }

        /// <summary>
        /// Update a hero
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="model">hero</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HeroModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys.Where(key => ModelState[key].Errors.Count > 0))
                {
                    return BadRequest(ModelState[key].Errors[0].ErrorMessage);
                }
            }
            try
            {
                var hero = await _heroService.GetHeroByIdAsync(id);
                if(hero == null)
                {
                    return BadRequest("Hero dose not exist!");
                }

                hero.Name = model.Name;
                await _heroService.UpdateAsync(hero);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred when updating hero");
            }
            return Ok();
        }

        /// <summary>
        /// Delete a hero
        /// </summary>
        /// <param name="id">hero id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Hero dose not exist!");
            }
            try
            {
                var hero = await _heroService.GetHeroByIdAsync(id);
                if (hero == null)
                {
                    return BadRequest("Hero dose not exist!");
                }
                await _heroService.DeleteAsync(hero);
            }
            catch (Exception)
            {
                return BadRequest("An error occurred when deleting hero");
            }

            return Ok();
        }

    }
}

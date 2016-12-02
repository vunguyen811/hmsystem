using HMS.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMS.Service.Business.Heros
{
    public interface IHeroService
    {
        #region Async method

        /// <summary>
        /// Get all Heroes
        /// </summary>
        /// <returns></returns>
        Task<List<Hero>> GetHeroes();

        /// <summary>
        /// Get a hero by id
        /// </summary>
        /// <param name="id">id of hero</param>
        /// <returns></returns>
        Task<Hero> GetHeroByIdAsync(int id);

        /// <summary>
        /// Create a hero
        /// </summary>
        /// <param name="hero">new hero</param>
        /// <returns></returns>
        Task CreateAsync(Hero hero);

        /// <summary>
        /// Update a hero
        /// </summary>
        /// <param name="hero">hero</param>
        /// <returns></returns>
        Task UpdateAsync(Hero hero);

        /// <summary>
        /// Delete a hero
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        Task DeleteAsync(Hero hero);

        /// <summary>
        /// Search hero
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        Task<List<Hero>> SearchAsync(string keyword);
        #endregion

    }
}

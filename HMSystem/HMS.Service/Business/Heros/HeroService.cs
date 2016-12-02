using HMS.Core.Domain;
using HMS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMS.Service.Business.Heros
{
    public class HeroService : IHeroService
    {
        #region Field
        private readonly HmsContext _context;
        private readonly DbSet<Hero> _heroDbSet;
        #endregion

        #region Constructor
        public HeroService(HmsContext context)
        {
            _context = context;
            _heroDbSet = _context.Set<Hero>();
        }
        #endregion

        #region Async method

        public Task<List<Hero>> GetHeroes()
        {
            var query = "SELECT * FROM [Heroes]";
            var result = _heroDbSet.FromSql(query).ToListAsync();
            return result;
        }

        public Task<Hero> GetHeroByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("id");
            var query = "SELECT * FROM [Heroes] WHERE Id = @p0";
            var result = _heroDbSet.FromSql(query,id).FirstOrDefaultAsync();
            return result;
        }

        public async Task CreateAsync(Hero hero)
        {
            if (hero == null)
                throw new ArgumentNullException("hero");
            _heroDbSet.Add(hero);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Hero hero)
        {
            if (hero == null)
                throw new ArgumentNullException("hero");
            _context.Entry(hero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Hero hero)
        {
            if (hero == null)
                throw new ArgumentNullException("hero");
            _context.Database.ExecuteSqlCommand("DELETE [Heroes] WHERE Id = @p0", hero.Id);
            await _context.SaveChangesAsync();
        }

        public Task<List<Hero>> SearchAsync(string keyword)
        {
            if (keyword == null)
                throw new ArgumentNullException("keyword");
            var query = "SELECT * FROM [Heroes] WHERE Id Like @p0 OR Name Like @p0";
            var result = _heroDbSet.FromSql(query, "%" + keyword + "%").ToListAsync();
            return result;
        }

        #endregion

        #region Sync method

        #endregion
    }
}

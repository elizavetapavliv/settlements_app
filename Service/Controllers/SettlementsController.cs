using System.Collections.Generic;
using System.Data.Entity;
using Lab2Service.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2Service.Controllers
{
    public class SettlementsController 
    {
        private readonly CountryDataContext db;

        public SettlementsController(CountryDataContext context)
        {
            db = context;
        }

        public async Task<List<Settlement>> SettlementIndex()
        {
            return await db.Settlements.ToListAsync();
        }

        public async Task Create(Settlement settlement)
        {
            db.Settlements.Add(settlement);
            await db.SaveChangesAsync();
        }

        public async Task<Settlement> Edit(int? id)
        {
            return await db.Settlements.FindAsync(id);
        }

        public async Task Edit(Settlement settlement)
        {
            var s = await db.Settlements.FindAsync(settlement.Id);
            s.Name = settlement.Name;
            s.Population = settlement.Population;
            s.DistrictId = settlement.DistrictId;
            s.Type = settlement.Type;
            await db.SaveChangesAsync();
        }
        public async Task<Settlement> Delete(int? id)
        {
            return await db.Settlements.FirstOrDefaultAsync(s => s.Id == id);
        }
      
        public async Task Delete(int id)
        {
            var settlement = await db.Settlements.FindAsync(id);
            db.Settlements.Remove(settlement);
            await db.SaveChangesAsync();
        }

        public async Task<List<District>> GetDistrictsList()
        {
            return await (from d in db.Districts select d).ToListAsync();
        }
    }
}
using System.Linq;
using System.Data.Entity;
using Lab2Service.Models;
using System.Threading.Tasks;

namespace Lab2Service.Controllers
{
    public class HomeController
    {
        private readonly CountryDataContext db;
        public HomeController(CountryDataContext context)
        {
            db = context;
        }

        public async Task<RegionIndexData> Index(int? id, int? districtId)
        {
            var viewModel = new RegionIndexData();

            viewModel.Regions = await db.Regions
                .Include(r => r.Districts)
                .ToListAsync();

            viewModel.Districts = await db.Districts.Include(d => d.Settlements).ToListAsync();
            if (id != null)
            {
                var region = viewModel.Regions.Where(r => r.Id == id.Value).Single();
                viewModel.Districts = region.Districts;
            }

            if (districtId != null)
            {
                var selectedDistrict = viewModel.Districts.Where(d => d.Id == districtId).Single();
                viewModel.Settlements = selectedDistrict.Settlements;
            }

            return viewModel;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index(int? id, int? districtId)
        {
            var endPoint = new ServiceReference.WebServiceSoapClient.EndpointConfiguration();
            var service = new ServiceReference.WebServiceSoapClient(endPoint);
            
            var viewModel = await service.IndexAsyncAsync(id, districtId);
       
            if (id != null)
            {
                  ViewData["RegionId"] = id.Value;
            }

            if (districtId != null)
            {
                ViewData["DistrictId"] = districtId.Value;
            }
            ViewBag.dataSource = viewModel.Body.IndexAsyncResult.Settlements;
            return View(viewModel.Body.IndexAsyncResult);
        }
    }
}

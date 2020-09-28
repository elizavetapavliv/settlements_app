using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceReference;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Lab1.Controllers
{
    public class SettlementsController : Controller
    {
       private static WebServiceSoapClient.EndpointConfiguration endPoint 
            = new WebServiceSoapClient.EndpointConfiguration();
        private static WebServiceSoapClient service 
            = new WebServiceSoapClient(endPoint);

        public async Task<IActionResult> Index()
        {
            var settlements = (await service.SIndexAsync()).Body.SIndexResult;
            return View(settlements);
        }

        public IActionResult Create()
        {
            DistrictsDropDownList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name","Type","Population","DistrictId")] Settlement settlement)
        {
            if (ModelState.IsValid)
            {
                await service.CreateAsync(settlement);
                return RedirectToAction("Index", "Home");
            }
            DistrictsDropDownList(settlement.DistrictId);
            return View(settlement);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var settlement = (await service.EditAsync(id)).Body.EditResult;
            if (settlement == null)
            {
                return NotFound();
            }
            DistrictsDropDownList();
            return View(settlement);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Settlement settlement)
        {
            if (ModelState.IsValid)
            {
                await service.PostEditAsync(settlement);
                DistrictsDropDownList(settlement.DistrictId);
                return RedirectToAction("Index", "Home");
            }
            return View(settlement);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var settlement = (await service.DeleteAsync(id)).Body.DeleteResult;
            if (settlement == null)
            {
                return NotFound();
            }

            return View(settlement);
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await service.PostDeleteAsync(id);
            return RedirectToAction("Index", "Home");
        }
        private void DistrictsDropDownList(object selectedDistrict = null)
        {
            var districtsQuery = service.GetDistrictsListAsync().Result.Body.GetDistrictsListResult;
            ViewBag.Districts = new SelectList(districtsQuery, "Id", "Name", selectedDistrict);
        }
    }
}
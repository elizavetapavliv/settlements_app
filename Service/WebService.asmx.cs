using Lab2Service.Controllers;
using Lab2Service.Models;
using Nito.AsyncEx;
using System.Collections.Generic;
using System.Web.Services;

namespace Lab2Service
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://webservices.example.com/GameServices/Game1")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod]
        public RegionIndexData IndexAsync(int? id, int? districtId)
        {
            return AsyncContext.Run(()=> hc.Index(id, districtId));
        }

        [WebMethod]
        public List<Settlement> SIndex()
        {
            return AsyncContext.Run(() => sc.SettlementIndex());
        }

        [WebMethod]
        public void Create(Settlement settlement)
        {
            AsyncContext.Run(() => sc.Create(settlement));
        }

        [WebMethod]
        public Settlement Edit(int? id)
        {
            return AsyncContext.Run(() => sc.Edit(id));
        }

        [WebMethod]
        public void PostEdit(Settlement settlement)
        {
            AsyncContext.Run(() => sc.Edit(settlement));
        }

        [WebMethod]
        public Settlement Delete(int? id)
        {
            return AsyncContext.Run(() => sc.Delete(id));
        }

        [WebMethod]
        public void PostDelete(int id)
        {
            AsyncContext.Run(() => sc.Delete(id));
        }

        [WebMethod]
        public List<District> GetDistrictsList()
        {
            return AsyncContext.Run(() => sc.GetDistrictsList());
        }

        private static CountryDataContext db = new CountryDataContext();
        private static HomeController hc = new HomeController(db);
        private static SettlementsController sc = new SettlementsController(db);
    }
}

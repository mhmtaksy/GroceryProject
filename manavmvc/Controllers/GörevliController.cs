using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using manavmvc.Models;

namespace manavmvc.Controllers
{
    public class GörevliController : Controller
    {
        // GET: Görevli
        public ActionResult Index()
        {
            IEnumerable<GörevliModel> responseList;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Görevli").Result;
            responseList = response.Content.ReadAsAsync<IEnumerable<GörevliModel>>().Result;
            return View(responseList);
        }
        public ActionResult EY(int id = 0)
        {
            if(id == 0)
            {
                return View(new GörevliModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Görevli/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<GörevliModel>().Result);
            }
            
        }
        [HttpPost]
        public ActionResult EY(GörevliModel save)
        {
            if (save.görevliID==0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Görevli",save).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Görevli/" + save.görevliID,save).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Görevli/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}
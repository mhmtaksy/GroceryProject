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
    public class MeyveController : Controller
    {
        HttpResponseMessage response;
        // GET: Meyve
        public ActionResult Index()
        {
            IEnumerable<MeyveModel> responseList;
            response = GlobalVariables.webapiclient.GetAsync("Meyvelers").Result;
            responseList = response.Content.ReadAsAsync<IEnumerable<MeyveModel>>().Result;
            return View(responseList);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new MeyveModel());
            }
            else
            {
                response = GlobalVariables.webapiclient.GetAsync("Meyvelers/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<IEnumerable<MeyveModel>>().Result);
            }
        }
        [HttpPost]
        public ActionResult EY(MeyveModel save)
        {
            if (save.meyveID==0)
            {
                response = GlobalVariables.webapiclient.PostAsJsonAsync("Meyvelers",save).Result;
            }
            else
            {
                response = GlobalVariables.webapiclient.PutAsJsonAsync("Meyvelers/"+save.meyveID,save).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            response = GlobalVariables.webapiclient.DeleteAsync("Meyvelers/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<IEnumerable<MeyveModel>>().Result);
        }
    }
}
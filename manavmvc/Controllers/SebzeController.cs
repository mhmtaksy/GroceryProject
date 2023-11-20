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
    public class SebzeController : Controller
    {
        HttpResponseMessage response;
        // GET: Sebze
        public ActionResult Index()
        {
            IEnumerable<SebzeModel> responseList;
            response = GlobalVariables.webapiclient.GetAsync("Sebzelers").Result;
            responseList = response.Content.ReadAsAsync<IEnumerable<SebzeModel>>().Result;
            return View(responseList);
        }
        public ActionResult EY(int id=0)
        {
            if (id==0)
            {
                return View(new SebzeModel());
            }
            else
            {
                response = GlobalVariables.webapiclient.GetAsync("Sebzelers/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<SebzeModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult EY(SebzeModel save)
        {
            if (save.sebzeID == 0)
            {
                response = GlobalVariables.webapiclient.PostAsJsonAsync("Sebzelers",save).Result;
            }
            else
            {
                response = GlobalVariables.webapiclient.PutAsJsonAsync("Sebzelers/" +save.sebzeID,save).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            response = GlobalVariables.webapiclient.DeleteAsync("Sebzelers/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<SebzeModel>().Result);
        }
    }
}
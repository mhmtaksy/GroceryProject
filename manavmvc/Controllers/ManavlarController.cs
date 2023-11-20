using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using manavmvc.Models;
using System.Runtime.Remoting.Messaging;

namespace manavmvc.Controllers
{
    public class ManavlarController : Controller
    {
        // GET: Manavlar
        public ActionResult Index()
        {
            IEnumerable<ManavModel> responseList;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Manavlars").Result;
            responseList = response.Content.ReadAsAsync<IEnumerable<ManavModel>>().Result;
            return View(responseList);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new ManavModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Manavlars/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<ManavModel>().Result);

            }
        }
        [HttpPost]
        public ActionResult EY(ManavModel save)
        {
            if (save.manavID==0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Manavlars",save).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Manavlars/"+save.manavID,save).Result;
                
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Manavlars/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
    
}
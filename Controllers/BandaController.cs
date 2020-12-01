using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class BandaController : Controller
    {

        BandaDAO bandaDAO = new BandaDAO();
        public static List<Banda> listaBanda = new List<Banda>();

        // GET: Banda
        public ActionResult Index()
        {
            listaBanda = bandaDAO.List();
            return View(listaBanda);
        }

        // GET: Banda/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Banda/Create
        public ActionResult Create()
        {
            return View();
        }

        /*
        // POST: Banda/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Banda banda = new Banda();
                banda.Id = listaBanda.Count;
                banda.Nome = collection["Nome"];
                listaBanda.Add(banda);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */

        // POST: Banda/Create
        [HttpPost]
        public ActionResult Create(Banda banda)
        {
            try
            {
                listaBanda.Add(banda);
                bandaDAO.Create(banda);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Banda/Edit/5
        public ActionResult Edit(int id)
        {
            var banda = listaBanda.Single(p => p.Id == id);

            return View(banda);
        }

        // POST: Banda/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var banda = listaBanda.Single(p => p.Id == id);
                if (TryUpdateModel(banda))
                {
                    bandaDAO.Edit(banda);
                    return RedirectToAction("Index");
                }
                return View(banda);
            }
            catch
            {
                return View();
            }
        }

        // GET: Banda/Delete/5
        public ActionResult Delete(int id)
        {
            var banda = listaBanda.Single(p => p.Id == id);
            return View(banda);
        }

        // POST: Banda/Delete/5
        [HttpPost]
        public ActionResult Delete(Banda banda)
        {
            try
            {
                listaBanda.Remove(banda);
                bandaDAO.Delete(banda);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

            /*

            public static List<Banda> listaBanda = new List<Banda>{
               new Banda{
                  Id = 1,
                  Nome = "ACDC"
               },
                new Banda{
                  Id = 2,
                  Nome = "Megadeth"
               },
                new Banda{
                  Id = 3,
                  Nome = "Xandria"
               },
                 new Banda{
                  Id = 4,
                  Nome = "Norther"
               },
                new Banda{
                  Id = 5,
                  Nome = "Lacuna Coil"
               },
            };
            */
        }
}

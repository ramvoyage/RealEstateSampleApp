using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Data;
using RealEstateApp.Helper;
using RealEstateApp.Models;

namespace RealEstateApp.Controllers
{
  public class RealEstatesController : BaseController<Data.Model.RealEstate>
  {
        private RealEstateAppContext db;

        private readonly BaseController<Data.Model.RealEstate> _db;

        public RealEstatesController()
        {
           _db = new BaseController<Data.Model.RealEstate>(new RealEstateAppContext());
        }
        public RealEstatesController(RealEstateAppContext db):base(db)
        {
            db = new RealEstateAppContext();
        }


    // GET: RealEstates
        public ActionResult Index()
        { 
            var list =  _db.GetAll().ToList();
            return View(list);
        }

        public JsonResult List()
        {
          var list = _db.GetAll().ToList();

          return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Search(Search str)
        {
          List<Data.Model.RealEstate> result;
          if (str.value != null)
          {
            result = _db.GetAll().Where(x => x.area.Contains(str.value) || x.price.ToString().Contains(str.value)).ToList();
          }
          else
          {
            result = _db.GetAll().Where(x => x.active).ToList();
          }
          return Json(result, JsonRequestBehavior.AllowGet);
        }
      

        // GET: RealEstates/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Data.Model.RealEstate realEstate)
        {
            if (ModelState.IsValid)
            {
                 _db.Add(realEstate);
        
                return RedirectToAction("List");
            }

            return View(realEstate);
        }

        // GET: RealEstates/Edit/5
        public ActionResult Edit(int? id)
        {
            return View();
        }

         [HttpGet]
        public JsonResult GetById(int? id)
        {
          Data.Model.RealEstate result;

          if (id == null)
          {
             return Json("", JsonRequestBehavior.AllowGet);
          }

          result = _db.GetById(id.Value);

          return Json(result, JsonRequestBehavior.AllowGet);
        }



    [HttpPost]
      public ActionResult Edit(Data.Model.RealEstate realEstate)
        {
            if (ModelState.IsValid)
            {

                var updateddata =  _db.Update(realEstate);

                var message = $"modified price, {updateddata.price}! area is {updateddata.area}";

                Task.Run(() => EmailBrokedMessage.SendAsync(message));

            }
            return View(realEstate);
        }

    }
}

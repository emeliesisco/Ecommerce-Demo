using Microsoft.AspNetCore.Mvc;
using MVCWebApplication.Data;
using MVCWebApplication.Models;

namespace MVCWebApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }

        //SET action method to Database.
        public IActionResult Index()
        {
            IEnumerable<Category> objCategory = _db.Categories;
            return View(objCategory);
        }

        //GET action method
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        //POST action method to database
        public IActionResult Create(Category value)
        {
            if(value.Name == value.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError","the model state cannot match displayName");
            }
            if (ModelState.IsValid)
            {
            //creating new record in database
            _db.Categories.Add(value);
            _db.SaveChanges();
                TempData["saved"] = "Category was created successfully";
            return RedirectToAction("index");
            }
            return View(value);
        }


        //GET action method for edit
        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var categoryFromDB = _db.Categories.Find(id);
            //var categoryFromDbFirst=_db.Categories.FirstOrDefault(c=>c.MyId==id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST action(to db) method for edit
        public IActionResult Edit(Category value) 
        {
            if (value.Name == value.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "the model state is not valid");
            }
            if (ModelState.IsValid)
            {
                //update record in database
                _db.Categories.Update(value);
                _db.SaveChanges();
                TempData["saved"] = "Category was updated successfully";
                return RedirectToAction("index");
            }
            return View(value);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDB = _db.Categories.Find(id);
            //var categoryFromDbFirst=_db.Categories.FirstOrDefault(c=>c.MyId==id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //POST action method for edit
        public IActionResult DeletePOST(int? id)
        {
           var obj =_db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
                //Delete record in database
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["saved"] = "Category was Deleted successfully";
            return RedirectToAction("index");
            
            //return View(obj);
        }
    }

}

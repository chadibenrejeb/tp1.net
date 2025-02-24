using CinemaManager_Chadi.Models.Cinema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManager_Chadi.Controllers
{
    public class ProducersController : Controller
    {
        CinemaDbContext _context;
        public ProducersController(CinemaDbContext context) {
            _context = context;
        }
        // GET: ProducersController
        public ActionResult Index()
        {
            return View(_context.Producers.ToList());
        }

        // GET: ProducersController/Details/5
        public ActionResult Details(int id)
        {
            var producer = _context.Producers.Find(id);
            if (producer == null) return NotFound();
            return View(producer);
        }

        // GET: ProducersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producer p)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    _context.Producers.Add(p);
                    _context.SaveChanges(); // Save changes to the database
                    return RedirectToAction("Index"); 
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving the producer.");
                }
            }

            return View(p); 
        }

        // GET: ProducersController/Edit/5
        public ActionResult Edit(int id)
        {
            var producer = _context.Producers.Find(id);
            if (producer == null) return NotFound();
            return View(producer);
        }

        // POST: ProducersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Producer updatedProducer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(updatedProducer);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An error occurred while updating the producer.");
                }
            }
            return View(updatedProducer);
        }

        // GET: ProducersController/Delete/5
        public ActionResult Delete(int id)
        {
            var producer = _context.Producers.Find(id);
            if (producer == null) return NotFound();
            return View(producer);
        }

        // POST: ProducersController/DeleteConfirmed/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var producer = _context.Producers.Find(id);
            if (producer == null) return NotFound();

            try
            {
                _context.Producers.Remove(producer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while deleting the producer.");
            }

            return View(producer);
        }
    }
}

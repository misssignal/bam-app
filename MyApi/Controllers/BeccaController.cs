using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeccaController : ControllerBase
    {
        [HttpGet(Name = "GetBecca")]
        public IEnumerable<Becca> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Becca
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = 9999,
                Summary = "HALLO"
            })
            .ToArray();
        }

        private readonly ILogger<BeccaController> _logger;

        public BeccaController(ILogger<BeccaController> logger)
        {
            _logger = logger;
        }

        /*        // GET: BeccaController
                public ActionResult Index()
                {
                    return View();
                }

                // GET: BeccaController/Details/5
                public ActionResult Details(int id)
                {
                    return View();
                }

                // GET: BeccaController/Create
                public ActionResult Create()
                {
                    return View();
                }

                // POST: BeccaController/Create
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Create(IFormCollection collection)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: BeccaController/Edit/5
                public ActionResult Edit(int id)
                {
                    return View();
                }

                // POST: BeccaController/Edit/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Edit(int id, IFormCollection collection)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: BeccaController/Delete/5
                public ActionResult Delete(int id)
                {
                    return View();
                }

                // POST: BeccaController/Delete/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Delete(int id, IFormCollection collection)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }*/
    }
}

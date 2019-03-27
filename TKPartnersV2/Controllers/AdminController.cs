using Microsoft.AspNetCore.Mvc;
using TKPartnersV2.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private INewsRepository repository;

        public AdminController(INewsRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.NewsRepo);

        public ViewResult Edit(int newsID) =>
            View(repository.NewsRepo
                .FirstOrDefault(p => p.NewsID == newsID));

        [HttpPost]
        public IActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                repository.SaveNews(news);
                TempData["message"] = $"{news.Name} збережено";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(news);
            }
        }

        public ViewResult Create() => View("Edit", new News());

        [HttpPost]
        public IActionResult Delete(int newsID)
        {
            News deletedNews = repository.DeleteNews(newsID);
            if (deletedNews != null)
            {
                TempData["message"] = $"{deletedNews.Name} видалено";
            }
            return RedirectToAction("Index");
        }
    }
}
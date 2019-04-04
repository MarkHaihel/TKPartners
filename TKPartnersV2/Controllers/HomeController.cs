using Microsoft.AspNetCore.Mvc;
using TKPartnersV2.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using TKPartnersV2.Models.ViewModels;

namespace TKPartnersV2.Controllers
{
    public class HomeController : Controller
    {
        private INewsRepository repository;
        public int PageSize = 4;

        public HomeController(INewsRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string search, int newsPage = 1)
         => View(new NewsListViewModel
         {
             NewsRepo = repository.NewsRepo
                 .OrderBy(n => n.Date)
                 .Skip((newsPage - 1) * PageSize)
                 .Take(PageSize),
             PagingInfo = new PagingInfo
             {
                 CurrentPage = newsPage,
                 ItemsPerPage = PageSize,
                 TotalItems = search == null ?
                     repository.NewsRepo.Count() :
                     repository.NewsRepo.Where(e =>
                        e.Name.Contains(search) || e.Author.Contains(search) || e.Description.Contains(search)).Count()
             },
             Search = search
         });

        public ViewResult News(int newsID)
            => View(repository.GetNews(newsID));

        public ViewResult Index() 
            => View(new Tuple<IQueryable<News>, FeedBack>(repository.LastNews(), new FeedBack()));
       
        [HttpPost]
        public IActionResult SendMessage(FeedBack feedBack)
        {
            SendMail sendMail = new SendMail(feedBack);
            sendMail.SendFeedBack();

            return RedirectToAction("Index");
        }

        public ViewResult Practices() => View();

        public ViewResult Practices1() => View();

        public ViewResult Practices2() => View();

        public ViewResult Practices3() => View();

        public ViewResult Practices4() => View();

        public ViewResult Practices5() => View();

        public ViewResult Practices6() => View();

        public ViewResult People() => View();

        public ViewResult Careers() => View();

        public ViewResult Contact() => View();
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TKPartnersV2.Models;

namespace TKPartnersV2.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private INewsRepository repository;

        public NavigationMenuViewComponent(INewsRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

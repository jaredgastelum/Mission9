using System;
using System.Linq;
using AmazonProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmazonProject.Components
{
    public class TypesViewComponent : ViewComponent 
    {
        private IAmazonProjectRepository repo { get; set; }

        public TypesViewComponent (IAmazonProjectRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["bookType"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}

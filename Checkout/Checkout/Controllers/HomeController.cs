using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Checkout.Business;
using Checkout.Models;
using Checkout.Services;

namespace Checkout.Controllers
{
    public class HomeController : Controller
    {
        private IDataContext _contextService;

        public ActionResult Index()
        {
            IDataContext obj = new DataContext();
            var items = obj.GetAllItems();
            //var items = _contextService.GetAllItems();

            var viewModel = new List<ItemViewModel>(from item in items
                select new ItemViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    OfferItemCount = item.OfferItemCount,
                    OfferPrice = item.OfferPrice
                });

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public HomeController(IDataContext contextService)
        {
            _contextService = contextService;
        }

        public HomeController()
        {
            
        }
    }
}
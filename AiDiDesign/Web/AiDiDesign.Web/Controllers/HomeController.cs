namespace AiDiDesign.Web.Controllers
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using AiDiDesign.Data.Models;
    using AiDiDesign.Data.Common.Repositories;
    using AiDiDesign.Web.ViewModels;

    public class HomeController : BaseController
    {
        IRepository<Furniture> products;

        public HomeController(IRepository<Furniture> products)
        {
            this.products = products;
        }

        public ActionResult Index()
        {
            if (this.HttpContext == null)
            {
                return null;
            }
            if (this.HttpContext.Cache["HomePageProducts"] == null)
            {
                var listOfProducts = this.products.All().OrderByDescending(x => x.Id).Take(6).Project().To<ProductHomeViewModel>();

                this.HttpContext.Cache.Add("HomePageProducts", listOfProducts.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Default, null);
            }

            var categories = this.data.FurnitureTypes.All().Project().To<FurnitureTypeViewModel>();
            this.ViewData.Add("Categories", categories);

            return this.View(this.HttpContext.Cache["HomePageProducts"]);
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

        public ActionResult GetImage(Guid id)
        {
            string imageSrc = this.products.All().Project().To<ProductHomeViewModel>().FirstOrDefault(x => x.Id == id).PicturesSource.FirstOrDefault().PictureUrl;
            var imageBitmap = new Bitmap(AiDiDesign.Common.Extensions.GetImageFromUrl(imageSrc));
            byte[] imageByte = AiDiDesign.Common.Extensions.ImageToByteArray(imageBitmap);
            return this.File(imageByte, "image/jpg");;
        }
    }
}
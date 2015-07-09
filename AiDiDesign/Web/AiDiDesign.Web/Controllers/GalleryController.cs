namespace AiDiDesign.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using AiDiDesign.Data;
    using AiDiDesign.Data.Common.Repositories;
    using AiDiDesign.Data.Models;
    using AiDiDesign.Web.ViewModels;
    using System.IO;

    public class GalleryController : BaseController
    {
        IRepository<Furniture> products;

        public GalleryController(IRepository<Furniture> products)
        {
            this.products = products;
        }

        // GET: Gallery
        public ActionResult Index()
        {
            var listOfProducts = this.products.All().Project().To<ProductHomeViewModel>();
            return View(listOfProducts.ToList());
        }

        // GET: Gallery/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductHomeViewModel productHomeViewModel = products.All().Where(x => x.Id == id).Project().To<ProductHomeViewModel>().FirstOrDefault();
            if (productHomeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(productHomeViewModel);
        }

        // GET: Gallery/Create
        public ActionResult Create()
        {
           var types = this.data.FurnitureTypes.All().Project().To<FurnitureTypeViewModel>().ToArray();
            //var typesDict = new Dictionary<FurnitureTypeViewModel, bool>();

            //foreach (var item in types)
            //{
            //    typesDict.Add(item, false);
            //}

            //var productFurnitureTypeModel = new ProductFurnitureTypeViewModel()
            //                                    {
            //                                        ProductHomeViewModel = new ProductHomeViewModel(),
            //                                        FurnitureTypeViewModels = types
            //                                    };

            ViewData["Types"] = types;

            return View();
        }

        // POST: Gallery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductHomeViewModel productHomeViewModel, IEnumerable<HttpPostedFileBase> files, string[] productTypes)
        {
            if (ModelState.IsValid)
            {
                if (productHomeViewModel == null)
                {
                    return HttpNotFound();
                }

                productHomeViewModel.Id = Guid.NewGuid();
                Furniture furniture = new Furniture()
                {
                    Description = productHomeViewModel.Description,
                    IsDeleted = false,
                    IsHidden = false,
                    Name = productHomeViewModel.Name,
                    Price = productHomeViewModel.Price,
                    Quantity = productHomeViewModel.Quantity
                };

                ICollection<Picture> pictures = new HashSet<Picture>();

                foreach (var file in files)
                {
                    // ToDo: Make check for .jpg files
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                        file.SaveAs(path);

                        Picture pic = new Picture()
                                    {
                                        Furniture = furniture,
                                        FurnitureId = furniture.Id,
                                        IsDeleted = false,
                                        IsHidden = false,
                                        PictureUrl = path
                                    };
                        pictures.Add(pic);
                    }
                }

                furniture.PicturesSource = pictures;

                // ToDo: Send two models to view
                foreach (var item in productTypes)
                {
                    if (item != "false")
                    {
                        var type = this.data.FurnitureTypes.All().Where(x => x.Name == item).FirstOrDefault();
                        type.Furnitures.Add(furniture);
                        furniture.FurnitureTypes.Add(type);
                    }
                }

                this.data.Furnitures.Add(furniture);
                this.data.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //    // POST: Gallery/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,Quantity")] ProductHomeViewModel productHomeViewModel)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            products.Entry(productHomeViewModel).State = EntityState.Modified;
        //            products.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(productHomeViewModel);
        //    }

        // GET: Gallery/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductHomeViewModel productHomeViewModel = products.All().Where(x => x.Id == id).Project().To<ProductHomeViewModel>().FirstOrDefault();
            if (productHomeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(productHomeViewModel);
        }

        //    // POST: Gallery/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(Guid id)
        //    {
        //        ProductHomeViewModel productHomeViewModel = products.GetById(id).Project().To<ProductHomeViewModel>();
        //        products.All().Project().To<ProductHomeViewModel>().Remove(productHomeViewModel);
        //        products.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            products.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
    }
}

using MvcApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MvcApi.Controllers
{
    public class ProductsController : Controller
    {
        MvcCategoryModel cat;
        // GET: Products
        public ActionResult Index()
        {
            IEnumerable<MvcProductsModel> prodList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            prodList = response.Content.ReadAsAsync<IEnumerable<MvcProductsModel>>().Result;

            return View(prodList);
        }
        public ActionResult AddOrEdit(int? id)
        {

            if(id == 0)
            {
                return View(new MvcProductsModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/"+id.ToString()).Result;
                var prodObj = response.Content.ReadAsAsync<MvcProductsModel>().Result;

                //HttpResponseMessage catresponse = GlobalVariables.WebApiClient.GetAsync("Categories").Result;
                //var catObj = catresponse.Content.ReadAsAsync<IEnumerable<MvcCategoryModel>>().Result;

                //ViewBag.CategoryId = new SelectList(catObj, "CategoryId", "CategoryName", cat.CategoryId);
                return View(prodObj);
               
            }
            
        }
        public ActionResult Details(int? id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/"+id.ToString()).Result;
            var prodList = response.Content.ReadAsAsync<MvcProductsModel>().Result;
            return View(prodList);
        }
    }
}
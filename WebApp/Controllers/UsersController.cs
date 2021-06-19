using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataPersistence.Database;
using DataPersistence.Models;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        // GET: UsersController
        [HttpGet("users")]
        public ActionResult Index()
        {
            var obj = new DataPersistence.Database.UserMaintenance();
            var list = obj.GetAll();
            return View(list);
        }

        [HttpGet("users/{id}")]
        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            ViewData["UserId"] = id;
            return View(new UserView(id));
        }
                
        [HttpGet("users/{id}/search")]
        // GET: UsersController/Search
        public ActionResult Search(int id, string keyword, string location, string country, int? distance, string hour, bool? favorites, bool? open)
        {
            if (keyword == null)  keyword = "";
            if (location == null) location = "";
            if (country == null) country = "";
            if (distance == null) distance = 20;
            if (hour == null)  hour = Utils.getCurrentHour();
            
            if (favorites == null) favorites = false;
            if (open == null) open = true;

            var filter = new RestaurantFilter(keyword, location, country, hour, (int)distance, (bool)favorites, (bool)open);
            ViewData["UserId"] = id;
            ViewData["Filter"] = filter;
            ViewData["Keyword"] = keyword;
            ViewData["Location"] = location;
            ViewData["Country"] = country;
            ViewData["Distance"] = distance;
            ViewData["Favorites"] = favorites;
            ViewData["Open"] = open;
            ViewData["Hour"] = hour;
            
            RestaurantsView view = new UserView().SearchRestaurants(id, filter);
            
            return View(view);

        }

        [HttpGet("users/{id}/addfavorite/{restaurantId}")]
        public ActionResult AddFavorite(int id, int restaurantId)
        {
            new UserView().FavoriteAdd(id, restaurantId);
            return RedirectToAction("Index");
        }

        [HttpGet("users/{id}/removefavorite/{restaurantId}")]
        public ActionResult RemoveFavorite(int id, int restaurantId)
        {
            new UserView().FavoriteRemove(id, restaurantId);
            return RedirectToAction("Index");
        }

        [HttpGet("users/{id}/addblacklist/{restaurantId}")]
        public ActionResult AddBlacklist(int id, int restaurantId)
        {
            new UserView().BlacklistAdd(id, restaurantId);
            return RedirectToAction("Index");
        }

        [HttpGet("users/{id}/removeblacklist/{restaurantId}")]
        public ActionResult RemoveBlacklist(int id, int restaurantId)
        {
            new UserView().BlacklistRemove(id, restaurantId);
            return RedirectToAction("Index");
        }


    }
}

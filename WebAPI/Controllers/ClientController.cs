using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataPersistence.Database;
using DataPersistence.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    /// <summary>
    ///  Controller: ClientController
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        // GET <ClientController>/5
        [HttpGet("user/{id}")]
        public UserView Get(int id)
        {
            return new UserView(id);
        }

        [HttpPost("user/{id}/search")]
        public RestaurantsView SearchRestaurants(int id, RestaurantFilter filter)
        {
            if (id > 0 && filter != null)
                return new UserView().SearchRestaurants(id, filter);
            else
                return null;
        }

        [HttpPost("user/{id}/addfavorite/{hotelid}")]
        public void FavoriteAdd(int id, int hotelid)
        {
            if (id > 0 && hotelid>0)
                new UserView().FavoriteAdd(id, hotelid);
        }

        [HttpPost("user/{id}/removefavorite/{hotelid}")]
        public void FavoriteRemove(int id, int hotelid)
        {
            if (id >0 && hotelid>0)
                new UserView().FavoriteRemove(id, hotelid);
        }

        [HttpPost("user/{id}/addblacklist/{hotelid}")]
        public void BlacklistAdd(int id, int hotelid)
        {
            if (id > 0 && hotelid > 0)
                new UserView().BlacklistAdd(id, hotelid);
        }

        [HttpPost("user/{id}/removeblacklist/{hotelid}")]
        public void BlacklistRemove(int id, int hotelid)
        {
            if (id > 0 && hotelid > 0)
                new UserView().BlacklistRemove(id, hotelid);
        }

    }
}

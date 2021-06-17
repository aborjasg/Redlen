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
    /// Controller: RestaurantController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private RestaurantMaintenance _restaurants;

        public RestaurantController()
        {
            _restaurants = new RestaurantMaintenance();
        }
        // GET: api/<RestaurantController>
        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _restaurants.GetAll();
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public Restaurant Get(int id)
        {
            return _restaurants.GetOne(id);
        }

        // POST api/<RestaurantController>/add
        [HttpPost("add")]
        public void Add([FromBody] Restaurant item)
        {
            _restaurants.Add(item);
        }

        // POST api/<RestaurantController>/update
        [HttpPost("update")]
        public void Update([FromBody] Restaurant item)
        {
            _restaurants.Update(item);
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _restaurants.Delete(id);
        }
    }
}

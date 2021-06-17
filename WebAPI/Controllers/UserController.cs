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
    /// Controller: UserController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserMaintenance _systemusers;

        public UserController()
        {
            _systemusers = new UserMaintenance();
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<SystemUser> Get()
        {
            return _systemusers.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public SystemUser Get(int id)
        {
            return _systemusers.GetOne(id);
        }

        // POST api/<UserController>/add
        [HttpPost("add")]
        public void Post([FromBody] SystemUser item)
        {
            _systemusers.Add(item);
        }

        // POST api/<UserController>/update
        [HttpPost("update")]
        public void Update([FromBody] SystemUser item)
        {
            _systemusers.Update(item);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _systemusers.Delete(id);
        }
    }
}

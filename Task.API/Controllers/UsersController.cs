using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task.API.Models;
using Bogus;
using Task.API.Fake;

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController:ControllerBase
    {  
        private List<User> _users = FakeData.GetUsers(5);
        [HttpGet]
        public List<User> Get ()
        {
            return _users;
        }
        [HttpGet("{ID}")]
        public User Get(int ID)
        {
            var user = _users.FirstOrDefault(x => x.ID == ID);
            return user;
        }

        [HttpPost]
        public User Post([FromBody] User user)
        {
            _users.Add(user);
            return user;
        }
        [HttpPut]
        public User Put([FromBody] User user)
        {
            var editedUser = _users.FirstOrDefault(x => x.ID == user.ID);
            editedUser.Firstname = user.Firstname;
            editedUser.Lastname = user.Lastname;
            editedUser.Address = user.Address;
            return user;
        }

        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {
            var deletedUser= _users.FirstOrDefault(x => x.ID == ID);
            _users.Remove(deletedUser);
        }
    }
}

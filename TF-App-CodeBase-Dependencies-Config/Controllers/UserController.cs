using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Logic.Managers;

namespace WebApiCerti.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            UserManager userMgr = new UserManager();
            return Ok(userMgr.GetUsers());
        }
    }
}

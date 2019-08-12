using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CB.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CB.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DBSettingsController : ControllerBase
    {
        public DBSettingsController()
        {

        }
        [HttpGet]
        public IEnumerable<DBLink> Get()
        {
            return new List<DBLink>() { new DBLink {  IP = "10.50.132.10", UserName = "sa", PWD = "1234.com" ,Name ="acs",DBName="fastdev"},
             new DBLink {  IP = "10.50.132.10", UserName = "sa", PWD = "1234.com" ,Name ="acsorder",DBName="acsorder"}}.ToArray();
        }
    }
}
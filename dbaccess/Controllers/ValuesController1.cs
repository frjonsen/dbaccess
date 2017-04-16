using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbaccess.Models;
using System.Net.Sockets;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dbaccess.Controllers
{
    [Route("/")]
    public class ValuesController1 : Controller
    {

        private readonly UserContext userContext;

        public ValuesController1(UserContext u)
        {
            userContext = u;
        }

        // GET: api/values
        [HttpGet]
        public string Get()
        {
            try
            {
                User user = new Models.User();
                user.Name = "Some name";
                
                userContext.Users.Add(user);
                userContext.SaveChanges();
            
                var u = userContext.Users.First();
                var name = u.Name;
                return name;
            }
            catch (SocketException se)
            {
                System.Console.WriteLine(se.Message);
            }
            catch (PostgresException pe)
            {
                System.Console.WriteLine(pe.Message);
            }
            return "Oops";
            //return new string[] { "value1", "value2" };
        }
    }
}

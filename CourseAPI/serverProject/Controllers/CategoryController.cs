using Microsoft.AspNetCore.Mvc;
using serverProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private static List<Category> categories = new List<Category> {
                new Category { id = 1, name = "Programming", icon = "code" },
                new Category { id = 2, name = "Design", icon = "paint-brush" },
                new Category { id = 3, name = "Business", icon = "briefcase" },
                new Category { id = 4, name = "Language", icon = "language" },
                new Category { id = 5, name = "Health", icon = "heart" }
        };
        private static int counter = 0;
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categories;
        }

        // GET: api/<CategoryController>?nane=name
        //[HttpGet]
        //public int Get(string name)
        //{
        //    return categories.Where(c => c.name == name).FirstOrDefault().id;
        //}

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return categories.Find(c => c.id == id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] Category value)
        {
            value.id = ++counter;
            categories.Add(value);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category value)
        {
            var c = categories.Find(c => c.id == id);
            if (c is null)
            {
                c.id = ++counter;
                categories.Add(c);
            }
            else
            {
                c.name = value.name;
                c.icon = value.icon;
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var c = categories.Find(c => c.id == id);
            categories.Remove(c);
        }
    }
}

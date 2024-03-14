using Microsoft.AspNetCore.Mvc;
using serverProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverProject.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private static List<Course> courses = new List<Course>  {
                new Course(1, "Introduction to Programming", 1, 12, new DateTime(2022, 3, 15), new List<string> {"Basic concepts", "Data types", "Control structures"}, LearningWay.Zoom, 1, "C:\\Users\\user\\Documents\\תכנות\\courseProject\\src\\assets\\img1.JPG"),
                new Course(2, "Artificial Intelligence Fundamentals", 2, 10, new DateTime(2022, 4, 10), new List<string> {"Machine learning", "Neural networks", "Deep learning"}, LearningWay.frontal, 2, "C:\\Users\\user\\Documents\\תכנות\\courseProject\\src\\assets\\img2.JPG"),
                new Course(3, "Financial Management", 3, 8, new DateTime(2022, 4, 25), new List<string> {"Budgeting", "Investment analysis", "Risk management"}, LearningWay.Zoom, 3, "C:\\Users\\user\\Documents\\תכנות\\courseProject\\src\\assets\\img3.JPG"),
                new Course(4, "Introduction to Psychology", 4, 15, new DateTime(2022, 5, 5), new List<string> {"Behavioral psychology", "Cognitive psychology", "Developmental psychology"}, LearningWay.frontal, 4, "C:\\Users\\user\\Documents\\תכנות\\courseProject\\src\\assets\\img4.JPG"),
                new Course(5, "Graphic Design Basics", 5, 6, new DateTime(2022, 5, 20), new List<string> {"Color theory", "Typography", "Layout design"}, LearningWay.Zoom, 5, "C:\\Users\\user\\Documents\\תכנות\\courseProject\\src\\assets\\img5.JPG")
            };
        private static int counter = 0;
        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return courses;
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public Course Get(int id)
        {
            return courses.Find(c=>c.id==id);
        }

        // POST api/<CourseController>
        [HttpPost]
        public void Post([FromBody] Course value)
        {
            value.id = ++counter;
            courses.Add(value);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Course value)
        {
            var c = courses.Find(c => c.id == id);
            if (c is null)
            {
                c.id = ++counter;
                courses.Add(c);
            }
            else
            {
                c.name = value.name;
                c.start = value.start;
                c.countOfLessons = value.countOfLessons;
                c.categoryId = value.categoryId;
                c.image = value.image;
                c.learningWay = value.learningWay;
                c.syllabus = value.syllabus;
                c.lecturerId = value.lecturerId;    
            }
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var c= courses.Find(c => c.id == id);
            courses.Remove(c);
        }
    }
}

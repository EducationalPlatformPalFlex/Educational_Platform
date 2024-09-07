using Educational_Platform.Database_Connection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;

namespace Educational_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly DatabaseContext _DatabaseContext;

        public HomeController(DatabaseContext dbContext)
        {
            _DatabaseContext = dbContext;
        }

        [HttpGet]
        [Route("getCourses")]
        public string GetCourses()
        {
            var AllCourses = _DatabaseContext.Course.ToList();
            int IsCoursesExisting = AllCourses.Count;

            if (IsCoursesExisting == 0)
                return "Null";

            else
            {
                JavaScriptSerializer JsData = new JavaScriptSerializer();
                JsData.MaxJsonLength = int.MaxValue;
                string Result = JsData.Serialize(AllCourses);
                return Result;
            }
        }
    }
}

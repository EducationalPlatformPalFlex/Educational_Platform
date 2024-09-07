using Educational_Platform.Database_Connection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;

namespace Educational_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseDetailsController : ControllerBase
    {
        private readonly DatabaseContext _DatabaseContext;

        public CourseDetailsController(DatabaseContext dbContext)
        {
            _DatabaseContext = dbContext;
        }

        [HttpGet]
        [Route("getCourse/{Id}")]
        public string GetCourses(string Id)
        {
            int courseID = int.Parse(Id);
            var CourseDetails = (from course in _DatabaseContext.Course
                                  where course.ID == courseID
                                 select new { course }).ToList();

            int IsCoursesExisting = CourseDetails.Count;

            if (IsCoursesExisting == 0)
                return "Null";

            else
            {
                JavaScriptSerializer JsData = new JavaScriptSerializer();
                JsData.MaxJsonLength = int.MaxValue;
                string Result = JsData.Serialize(CourseDetails);
                return Result;
            }
        }
    }
}

using Educational_Platform.Database_Connection;
using Educational_Platform.Models;
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
          
            var CourseDetails = from course in _DatabaseContext.Course where course.ID == int.Parse(Id)
                                join techer in _DatabaseContext.Teacher on course.TeacherID equals techer.ID
                                join user in _DatabaseContext.User on techer.UserID equals user.ID
                                select new { course.ID, course.TeacherID, course.Title, course.Description, course.Status, course.Price, techer.AcademicDegree, techer.Experience, user.Name };

            int IsCoursesExisting = CourseDetails.Count();

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

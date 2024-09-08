using Educational_Platform.Database_Connection;
using Educational_Platform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;

namespace Educational_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private readonly DatabaseContext _Conn;

        public CoursesController(DatabaseContext Conn)
        {
            _Conn = Conn;
        }

        [HttpGet]
        [Route("AllCourses")]
        public string GetAllCourses()
        {


            var GetData = from course in _Conn.Course
                          join techer in _Conn.Teacher on course.TeacherID equals techer.ID
                          join user in _Conn.User on techer.UserID equals user.ID
                          select new { course.ID, course.TeacherID, course.Title, course.Description, course.Status, course.Price, techer.AcademicDegree, techer.Experience, user.Name };


            JavaScriptSerializer JsData = new JavaScriptSerializer();
            JsData.MaxJsonLength = int.MaxValue;
            string AllCourses = JsData.Serialize(GetData);

            return AllCourses;
        }


        [HttpGet]
        [Route("AddCourse/{TeacherID}/{Title}/{Description}/{Status}/{Price}")]
        public string AddCourse(int TeacherID, string Title, string Description, string Status, string Price)
        {
            Course ObjCourse = new Course();
            ObjCourse.TeacherID = TeacherID;
            ObjCourse.Title = Title;
            ObjCourse.Description = Description;
            ObjCourse.Status = Status;
            ObjCourse.Price = Price;

            _Conn.Course.Add(ObjCourse);
            _Conn.SaveChanges();


            JavaScriptSerializer JsData = new JavaScriptSerializer();
            JsData.MaxJsonLength = int.MaxValue;
            string Course = JsData.Serialize(ObjCourse);

            return "Course Added\n" + Course;
        }

    }
}

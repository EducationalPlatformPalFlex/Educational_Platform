using System.Data;
using System.Net;
using Educational_Platform.Database_Connection;
using Educational_Platform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;

namespace Educational_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboradController : ControllerBase
    {
        private readonly DatabaseContext _DatabaseContext;

        public DashboradController(DatabaseContext dbContext)
        {
            _DatabaseContext = dbContext;
        }

        [HttpGet]
        [Route("addCourse/{teacherID}/{title}/{description}/{status}/{price}")]
        public string AddCourse(string teacherID, string title, string description, string status, string price) 
        {
            Course course = new Course();
            course.TeacherID = int.Parse(teacherID);
            course.Title = title;
            course.Description = description;
            course.Status = status;
            course.Price = price;
            _DatabaseContext.Course.Add(course);
            _DatabaseContext.SaveChanges();

            JavaScriptSerializer JsData = new JavaScriptSerializer();
            JsData.MaxJsonLength = int.MaxValue;
            string Result = JsData.Serialize(course);
            return Result;
        }

        [HttpGet]
        [Route("updateCourse/{id}/{title}/{description}/{status}/{price}")]
        public string UpdateCourse(string id, string title, string description, string status, string price) 
        {
            int idcourse = int.Parse(id);
            Course course = new Course();
            course = _DatabaseContext.Course.Single(Node => Node.ID == idcourse);
            course.Title = title;
            course.Description = description;
            course.Status = status;
            _DatabaseContext.Course.Update(course);
            _DatabaseContext.SaveChanges();

            JavaScriptSerializer JsData = new JavaScriptSerializer();
            JsData.MaxJsonLength = int.MaxValue;
            string Result = JsData.Serialize(course);
            return Result;
        }

        [HttpGet]
        [Route("deleteCourse/{id}")]
        public string DeleteCourse(string id) 
        {
            int idcourse = int.Parse(id);
            Course course = new Course();
            course = _DatabaseContext.Course.Single(Node => Node.ID == idcourse);
            _DatabaseContext.Course.Remove(course);
            _DatabaseContext.SaveChanges();
            return "Course Deleted";
        }

        [HttpGet]
        [Route("getCoursesTeacher/{teacherId}")]
        public string GetCourses(string teacherId) 
        {
            int TID = int.Parse(teacherId);
            var CoursesTeacher = (from course in _DatabaseContext.Course
                                  where course.TeacherID == TID
                                  select new {course.ID,course.Title}).ToList();

            int IsCoursesExisting = CoursesTeacher.Count;

            if (IsCoursesExisting == 0)
                return "Null";

            else
            {
                JavaScriptSerializer JsData = new JavaScriptSerializer();
                JsData.MaxJsonLength = int.MaxValue;
                string Result = JsData.Serialize(CoursesTeacher);
                return Result;
            }
        }
    }
}

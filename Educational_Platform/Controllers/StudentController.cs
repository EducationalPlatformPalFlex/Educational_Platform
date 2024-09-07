using Educational_Platform.Database_Connection;
using Educational_Platform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;

namespace Educational_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {



        private readonly DatabaseContext _Conn;

        public StudentController(DatabaseContext Conn)
        {
            _Conn = Conn;
        }

        [HttpGet]
        [Route("AddCourse/{CourseID}/{StudentID}")]
        public string AddCourse(int CourseID, int StudentID)
        {


            var GetCS = (from CS in _Conn.CourseStudent
                         where CS.CourseID == CourseID && CS.StudentID_ForCourseStudent == StudentID
                         select new { CS.CourseID }).ToList();

            var GetCourse = (from Course in _Conn.Course
                            where Course.ID == CourseID
                            select new { Course.ID}).ToList();

            var GetStudent = (from Student in _Conn.Student
                          where Student.ID == StudentID
                          select new { Student.ID }).ToList();

            int CountCS = GetCS.Count();
            int CountCourse  = GetCourse.Count();
            int CountStudent = GetStudent.Count();

            if (CountCS == 1)
            {
                return "Your Are Already in The Course";
            }
            else if(CountCourse == 1 && CountStudent == 1)
            {
                CourseStudent ObjCS = new CourseStudent();
                ObjCS.CourseID = CourseID;
                ObjCS.StudentID_ForCourseStudent = StudentID;
                ObjCS.JoinDate = DateTime.Now.ToString();


                _Conn.CourseStudent.Add(ObjCS);
                _Conn.SaveChanges();

                JavaScriptSerializer JsData = new JavaScriptSerializer();
                JsData.MaxJsonLength = int.MaxValue;
                string StudentCourse = JsData.Serialize(ObjCS);

                return " The course has been registered" + StudentCourse;

            }
            else if (CountCourse == 0 && CountStudent == 1)
            {
               
                return "Course Not Found" + CountCourse;
            }
            else if (CountCourse == 1 && CountStudent == 0)
            {
                return "Student Not Found";
            }
            else if (CountCourse == 0 && CountStudent == 0)
                return "Course And Student Not Found";
            else
                return "Something went Wrong";

          


         
        }
    }
}

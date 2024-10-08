﻿using Educational_Platform.Database_Connection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Educational_Platform.Models;

namespace Educational_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly DatabaseContext _DatabaseContext;

        public AuthenticationController(DatabaseContext dbContext)
        {
            _DatabaseContext = dbContext;
        }

        [HttpGet]
        [Route("signup/{name}/{photo}/{address}/{role}/{email}/{password}/{city}")]
        public string SignUpUser(string name, string photo,string address, string role, 
                                 string email, string password, string city) 
        {
            var UserData = (from user in _DatabaseContext.User
                            where user.Email == email select user.ID ).ToList();

            var IsUserExisting = UserData.Count();

            if (IsUserExisting == 0)
            {
                User user = new User();
                user.Name = name;
                user.Photo = photo;
                user.Address = address;
                user.Role = role;
                user.Email = email;
                user.Password = password;
                user.City = city;
                _DatabaseContext.User.Add(user);
                _DatabaseContext.SaveChanges();

                JavaScriptSerializer JsData = new JavaScriptSerializer();
                JsData.MaxJsonLength = int.MaxValue;
                string Result = JsData.Serialize(user);
                return Result;
            }
            else
                return "User Exist";
        }

        [HttpGet]
        [Route("signupTeacher/{userID}/{academicDegree}/{experience}/{phoneNumber}/{birthdate}")]
        public string SignUpTeacher(string userID, string academicDegree, string experience, string phoneNumber, string birthdate)
        {
            Teacher teacher = new Teacher();
            teacher.UserID = int.Parse(userID);
            teacher.AcademicDegree = academicDegree;
            teacher.Experience = experience;
            teacher.PhoneNumber = int.Parse(phoneNumber);
            teacher.Birthdate = birthdate;
            _DatabaseContext.Teacher.Add(teacher);
            _DatabaseContext.SaveChanges();

            JavaScriptSerializer JsData = new JavaScriptSerializer();
            JsData.MaxJsonLength = int.MaxValue;
            string Result = JsData.Serialize(teacher);
            return Result;
        }

        [HttpGet]
        [Route("signupStudent/{userID}/{classStudent}/{academicDegree}/{interests}")]
        public string SignUpStudent(string userID, string classStudent, string academicDegree, string interests)
        {
            Student student = new Student();
            student.UserID = int.Parse(userID);
            student.Class = classStudent;
            student.AcademicDegree = academicDegree ;
            student.Interests = interests;

            _DatabaseContext.Student.Add(student);
            _DatabaseContext.SaveChanges();

            JavaScriptSerializer JsData = new JavaScriptSerializer();
            JsData.MaxJsonLength = int.MaxValue;
            string Result = JsData.Serialize(student);
            return Result;
        }

        [HttpGet]
        [Route("login/{email}/{password}")]
        public string LoginUser(string email, string password)
        {
            var UserData = (from user in _DatabaseContext.User
                            where user.Email == email && user.Password == password
                            select new { user.Name, user.Photo, user.Address, user.Role, user.City })
                            .ToList();

            int IsUserExisting = UserData.Count;

            if (IsUserExisting == 0)
                return "Null";

            else if (IsUserExisting == 1)
            {
                JavaScriptSerializer JsData = new JavaScriptSerializer();
                JsData.MaxJsonLength = int.MaxValue;
                string Result = JsData.Serialize(UserData);
                return Result;
            }
                
            else
                return "Error";
        }
    }
}

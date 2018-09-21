using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class CourseManager
    {
        private CourseGateway courseGateway;

        public CourseManager()
        {
            courseGateway = new CourseGateway();
        }

        public string SaveCourse(Course course)
        {
            string message = courseGateway.isExisted(course);
            if (message.Equals("success"))
            {
                int rowAffect = courseGateway.SaveCourse(course);
                if (rowAffect > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save Failed";
                }

            }
            else
            {
                return message;
            }
        }

        public List<Course> GetAllCoursebyStudentId(int StudentId)
        {
            return courseGateway.GetAllCourseByStudentId(StudentId);
        }

        public List<SelectListItem> GetAllCourseByStudentIdForDropDownList(int studentId)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            List<Course> getAllCourseList = courseGateway.GetAllCourseByStudentId(studentId);


            foreach (Course aCourse in getAllCourseList)
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Text = aCourse.CourseCode;
                selectList.Value = aCourse.CourseId.ToString();
                selectListItems.Add(selectList);
            }
            return selectListItems;
        }

        public List<SelectListItem> GetAllSemesterForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });
            foreach (Semester semester in courseGateway.GetAllSemesters())
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = semester.SemesterName;
                selectListItem.Value = semester.SemesterId.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

    }
}
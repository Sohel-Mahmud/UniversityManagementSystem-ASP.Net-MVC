using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if (course.Credit > 0.4 && course.Credit < 5.0)
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
                return "Credit must be within 0.5 to 5.0";
            }
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
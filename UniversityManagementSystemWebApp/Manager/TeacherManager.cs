using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class TeacherManager
    {
        private TeacherGateway teacherGateway;
       // private double remainingCredit;

        public TeacherManager()
        {
            teacherGateway = new TeacherGateway();
        }


        public string SaveTeacher(Teacher teacher)
        {

            if (!teacherGateway.IsExists(teacher))
            {
                int rowAffected = teacherGateway.SaveTeacher(teacher);
                if (rowAffected > 0)
                {
                    return "Save successful";
                }
                else
                {
                    return "Save Failed";
                }
            }
            else
            {
                return "Email is already existed";
            }

        }
        public List<SelectListItem> GetAllDesignationForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });
            foreach (Designations designations in teacherGateway.GetAllDesignation())
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = designations.DesignationName;
                selectListItem.Value = designations.DesignationsId.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }
        public string AssignCourseToTeacher(AssignCourse assignCourse)
        {
            if (!teacherGateway.isExisted(assignCourse))
            {
                int rowAffected = teacherGateway.AssignCourseToTeacher(assignCourse);
                if (rowAffected > 0)
                {
                    return "Successfully Assigned";
                }
                else
                {
                    return "Assigned Failed";
                }
            }
            else
            {
                return "This course is already Assigned";
            }

        }

        public List<Teacher> GetAllTeacherByDeptID(int DepartmentId)
        {
            return teacherGateway.GetAllTeacherByDeptID(DepartmentId);
        }

        public Teacher GetTeacherInfoByTeacherId(int TeacherId)
        {
            return teacherGateway.GetTeacherInfoByTeacherId(TeacherId);
        }

        public List<Course> GetAllCourseCodeByDeptId(int departmentId)
        {
            return teacherGateway.GetAllCourseCodeByDeptId(departmentId);
        }

        public Course GetCourseNameCreditByCourseId(int courseId)
        {
            return teacherGateway.GetCourseNameCreditByCourseId(courseId);
        }

        public double GetCreditTakenSumOfTeacherByTeacherId(int teacherId)
        {
            return teacherGateway.GetCreditTakenSumOfTeacherByTeacherId(teacherId);
        }

    }
}
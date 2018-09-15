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

        public TeacherManager()
        {
            teacherGateway = new TeacherGateway();
        }

        public string SaveTeacher(Teacher teacher)
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
    }
}
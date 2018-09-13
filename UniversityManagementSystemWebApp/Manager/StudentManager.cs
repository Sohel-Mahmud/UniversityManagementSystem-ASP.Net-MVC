using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class StudentManager
    {
        private StudentGateway studentGateway;

        public StudentManager()
        {
            studentGateway = new StudentGateway();
        }

        public string Save(Student student)
        {
            if (!studentGateway.IsExists(student))
            {
                int rowAffect = studentGateway.Save(student);
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
                return "Given Email Already Exists!!!";
            }
        }

        public int GetRowCount()
        {
           return studentGateway.GetRowCount();
        }

        public Student GetStudentbyId(int id)
        {
            return studentGateway.GetStudentbyId(id);
        }

        public List<Student> GetAllStudents()
        {
            return studentGateway.GetAllStudents();
        }
    }

}
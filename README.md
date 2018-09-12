# UniversityManagementSystem-ASP.Net-MVC
This web application is only for using one semester only of a university. If it will make user happy in a semester, university will then ask you for changing several features so that it can be used for long time. So, just think about the stories and features below (don’t think about the future). Noted that, you are not authorized person for changing any specification. 
For accessing all the features below, you should make a home page and keep menus/submenus or links accordingly. 

# 1. Save Department 

During department saving, you must ensure that, code and name must be unique. Noted that, code must be two (2) to seven (7) characters long. 

![alt text](https://github.com/Sohel-Mahmud/UniversityManagementSystem-ASP.Net-MVC/blob/master/sss.PNG)
# 2. View All Departments 

In this page, all the existing department information will be displayed. 

# 3. Save Course 

Here, code and name must be unique. Code must be at least five (5) characters long. Credit range is from 0.5 to 5.0 i.e. credit cannot be less than 0.5 and more than 5.0. Department DropDownList will be loaded with the existing department data from database. You should keep eight (8) semesters’ data in database and the semester DropDownList will be loaded with those data

# 4. Save Teacher 
During teacher saving, you must ensure that, email must be in correct format and unique.
You don’t need to make a UI for entering designation information, just keep some designation in database and Designation DropDownList will be loaded with those data. You also have to ensure that, Credit to be taken field must contain a non-negative value. 

# 5. Course Assign to Teacher 
User will select a department from the DropDownList and all the teachers’ name and course code of that specific
department will be loaded in the Teacher and Course Code DropDownList. When user will select a teacher,
Credit to be taken and Remaining credit will be displayed accordingly. When user will select a course code, 
Name and Credit of that course will be displayed. You must ensure to avoid overlapping problem.
A course cannot be assigned to more than one teacher, i.e. an assigned course cannot be assigned again.
If user tries to assign a course, which credit is more than teacher’s remaining credit, system will show an option (Yes/No) dialog box and work accordingly.
 
# 6. View Course Statics 
User will select a department and all the course information (Code, Name/Title, Semester and Assigned To) will be displayed accordingly.
If there is any course which is not assigned to any teacher yet, then in the Assigned To column there must be written “Not Assigned Yet”. 

# 7. Register Student 
During student registration, you must ensure that, email must be in correct format and unique. In date there should be a DatePicker, where current date should be selected by default. When register successfully, all the information will be displayed as well as a Registration Number. For registration number, there is a fixed format. Registration Number format: <dept code>-<current year>-XXX. For example, CSE-2012-001, CSE-2012-002, EEE-2012-001, EEE-2013-001, CSE-2013-001, BBA-2015-001, BBA-2015-002, BBA-2015-003. 
 
# 8. Allocate Classrooms 
Day DropDownList will be loaded with seven (7) days’ name of the week. Keep some room data in database and Room No. DropDownList will be loaded with those data. You must ensure to avoid the overlapping problem here. Both full and partial overlapping must be avoided. 

# 9. View Class Schedule and Room Allocation Information 
User will select a department, the class schedule and room allocation information of the courses of that particular department will be displayed. Noted that, for a single course, a single row will be generated, i.e. you cannot generate multiple rows for multiple schedule of a single course. If there is any course which is not scheduled yet, then in the Schedule Info column there must be written “Not Scheduled Yet”. 

# 10. Enroll In a Course 
Student Reg. No. DropDownList will be loaded with existing students’ registration numbers. User will select a registration number, and name, email, department of that particular student will be displayed. Select Course DropDownList will be loaded with the courses’ name of that selected student’s department. A student can enroll in a course once only. 

# 11. Save Student Result 
User will select a registration number, and name, email, department of that particular student will be displayed. Select Course DropDownList will be loaded with the enrolled courses’ name of that selected student. In the Select Grade Letter DropDownList, there will be thirteen (13) grades - A+, A, A-, B+, B, B-, C+, C, C-, D+, D, D-, and F. Note that result can be saved only for enrolled courses of that student. 

# 12. View Result 
User will select a registration number, and name, email, department along with the enrolled courses’ information (Course Code, Name and Grade) of that particular student will be displayed. If there is any course which is not graded yet, then in the Grade column there must be written “Not Graded Yet”. When user will click Make PDF button, a PDF will be generated with that student’s name, registration number, department, email and all the courses’ result in a nice format. 

# 13. Unassign All Courses 
When user will click the Unassign Courses button, a confirmation dialog box will be displayed: “Are you sure to unassign all courses?” with Yes/No button. If user clicks Yes button, all the courses will be unassigned. Noted that, you cannot delete data from database for unassigning courses. 
 
# 14. Unallocate All Classrooms 
When user will click the Unallocate Rooms button, a confirmation dialog box will be displayed: “Are you sure to unallocate all classrooms info?” with Yes/No button. If user clicks Yes button, all the classrooms will be unallocated, i.e. all class schedule and room allocation information will be unallocated/reset. Noted that, you can’t delete data from database when for unallocating classrooms information. 
 
 


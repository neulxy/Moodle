using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataAccessLayer;


namespace BusinessLayer
{
    public class StudentBusinessLayer
    {
        private MoodleDAL moodleDAL = new MoodleDAL();
        public List<Student> GetStudents()
        {
            return moodleDAL.Students.ToList();
        }

        /// <summary>
        /// Add a student
        /// </summary>
        /// <param name="student"></param>
        public void AddStudent(Student student)
        {
            moodleDAL.Students.Add(student);
            moodleDAL.SaveChanges();
        }

        /// <summary>
        /// Find a student using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student FindStudent(int id)
        {
            Student student = moodleDAL.Students.Find(id);
            return student;
        }

        public void SaveEditStudent(Student student)
        {
            moodleDAL.Entry(student).State = EntityState.Modified;
            moodleDAL.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            Student student = FindStudent(id);
            moodleDAL.Students.Remove(student);
            moodleDAL.SaveChanges();
        }

        public bool StudentExistsByStuId(string StuId)
        {
             return moodleDAL.Students.Where(item => item.StuId == StuId).Count() > 0;
        }

        /// <summary>
        /// return the student name with given student id
        /// </summary>
        /// <param name="stuId"></param>
        /// <returns></returns>
        public string FindStuName(string stuId)
        {
            List<Student> resultSet = moodleDAL.Students.Where(item => item.StuId == stuId).ToList();
            string stuName = null;
            if (resultSet.Count > 0)
            {
                stuName = resultSet.ElementAt(0).StuName;
            }
            return stuName;
        }

    }
}

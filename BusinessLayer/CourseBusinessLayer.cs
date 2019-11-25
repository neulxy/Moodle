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
    public class CourseBusinessLayer
    {
        private MoodleDAL moodleDAL = new MoodleDAL();
        public List<Course> GetCourses()
        {
            return moodleDAL.Courses.ToList();
        }

        /// <summary>
        /// Add a course
        /// </summary>
        /// <param name="course"></param>
        public void AddCourse(Course course)
        {
            moodleDAL.Courses.Add(course);
            moodleDAL.SaveChanges();
        }

        /// <summary>
        /// Find a course using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Course FindCourse(int id)
        {
            Course course = moodleDAL.Courses.Find(id);
            return course;
        }

        public void SaveEditCourse(Course course)
        {
            moodleDAL.Entry(course).State = EntityState.Modified;
            moodleDAL.SaveChanges();
        }

        /// <summary>
        /// return the course name with given course code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string FindCourseName(string code)
        {
            List<Course> resultSet = moodleDAL.Courses.Where(item => item.CourseCode == code).ToList();
            string CourseName = null;
            if (resultSet.Count > 0)
            {
                CourseName = resultSet.ElementAt(0).CourseName;
            }
            return CourseName;
        }


        public bool CourseExistByCode(string code)
        {
            return moodleDAL.Courses.Where(item => item.CourseCode == code).ToList().Count > 0;
        }

        public void DeleteCourse(int id)
        {
            Course course = FindCourse(id);
            moodleDAL.Courses.Remove(course);
            moodleDAL.SaveChanges();
        }

    }
}

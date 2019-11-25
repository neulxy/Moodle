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
    public class UserBusinessLayer
    {
        private MoodleDAL moodleDAL = new MoodleDAL();
        public List<User> GetUsers()
        {
            return moodleDAL.Users.ToList();
        }

        /// <summary>
        /// Add a user
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            moodleDAL.Users.Add(user);
            moodleDAL.SaveChanges();
        }

        /// <summary>
        /// Find a user using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User FindUser(int id)
        {
            User user = moodleDAL.Users.Find(id);
            return user;
        }

        public bool IsValidUser(User u)
        {
            if (moodleDAL.Users.Where(item => item.UserName==u.UserName && item.Password== u.Password).ToList().Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //public void SaveEditStudent(Student student)
        //{
        //    moodleDAL.Entry(student).State = EntityState.Modified;
        //    moodleDAL.SaveChanges();
        //}

        //public void DeleteStudent(int id)
        //{
        //    Student student = FindStudent(id);
        //    moodleDAL.Students.Remove(student);
        //    moodleDAL.SaveChanges();
        //}

        //public bool StudentExistsByStuId(string StuId)
        //{
        //     return moodleDAL.Students.Where(item => item.StuId == StuId).Count() > 0;
        //}

        /// <summary>
        /// return the student name with given student id
        /// </summary>
        /// <param name="stuId"></param>
        /// <returns></returns>
        //public string FindStuName(string stuId)
        //{
        //    List<Student> resultSet = moodleDAL.Students.Where(item => item.StuId == stuId).ToList();
        //    string stuName = null;
        //    if (resultSet.Count > 0)
        //    {
        //        stuName = resultSet.ElementAt(0).StuName;
        //    }
        //    return stuName;
        //}

    }
}

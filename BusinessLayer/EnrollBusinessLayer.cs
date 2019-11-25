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
    public class EnrollBusinessLayer
    {
        private MoodleDAL moodleDAL = new MoodleDAL();
        public List<Enroll> GetEnrolls()
        {
            return moodleDAL.Enrolls.ToList();
        }

        /// <summary>
        /// Add a student
        /// </summary>
        /// <param name="student"></param>
        public void AddEnroll(Enroll enroll)
        {
            moodleDAL.Enrolls.Add(enroll);
            moodleDAL.SaveChanges();
        }

        /// <summary>
        /// Find an enrollment using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Enroll FindEnroll(int id)
        {
            Enroll enroll = moodleDAL.Enrolls.Find(id);
            return enroll;
        }


        public void DeleteEnroll(int id)
        {
            Enroll enroll = FindEnroll(id);
            moodleDAL.Enrolls.Remove(enroll);
            moodleDAL.SaveChanges();
        }

        public bool EnrollExist(Enroll enroll)
        {
            return EnrollExist(enroll.StuId, enroll.CourseCode, enroll.Year.Value, enroll.Semester.Value);
        }

        public bool EnrollExist(string StuId, string CourseCode, int Year, int Semester)
        {
            return moodleDAL.Enrolls.Where(item => 
                                           item.StuId == StuId && 
                                           item.CourseCode == CourseCode &&
                                           item.Year == Year &&
                                           item.Semester == Semester).Count() > 0;
        }

    }
}

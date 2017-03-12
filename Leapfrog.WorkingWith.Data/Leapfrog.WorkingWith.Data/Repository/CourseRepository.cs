using Leapfrog.WorkingWith.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.WorkingWith.Data.Repository
{
  
        public interface ICourseRepository
        {
            void Insert(Courses courses);
            bool Delete(int Id);
            bool Delete(string name);
            Courses GetByID(int Id);
            Courses GetByName(string name);
            IList<Courses> GetAll();
        }
        public class CourseRepository : ICourseRepository
        {
            private IList<Courses> _CourseList = new List<Courses>();
            public void Insert(Courses courses)
            {
                _CourseList.Add(courses);
            }
            public bool Delete(int Id) 
            {
                Courses c = GetByID(Id);
                if (c != null)
                {
                    return _CourseList.Remove(c);
                }
                return false;
            }
            public bool Delete(string name) 
            {
                Courses c = GetByName(name);
                if (c != null)
                {
                    return _CourseList.Remove(c);
                }
                return false;
            }
            public Courses GetByID(int Id) 
            {
                foreach (Courses c in _CourseList)
                {
                    if (c.CourseID == Id)
                    {
                        return c;
                    }
                }
                return null;
            }
            public Courses GetByName(string name) 
            {
                foreach (Courses c in _CourseList)
                {
                    if (c.Name == name)
                    {
                        return c;
                    }
                }
                return null;
            }
            public IList<Courses> GetAll() 
            {
                return _CourseList;
            }
        }
    }


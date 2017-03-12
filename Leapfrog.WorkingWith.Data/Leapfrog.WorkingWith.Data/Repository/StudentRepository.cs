using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leapfrog.WorkingWith.Data.Models;

namespace Leapfrog.WorkingWith.Data.Repository
{
   
         public interface IStudentRepository
        {
            void Insert(Students Students);
            bool Delete(int Id);
            bool Delete(string name);
            Students GetByID(int Id);
            Students GetByName(string name);
            IList<Students> GetAll();
        }
        public class StudentRepository : IStudentRepository
        {
            private IList<Students> _StudentList = new List<Students>();
            public void Insert(Students Students)
            {
                _StudentList.Add(Students);
            }
            public bool Delete(int Id) 
            {
                Students c = GetByID(Id);
                if (c != null)
                {
                    return _StudentList.Remove(c);
                }
                return false;
            }
            public bool Delete(string name) 
            {
                Students c = GetByName(name);
                if (c != null)
                {
                    return _StudentList.Remove(c);
                }
                return false;
            }
            public Students GetByID(int Id) 
            {
                foreach (Students c in _StudentList)
                {
                    if (c.StudentID == Id)
                    {
                        return c;
                    }
                }
                return null;
            }
            public Students GetByName(string name) 
            {
                foreach (Students c in _StudentList)
                {
                    if (c.FirstName == name)
                    {
                        return c;
                    }
                }
                return null;
            }
            public IList<Students> GetAll() 
            {
                return _StudentList;
            }
        }
    }
    


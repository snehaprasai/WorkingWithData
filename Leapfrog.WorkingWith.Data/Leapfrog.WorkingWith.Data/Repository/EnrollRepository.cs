using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leapfrog.WorkingWith.Data.Models;

namespace Leapfrog.WorkingWith.Data.Repository
{
   
         public interface IEnrollRepository
        {
            void Insert(Enrollment Enroll);
            bool Delete(int Id);
            Enrollment GetByID(int Id);
           
            IList<Enrollment> GetAll();
        }
        public class EnrollRepository : IEnrollRepository
        {
            private IList<Enrollment> _EnrollList = new List<Enrollment>();
            public void Insert(Enrollment Enrolls)
            {
                _EnrollList.Add(Enrolls);
            }
            public bool Delete(int Id) 
            {
                Enrollment c = GetByID(Id);
                if (c != null)
                {
                    return _EnrollList.Remove(c);
                }
                return false;
            }
            
            
            public Enrollment GetByID(int Id)
            {
                foreach (Enrollment en in _EnrollList)
                {
                    if (en.StudentID == Id)
                    {
                        return en;
                    }
                }
                return null;

            }
           
            
            public IList<Enrollment> GetAll() 
            {
                return _EnrollList;
            }
        }
    }
    


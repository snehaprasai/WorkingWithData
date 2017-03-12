using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leapfrog.WorkingWith.Data.Repository;
using Leapfrog.WorkingWith.Data.Models;

namespace Leapfrog.WorkingWith.Data.Controller
{
    public class PaymentController
    { 
        public IPaymentRepository _PaymentRepository;
        private ICourseRepository _CourseRepository = new CourseRepository();
        private IStudentRepository _StudentRepository = new StudentRepository();
        private IEnrollRepository _EnrollRepository = new EnrollRepository();
        string bill = "LFA";
        int num = 17000;
        public PaymentController(IPaymentRepository PaymentRepository){
            this._PaymentRepository= PaymentRepository;
        }
        
        
        public void Menu()
        {
            Console.WriteLine("1. Course");
            Console.WriteLine("2. Student");
            Console.WriteLine("3. Enroll");
            Console.WriteLine("4. Payment");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice:");
        }
            public void Course(){
                Console.WriteLine("1. Add Course");
                Console.WriteLine("2. Delete Course");
                Console.WriteLine("3. Search By Id");
                Console.WriteLine("4. Show All");
                Console.WriteLine("Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
               
                switch (choice)
                {
                    case 1:
                        InsertCourse();
                        break;
                    case 2:
                        Console.WriteLine("Delete-----------------------------------");
                        Console.WriteLine("Do you want to Delete Courses[Y/N]?");
                        if (Console.ReadLine().ToUpper().Equals("Y"))
                        {
                            Console.WriteLine("Enter Course Code:");
                            string code = Console.ReadLine();
                            foreach (Enrollment e in _EnrollRepository.GetAll())
                            {
                                if (e.CourseCode!=code)
                                {
                                    _CourseRepository.Delete(code);
                                }
                                else
                                {
                                    Console.WriteLine("Course is already enrolled.Cannot delete this record");
                                }
                            }
                           
                        }
                        break;
                    case 3:
                        Console.WriteLine("Search-------------------------------");
                        Console.WriteLine("Enter Course ID:");
                        int cid = Convert.ToInt32(Console.ReadLine());
                        foreach (Courses c in _CourseRepository.GetAll())
                        {
                            if (c.CourseID == cid)
                            {
                                Console.WriteLine("Course ID:{0}\r\nName:{1}\r\nCourse Code:{2}\r\nFees:{3}\r\n",c.CourseID,c.Name,c.CourseCode,c.Fees);
                            }
                            
                        }
                        break;
                    case 4:
                        Console.WriteLine("Printing All Courses-------------------");
                        foreach (Courses c in _CourseRepository.GetAll())
                        {
                            Console.WriteLine("Course ID:{0}\r\nName:{1}\r\nCourse Code:{2}\r\nFees:{3}\r\n",c.CourseID,c.Name,c.CourseCode,c.Fees);
                        }

                        break;
                }
            }
            public void Student()
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Delete Student");
                Console.WriteLine("3. Search By Id");
                Console.WriteLine("4. Show All");
                Console.WriteLine("Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        InsertStudent();
                        break;
                    case 2:
                        Console.WriteLine("Delete-----------------------------------");
                        Console.WriteLine("Do you want to Delete Student[Y/N]?");
                        if (Console.ReadLine().ToUpper().Equals("Y"))
                        {
                            Console.WriteLine("Enter Student ID:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            foreach (Enrollment e in _EnrollRepository.GetAll())
                            {
                                if (e.StudentID != id)
                                {
                                    _StudentRepository.Delete(id);
                                }
                                else
                                {
                                    Console.WriteLine("Student is already enrolled.Cannot delete this record");
                                }
                            }
                          
                        }
                        break;
                    case 3:
                        Console.WriteLine("Search-------------------------------");
                        Console.WriteLine("Enter Student ID:");
                        int sid = Convert.ToInt32(Console.ReadLine());
                        foreach (Students s in _StudentRepository.GetAll())
                        {
                            if (s.StudentID == sid)
                            {
                                Console.WriteLine("Student ID:{0}\r\nFirst Name:{1}\r\nLast Name:{2}\r\nEmail:{3}\r\n", s.StudentID,s.FirstName,s.LastName,s.Email);
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Printing All Courses-------------------");
                        foreach (Students s in _StudentRepository.GetAll())
                        {
                            
                                Console.WriteLine("Student ID:{0}\r\nFirst Name:{1}\r\nLast Name:{2}\r\nEmail:{3}\r\n", s.StudentID,s.FirstName,s.LastName,s.Email);
                            
                        }
                        break;
                }
            }
            public void InsertCourse()
            {
                Courses c = new Courses();
                Console.WriteLine("Enter Course ID:");
                c.CourseID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Course Name:");
                c.Name = Console.ReadLine();
                Console.WriteLine("Enter Course Code:");
                c.CourseCode = Console.ReadLine();
                Console.WriteLine("Enter Fees:");
                c.Fees = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                _CourseRepository.Insert(c);
            }
            public void InsertStudent()
            {
                Students s = new Students();
                Console.WriteLine("Enter ID:");
                s.StudentID= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter First Name:");
                s.FirstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name:");
                s.LastName = Console.ReadLine();
                Console.WriteLine("Enter Email:");
                s.Email= Console.ReadLine();
                _StudentRepository.Insert(s);
            }
            public void Enrollment()
            {
                Console.WriteLine("1.Enroll Records");
                Console.WriteLine("2.Show Records");
                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        EnrollRecord();
                        break;
                    case 2:
                        foreach (Enrollment e in _EnrollRepository.GetAll())
                        {
                            Console.WriteLine("Student ID\tCourse Code\tStatus");
                            Console.WriteLine(e.StudentID + "\t\t" + e.CourseCode + "\t" + e.date);
                        }
                        break;
                }
            }
            public void EnrollRecord()
            {
                string ans="Y";
                while (ans.ToUpper().Equals("Y"))
                {
                    Console.WriteLine("Search Student---------------------");
                    Console.WriteLine("Enter name of student:");
                    string name = Console.ReadLine();
                    foreach (Students s in _StudentRepository.GetAll())
                    {
                        if (s.FirstName == name)
                        {
                            Console.WriteLine("Student ID:\tFirst Name:\tLast Name:\tEmail:");
                            Console.WriteLine(s.StudentID + "\t\t" + s.FirstName + "\t" + s.LastName + "\t" + s.Email);
                            Console.WriteLine("Do you want to search again[Y/N]?");
                            ans = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Record Not found. Do you want to search for another student[Y/N]?");
                            ans = Console.ReadLine();
                        }
                    }
                }
                string val = "Y";
                while (val.ToUpper().Equals("Y"))
                {

                    Console.WriteLine("Search Course---------------------");
                    Console.WriteLine("Enter Course Code:");
                    string code = Console.ReadLine();
                    foreach (Courses c in _CourseRepository.GetAll())
                    {
                        if (c.CourseCode == code)
                        {
                            Console.WriteLine("Course ID\tName\tCourse Code\tFees");
                            Console.WriteLine(c.CourseID + "\t\t" + c.Name + "\t" + c.CourseCode + "\t" + c.Fees);
                            Console.WriteLine("Do you want to search again[Y/N]?");
                            val = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Record Not found. Do you want to search for another course[Y/N]?");
                            val = Console.ReadLine();
                        }
                    }
                }
                Console.WriteLine("Enrollment-----------------------");
                Enrollment enroll = new Enrollment();
                Console.WriteLine("Enter Course Code:");
                enroll.CourseCode=Console.ReadLine();
                Console.WriteLine("Enter Student ID:");
                enroll.StudentID = Convert.ToInt32(Console.ReadLine());                          
                Console.WriteLine("Enter enroll date:");
                enroll.date = Console.ReadLine();
                _EnrollRepository.Insert(enroll);                
               }
            
            public void Payment()
            {
                int id;
                Payment payment = new Payment();
                Console.WriteLine("Bill number:");
                payment.BillNum = bill + (++num);
                Console.WriteLine(payment.BillNum);
                Console.WriteLine("Student ID:");
                id = Convert.ToInt32(Console.ReadLine());
                Enrollment enroll = _EnrollRepository.GetByID(id);
                if (enroll != null)
                {
                    payment.StudentId = enroll;
                    Console.WriteLine("Fees:");
                    payment.fees = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Paid");
                    payment.Paid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Due");
                    payment.Due = payment.fees - payment.Paid;
                    Console.WriteLine(payment.Due);
                    _PaymentRepository.Insert(payment);
                }
                else
                {
                    num = num - 1;
                    Console.WriteLine("Student not enrolled");
                }
                
                

            }
        public void process(int choice)
        {
            switch (choice)
            {
                case 1:
                    Course();
                    break;
                case 2:
                    Student();
                    break;
                case 3:
                    Enrollment();
                    break;
                case 4:
                    Payment();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

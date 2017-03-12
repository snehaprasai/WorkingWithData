using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leapfrog.WorkingWith.Data.Controller;
using Leapfrog.WorkingWith.Data.Repository;
using Leapfrog.WorkingWith.Data.Models;

namespace Leapfrog.WorkingWith.Data
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IPaymentRepository _PaymentRepository = new PaymentRepository();
            PaymentController _PaymentController = new PaymentController(_PaymentRepository);
            while (true)
            {

                _PaymentController.Menu();
                _PaymentController.process(Convert.ToInt32(Console.ReadLine()));


            }
        }
    }
}

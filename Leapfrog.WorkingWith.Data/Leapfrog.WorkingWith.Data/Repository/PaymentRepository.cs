using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leapfrog.WorkingWith.Data.Models;

namespace Leapfrog.WorkingWith.Data.Repository
{
    
        public interface IPaymentRepository
        {
            void Insert(Payment pay);
            //bool Delete(int Id);
            //Payment GetByID(int Id);
            IList<Payment> GetAll();
        }
        public class PaymentRepository:IPaymentRepository
        {
            private IList<Payment> _PaymentList = new List<Payment>();
            public void Insert(Payment pay)
            {
                _PaymentList.Add(pay);
            }
            //public bool Delete(string billNum) 
            //{
            //    Payment p = GetByID(billNum);
            //    if (p.BillNum != null)
            //    {
            //        _PaymentList.Remove(p);
            //    }
            //    return false;
            //}
            //public Payment GetByID(int Id) 
            //{
            //    foreach (Payment p in _PaymentList)
            //    {
            //        if (p.BillNum == Id)
            //        {
            //            return p;
            //        }
            //    }
            //    return null;
            //}
            public IList<Payment> GetAll()
            {
                return _PaymentList;
            }
        }
}

using System;
using System.Linq;

namespace AmazonProject.Models
{
    public interface IPaymentRepository
    {
        IQueryable<Payment> Payments { get; }

        void SavePayment(Payment payment);
    }
}

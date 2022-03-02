using PaymentMS.Domain.Models.States.Interfaces;
using System.Reflection;

namespace PaymentMS.Data.Utils
{
    public static class StringExtensions
    {
        /// <summary>
        /// Return a instance of payment state classname
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static IPaymentState GetState(this string className)
        {
            Assembly assembly = Assembly.Load("PaymentMS.Domain");
            string fullClassName = $"PaymentMS.Domain.Models.States.{className}";
            Type type = assembly.GetType(fullClassName);
            IPaymentState state = (IPaymentState)Activator.CreateInstance(type);
            return state;
        }
    }
}
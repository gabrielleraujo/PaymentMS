using Microsoft.Extensions.DependencyInjection;
using PaymentMS.ApplicationService.Interfaces;
using PaymentMS.DomainService.Interfaces;
using PaymentMS.DomainService.Mappers;
using PaymentMS.Infrastructure.Data.Repository;
using PaymentMS.Infrastructure.IoC.Factories;

namespace PaymentMS.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            // Mappers
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            service.AddTransient(typeof(ICustomMapper<,>), typeof(CustomMapper<,>));

            //Events
            AddEvents(service);

            // ApplicationService
            AddApplicationServices(service);

            // DomainService
            AddDomainServices(service);

            // Repository
            AddRepository(service);
        }


        private static void AddEvents(IServiceCollection service)
        {
            service.AddTransient((serviceProvider) => PaymentEventFactory.Create());
            service.AddTransient((serviceProvider) => IssueInvoiceEventFactory.Create());
        }

        private static void AddApplicationServices(IServiceCollection service)
        {
            service.AddTransient(typeof(IBoletoApplicationService<>), typeof(BoletoApplicationService<>));
            service.AddTransient(typeof(ICreditCardApplicationService<>), typeof(CreditCardApplicationService<>));
            service.AddTransient(typeof(IDebitCardApplicationService<>), typeof(DebitCardApplicationService<>));
        }

        private static void AddDomainServices(IServiceCollection service)
        {
            service.AddTransient(typeof(IBoletoDomainService<>), typeof(BoletoDomainService<>));
            service.AddTransient(typeof(ICreditCardDomainService<>), typeof(CreditCardDomainService<>));
            service.AddTransient(typeof(IDebitCardDomainService<>), typeof(DebitCardDomainService<>));
        }

        private static void AddRepository(IServiceCollection service)
        {
            service.AddScoped(typeof(IPaymentRepository<>), typeof(PaymentRepository<>));
        }
    }
}
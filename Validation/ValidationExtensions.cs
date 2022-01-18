using Microsoft.Extensions.DependencyInjection;

namespace CQRSDemo.Validation
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// Using Scrutor pkg to link all the validators available in the given assembly
        /// </summary>
        /// <param name="services"></param>
        public static void AddValidators(this IServiceCollection services)
        {
            services.Scan(scan => scan
              .FromAssemblyOf<IValidationHandler>()
                .AddClasses(classes => classes.AssignableTo<IValidationHandler>())
                  .AsImplementedInterfaces()
                  .WithTransientLifetime());
        }
    }
}

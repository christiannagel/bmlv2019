using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CosmosDBSampleWithEFCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var container = RegisterServices();
            var runner = container.GetService<MyRunner>();
            await runner.CreateTheDatabaseAsync();
            await runner.AddPersonAsync(new Person { PersonId = Guid.NewGuid().ToString(), FirstName = "Katharina", LastName = "Nagel" });
        }

        private static IServiceProvider RegisterServices()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets("b873fdc8-068b-478a-b4a1-080b5b73f0af")
                .Build();
            string uri = config["uri"];
            string key = config["mykey"];
            string databaseName = "BMLVCosmos";
            var services = new ServiceCollection();
            services.AddDbContext<PeopleContext>(options =>
            {
                options.UseCosmos(uri, key, databaseName);
            });
            services.AddTransient<MyRunner>();
            return services.BuildServiceProvider();
        }
    }
}

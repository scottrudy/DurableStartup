using DurableStartup;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace DurableStartup {
	public class Startup : FunctionsStartup {
		public override void Configure(IFunctionsHostBuilder builder) {
			builder.Services.AddSingleton<TopicSubscriptionEnsurer>();
		}
	}
}
using System;
using DurableStartup;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(WebJobsExtensionStartup))]

namespace DurableStartup {
    /// <summary>We expect this to run prior to the trigger ever being called (i.e. on deployment)</summary>
	public class WebJobsExtensionStartup : IWebJobsStartup {
		public void Configure(IWebJobsBuilder builder) {
			builder.AddExtension<InjectionExtensionConfigurationProvider>();
		}
	}

	public class InjectionExtensionConfigurationProvider : IExtensionConfigProvider {
		private readonly IServiceProvider _serviceProvider;

		public InjectionExtensionConfigurationProvider(IServiceProvider serviceProvider) {
			_serviceProvider = serviceProvider;
		}

		public void Initialize(ExtensionConfigContext context) {
			var subscriptionEnsurer = (TopicSubscriptionEnsurer)_serviceProvider.GetService(typeof(TopicSubscriptionEnsurer));
            // This ensures the Topic Subscription has been created
			subscriptionEnsurer.EnsureAsync().Wait();
		}
	}    
}
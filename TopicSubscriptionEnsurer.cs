using System;
using System.Threading.Tasks;

namespace DurableStartup {
    /// <summary>This will create a subscription on a topic to ensure the trigger will work.</summary>
	public class TopicSubscriptionEnsurer {
        public async Task EnsureAsync() {
            var connection = Environment.GetEnvironmentVariable("AzureWebJobsServiceBus");
            var topic = Environment.GetEnvironmentVariable("ServiceBus.Topic");
			var subscription = Environment.GetEnvironmentVariable("ServiceBus.Subscription");
            await Task.Run(() => Console.WriteLine("Create a topic subscription in Azure Service Bus"));
        }
    }
}
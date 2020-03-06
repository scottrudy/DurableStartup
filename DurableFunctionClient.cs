using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;

namespace DurableStartup
{
    public static class DurableFunctionClient {

        /// <summary>This trigger depends on the subscription existing</summary>
        [FunctionName(nameof(StartupClientFunction))]
        public static async Task<HttpResponseMessage> StartupClientFunction(
            [ServiceBusTrigger("%ServiceBus.Topic%", "%ServiceBus.Subscription%", Connection = "AzureWebJobsServiceBus")]
            Message message,
            [OrchestrationClient]
            DurableOrchestrationClientBase orchestrationClient) {

            string instanceId = await orchestrationClient.StartNewAsync(
                nameof(ContexuallyIrrelevant.OrchestrationClientFunction), null);
            return orchestrationClient.CreateCheckStatusResponse(null, instanceId);
        }
    }
}
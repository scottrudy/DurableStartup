using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace DurableStartup {

    /// <summary>Nothing is important here and is included only for completeness</summary>
    public class ContexuallyIrrelevant {

        [FunctionName(nameof(OrchestrationClientFunction))]
        public static async Task<string[]> OrchestrationClientFunction(
            [OrchestrationTrigger] DurableOrchestrationContextBase context) {
            var outputs = new string[3];

            outputs[0] = await context.CallActivityAsync<string>(nameof(ActivityFunction), "Tokyo");
            outputs[1] = await context.CallActivityAsync<string>(nameof(ActivityFunction), "Seattle");
            outputs[2] = await context.CallActivityAsync<string>(nameof(ActivityFunction), "London");
            return outputs;
        }        

        [FunctionName(nameof(ActivityFunction))]
        public static string ActivityFunction([ActivityTrigger] string name) {
            return $"Hello {name}!";
        }
    }
}
using Novafuria.DataIngester.Prepaper.Domain.Core.ValueObjects;
using Novafuria.DataIngester.Preparer.Domain.UseCase;
using Novafuria.DataIngester.Preparer.Temporalio.UseCases.Activities;
using Temporalio.Workflows;

namespace Novafuria.DataIngester.Preparer.Temporalio.UseCase.Workflows
{
    [Workflow("prueba1")]
    public class PrepareWorkflow : IPrepareUseCase
    {
        [WorkflowRun]
        public Task PrepareDataAsync(ConciliationWorkflow workflow, Origin origin, UniqueSelector uniqueSelector)
        {

            Workflow.ExecuteActivityAsync<PareparerActivities>(Workflow.CurrentRunId, x => x.SetupResources(uniqueSelector)); 
        }
    }
}

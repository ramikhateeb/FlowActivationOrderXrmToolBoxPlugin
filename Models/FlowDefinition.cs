using Microsoft.Xrm.Sdk.Workflow.Activities;

namespace FlowActivationOrder.Models
{
    public class FlowDefinition
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ClientData { get; set; }
        public string Description { get; set; }
        public bool Solution { get; set; }
        public bool Managed { get; set; }
        public string UniqueId { get; set; }
    }
}
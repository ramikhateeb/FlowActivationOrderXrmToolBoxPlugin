using FlowActivationOrder.Models;
using McTools.Xrm.Connection;
using Microsoft.Msagl.GraphmapsWithMesh;
using Microsoft.Msagl.Drawing;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using QuikGraph;
using QuikGraph.Algorithms.TopologicalSort;
using QuikGraph.MSAGL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using XrmToolBox.Extensibility;

using LocalModels = FlowActivationOrder.Models;

namespace FlowActivationOrder
{
    public partial class MainControl : PluginControlBase
    {
        private Settings mySettings;

        public MainControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }

            ExecuteMethod(LoadSolutions);
        }

        private void solutionsToolStripDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var solution = e.ClickedItem.Tag as LocalModels.Solution;
            LoadFlows(solution);
        }




        private void LoadFlows(LocalModels.Solution solution)
        {
            WorkAsync(
                new WorkAsyncInfo
                {
                    Message = "Retrieiving the Flows",
                    Work = (w, e) =>
                    {
                        List<LocalModels.FlowDefinition> flowList = new List<LocalModels.FlowDefinition>();

                        var qe = new QueryExpression("workflow");
                        qe.ColumnSet.AddColumns("ismanaged", "clientdata", "description", "name", "createdon", "modifiedon", "modifiedby", "createdby", "workflowidunique");
                        qe.Criteria.AddCondition("category", ConditionOperator.Equal, 5);

                        qe.AddOrder("name", OrderType.Ascending);

                        if (solution != null)
                        {
                            var solComp = qe.AddLink("solutioncomponent", "workflowid", "objectid", JoinOperator.Inner);
                            solComp.EntityAlias = "solComp";
                            solComp.LinkCriteria.AddCondition("solutionid", ConditionOperator.Equal, solution.Id);                            
                        }

                        var flowRecords = Service.RetrieveMultiple(qe);
                        foreach (var flowRecord in flowRecords.Entities)
                        {
                            var flowDef = new LocalModels.FlowDefinition
                            {
                                Id = flowRecord["workflowid"].ToString(),
                                Name = flowRecord["name"].ToString(),
                                ClientData = flowRecord["clientdata"].ToString(),
                                Description = !flowRecord.Attributes.Contains("description") ? string.Empty : flowRecord["description"].ToString(),
                                Solution = true,
                                Managed = (bool)flowRecord["ismanaged"],
                                UniqueId = flowRecord["workflowidunique"].ToString()
                            };

                            flowList.Add(flowDef);
                        }

                        e.Result = flowList;
                    },
                    ProgressChanged = e => { },
                    PostWorkCallBack = e =>
                    {
                        var returnFlows = e.Result as List<LocalModels.FlowDefinition>;

                        flowsDataGridView.AutoGenerateColumns = true;
                        flowsDataGridView.DataSource = returnFlows;
                    },
                }
            );
        }

        private void LoadSolutions()
        {
            solutionsToolStripDropDownButton.DropDown.Items.Clear();

            WorkAsync(
                new WorkAsyncInfo
                {
                    Message = "Retrieiving the Solutions",
                    Work = (w, e) =>
                    {
                        List<LocalModels.Solution> solList = new List<LocalModels.Solution>();

                        QueryExpression solQry = new QueryExpression("solution");
                        solQry.Distinct = true;
                        solQry.ColumnSet = new ColumnSet("solutionid", "uniquename", "friendlyname", "version", "publisherid");
                        solQry.AddOrder("friendlyname", OrderType.Ascending);
                        solQry.Criteria = new FilterExpression();
                        solQry.Criteria.AddCondition(new ConditionExpression("isvisible", ConditionOperator.Equal, true));
                        solQry.Criteria.AddCondition(new ConditionExpression("uniquename", ConditionOperator.NotEqual, "Default"));
                        solQry.Criteria.AddCondition(new ConditionExpression("ismanaged", ConditionOperator.Equal, false));

                        var solutionEntities = Service.RetrieveMultiple(solQry);

                        foreach (var solution in solutionEntities.Entities)
                        {
                            solList.Add(new LocalModels.Solution
                            {
                                Id = solution["solutionid"].ToString(),
                                UniqueName = solution["uniquename"].ToString(),
                                FriendlyName = solution["friendlyname"].ToString(),
                                VersionNumber = solution["version"].ToString(),
                                PublisherId = ((EntityReference)solution["publisherid"]).Id.ToString(),
                                PublisherIdName = ((EntityReference)solution["publisherid"]).Name
                            });
                        }

                        e.Result = solList;
                    },
                    ProgressChanged = e => { },
                    PostWorkCallBack = e =>
                    {
                        if (e.Error != null)
                        {
                            LogError("An error happend while loading the solutions.", e.Error);
                            MessageBox.Show(e.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        var solList = e.Result as List<LocalModels.Solution>;
                        foreach (var solution in solList)
                        {
                            if (solution.UniqueName == "Active" || solution.UniqueName == "Default" || solution.UniqueName == "Basic")
                                continue;

                            ToolStripDropDownButton lstItem = new ToolStripDropDownButton();
                            lstItem.Text = solution.FriendlyName;
                            lstItem.Tag = solution;

                            solutionsToolStripDropDownButton.DropDown.Items.Add(lstItem);
                        }
                    },
                }
            );
        }

        private void generateToolStripButton_Click(object sender, EventArgs e)
        {
            var dependencyGraph = new BidirectionalGraph<FlowNode, Edge<FlowNode>>(true);
            var flowNodeDictionary = new Dictionary<string, FlowNode>();

            // add vertices
            foreach (DataGridViewRow row in flowsDataGridView.SelectedRows)
            {
                var flow = new FlowNode(row.DataBoundItem as LocalModels.FlowDefinition);
                dependencyGraph.AddVertex(flow);
                flowNodeDictionary.Add(flow.Flow.Id, flow);
            }

            // add edges
            foreach (var flow in dependencyGraph.Vertices) 
            {
                var workflow = LocalModels.WorkflowObject.FromJson(flow.Flow.ClientData);
                var childWorkflowReferenceNames = GetActions(workflow, LocalModels.ActionType.Workflow)
                                .Where(action => action.Inputs.HasValue && action.Inputs.Value.Object != null)            
                                .Select(action => action.Inputs.Value.Object.Host.WorkflowReferenceName)
                                .Distinct();

                foreach (var childWorkflowReference in childWorkflowReferenceNames)
                {
                    if(flowNodeDictionary.TryGetValue(childWorkflowReference, out FlowNode childFlow))
                    {
                        dependencyGraph.AddEdge(new Edge<FlowNode>(childFlow, flow));
                    }
                }
            }

            var sorter = new TopologicalSortAlgorithm<FlowNode, Edge<FlowNode>>(dependencyGraph);
            sorter.Compute();

            for (var index = 0; index < sorter.SortedVertices.Length; index++)
            {
                var flowNode = sorter.SortedVertices[index];
                flowNode.Index = index;
            }

            flowsOrderedListTextBox.Text = GetOutputForFlowsOrderedList(sorter.SortedVertices);
            almAcceleratorConfigsTextBox.Text = GetOutputForALMAcceleratorConfigs(sorter.SortedVertices);
            GetOutputForVisual(dependencyGraph);

        }

        private IEnumerable<LocalModels.Action> GetActions(object obj, LocalModels.ActionType actionType)
        {
            if (obj == null) yield break;

            if (obj is LocalModels.Action action)
            {
                if (action.Type == actionType)
                    yield return action;
            }

            Type objType = obj.GetType();

            if (objType.Assembly != this.GetType().Assembly) yield break;

            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);
                if (propValue is IList list)
                {
                    foreach (var item in list)
                    {
                        foreach (var childItem in GetActions(item, actionType))
                            yield return childItem;
                    }
                }
                else if (propValue is IDictionary map)
                {
                    foreach (var item in map.Values)
                    {
                        foreach (var childItem in GetActions(item, actionType))
                            yield return childItem;
                    }
                }
                else
                {
                    foreach (var childItem in GetActions(propValue, actionType))
                        yield return childItem;
                }
            }
        }

        private void GetOutputForVisual(IEdgeListGraph<FlowNode, Edge<FlowNode>> graph)
        {

            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();

            viewer.Graph = graph.ToMsaglGraph();

            this.splitContainer2.Panel2.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Panel2.Controls.Add(viewer);
            this.splitContainer2.Panel2.ResumeLayout();
        }

            private string GetOutputForFlowsOrderedList(FlowNode[] flows)
        {
            var items = new List<string>();

            for (var index = 0; index < flows.Length; index++)
            {
                var flow = flows[index];

                items.Add(string.Format("[{0}] {1}", index, flow.Flow.Name));
            }

            return String.Join(Environment.NewLine, items);
        }

        private string GetOutputForALMAcceleratorConfigs(FlowNode[] flows) 
        {
            var items = new List<string>();

            for(var index = 0; index < flows.Length; index++) 
            {
                var flow = flows[index];

                var name = flow.Flow.Name.Replace(" ", "");
                
                items.Add(
                    string.Format(
@"{{
    ""Name"": ""owner.ownerEmail.{0}.{1}"",
    ""Value"": """"
}},{{
    ""Name"": ""flow.sharing.{0}.{1}"",
    ""Value"": """"
}},{{
    ""Name"": ""activateflow.order.{0}.{1}"",
    ""Value"": ""{2}""
}},{{
    ""Name"": ""activateflow.activate.{0}.{1}"",
    ""Value"": ""true""
}}", name, flow.Flow.Id, index+1));
            }

            return String.Join(",", items);
        }
    }

    class FlowNode 
    {
        public FlowNode(LocalModels.FlowDefinition flow) : this(flow, 0)
        {
        }

        public FlowNode(LocalModels.FlowDefinition flow, int index)
        {
            this.Flow = flow;
            this.Index = index;
        }

        public int Index { get; set; }    

        public LocalModels.FlowDefinition Flow { get; set; }

        public override string ToString()
        {
            return this.Index.ToString();
        }
    }
}
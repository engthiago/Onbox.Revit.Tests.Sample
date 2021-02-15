using Autodesk.Revit.UI;
using Onbox.Abstractions.V9;
using Onbox.Core.V9;
using Onbox.Revit.Tests.Sample.Revit.Commands;
using Onbox.Revit.Tests.Sample.Revit.Commands.Availability;
using Onbox.Revit.Tests.Sample.Services;
using Onbox.Revit.V9;
using Onbox.Revit.V9.Applications;
using Onbox.Revit.V9.UI;

namespace Onbox.Revit.Tests.Sample.Revit
{
    [ContainerProvider("8641d635-3f09-4fbc-9579-f4df5ceef1a7")]
    public class App : RevitApp
    {
        public override void OnCreateRibbon(IRibbonManager ribbonManager)
        {
            // Here you can create Ribbon tabs, panels and buttons

            var br = ribbonManager.GetLineBreak();

            // Adds a Ribbon Panel to the Addins tab
            var addinPanelManager = ribbonManager.CreatePanel("Onbox.Revit.Tests.Sample");
            addinPanelManager.AddPushButton<HelloCommand, AvailableOnProject>($"Hello{br}Framework", "onbox_logo");

            // Adds a new Ribbon Tab with a new Panel
            var panelManager = ribbonManager.CreatePanel("Onbox.Revit.Tests.Sample", "Hello Panel");
            panelManager.AddPushButton<HelloCommand, AvailableOnProject>($"Hello{br}Framework", "onbox_logo");
        }

        public override Result OnStartup(IContainer container, UIControlledApplication application)
        {
            // Here you can add all necessary dependencies to the container
            container.AddOnboxCore();

            // Add TaskDialog Service the message service
            container.AddSingleton<IMessageService, TaskMessageService>();

            return Result.Succeeded;
        }

        public override Result OnShutdown(IContainerResolver container, UIControlledApplication application)
        {
            // No Need to cleanup the Container, the framework will do it for you
            return Result.Succeeded;
        }
    }

}
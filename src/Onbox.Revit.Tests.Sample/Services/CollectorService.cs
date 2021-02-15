using Autodesk.Revit.DB;
using System.Linq;

namespace Onbox.Revit.Tests.Sample.Services
{
    public class CollectorService
    {
        public ElementId CollectFirstLevelInstance(Document doc)
        {
            var level = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType()
                .ToElementIds()
                .First();

            return level;
        }
    }
}

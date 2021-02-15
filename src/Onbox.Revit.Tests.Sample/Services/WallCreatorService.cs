using Autodesk.Revit.DB;

namespace Onbox.Revit.Tests.Sample.Services
{
    public class WallCreatorService
    {
        private readonly CollectorService collector;

        public WallCreatorService(CollectorService collector)
        {
            this.collector = collector;
        }

        public Wall CreateWall(Document doc, Line line)
        {
            var levelId = this.collector.CollectFirstLevelInstance(doc);
            var wall = Wall.Create(doc, line, levelId, false);
            return wall;
        }
    }
}

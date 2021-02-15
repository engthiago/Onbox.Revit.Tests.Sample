using Autodesk.Revit.DB;
using NUnit.Framework;
using Onbox.Revit.NUnit.Core;
using Onbox.Revit.Tests.Sample.Services;

namespace Onbox.Revit.Tests
{
    [TestFixture]
    public class CollectorShould : RevitTestFixture
    {
        private Document doc;

        [OneTimeSetUp]
        public void PrepareRevitProj()
        {
            this.doc = this.app.NewProjectDocument(UnitSystem.Metric);
        }

        [Test]
        public void CollectFirstLevel()
        {
            var collector = new CollectorService();
            var levelId = collector.CollectFirstLevelInstance(this.doc);
            Assert.NotNull(levelId);
            Assert.AreNotEqual(levelId.IntegerValue, -1);
        }

        [OneTimeTearDown]
        public void CLoseRevitProj()
        {
            this.doc.Close(false);
        }
    }
}

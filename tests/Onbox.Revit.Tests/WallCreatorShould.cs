using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using NUnit.Framework;
using Onbox.Revit.NUnit.Core;
using Onbox.Revit.Tests.Sample.Services;

namespace Onbox.Revit.Tests
{
    [TestFixture]
    public class WallCreatorShould : RevitTestFixture
    {
        private Document doc;

        [OneTimeSetUp]
        public void PrepareRevitProj()
        {
            this.doc = this.app.NewProjectDocument(UnitSystem.Metric);
        }

        [Test]
        public void CreateWall()
        {
            var collector = new CollectorService();
            var wallService = new WallCreatorService(collector);
            var line = Line.CreateBound(XYZ.Zero, XYZ.BasisX.Multiply(10));

            Wall wall;
            using (Transaction t = new Transaction(this.doc, "Create Wall"))
            {
                t.Start();
                wall = wallService.CreateWall(doc, line);
                t.Commit();
            }

            Assert.NotNull(wall);
        }

        [Test]
        public void ThisTestShouldFail()
        {
            Assert.AreEqual(true, false);
        }

        [Test]
        public void ThrowExceptionWhenCreatingOutsideOfTransaction()
        {
            var collector = new CollectorService();
            var wallService = new WallCreatorService(collector);
            var line = Line.CreateBound(XYZ.Zero, XYZ.BasisY.Multiply(10));

            Assert.Throws<ModificationOutsideTransactionException>(() => wallService.CreateWall(doc, line));
        }

        [OneTimeTearDown]
        public void CloseRevitProj()
        {
            this.doc.Close(false);
        }
    }
}

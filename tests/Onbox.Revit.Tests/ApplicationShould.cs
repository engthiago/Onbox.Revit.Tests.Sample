using NUnit.Framework;
using Onbox.Revit.NUnit.Core;

namespace Onbox.Revit.Tests
{
    [TestFixture]
    public class ApplicationShould : RevitTestFixture
    {
        [Test]
        public void NotBeNull()
        {
            Assert.NotNull(this.app);
        }
    }
}

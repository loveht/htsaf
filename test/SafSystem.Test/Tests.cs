using Ataoge.SafSystem;
using Xunit;

namespace TestsApp
{
    public class SafSystemTests
    {
        [Fact]
        public void TestThing() {
            Assert.Equal(42, new Thing().Get(19, 23));
        }
    }
}

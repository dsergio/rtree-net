using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RTree.Business.Tests
{
	[TestClass]
    public class TestBase : RTree.Data.Tests.TestBase
    {
        // Justification: Set by TestInitialize
#nullable disable // CS8618: Non-nullable field is uninitialized. Consider declaring as nullable.
        protected IMapper Mapper { get; private set; }
#nullable enable

        [TestInitialize]
        public override void InitializeTests()
        {
            base.InitializeTests();
            Mapper = AutomapperConfigurationProfile.CreateMapper();
        }
    }
}

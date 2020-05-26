using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace RTree.Data.Tests
{
	[TestClass]
	public class BinaryAttrTests : TestBase
	{
		[TestMethod]
		public void BinaryAttribute_Add_RetrieveSuccess()
		{
			// Arrange
			BinaryAttrSet set = new BinaryAttrSet();
			BinaryAttr attr = new BinaryAttr("Test1", true, set);

			// Act
			set.AddAttribute(attr);
			BinaryAttr attrRetrieved = set.GetAttr("Test1");

			// Assert
			Assert.AreEqual(true, attrRetrieved.Value);
		}

		[TestMethod]
		public void BinaryAttribute_Add_RetrieveFail()
		{
			// Arrange
			BinaryAttrSet set = new BinaryAttrSet();
			BinaryAttr attr = new BinaryAttr("Test1", true, set);

			// Act
			set.AddAttribute(attr);
			BinaryAttr attrRetrieved = set.GetAttr("Test2");

			// Assert
			Assert.IsNull(attrRetrieved);
		}

		[TestMethod]
		public async Task BinaryAttr_CanBeSavedToDatabase()
		{
			// Arrange
			using (var dbContext = new ApplicationDbContext(Options))
			{
				BinaryAttrSet set = new BinaryAttrSet();
				dbContext.BinaryAttr.Add(new BinaryAttr("Test3", true, set));
				await dbContext.SaveChangesAsync().ConfigureAwait(false);
			}
			// Act
			// Assert
			using (var dbContext = new ApplicationDbContext(Options))
			{
				var attrs = await dbContext.BinaryAttr.ToListAsync();

				Assert.AreEqual(1, attrs.Count);
				Assert.AreEqual("Test3", attrs[0].Name);
				Assert.AreEqual(true, attrs[0].Value);
				
			}
		}
	}
}

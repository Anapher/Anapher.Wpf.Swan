using Xunit;

namespace Anapher.Wpf.Swan.Tests
{
	public class TransactionalObservableCollectionTests
	{
		[Fact]
		public void TestAddRemove()
		{
			var collection = new TransactionalObservableCollection<string>();
			var triggers = 0;
			collection.CollectionChanged += (sender, args) => triggers++;

			collection.Add("test");
			Assert.Equal(1, triggers);

			collection.Add("the");
			Assert.Equal(2, triggers);

			collection.Remove("the");
			Assert.Equal(3, triggers);

			collection.AddRange(new[] {"im", "a", "developer"});
			Assert.Equal(4, triggers);
			Assert.Equal(new[] {"test", "im", "a", "developer"}, collection);

			collection.RemoveRange(new[] {"test", "im", "hey"});
			Assert.Equal(5, triggers);
			Assert.Equal(new[] {"a", "developer"}, collection);
		}
	}
}
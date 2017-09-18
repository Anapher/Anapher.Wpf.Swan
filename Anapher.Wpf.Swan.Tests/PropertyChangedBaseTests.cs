using Xunit;

namespace Anapher.Wpf.Swan.Tests
{
	public class PropertyChangedBaseTests : PropertyChangedBase
	{
		private string _testProperty;

		public string TestProperty
		{
			get => _testProperty;
			set => _testProperty = value;
		}

		[Fact]
		public void TestGetPropertyName()
		{
			Assert.Equal(nameof(TestProperty), GetPropertyName(() => TestProperty));
		}

		[Fact]
		public void TestOnPropertyChanged()
		{
			var raised = false;
			PropertyChanged += (sender, args) =>
			{
				Assert.Equal(nameof(TestProperty), args.PropertyName);
				raised = true;
			};
			OnPropertyChanged(nameof(TestProperty));

			Assert.True(raised);
		}

		[Fact]
		public void TestOnPropertyChangedExpression()
		{
			var raised = false;
			PropertyChanged += (sender, args) =>
			{
				Assert.Equal(nameof(TestProperty), args.PropertyName);
				raised = true;
			};
			OnPropertyChanged(() => TestProperty);

			Assert.True(raised);
		}

		[Fact]
		public void TestSetProperty()
		{
			var raised = false;
			PropertyChanged += (sender, args) =>
			{
				Assert.Equal(nameof(TestProperty), args.PropertyName);
				raised = true;
			};

			Assert.True(SetProperty("test", ref _testProperty, nameof(TestProperty)));
			Assert.True(raised);

			raised = false;
			Assert.False(SetProperty("test", ref _testProperty, nameof(TestProperty)));
			Assert.False(raised);
		}
	}
}
using Xunit;

namespace Anapher.Wpf.Swan.Tests
{
	public class RelayCommandGenericTests
	{
		[Fact]
		public void TestExecute()
		{
			var executed = false;
			var command = new RelayCommand<string>(parameter => executed = true);
			command.Execute(null);
			Assert.True(executed);
		}

		[Fact]
		public void TestExecuteWithParameter()
		{
			var executed = false;
			var command = new RelayCommand<string>(parameter =>
			{
				Assert.Equal("test", parameter);
				executed = true;
			});
			command.Execute("test");
			Assert.True(executed);
		}

		[Fact]
		public void TestCanExecute()
		{
			var canExecute = false;
			var command = new RelayCommand<string>(parameter => {}, () => canExecute);
			Assert.False(command.CanExecute("asd"));

			canExecute = true;
			Assert.True(command.CanExecute(null));
		}
	}
}

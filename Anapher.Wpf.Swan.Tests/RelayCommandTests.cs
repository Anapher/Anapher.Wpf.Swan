using Xunit;

namespace Anapher.Wpf.Swan.Tests
{
	public class RelayCommandTests
	{
		[Fact]
		public void TestExecute()
		{
			var executed = false;
			var command = new RelayCommand(parameter => executed = true);
			command.Execute(null);
			Assert.True(executed);
		}

		[Fact]
		public void TestExecuteWithParameter()
		{
			var executed = false;
			var command = new RelayCommand(parameter =>
			{
				Assert.Equal("test", (string) parameter);
				executed = true;
			});
			command.Execute("test");
			Assert.True(executed);
		}

		[Fact]
		public void TestCanExecute()
		{
			var canExecute = false;
			var command = new RelayCommand(parameter => {}, () => canExecute);
			Assert.False(command.CanExecute(null));

			canExecute = true;
			Assert.True(command.CanExecute(null));
		}
	}
}

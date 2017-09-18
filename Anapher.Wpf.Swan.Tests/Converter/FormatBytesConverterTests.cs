using Anapher.Wpf.Swan.Converter;
using Xunit;

namespace Anapher.Wpf.Swan.Tests.Converter
{
	public class FormatBytesConverterTests
	{
		[Theory]
		[InlineData(0, "0 B")]
		[InlineData(1, "1 B")]
		[InlineData(-1, "-1 B")]
		[InlineData(1024, "1 KiB")]
		[InlineData(-1024, "-1 KiB")]
		[InlineData(1048576, "1 MiB")]
		[InlineData(-1048576, "-1 MiB")]
		[InlineData(1073741824, "1 GiB")]
		[InlineData(-1073741824, "-1 GiB")]
		[InlineData(int.MaxValue, "2 GiB")]
		[InlineData(uint.MaxValue, "4 GiB")]
		[InlineData(int.MinValue, "-2 GiB")]
		[InlineData(long.MaxValue, "8 EiB")]
		[InlineData(-9223372036854775807, "-8 EiB")]
		public void TestFormat(long size, string result)
		{
			Assert.Equal(result, FormatBytesConverter.BytesToString(size));
		}

		[Fact]
		public void TestBoxedByte()
		{
			Assert.Equal("123 B", new FormatBytesConverter().Convert((byte) 123, null, null, null));
		}

		[Fact]
		public void TestBoxedDecimal()
		{
			Assert.Equal("123 B", new FormatBytesConverter().Convert(123M, null, null, null));
		}

		[Fact]
		public void TestBoxedDouble()
		{
			Assert.Equal("123 B", new FormatBytesConverter().Convert(123d, null, null, null));
		}

		[Fact]
		public void TestBoxedFloat()
		{
			Assert.Equal("123 B", new FormatBytesConverter().Convert(123f, null, null, null));
		}

		[Fact]
		public void TestBoxedInteger()
		{
			Assert.Equal("123 B", new FormatBytesConverter().Convert(123, null, null, null));
		}

		[Fact]
		public void TestBoxedLong()
		{
			Assert.Equal("123 B", new FormatBytesConverter().Convert(123L, null, null, null));
		}

		[Fact]
		public void TestBoxedSByte()
		{
			Assert.Equal("123 B", new FormatBytesConverter().Convert((sbyte) 123, null, null, null));
		}

		[Fact]
		public void TestBoxedShort()
		{
			Assert.Equal("123 B", new FormatBytesConverter().Convert((short) 123, null, null, null));
		}

		[Fact]
		public void TestBoxedUInteger()
		{
			Assert.Equal("123 B", new FormatBytesConverter().Convert(123U, null, null, null));
		}

		[Fact]
		public void TestBoxedULong()
		{
			Assert.Equal("123 B", new FormatBytesConverter().Convert(123UL, null, null, null));
		}

		[Fact]
		public void TestBoxedUShort()
		{
			Assert.Equal("123 B", new FormatBytesConverter().Convert((ushort) 123, null, null, null));
		}

		[Fact]
		public void TestString()
		{
			Assert.Equal("123 B", new FormatBytesConverter().Convert("123", null, null, null));
		}
	}
}
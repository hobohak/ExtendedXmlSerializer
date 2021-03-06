﻿// MIT License
//
// Copyright (c) 2016-2018 Wojciech Nagórski
//                    Michael DeMond
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using ExtendedXmlSerializer.Configuration;
using ExtendedXmlSerializer.ExtensionModel.Xml;
using System.Collections.Generic;
using Xunit;

namespace ExtendedXmlSerializer.Tests.ContentModel.Collections
{
	public class CollectionWithMembersInnerContentHandlerTests
	{
		const string HelloWorld = "Hello World!";
		readonly IExtendedXmlSerializer _serializer = new ConfigurationContainer().Create();

		[Fact]
		public void BasicAttributes()
		{
			var serializer = new ConfigurationContainer()
				.Type<SimpleSubject>()
				.Member(x => x.Number, x => x.Attribute())
				.Create();

			var expected = new SimpleSubject {Message = "Hello World!", Number = 6776};
			var data = serializer.Serialize(expected);
			var actual = serializer.Deserialize<SimpleSubject>(data);
			Assert.Equal(expected.Message, actual.Message);
			Assert.Equal(expected.Number, actual.Number);
		}

		[Fact]
		public void ListProperties()
		{
			var expected = new ListWithProperties {"Hello", "World", "Hope", "This", "Works!"};
			expected.Message = HelloWorld;
			expected.Number = 6776;
			var data = _serializer.Serialize(expected);
			var actual = _serializer.Deserialize<ListWithProperties>(data);
			Assert.Equal(expected, actual);
			Assert.Equal(HelloWorld, actual.Message);
			Assert.Equal(6776, actual.Number);
		}

		[Fact]
		public void ListAttributes()
		{
			var serializer = new ConfigurationContainer()
				.Type<ListWithProperties>()
				.Member(x => x.Message, x => x.Attribute())
				.Create();

			var expected = new ListWithProperties {"Hello", "World", "Hope", "This", "Works!"};
			expected.Message = HelloWorld;
			expected.Number = 6776;
			var data = serializer.Serialize(expected);
			var actual = serializer.Deserialize<ListWithProperties>(data);
			Assert.Equal(expected.Message, actual.Message);
			Assert.Equal(expected.Number, actual.Number);
		}

		[Fact]
		public void GenericListProperties()
		{
			var expected = new ListWithProperties<string> {"Hello", "World", "Hope", "This", "Works!"};
			expected.Message = HelloWorld;
			expected.Number = 6776;
			var data = _serializer.Serialize(expected);
			var actual = _serializer.Deserialize<ListWithProperties<string>>(data);
			Assert.Equal(expected, actual);
			Assert.Equal(HelloWorld, actual.Message);
			Assert.Equal(6776, actual.Number);
		}

		[Fact]
		public void GenericListAttributes()
		{
			var serializer = new ConfigurationContainer()
				.Type<ListWithProperties<string>>()
				.Member(x => x.Message, x => x.Attribute())
				.Member(x => x.Number, x => x.Attribute())
				.Create();

			var expected = new ListWithProperties<string> {"Hello", "World", "Hope", "This", "Works!"};
			expected.Message = HelloWorld;
			expected.Number = 6776;
			var data = serializer.Serialize(expected);
			var actual = serializer.Deserialize<ListWithProperties<string>>(data);
			Assert.Equal(expected, actual);
			Assert.Equal(expected.Message, actual.Message);
			Assert.Equal(expected.Number, actual.Number);
		}

		[Fact]
		public void HashSetProperties()
		{
			var expected = new HashSetWithProperties {"Hello", "World", "Hope", "This", "Works!"};
			expected.Message = HelloWorld;
			expected.Number = 6776;
			var data = _serializer.Serialize(expected);
			var actual = _serializer.Deserialize<HashSetWithProperties>(data);
			Assert.True(actual.SetEquals(expected));
			Assert.Equal(HelloWorld, actual.Message);
			Assert.Equal(6776, actual.Number);
		}

		[Fact]
		public void HashSetAttributes()
		{
			var serializer = new ConfigurationContainer()
				.Type<HashSetWithProperties>()
				.Member(x => x.Number, x => x.Attribute())
				.Create();

			var expected = new HashSetWithProperties {"Hello", "World", "Hope", "This", "Works!"};
			expected.Message = HelloWorld;
			expected.Number = 6776;
			var data = serializer.Serialize(expected);
			var actual = serializer.Deserialize<HashSetWithProperties>(data);
			Assert.True(actual.SetEquals(expected));
			Assert.Equal(expected.Message, actual.Message);
			Assert.Equal(expected.Number, actual.Number);
		}

		[Fact]
		public void GenericHashSetWithProperties()
		{
			var expected = new HashSetWithProperties<string> {"Hello", "World", "Hope", "This", "Works!"};
			expected.Message = HelloWorld;
			expected.Number = 6776;
			var data = _serializer.Serialize(expected);
			var actual = _serializer.Deserialize<HashSetWithProperties<string>>(data);
			Assert.True(actual.SetEquals(expected));
			Assert.Equal(HelloWorld, actual.Message);
			Assert.Equal(6776, actual.Number);
		}

		[Fact]
		public void GenericHashSetAttributes()
		{
			var serializer = new ConfigurationContainer()
				.Type<SimpleSubject>()
				.Member(x => x.Number, x => x.Attribute())
				.Create();

			var expected = new HashSetWithProperties<string> {"Hello", "World", "Hope", "This", "Works!"};
			expected.Message = HelloWorld;
			expected.Number = 6776;
			var data = serializer.Serialize(expected);
			var actual = serializer.Deserialize<HashSetWithProperties<string>>(data);
			Assert.True(actual.SetEquals(expected));
			Assert.Equal(expected.Message, actual.Message);
			Assert.Equal(expected.Number, actual.Number);
		}

		[Fact]
		public void DictionaryProperties()
		{
			var expected = new DictionaryWithProperties
			               {
				               {"First", 1},
				               {"Second", 2},
				               {"Other", 3}
			               };
			expected.Message = HelloWorld;
			expected.Number = 6776;

			var data = _serializer.Serialize(expected);
			var actual = _serializer.Deserialize<DictionaryWithProperties>(data);
			Assert.NotNull(actual);
			Assert.Equal(HelloWorld, actual.Message);
			Assert.Equal(6776, actual.Number);
			Assert.Equal(expected.Count, actual.Count);
			foreach (var entry in actual)
			{
				Assert.Equal(expected[entry.Key], entry.Value);
			}
		}

		[Fact]
		public void DictionaryAttributes()
		{
			var serializer = new ConfigurationContainer()
				.Type<SimpleSubject>()
				.Member(x => x.Number, x => x.Attribute())
				.Create();

			var expected = new DictionaryWithProperties
			               {
				               {"First", 1},
				               {"Second", 2},
				               {"Other", 3}
			               };
			expected.Message = HelloWorld;
			expected.Number = 6776;

			var data = serializer.Serialize(expected);
			var actual = serializer.Deserialize<DictionaryWithProperties>(data);
			Assert.NotNull(actual);
			Assert.Equal(HelloWorld, actual.Message);
			Assert.Equal(6776, actual.Number);
			Assert.Equal(expected.Count, actual.Count);
			foreach (var entry in actual)
			{
				Assert.Equal(expected[entry.Key], entry.Value);
			}
		}

		[Fact]
		public void GenericDictionaryProperties()
		{
			var expected = new GenericDictionaryWithProperties<int, string>
			               {
				               {1, "First"},
				               {2, "Second"},
				               {3, "Other"}
			               };
			expected.Message = HelloWorld;
			expected.Number = 6776;

			var data = _serializer.Serialize(expected);
			var actual = _serializer.Deserialize<GenericDictionaryWithProperties<int, string>>(data);
			Assert.NotNull(actual);
			Assert.Equal(HelloWorld, actual.Message);
			Assert.Equal(6776, actual.Number);
			Assert.Equal(expected.Count, actual.Count);
			foreach (var entry in actual)
			{
				Assert.Equal(expected[entry.Key], entry.Value);
			}
		}

		[Fact]
		public void GenericDictionaryAttributes()
		{
			var serializer = new ConfigurationContainer()
				.Type<GenericDictionaryWithProperties<int, string>>()
				.Member(x => x.Message, x => x.Attribute())
				.Member(x => x.Number, x => x.Attribute())
				.Create();

			var expected = new GenericDictionaryWithProperties<int, string>
			               {
				               {1, "First"},
				               {2, "Second"},
				               {3, "Other"}
			               };
			expected.Message = HelloWorld;
			expected.Number = 6776;

			var data = serializer.Serialize(expected);
			var actual = serializer.Deserialize<GenericDictionaryWithProperties<int, string>>(data);
			Assert.NotNull(actual);
			Assert.Equal(HelloWorld, actual.Message);
			Assert.Equal(6776, actual.Number);
			Assert.Equal(expected.Count, actual.Count);
			foreach (var entry in actual)
			{
				Assert.Equal(expected[entry.Key], entry.Value);
			}
		}

		class ListWithProperties : List<string>
		{
			public string Message { get; set; }

			public int Number { get; set; }
		}

		class ListWithProperties<T> : List<T>
		{
			public string Message { get; set; }

			public int Number { get; set; }
		}

		class HashSetWithProperties<T> : HashSet<T>
		{
			public string Message { get; set; }

			public int Number { get; set; }
		}

		class HashSetWithProperties : HashSet<string>
		{
			public string Message { get; set; }

			public int Number { get; set; }
		}

		class GenericDictionaryWithProperties<TKey, TValue> : Dictionary<TKey, TValue>
		{
			public string Message { get; set; }

			public int Number { get; set; }
		}

		class DictionaryWithProperties : Dictionary<string, int>
		{
			public string Message { get; set; }

			public int Number { get; set; }
		}

		class SimpleSubject
		{
			public string Message { get; set; }

			public int Number { get; set; }
		}
	}
}
// MIT License
//
// Copyright (c) 2016-2018 Wojciech Nag�rski
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

using ExtendedXmlSerializer.Core;
using ExtendedXmlSerializer.Core.Specifications;
using System.Collections.Generic;

namespace ExtendedXmlSerializer.ExtensionModel.References
{
	sealed class Encounters : IEncounters
	{
		readonly ISpecification<object> _specification;
		readonly IDictionary<object, Identifier> _store;

		public Encounters(IDictionary<object, Identifier> store) : this(new FirstInvocationByParameterSpecification<object>(), store) {}

		public Encounters(ISpecification<object> specification, IDictionary<object, Identifier> store)
		{
			_specification = specification;
			_store = store;
		}

		public bool IsSatisfiedBy(object parameter) => _specification.IsSatisfiedBy(parameter);

		public Identifier? Get(object parameter) => _store.GetStructure(parameter);
	}
}
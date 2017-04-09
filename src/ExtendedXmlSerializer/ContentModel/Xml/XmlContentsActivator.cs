// MIT License
// 
// Copyright (c) 2016 Wojciech Nag�rski
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

namespace ExtendedXmlSerializer.ContentModel.Xml
{
	sealed class XmlContentsActivator : IContentsActivator
	{
		readonly IContentReader _activator;
		readonly IXmlContentsActivator _contents;

		public XmlContentsActivator(IContentReader activator, IXmlContentsActivator contents)
		{
			_activator = activator;
			_contents = contents;
		}

		public IContentsAdapter Get(IContentAdapter parameter)
		{
			var reader = (IXmlReader) parameter;
			var xml = reader.Get();
			var attributes = xml.HasAttributes ? new XmlAttributes(xml) : (XmlAttributes?) null;

			var depth = XmlDepth.Default.Get(xml);
			var content = depth.HasValue ? new XmlContent(xml, depth.Value) : (XmlContent?) null;

			var result = attributes.HasValue || content.HasValue
				? _contents.Create(reader, _activator.Get(parameter), new XmlContents(attributes, content))
				: null;
			return result;
		}
	}
}
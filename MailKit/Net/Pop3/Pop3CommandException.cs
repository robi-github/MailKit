﻿//
// Pop3CommandException.cs
//
// Author: Jeffrey Stedfast <jeff@xamarin.com>
//
// Copyright (c) 2013-2014 Xamarin Inc. (www.xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
#if !NETFX_CORE
using System.Runtime.Serialization;
#endif

namespace MailKit.Net.Pop3 {
	/// <summary>
	/// A POP3 command exception.
	/// </summary>
	/// <remarks>
	/// The exception that is thrown when a POP3 command fails. Unlike a <see cref="Pop3ProtocolException"/>,
	/// a <see cref="Pop3CommandException"/> does not require the <see cref="Pop3Client"/> to be reconnected.
	/// </remarks>
#if !NETFX_CORE
	[Serializable]
#endif
	public class Pop3CommandException : CommandException
	{
#if !NETFX_CORE
		/// <summary>
		/// Initializes a new instance of the <see cref="MailKit.Net.Pop3.Pop3CommandException"/> class.
		/// </summary>
		/// <remarks>
		/// Creates a new <see cref="Pop3CommandException"/> from the serialized data.
		/// </remarks>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		protected Pop3CommandException (SerializationInfo info, StreamingContext context) : base (info, context)
		{
			if (info == null)
				throw new ArgumentNullException ("info");

			StatusText = info.GetString ("StatusText");
		}
#endif

		/// <summary>
		/// Initializes a new instance of the <see cref="MailKit.Net.Pop3.Pop3CommandException"/> class.
		/// </summary>
		/// <remarks>
		/// Creates a new <see cref="Pop3CommandException"/>.
		/// </remarks>
		/// <param name="message">The error message.</param>
		/// <param name="innerException">An inner exception.</param>
		public Pop3CommandException (string message, Exception innerException) : base (message, innerException)
		{
			StatusText = string.Empty;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MailKit.Net.Pop3.Pop3CommandException"/> class.
		/// </summary>
		/// <remarks>
		/// Creates a new <see cref="Pop3CommandException"/>.
		/// </remarks>
		/// <param name="message">The error message.</param>
		/// <param name="statusText">The response status text.</param>
		/// <param name="innerException">An inner exception.</param>
		/// <exception cref="System.ArgumentNullException">
		/// <paramref name="statusText"/> is <c>null</c>.
		/// </exception>
		public Pop3CommandException (string message, string statusText, Exception innerException) : base (message, innerException)
		{
			if (statusText == null)
				throw new ArgumentNullException ("statusText");

			StatusText = statusText;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MailKit.Net.Pop3.Pop3CommandException"/> class.
		/// </summary>
		/// <remarks>
		/// Creates a new <see cref="Pop3CommandException"/>.
		/// </remarks>
		/// <param name="message">The error message.</param>
		public Pop3CommandException (string message) : base (message)
		{
			StatusText = string.Empty;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MailKit.Net.Pop3.Pop3CommandException"/> class.
		/// </summary>
		/// <remarks>
		/// Creates a new <see cref="Pop3CommandException"/>.
		/// </remarks>
		/// <param name="message">The error message.</param>
		/// <param name="statusText">The response status text.</param>
		/// <exception cref="System.ArgumentNullException">
		/// <paramref name="statusText"/> is <c>null</c>.
		/// </exception>
		public Pop3CommandException (string message, string statusText) : base (message)
		{
			StatusText = statusText;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MailKit.Net.Pop3.Pop3CommandException"/> class.
		/// </summary>
		/// <remarks>
		/// Creates a new <see cref="Pop3CommandException"/>.
		/// </remarks>
		public Pop3CommandException ()
		{
			StatusText = string.Empty;
		}

		/// <summary>
		/// Get the response status text.
		/// </summary>
		/// <remarks>
		/// Gets the response status text.
		/// </remarks>
		/// <value>The response status text.</value>
		public string StatusText {
			get; private set;
		}
	}
}

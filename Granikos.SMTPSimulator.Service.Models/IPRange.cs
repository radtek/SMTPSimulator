// MIT License
// 
// Copyright (c) 2017 Granikos GmbH & Co. KG (https://www.granikos.eu)
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
using System;
using System.Diagnostics;
using System.Net;

namespace Granikos.SMTPSimulator.Service.Models
{
    public class IPRange : IIpRange
    {
        private IPAddress _start;
        private IPAddress _end;

        public IPRange(IPAddress start, IPAddress end)
        {
            if (start == null) throw new ArgumentNullException();
            if (end == null) throw new ArgumentNullException();
            if (!(start.AddressFamily == end.AddressFamily)) throw new ArgumentException();

            Start = start;
            End = end;
        }

        public IPAddress Start
        {
            get { return _start; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                if (!(value.AddressFamily == End.AddressFamily)) throw new ArgumentException();

                _start = value;
            }
        }

        public IPAddress End
        {
            get { return _end; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                if (!(value.AddressFamily == Start.AddressFamily)) throw new ArgumentException();
                
                _end = value;
            }
        }
    }
}
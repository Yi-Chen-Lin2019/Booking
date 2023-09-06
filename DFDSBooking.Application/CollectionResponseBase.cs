using System;
using System.Collections.Generic;

namespace DFDSBooking.Application
{
    public class CollectionResponseBase<T>
    {
        public IEnumerable<T> Data { get; set; }
    }
}

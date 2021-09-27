using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment
{
    public class SpaceProvider : IElementsProvider<string>
    {
        private readonly string separator = " ";


        public IEnumerable<string> ProcessData(string source)
        {
            return source.Split(separator);
        }
    }
}

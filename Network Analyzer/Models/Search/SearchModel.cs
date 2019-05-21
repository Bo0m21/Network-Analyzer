using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_Analyzer.Models.Search
{
    /// <summary>
    /// Selected type search
    /// </summary>
    public class SearchModel
    {
        public SelectedSearchType Type { get; set; }

        public int Opcode { get; set; }
        public byte[] Bytes { get; set; }
    }
}

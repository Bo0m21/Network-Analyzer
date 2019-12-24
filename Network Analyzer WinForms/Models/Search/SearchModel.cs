namespace Network_Analyzer_WinForms.Models.Search
{
    /// <summary>
    ///     Selected type search
    /// </summary>
    public class SearchModel
    {
        public SelectedSearchType Type { get; set; }

		public string Name { get; set; }
		public string Opcode { get; set; }
        public byte[] Bytes { get; set; }
    }
}
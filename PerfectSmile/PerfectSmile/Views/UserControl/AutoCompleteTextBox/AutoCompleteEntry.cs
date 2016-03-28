namespace PerfectSmile.Views.UserControl.AutoCompleteTextBox
{
    public class AutoCompleteEntry
    {
        private string[] keywordStrings;
        private string displayString;

        public string[] KeywordStrings
        {
            get
            {
                if (keywordStrings == null)
                {
                    keywordStrings = new string[] { displayString };
                }
                return keywordStrings;
            }
        }

        public string DisplayName
        {
            get { return displayString; }
            set { displayString = value; }
        }

        public string DisplayVal { get; set; }

        public AutoCompleteEntry(string name, string displayVal = null, params string[] keywords)
        {
            displayString = name;
            keywordStrings = keywords;
            DisplayVal = displayVal;
        }

        public override string ToString()
        {
            return displayString;
        }
    }
}

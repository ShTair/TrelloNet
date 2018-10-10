namespace ShComp.TrelloNet.Models
{
    public class CustomField
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Option[] Options { get; set; }

        public string idModel { get; set; }
        public string modelType { get; set; }
        public string fieldGroup { get; set; }
        public Display display { get; set; }
        public int pos { get; set; }
        public string type { get; set; }
    }

    public class Display
    {
        public bool cardFront { get; set; }
    }

    public class Option
    {
        public string Id { get; set; }

        public Value Value { get; set; }

        public string idCustomField { get; set; }
        public string color { get; set; }
        public int pos { get; set; }
    }

    public class Value
    {
        public string Text { get; set; }
    }

}

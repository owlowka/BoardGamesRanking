namespace BoardGamesRanking
{
    public class Item
    {
        public Item(string name, string publisher)
        {
            Name = name;
            Publisher = publisher;
        }
        public string Name { get; set; }
        public string Publisher { get; set; }

    }
}

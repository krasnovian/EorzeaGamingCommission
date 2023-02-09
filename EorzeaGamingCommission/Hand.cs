namespace EorzeaGamingCommission
{
    public class Hand
    {
        public List<Card> Cards { get; set; }
        public int Value { get; set; }
        public bool IsDealer { get; set; }

        public Hand(bool isDealer)
        {
            IsDealer = isDealer;
            Cards = new List<Card>();
            Value = 0;
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
            if (card.Rank == "Jack" || card.Rank == "Queen" || card.Rank == "King")
            {
                Value += 10;
            }
            else if (card.Rank == "Ace")
            {
                Value += 11;
            }
            else
            {
                Value += int.Parse(card.Rank);
            }
        }

        public override string ToString()
        {
            if (IsDealer)
            {
                return "Dealer hand: " + Cards[0] + " and Unkown card";
            }
            else
            {
                return "Player's hand: " + string.Join(", ", Cards) + ", Score: " + Value;

            }
        }
    }
}

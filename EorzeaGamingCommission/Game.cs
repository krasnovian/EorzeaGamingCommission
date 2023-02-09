namespace EorzeaGamingCommission
{
    public class Game
    {
        public Game() { }

        /// <summary>
        /// Simulates a basic game of blackjack
        /// </summary>
        /// <returns>0 for player loss, 1 for player win, 2 for push</returns>
        public int SimulateGame()
        {
            Deck deck = new Deck();
            deck.Shuffle();

            Hand playerHand = new Hand(false);
            Hand dealerHand = new Hand(true);

            playerHand.AddCard(deck.Deal());
            dealerHand.AddCard(deck.Deal());
            playerHand.AddCard(deck.Deal());
            dealerHand.AddCard(deck.Deal());

            Console.WriteLine(playerHand);
            Console.WriteLine(dealerHand);

            bool playerTurn = true;
            int upCardValue = int.Parse(dealerHand.Cards[0].Rank);
            string playerAction = "";
            while (playerTurn)
            {
                if (playerHand.Value <= 11)
                {
                    playerAction = "hit";
                    playerHand.AddCard(deck.Deal());
                }
                else if (playerHand.Value <= 16)
                {
                    if (upCardValue >= 7)
                    {
                        playerAction = "hit";
                        playerHand.AddCard(deck.Deal());
                    }
                }
                else { playerAction = "stay"; }
                if (playerAction == "hit" && playerHand.Value > 21) //bust
                {
                    return 0;
                }
                if (playerAction == "stay") { playerTurn = false; }
            }

            while (dealerHand.Value < 17)
            {
                dealerHand.AddCard(deck.Deal());
            }

            if (dealerHand.Value > 21) { return 1; }
            else if (dealerHand.Value > playerHand.Value) { return 0; }
            else if (dealerHand.Value == playerHand.Value) { return 2; }
            else { return 1; }
        }
    }
}

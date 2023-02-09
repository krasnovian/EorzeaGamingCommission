using Microsoft.AspNetCore.Mvc;

namespace EorzeaGamingCommission.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            bool playAgain = true;
            while (playAgain)
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

            }
            return View();
        }
    }
}

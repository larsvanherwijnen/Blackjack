using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Dealer
    {
        Deck Deck = new Deck();

        Hand DealerHand = new Hand();

        private bool IsBusted = false;

        //returns of dealer busted is
        public bool isBusted
        {
            get { return IsBusted; }
            set { IsBusted = value; }
        }
        //functie om de deck te shufflen 
        public void Shuffle()
        {
            Deck.Shuffle();
        }

        //pakt kaart uit deck en voegt deze toe aan de hand van de dealer
        public void Handcardtodealer(Dealer dealer)
        {
            //kijkt of dit de eerste kaart van de dealer is zoja, print de uit anders wordt de kaart alleen toegevoegd aan de hand van de dealer
            if (dealer.CardListLength() == 0)
            {
                Card card = Deck.GetCard();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Cards for dealer" + "\n" + card.naam + "\n");
                Console.ResetColor();
                dealer.AddCard(card);
            }
            else
            {
                Card card = Deck.GetCard();
                dealer.AddCard(card);
            }

        }
        //pakt kaart uit deck en voegt deze toe aan de hand van de speler
        public void HandCardToPlayer(Player player)
        {
            if (player.CardsList().Count == 0)
            {
                Card card = Deck.GetCard();
                Console.WriteLine("First card for " + player.Naam + "\n" + card.naam + "\n");
                player.AddCard(card);
            }
            else
            {
                Card card = Deck.GetCard();
                player.AddCard(card);

                Console.WriteLine("All cards for " + player.Naam + "\n");
                foreach (Card cards in player.CardsList())
                {
                    Console.WriteLine(" - " + cards.naam);
                };

                if (player.HandValue() <= 21)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Total value = " + player.HandValue());
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You busted with a total value of " + player.HandValue());
                    Console.ResetColor();
                }
            }
        }

        //print de voledige hand van de dealer
        public void RevealHand(Dealer dealer)
        {
            Console.WriteLine("All cards for dealer");
            foreach (Card cards in dealer.CardsList())
            {
                Console.WriteLine(" - " + cards.naam);
            };
            if (dealer.HandValue() <= 21)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Total value = " + dealer.HandValue());
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Total value = " + dealer.HandValue());
                Console.ResetColor();
            }
        }

        //bepaalt wie er gewonnen heeft de dealer of de speler
        public void WhoHasWon(Player player)
        {

            double WinOrLoss = 0;

            if (player.twoCardBlackjack == true && player.IsPlaying == false)
            {
                WinOrLoss = player.Bet * 1.5;
            }
            if (player.IsBusted == true)
            {
                WinOrLoss = player.Bet = 0;
            }

            if (isBusted == true)
            {
                WinOrLoss = player.Bet * 2;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Dealer busted");
                Console.ResetColor();
            }
            else
            {

                if (player.twoCardBlackjack == false)
                {
                    if (player.HandValue() < HandValue() && player.IsBusted == false)
                    {
                        WinOrLoss = player.Bet = 0;
                    }

                    if (player.HandValue() > HandValue() && player.IsBusted == false)
                    {
                        WinOrLoss = player.Bet * 2;
                    }
                }
            }

            if (HandValue() == player.HandValue())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(player.Naam + ", You and the dealer have the same handvalue! You will keep your bet!");
                Console.ResetColor();
            }
            else
            {
                if (player.IsBusted == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(player.Naam + ", You busted with a handvalue of " + player.HandValue());
                    Console.ResetColor();
                }
                else
                {
                    if (WinOrLoss == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(player.Naam + ", You lost your bet :( Dealer had a Handvalue of: " + HandValue() + ", You had a handvalue of " + player.HandValue());
                        Console.ResetColor();
                    }
                    else
                    {
      
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(player.twoCardBlackjack ? player.Naam + ", You had a blackJack with two cards! You won:  " + WinOrLoss : player.Naam + ", You won for the dealer! You won: " + WinOrLoss);
                        Console.ResetColor();
                    }
                }
            }
            Console.WriteLine("\n");



        }


        public void AddCard(Card card)
        {
            DealerHand.AddCardtoHand(card);
        }

        public List<Card> CardsList()
        {
            return DealerHand.GetCardsInHand();
        }

        public int CardListLength()
        {
            return Deck.GetCards();
        }

        public int HandValue()
        {
            return DealerHand.GetHandValue();
        }


    }
}

using System;
using System.Collections.Generic;
namespace Blackjack
{



    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Please put in de numbers of player you want to play with");
            Console.WriteLine("Enter number. Max 5!");
            int numberOfPlayers = 0;
            //hier word gekeken of er nummer word ingevoerd of niet 
            bool WrongInput = true;
            while (WrongInput)
            {
                var isValidNumber = Int32.TryParse(Console.ReadLine(), out numberOfPlayers);
                if (!isValidNumber)
                {
                    Console.WriteLine("Invalid number entered!");
                }
                else
                {
                    WrongInput = false;
                }
            }

            int activePlayers = numberOfPlayers;

            if (numberOfPlayers > 5)
            {
                Console.WriteLine("No room at the table, ending game");
                Environment.Exit(0);
            };

            List<Player> listOfPlayers = new List<Player>
            {

            };

            for (int i = 0; i <= numberOfPlayers - 1; i++)
            {

                int currentPlayer = i + 1;
                Console.WriteLine("Please enter name for player " + currentPlayer);
                String naam = Console.ReadLine();
                Console.WriteLine("Please enter bet for player " + currentPlayer);

                try
                {
                    int bet = Convert.ToInt32(Console.ReadLine());
                    listOfPlayers.Add(new Player(currentPlayer, naam, bet));
                }
                catch (Exception e)
                {
                    Console.WriteLine("It looks like your input was not a number, please try again");
                    int bet = Convert.ToInt32(Console.ReadLine());
                    listOfPlayers.Add(new Player(currentPlayer, naam, bet));
                }
            };

            //nieuwe dealer en dealer shuffled deck
            Dealer dealer = new Dealer();
            dealer.Shuffle();


            //in deze foreach krijg iedere speler 2 kaarten
            foreach (Player player in listOfPlayers)
            {
                if (player.IsPlaying == true)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        dealer.HandCardToPlayer(player);
                        if (player.HandValue() == 21)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("BlackJack");
                            Console.ResetColor();
                            activePlayers -= 1;
                            player.IsPlaying = false;
                            player.twoCardBlackjack = true;
                        }
                    }
                    Console.WriteLine("\n");
                }
            };

            //dealer krijgt eerste kaart
            dealer.Handcardtodealer(dealer);

            //zolang de deck meer dan 4 kaarten heeft en meer dan 0 active spelers
            //wordt er gevraagd of zo nog een kaart willen
            while (dealer.CardListLength() > 4 && activePlayers > 0)
            {

                foreach (Player player in listOfPlayers)
                {
                    if (player.IsPlaying == true)
                    {
                        Console.WriteLine(player.Naam + ", Do you want another card? Your current handvalue is " + player.HandValue());
                        Console.WriteLine("\n");
                        Console.WriteLine("Enter 1 for hit!");
                        Console.WriteLine("Enter 2 for stand!");
                        int choice = 0;

                       
                        bool WrongInput2 = true;
                        while (WrongInput2)
                        {
                            var isValidNumber = Int32.TryParse(Console.ReadLine(), out choice);
                            if (!isValidNumber)
                            {
                                Console.WriteLine("Invalid number entered!");
                            }
                            else
                            {
                                WrongInput2 = false;
                            }
                        }

                        //switchcase to 
                        switch (choice)
                        {
                            case 1:
                                dealer.HandCardToPlayer(player);
                                if (player.HandValue() > 21)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Busted");
                                    Console.ResetColor();
                                    activePlayers -= 1;
                                    player.IsPlaying = false;
                                    player.IsBusted = true;
                                }
                                if (player.HandValue() == 21)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("BlackJack");
                                    Console.ResetColor();
                                    activePlayers -= 1;
                                    player.IsPlaying = false;
                                }
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Stand with handvalue of: " + player.HandValue());
                                if (dealer.HandValue() > 21)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Dealer busted: " + dealer.HandValue());
                                    Console.ResetColor(); ;
                                }
                                Console.ResetColor();
                                activePlayers -= 1;
                                player.IsPlaying = false;
                                break;
                            default:
                                Console.WriteLine("Looks like the number you put in is not a option");
                                break;
                        }
                    }
                }
            }

            //dealer krijgt tweede kaart
            dealer.Handcardtodealer(dealer);

            bool KeepPicking = true;

            //als er geen active speler meer zijn word er gekeken of dealer nog meer kaarten moet pakken
            if (activePlayers == 0 && dealer.isBusted == false)
            {
                while (KeepPicking)
                {
                    if (dealer.HandValue() <= 16)
                    {
                        dealer.Handcardtodealer(dealer);
                        dealer.RevealHand(dealer);

                        if (dealer.HandValue() > 21)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Dealer busted: " + dealer.HandValue());
                            Console.ResetColor();
                            KeepPicking = false;
                            dealer.isBusted = true;

                        }
                    }
                    else
                    {
                        dealer.RevealHand(dealer);
                        KeepPicking = false;
                    }
                }
                //als dealer geen kaart meer hoeft te pakken word er voor iedere speler gekeken wie er gewonnen heeft
                foreach (Player player in listOfPlayers)
                {
                    dealer.WhoHasWon(player);
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;

namespace Blackjack
{

    class Deck
    {
        private static Random rng = new Random();

        List<Card> DeckOfCards = new List<Card>
        {
            new Card {sleeve = "Schoppen", cardValue = 11, naam = "Schoppen Ace"},
            new Card {sleeve = "Schoppen", cardValue = 2, naam = "Schoppen 2"},
            new Card {sleeve = "Schoppen", cardValue = 3, naam = "Schoppen 3"},
            new Card {sleeve = "Schoppen", cardValue = 4, naam = "Schoppen 4"},
            new Card {sleeve = "Schoppen", cardValue = 5, naam = "Schoppen 5"},
            new Card {sleeve = "Schoppen", cardValue = 6, naam = "Schoppen 6"},
            new Card {sleeve = "Schoppen", cardValue = 7, naam = "Schoppen 7"},
            new Card {sleeve = "Schoppen", cardValue = 8, naam = "Schoppen 8"},
            new Card {sleeve = "Schoppen", cardValue = 9, naam = "Schoppen 9"},
            new Card {sleeve = "Schoppen", cardValue = 10, naam = "Schoppen 10"},
            new Card {sleeve = "Schoppen", cardValue = 10, naam = "Schoppen Boer"},
            new Card {sleeve = "Schoppen", cardValue = 10, naam = "Schoppen Heer"},
            new Card {sleeve = "Schoppen", cardValue = 10, naam = "Schoppen Dame"},

            new Card {sleeve = "Ruiten", cardValue = 11, naam = "Ruiten Ace"},
            new Card {sleeve = "Ruiten", cardValue = 2, naam = "Ruiten 2"},
            new Card {sleeve = "Ruiten", cardValue = 3, naam = "Ruiten 3"},
            new Card {sleeve = "Ruiten", cardValue = 4, naam = "Ruiten 4"},
            new Card {sleeve = "Ruiten", cardValue = 5, naam = "Ruiten 5"},
            new Card {sleeve = "Ruiten", cardValue = 6, naam = "Ruiten 6"},
            new Card {sleeve = "Ruiten", cardValue = 7, naam = "Ruiten 7"},
            new Card {sleeve = "Ruiten", cardValue = 8, naam = "Ruiten 8"},
            new Card {sleeve = "Ruiten", cardValue = 9, naam = "Ruiten 9"},
            new Card {sleeve = "Ruiten", cardValue = 10, naam = "Ruiten 10"},
            new Card {sleeve = "Ruiten", cardValue = 10, naam = "Ruiten Boer"},
            new Card {sleeve = "Ruiten", cardValue = 10, naam = "Ruiten Heer"},
            new Card {sleeve = "Ruiten", cardValue = 10, naam = "Ruiten Dame"},

            new Card {sleeve = "Harten", cardValue = 11, naam = "Harten Ace"},
            new Card {sleeve = "Harten", cardValue = 2, naam = "Harten 2"},
            new Card {sleeve = "Harten", cardValue = 3, naam = "Harten 3"},
            new Card {sleeve = "Harten", cardValue = 4, naam = "Harten 4"},
            new Card {sleeve = "Harten", cardValue = 5, naam = "Harten 5"},
            new Card {sleeve = "Harten", cardValue = 6, naam = "Harten 6"},
            new Card {sleeve = "Harten", cardValue = 7, naam = "Harten 7"},
            new Card {sleeve = "Harten", cardValue = 8, naam = "Harten 8"},
            new Card {sleeve = "Harten", cardValue = 9, naam = "Harten 9"},
            new Card {sleeve = "Harten", cardValue = 10, naam = "Harten 10"},
            new Card {sleeve = "Harten", cardValue = 10, naam = "Harten Boer"},
            new Card {sleeve = "Harten", cardValue = 10, naam = "Harten Heer"},
            new Card {sleeve = "Harten", cardValue = 10, naam = "Harten Dame"},

            new Card {sleeve = "Klaveren", cardValue = 11, naam = "Klaveren Ace"},
            new Card {sleeve = "Klaveren", cardValue = 2, naam = "Klaveren 2"},
            new Card {sleeve = "Klaveren", cardValue = 3, naam = "Klaveren 3"},
            new Card {sleeve = "Klaveren", cardValue = 4, naam = "Klaveren 4"},
            new Card {sleeve = "Klaveren", cardValue = 5, naam = "Klaveren 5"},
            new Card {sleeve = "Klaveren", cardValue = 6, naam = "Klaveren 6"},
            new Card {sleeve = "Klaveren", cardValue = 7, naam = "Klaveren 7"},
            new Card {sleeve = "Klaveren", cardValue = 9, naam = "Klaveren 9"},
            new Card {sleeve = "Klaveren", cardValue = 8, naam = "Klaveren 8"},
            new Card {sleeve = "Klaveren", cardValue = 10, naam = "Klaveren 10"},
            new Card {sleeve = "Klaveren", cardValue = 10, naam = "Klaveren Boer"},
            new Card {sleeve = "Klaveren", cardValue = 10, naam = "Klaveren Heer"},
            new Card {sleeve = "Klaveren", cardValue = 10, naam = "Klaveren Dame"}
        };

        //functie om deck de shufflen
        public void Shuffle()
        {
            int n = DeckOfCards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card card = DeckOfCards[k];
                DeckOfCards[k] = DeckOfCards[n];
                DeckOfCards[n] = card;
            }

        }
        //pakt eerste kaart uit deck en returned deze 
        //ook word de gekozen kaart hier uit de deck verwijderd
        public Card GetCard()
        {
            Card card = DeckOfCards[1];
            DeckOfCards.RemoveAt(1);
            return card;
        }
        //return de lengte van de list
        public int GetCards()
        {
            return DeckOfCards.Count;
        }

    }
}


using System.Collections.Generic;

namespace Blackjack
{
    class Hand
    {


        List<Card> DeckOfCards = new List<Card>
        {

        };
        
        int noOfAces = 0;
        int totalHandValue = 0;

        //hier word er een kaart aan de hand van de speler of dealer toevoegd 
        //en gekeken of de ace 1 of 11 waard moet zijn en de handvalue berekent
        public void AddCardtoHand(Card card)
        {
            if (card.cardValue == 11)
            {
                noOfAces += 1;
            }
            totalHandValue += card.cardValue;
            if (totalHandValue > 21 && noOfAces > 0)
            {
                totalHandValue -= 10;
                noOfAces -= 1;

            }

            DeckOfCards.Add(card);
        }

        //returns list van alle card
        public List<Card> GetCardsInHand()
        {
            return DeckOfCards;
        }

        //hier word de handvalue gereturned
        public int GetHandValue()
        {
            return totalHandValue;
        }


    }
}

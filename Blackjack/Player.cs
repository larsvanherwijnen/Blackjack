using System.Collections.Generic;

namespace Blackjack
{
    class Player
    {
        private int id;
        private string naam;
        private int bet;
        private bool isplaying = true;
        private bool isBusted = false;
        private bool TwoCardBlackjack = false;

        public Player(int id, string naam, int bet)
        {
            this.id = id;
            this.naam = naam;
            this.bet = bet;
        }

        public int Id
        {
            get { return id; }
        }

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }
        public int Bet
        {
            get { return bet; }
            set { bet = value; }
        }

        public bool IsPlaying
        {
            get { return isplaying; }
            set { isplaying = value; }
        }
        public bool IsBusted
        {
            get { return isBusted; }
            set { isBusted = value; }
        }

        public bool twoCardBlackjack
        {
            get { return TwoCardBlackjack; }
            set { TwoCardBlackjack = value; }
        }
        Hand spelerHand = new Hand();

        //functie om kaart aan hand in dealer class gekozen kaart toe tevoegen aan spelerhand
        public void AddCard(Card card)
        {
            spelerHand.AddCardtoHand(card);
        }
        public int HandValue()
        {
            return spelerHand.GetHandValue();
        }

        public List<Card> CardsList()
        {
            return spelerHand.GetCardsInHand();
        }

    }
}

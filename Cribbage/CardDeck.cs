namespace Cribbage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class functions as a standard 52-card deck of cards.
    /// You can draw from the deck and return cards to the deck.
    ///
    /// Credit for portions of the implementation goes to user, Bridge 
    /// @https://stackoverflow.com/questions/18484577/how-to-get-a-random-number-from-a-range-excluding-some-values.
    /// I added the removal of cards from the deck and the interaction with the card manager, but the rest
    /// is acredited to Bridge.
    /// </summary>
    public class CardDeck
    {
        // Constants for defining the dimensions of the deck.
        private const int TOTAL_CARDS = 52;
        
        private HashSet<int> drawn;
        private Random rand;

        public CardDeck()
        {
            drawn = new HashSet<int>() {};
            rand = new System.Random();
        }

        public byte DrawCard()
        {
            IEnumerable<int> range = Enumerable.Range(1,TOTAL_CARDS).Where(i => !drawn.Contains(i));
            int rangeIdx = rand.Next(0, 100-drawn.Count);
            int cardIdx = range.ElementAt(rangeIdx);
            drawn.Append(cardIdx);
            return CardManager.GetCardID(cardIdx);
        }

        public void ReturnCard(int cardIdx) => drawn.Remove(cardIdx);
        public void ReturnCard(byte cardID)
        {
            int cardIdx = CardManager.GetCardIdx(cardID);
            drawn.Remove(cardIdx);
        }
    }
}
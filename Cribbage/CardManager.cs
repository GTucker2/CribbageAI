namespace Cribbage
{
    using System;

    /// <summary>
    /// This class defines a series of readonly bytes to
    /// be used to represent the suits and numbers of a 
    /// standard, 52-card deck of cards.
    /// </summary>
    public static class CardManager
    {
        // Readonly vars defining card suits.
        public static readonly byte CLUBS    = 0b00010000;
        public static readonly byte DIAMONDS = 0b00100000;
        public static readonly byte HEARTS   = 0b01000000;
        public static readonly byte SPADES   = 0b10000000;
        public static readonly byte [] SUITS = {CLUBS, DIAMONDS, HEARTS, SPADES};

        // Readonly vars defining card numbers.
        public static readonly byte _A  = 0b00000001;
        public static readonly byte _2  = 0b00000010;
        public static readonly byte _3  = 0b00000011;
        public static readonly byte _4  = 0b00000100;
        public static readonly byte _5  = 0b00000101;
        public static readonly byte _6  = 0b00000110;
        public static readonly byte _7  = 0b00000111;
        public static readonly byte _8  = 0b00001000;
        public static readonly byte _9  = 0b00001001;
        public static readonly byte _10 = 0b00001010;
        public static readonly byte _J  = 0b00001011;
        public static readonly byte _Q  = 0b00001100;
        public static readonly byte _K  = 0b00001101;
        public static readonly byte [] NUMS = {_A, _2, _3, _4, _5, _6, _7, _8, _9, _10, _J, _Q, _K};
    
        /// <summary>
        /// Generates and returns the ID for the specified card.
        /// Card IDs are generated on the basis that the first card is
        /// the Ace of Clubs and that the last card is the King of Spades.
        /// Suits are ordered as follows: Clubs, Diamonds, Hearts, Spades.
        /// Cards are numbered numerically. Face cards follow the ordering: Jack, Queen, King. 
        /// </summary>
        /// <param name="cardIdx">
        /// The index of the desired card within the range, 1 to 52.
        /// </param>
        /// <returns>
        /// Returns the ID of the specified card.
        /// </returns>
        public static byte GetCardID(int cardIdx)
        {
            // Check for invalid input.
            if (cardIdx > 52 || cardIdx <= 0)
            {
                Console.WriteLine("No card for specified index, " + cardIdx + ". Returning '0'.");
                return 0b0;
            }

            // Generate and return the ID of the specified card.
            if (cardIdx % NUMS.Length == 0) return (byte)(SUITS[cardIdx / NUMS.Length] & _A);
            else return (byte)(SUITS[cardIdx / NUMS.Length] & NUMS[cardIdx % NUMS.Length]);
        }

        /// <summary>
        /// Generates and returns the index for the specified card between 1 and 52.
        /// Card indecies are generated on the basis that the first card is
        /// the Ace of Clubs and that the last card is the King of Spades.
        /// Suits are ordered as follows: Clubs, Diamonds, Hearts, Spades.
        /// Cards are numbered numerically. Face cards follow the ordering: Jack, Queen, King. 
        /// </summary>
        /// <param name="cardID">
        /// The ID of the desired card within the range.
        /// </param>
        /// <returns>
        /// Returns the index of the specified card between 1 and 52.
        /// </returns>
        public static int GetCardIdx(byte cardID)
        {
            // Check for invalid input

            // Generage the ID of the card based on the given index.
            int cardIdx = 0;
            for (int byteIDX = 0; byteIDX < SUITS.Length; byteIDX++)
                if ((cardID & SUITS[byteIDX]) == SUITS[byteIDX]) cardIdx = NUMS.Length * byteIDX;
            cardID &= 0b00001111;
            cardIdx += cardID;
            return cardIdx;
        }
    }
}
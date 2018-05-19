namespace Cards
{
    using System;

    abstract class CardsPlayer
    {
        abstract private byte [] hand;
        abstract public void printHand();

    }
}

namespace Cribbage
{
    public class CribbagePlayer : CardsPlayer
    {
        private const HAND_MAX_PRESHOW = 6;
        private const HAND_MAX_POSTSHOW = 4;

        private override byte [] hand = new byte [HAND_MAX_PRESHOW];

        public CribbagePlayer()
        {

        }

        public override void printHand()
        {

        }
    }
}
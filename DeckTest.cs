using FluentAssertions;

namespace cassidoo_2025_12_8
{
    [TestClass]
    public sealed class DeckTest
    {
        private void CheckValidCards(string[] cards)
        {
			foreach (string c in cards)
			{
				c.Length.Should().BeInRange(2, 3);
			}
		}

        private void CheckDistinct(string[] hand1, string[] hand2)
        {
            foreach (string c in hand1)
            {
                hand2.Contains(c).Should().BeFalse();
            }
        }

        [TestMethod]
        public void TestDeckInitialize()
        {
            Deck d = new Deck();
            d.cards.Should().NotBeNull();
            d.cards.Should().HaveCount(52);
            CheckValidCards(d.cards);
        }

        [TestMethod]
        public void TestDeckDraw()
        {
            Deck d = new Deck();
            string[] hand = d.Draw(5);
            hand.Should().HaveCount(5);
            d.cards.Should().HaveCount(52 - 5);
            CheckValidCards(hand);
            CheckValidCards(d.cards);
            CheckDistinct(hand, d.cards);

            string[] hand2 = d.Draw(10);
            hand2.Should().HaveCount(10);
            d.cards.Should().HaveCount(52 - 5 - 10);
            CheckValidCards(hand2);
            CheckValidCards(d.cards);
            CheckDistinct(hand2, d.cards);
            CheckDistinct(hand, hand2);

            string[] hand3 = d.Draw(52);
            hand3.Should().HaveCount(52 - 5 - 10);
            CheckValidCards(hand3);
            CheckDistinct(hand3, hand);
            CheckDistinct(hand3, hand2);
            d.cards.Should().BeEmpty();

            string[] hand4 = d.Draw(1);
            hand4.Should().BeEmpty();
            d.cards.Should().BeEmpty();
        }

        [TestMethod]
        public void TestShuffle()
        {
            Random r = new Random(5);
            Deck d = new Deck();
            d.random = r; // this lets us control the randomness so the test will be consistent.
            string[] cardCopy = new string[52];
            d.cards.CopyTo(cardCopy, 0);
            d.Shuffle();
            d.cards.Should().HaveCount(52);
            CheckValidCards(d.cards);
            string[] allDeck = d.Draw(52);
            allDeck.Should().HaveCount(52);
            CheckValidCards(allDeck);
            bool allSame = true;
            for(int i = 0; i < 52; ++i)
            {
                if (cardCopy[i] != allDeck[i]) 
                {
                    allSame = false;
                    break;
                }
            }
            allSame.Should().BeFalse();
        }

        public void TestShuffleAndDraw()
        {
            Deck d = new Deck();
            d.Shuffle();
            string[] hand5 = d.Draw(5);
            hand5.Should().HaveCount(5);
            d.cards.Should().HaveCount(52 - 5);
            CheckDistinct(hand5, d.cards);
        }
    }
}

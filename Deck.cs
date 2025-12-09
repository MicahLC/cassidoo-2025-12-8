using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassidoo_2025_12_8
{
	public class Deck
	{
		internal string[] cards = new string[52];
		internal Random random = new Random(DateTime.Now.Millisecond); // give it a random seed so it's different every time

		private static string[] RANKS = ["A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2"];
		private static string[] SUITS = ["♣️", "♦️", "♥️", "♠️"];
		public Deck()
		{
			int index = 0;
			foreach (string rank in RANKS)
			{
				foreach (string suit in SUITS)
				{
					string combined = rank + suit;
					cards[index++] = combined;
				}
			}
		}

		public string[] Draw(int n)
		{
			if (cards.Length == 0)
			{
				return [];
			}
			int remains = cards.Length - n;
			if (remains < 0) {
				n = cards.Length;
				remains = 0;
			}
			string[] hand = cards.Take(n).ToArray();
			if (remains == 0)
			{
				cards = [];
			}
			else
			{
				cards = cards.Skip(n).ToArray();
			}
			return hand;
		}

		public void Shuffle()
		{
			int length = cards.Length;
			for(int i = 0; i < length; ++i)
			{
				// Let's do a swap for every index, that'll be sufficient.
				int swapIndex = random.Next(length - 1);
				if (swapIndex == i)
				{
					continue;
				}
				string s = cards[i];
				cards[i] = cards[swapIndex];
				cards[swapIndex] = s;
			}
		}
	}
}

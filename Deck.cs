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
		internal Random random = new Random();

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
			return [];
		}

		public void Shuffle()
		{

		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBlackGack
{
    class Koloda
    {
        List<Card> _cards;
        string[] _mast;

        public Koloda(string filepath)
        {
            _cards = new List<Card>();
            _mast = new string[4] { "♥", "♦", "♣", "♠" };
            GenerateNewKoloda(filepath);
        }
        public Card GetCard()
        {
            if (_cards.Count > 0)
            {
                Card card = _cards[0];
                _cards.RemoveAt(0);
                return card;
            }
            return null;
        }
        public void Shuffle()
        {
            Random random = new Random();

            for (int i = 0; i < _cards.Count; i++)
            {
                int num = random.Next(_cards.Count);
                Card card = _cards[i];
                _cards[i] = _cards[num];
                _cards[num] = card;
            }
        }
        public void GenerateNewKoloda(string filepath)
        {
            int I = 1;
            _cards.Clear();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    string cardname = "image_part_0";
                    if (I < 10)
                        cardname += "0";
                    cardname += I.ToString() + ".jpg";
                    I++;
                    _cards.Add(new Card()
                    {
                        Mast = _mast[i],
                        Nominal = j + 1,
                        BackPicture = filepath + "rib.jpg",
                        IsBack = true,
                        Picture = filepath + cardname
                    });
                }
            }
        }
    }
}

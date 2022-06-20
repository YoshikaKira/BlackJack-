using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBlackGack
{
    class BlackJack
    {
        List<Player> _players;
        Koloda _koloda;
        public BlackJack(List<Player> players)
        {
            _players = players;
        }
        public void NewGame()
        {
            _koloda = new Koloda("C:\\Users\\STUDENT\\Desktop\\cards\\");
            _koloda.Shuffle();
            foreach(Player pl in _players)
            {
                pl.Hand.Clear();
                pl.Hand.Add(_koloda.GetCard());
                pl.Hand[0].IsBack = false;
                pl.Hand.Add(_koloda.GetCard());
            }
        }
        public void EndGame()
        {
            int max = 0;
            int Jackpot = 0;
            int count = 0;
            foreach(Player player in _players)
            {
                int PlayerScore = Score(player);
                if (PlayerScore <= 21 && PlayerScore > max)
                {
                    max = Score(player);
                }
                Jackpot += player.Bet;
            }
            /*foreach (Player player in _players)
                count += Score(player) == max ? 1 : 0;
            Jackpot /= count;*/
            foreach (Player player in _players)
            {
                if (Score(player) == max)
                    player.Bank += player.Bet*2;
                else
                    player.Bank += 0;
            }
        }
        public void MoreCard(Player player)
        {
            player.Hand.Add(_koloda.GetCard());
        }

        public int Score(Player player)
        {
            int score = 0;
            int count = 0;
            foreach (Card card in player.Hand)
            {
                if (card.Nominal >= 10)
                    score += 10;
                else if (card.Nominal > 1)
                    score += card.Nominal;
                else
                    count++;
            }
            score += count;
            if (count > 0 && score <= 11)
                score += 10;
            return score;
        }
    }
}

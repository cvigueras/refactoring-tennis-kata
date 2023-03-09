namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _mScore1;
        private int _mScore2;
        private readonly string _player1Name;

        private TennisGame1(string player1Name)
        {
            _player1Name = player1Name;
        }

        public static TennisGame1 Create(string player1Name)
        {
            return new TennisGame1(player1Name);
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                _mScore1 += 1;
            else
                _mScore2 += 1;
        }

        public string GetScore()
        {
            var score = string.Empty;
            if (_mScore1 == _mScore2)
            {
                score = GetScoreEquals();
            }
            else if (_mScore1 >= 4 || _mScore2 >= 4)
            {
                score = ScoreAdvantageOrWin();
            }
            else
            {
                score = GetGeneralScore(score);
            }
            return score;
        }

        private string GetGeneralScore(string score)
        {
            for (var i = 1; i < 3; i++)
            {
                score = SetPlayerScore(score, i);
            }

            return score;
        }

        private string SetPlayerScore(string score, int i)
        {
            int tempScore;
            if (i != 1)
            {
                score += "-";
                tempScore = _mScore2;
            }
            else
                tempScore = _mScore1;

            switch (tempScore)
            {
                case 0:
                    score += "Love";
                    break;
                case 1:
                    score += "Fifteen";
                    break;
                case 2:
                    score += "Thirty";
                    break;
                case 3:
                    score += "Forty";
                    break;
            }

            return score;
        }

        private string ScoreAdvantageOrWin()
        {
            var minusResult = _mScore1 - _mScore2;
            return minusResult switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };
        }

        private string GetScoreEquals() =>
            _mScore1 switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
    }
}
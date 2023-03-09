namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;

        private string _p1Res = string.Empty;
        private string _p2Res = string.Empty;
        private string _player1Name;
        private string _player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _p1Point = 0;
            _player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = string.Empty;
            score = SetP1Point(score);
            score = SetP2Point(score);

            score = SetScoreAdvantageP1(score);
            score = SetScoreAdvantageP2(score);

            score = GetScoreAdvantagePlayer(score);

            score = GetScoreWinPlayer(score);
            return score;
        }

        private string GetScoreWinPlayer(string score)
        {
            if (_p1Point >= 4 && _p2Point >= 0 && (_p1Point - _p2Point) >= 2)
            {
                score = "Win for player1";
            }

            if (_p2Point >= 4 && _p1Point >= 0 && (_p2Point - _p1Point) >= 2)
            {
                score = "Win for player2";
            }

            return score;
        }

        private string GetScoreAdvantagePlayer(string score)
        {
            if (_p1Point > _p2Point && _p2Point >= 3)
            {
                score = "Advantage player1";
            }

            if (_p2Point > _p1Point && _p1Point >= 3)
            {
                score = "Advantage player2";
            }

            return score;
        }

        private string SetScoreAdvantageP2(string score)
        {
            if (_p2Point > _p1Point && _p2Point < 4)
            {
                if (_p2Point == 2)
                    _p2Res = "Thirty";
                if (_p2Point == 3)
                    _p2Res = "Forty";
                if (_p1Point == 1)
                    _p1Res = "Fifteen";
                if (_p1Point == 2)
                    _p1Res = "Thirty";
                score = _p1Res + "-" + _p2Res;
            }

            return score;
        }

        private string SetScoreAdvantageP1(string score)
        {
            if (_p1Point > _p2Point && _p1Point < 4)
            {
                _p1Res = _p1Point switch
                {
                    2 => "Thirty",
                    3 => "Forty",
                    _ => _p1Res
                };
                if (_p2Point == 1)
                    _p2Res = "Fifteen";
                if (_p2Point == 2)
                    _p2Res = "Thirty";
                score = _p1Res + "-" + _p2Res;
            }

            return score;
        }

        private string SetP2Point(string score)
        {
            if (_p2Point > 0 && _p1Point == 0)
            {
                _p2Res = _p2Point switch
                {
                    1 => "Fifteen",
                    2 => "Thirty",
                    3 => "Forty",
                    _ => _p2Res
                };

                _p1Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }

            return score;
        }

        private string SetP1Point(string score)
        {
            if (_p1Point == _p2Point && _p1Point < 3)
            {
                score = _p1Point switch
                {
                    0 => "Love",
                    1 => "Fifteen",
                    2 => "Thirty",
                    _ => score
                };
                score += "-All";
            }

            if (_p1Point == _p2Point && _p1Point > 2)
                score = "Deuce";

            if (_p1Point > 0 && _p2Point == 0)
            {
                _p1Res = _p1Point switch
                {
                    1 => "Fifteen",
                    2 => "Thirty",
                    3 => "Forty",
                    _ => _p1Res
                };

                _p2Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }

            return score;
        }

        private void P1Score()
        {
            _p1Point++;
        }

        private void P2Score()
        {
            _p2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == _player1Name)
                P1Score();
            else
                P2Score();
        }

    }
}
namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;
        private readonly string _player1Name;
        private readonly string _player2Name;
        private readonly string[] _allPoints;


        public TennisGame3(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
            _allPoints = new[] { "Love", "Fifteen", "Thirty", "Forty", "Deuce" };
        }

        public string GetScore()
        {
            string point;
            if ((_p2Point < 4 && _p1Point < 4) && (_p2Point + _p1Point < 6))
            {
                point = _allPoints[_p2Point];
                return (_p2Point == _p1Point) ? point + "-All" : point + "-" + _allPoints[_p1Point];
            }

            if (_p2Point.Equals(_p1Point))
                return _allPoints[^1];

            point = _p2Point > _p1Point ? _player1Name : _player2Name;
            return ((_p2Point - _p1Point) * (_p2Point - _p1Point) == 1) ? "Advantage " + point : "Win for " + point;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _p2Point += 1;
            else
                _p1Point += 1;
        }

    }
}
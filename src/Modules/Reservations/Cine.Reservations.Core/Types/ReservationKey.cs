namespace Cine.Reservations.Core.Types
{
    public class ReservationKey
    {
        public string Value => $"{_cinemaId}:{_movieId}:{_hallId}:{_row}:{_number}";

        private readonly CinemaId _cinemaId;
        private readonly MovieId _movieId;
        private readonly HallId _hallId;
        private readonly string _row;
        private readonly int _number;

        public ReservationKey(CinemaId cinemaId, MovieId movieId, HallId hallId, string row, int number)
        {
            _cinemaId = cinemaId;
            _movieId = movieId;
            _hallId = hallId;
            _row = row;
            _number = number;
        }
    }
}

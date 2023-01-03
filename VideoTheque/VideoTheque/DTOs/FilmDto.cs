namespace VideoTheque.DTOs
{
    public class FilmDto
    {
        public int Id { get; set; }
        public PersonneDto Director { get; set; }
        public PersonneDto Scenarist { get; set; }
        public long Duration { get; set; }
        public SupportDto Support { get; set; }
        public AgeRatingDto AgeRating { get; set; }
        public GenreDto Genre { get; set; }
        public string Title { get; set; }
        public PersonneDto FirstActor { get; set; }
    }
}

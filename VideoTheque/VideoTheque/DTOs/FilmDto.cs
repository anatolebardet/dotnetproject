namespace VideoTheque.DTOs
{
    public class FilmDto
    {
        public int Id { get; set; }
        public int IdDirector { get; set; }
        public int IdScenarist { get; set; }
        public long Duration { get; set; }
        public int IdSupport { get; set; }
        public int IdAgeRating { get; set; }
        public int IdGenre { get; set; }
        public string Title { get; set; }
        public int IdFirstActor { get; set; }
    }
}

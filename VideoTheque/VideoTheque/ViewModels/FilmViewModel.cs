using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VideoTheque.ViewModels
{
    public class FilmViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("iddirector")]
        [Required]
        public int IdDirector { get; set; }

        [JsonPropertyName("idscenarist")]
        public int IdScenarist { get; set; }

        [JsonPropertyName("duration")]
        [Required]
        public long Duration { get; set; }

        [JsonPropertyName("idsupport")]
        public int IdSupport { get; set; }

        [JsonPropertyName("idagerating")]
        [Required]
        public int IdAgeRating { get; set; }

        [JsonPropertyName("idgenre")]
        public int IdGenre { get; set; }

        [JsonPropertyName("title")]
        [Required]
        public string Title { get; set; }

        [JsonPropertyName("idfirstactor")]
        public int IdFirstActor { get; set; }

    }
}

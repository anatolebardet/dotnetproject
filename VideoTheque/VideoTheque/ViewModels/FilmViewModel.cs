using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VideoTheque.DTOs;

namespace VideoTheque.ViewModels
{
    public class FilmViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("director")]
        [Required]
        public string Director { get; set; }

        [JsonPropertyName("scenarist")]
        public string Scenarist { get; set; }

        [JsonPropertyName("duration")]
        [Required]
        public long Duration { get; set; }

        [JsonPropertyName("support")]
        public string Support { get; set; }

        [JsonPropertyName("agerating")]
        [Required]
        public string AgeRating { get; set; }

        [JsonPropertyName("genre")]
        public string Genre { get; set; }

        [JsonPropertyName("title")]
        [Required]
        public string Title { get; set; }

        [JsonPropertyName("firstactor")]
        public string FirstActor { get; set; }

    }
}

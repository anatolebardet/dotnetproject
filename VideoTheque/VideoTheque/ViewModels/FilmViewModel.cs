using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VideoTheque.DTOs;

namespace VideoTheque.ViewModels
{
    public class FilmViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("realisateur")]
        [Required]
        public int IdDirector { get; set; }

        [JsonPropertyName("scenariste")]
        [Required]
        public int IdScenarist { get; set; }

        [JsonPropertyName("duree")]
        [Required]
        public long Duration { get; set; }

        [JsonPropertyName("support")]
        [Required]
        public int IdSupport { get; set; }

        [JsonPropertyName("age-rating")]
        [Required]
        public int IdAgeRating { get; set; }

        [JsonPropertyName("genre")]
        [Required]
        public int IdGenre { get; set; }

        [JsonPropertyName("titre")]
        [Required]
        public string Title { get; set; }

        [JsonPropertyName("acteur-principal")]
        [Required]
        public string IdFirstActor { get; set; }

    }
}
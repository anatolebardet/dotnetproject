using VideoTheque.DTOs;

namespace VideoTheque.Businesses.AgeRatings
{
    public interface IAgeRatingsBusiness
    {
        Task<List<AgeRatingDto>> GetAgeRatings();

        AgeRatingDto GetAgeRating(int id);

        AgeRatingDto InsertAgeRating(AgeRatingDto AgeRating);

        void UpdateAgeRating(int id, AgeRatingDto AgeRating);

        void DeleteAgeRating(int id);
    }
}

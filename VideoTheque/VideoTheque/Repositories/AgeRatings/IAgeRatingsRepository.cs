using Microsoft.EntityFrameworkCore.ChangeTracking;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.AgeRatings
{
    public interface IAgeRatingsRepository
    {
        Task<List<AgeRatingDto>> GetAgeRatings();

        ValueTask<AgeRatingDto?> GetAgeRating(int id);

        Task InsertAgeRating(AgeRatingDto ageRating);

        Task UpdateAgeRating(int id, AgeRatingDto ageRating);

        Task DeleteAgeRating(int id);
    }
}

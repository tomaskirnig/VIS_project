using Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Domain
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public DateTime ReviewDate { get; set; }

        public Review(ReviewDTO reviewDTO)
        {
            MapReview(reviewDTO);
        }

        public Review(int reviewId)
        {
            ReviewDTO review = ReviewTDG.GetById(reviewId);

            if (review != null)
            {
                MapReview(review);
            }
            else
            {
                throw new ArgumentException("Review not found");
            }
        }

        public void MapReview(ReviewDTO reviewDTO)
        {
            ReviewId = reviewDTO.ReviewId;
            GameId = reviewDTO.GameId;
            PlayerId = reviewDTO.PlayerId;
            Rating = reviewDTO.Rating;
            Text = reviewDTO.Text;
            ReviewDate = reviewDTO.ReviewDate;
        }

        public void Update()
        {
            ReviewDTO review = new ReviewDTO
            {
                ReviewId = ReviewId,
                GameId = GameId,
                PlayerId = PlayerId,
                Rating = Rating,
                Text = Text,
                ReviewDate = ReviewDate
            };

            ReviewTDG.Update(review);
        }

        public static List<Review> GetAllReviews()
        {
            List<ReviewDTO> reviewsDTO = ReviewTDG.GetAll();
            return reviewsDTO.Select(dto => new Review(dto)).ToList();
        }

        public static int GetAverageRating(int gameId)
        {
            return (int)ReviewTDG.GetAverageRating(gameId);
        }

        public static List<(int GameId, float AverageRating)> GetTopNAverageRatings(int count)
        {
            return ReviewTDG.GetTopNAverageRatings(count);
        }
    }
}

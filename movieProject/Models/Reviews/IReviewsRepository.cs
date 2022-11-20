using movieProject.Models.Category;

namespace movieProject.Models.Reviews
{
    public interface IReviewsRepository
    {
        public IEnumerable<Reviews> GetAllReviews();
        public Reviews GetReviewProductID(int id);
        public void UpdateReview(Reviews review);
        public void InsertReview(Reviews reviewToInsert);
        public void DeleteReview(Reviews review);
    }
}

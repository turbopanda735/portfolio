using Dapper;
using movieProject.Models.Product;
using System.Data;

namespace movieProject.Models.Reviews
{
    public class ReviewRepository : IReviewsRepository
    {
        private readonly IDbConnection _conn;
        public ReviewRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void DeleteReview(Reviews review)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reviews> GetAllReviews()
        {
            return _conn.Query<Reviews>("SELECT * FROM REVIEWS;");
        }

        public Reviews GetReviewProductID(int id)
        {
            return _conn.QuerySingle<Reviews>("SELECT * FROM REVIEWS WHERE PRODUCTID = @id", new { id = id });
        }

        public void InsertReview(Reviews reviewToInsert)
        {
            _conn.Execute("INSERT INTO reviews (PRODUCTID, REVIEWER, RATING, COMMENT) VALUES (@productID, @reviewer, @rating, @comment);",
            new
            {
                productID = reviewToInsert.ProductID,
                reviewer = reviewToInsert.Reviewer,
                rating = reviewToInsert.Rating,
                comment = reviewToInsert.Comment
            });
        }

        public void UpdateReview(Reviews review)
        {
            _conn.Execute("UPDATE reviews SET Reviewer = @reviewer, Rating = @rating, Comment = @comment WHERE ProductID = @id",
            new
            {
                reviewer = review.Reviewer,
                rating = review.Rating,
                comment = review.Comment
            });
        }
    }
}

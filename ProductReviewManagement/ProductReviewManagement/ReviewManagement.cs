using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    internal class ReviewManagement
    {
        //UC1 to add default values in list of productReview and print the data.
        public void getReview(List<ProductReview> productReviews)
        {
            foreach (var item in productReviews)
            {
                Console.WriteLine("Product ID: "+ item.ProductId + "\tUser ID: " + item.UserId + "\tRating: " + item.Rating + "\tReview: " + item.Review + "\tisLike: " + item.isLike);
            }
        }
        //UC2 to get top 3 records having high rateings
        public void top3HighRatedRecords(List<ProductReview> productReviews)
        {
            var result = (from product in productReviews
                          orderby product.Rating descending
                          select product).Take(3);
            foreach (var item in result)
            {
                Console.WriteLine("Product ID: " + item.ProductId + "\tUser ID: " + item.UserId + "\tRating: " + item.Rating + "\tReview: " + item.Review + "\tisLike: " + item.isLike);
            }
        }
    }
}

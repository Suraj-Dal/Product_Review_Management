using System;
using System.Collections.Generic;
using System.Data;
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
            Console.WriteLine("Top 3 Records having high rating.");
            foreach (var item in result)
            {
                Console.WriteLine("Product ID: " + item.ProductId + "\tUser ID: " + item.UserId + "\tRating: " + item.Rating + "\tReview: " + item.Review + "\tisLike: " + item.isLike);
            }
        }
        //UC3 Retrieve all record from the list who’s rating are greater than 3 and productID is 1 or 4 or 9
         public void ratingsGreaterThan3(List<ProductReview> productReviews)
        {
            var result = (from product in productReviews
                          where product.Rating > 3 &&
                          (product.ProductId == 1 || product.ProductId == 4 || product.ProductId == 9)
                          select product);
            Console.WriteLine("Record having ratings greater than 3 and who's product ID is 1 or 4 or 9.");
            foreach(var item in result)
            {
                Console.WriteLine("Product ID: " + item.ProductId + "\tUser ID: " + item.UserId + "\tRating: " + item.Rating + "\tReview: " + item.Review + "\tisLike: " + item.isLike);

            }
        }
        //UC4 count of review present for each product ID
        public void countOFReviewForProductID(List<ProductReview> productReviews)
        {
            var result = (productReviews.GroupBy(product => product.ProductId).Select(p => new {ProductID = p.Key, Count = p.Count()}));
            Console.WriteLine("Product ID\t|\tCount");
            foreach (var item in result)
            {
                Console.WriteLine("\t"+ item.ProductID + "\t|\t" + item.Count);
            }
        }
        //UC5 Retrieve only Product ID and review from records
        public void productIDAndReview(List<ProductReview> productReviews)
        {
            var result = (from product in productReviews
                          select new { ProductID = product.ProductId, Review = product.Review });
            Console.WriteLine("Product ID\t|\tReview");
            foreach( var item in result)
            {
                Console.WriteLine("\t" + item.ProductID + "\t|\t" + item.Review);
            }
        }
        //UC6 skip top 5 records and display other records
        public void skipTop5Records(List<ProductReview> productReviews)
        {
            var result = (from product in productReviews
                          select product).Skip(5);
            Console.WriteLine("Records after skiping top 5.");
            foreach (var item in result)
            {
                Console.WriteLine("Product ID: " + item.ProductId + "\tUser ID: " + item.UserId + "\tRating: " + item.Rating + "\tReview: " + item.Review + "\tisLike: " + item.isLike);
            }
        }
        //UC7 Retrieve only Product ID and review from records using LINQ select
        public void productIDAndReviewUsingSelectLINQ(List<ProductReview> productReviews)
        {
            var result = productReviews.Select(reviews => new { ProductID = reviews.ProductId, Review = reviews.Review });
            Console.WriteLine("Product ID\t|\tReview");
            foreach (var item in result)
            {
                Console.WriteLine("\t" + item.ProductID + "\t|\t" + item.Review);
            }
        }
        //UC 8 to create datatable and add values in it.
        public DataTable createDatatable(List<ProductReview> productReviews)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductID", typeof(Int32)); 
            table.Columns.Add("UserID", typeof(Int32)); 
            table.Columns.Add("Rating", typeof(Int32));
            table.Columns.Add("Review", typeof(string)); 
            table.Columns.Add("isLike", typeof(bool)); 
            foreach(var item in productReviews)
            {
                table.Rows.Add(item.ProductId, item.UserId, item.Rating, item.Review, item.isLike);
            }
            Console.WriteLine("Records in DataTable.");
            foreach(var item in table.AsEnumerable())
            {
                Console.WriteLine("ProductID: "+ item.Field<int>("ProductID") +"\tUserID: "+ item.Field<int>("UserID") +"\tRating: "+ item.Field<int>("Rating") +"\tReview: "+ item.Field<string>("Review") +"\tisLike: "+ item.Field<bool>("isLike"));
            }
            return table;
        }
        //UC9 records from datatable who's isLike value is true.
        public void isLikeValueTrue(DataTable table)
        {
            var result = (from product in table.AsEnumerable()
                          where product.Field<bool>("isLike") == true
                          select product);
            Console.WriteLine("\nRecords Who's value is true.\n");
            foreach (var item in result)
            {
                Console.WriteLine("ProductID: " + item.Field<int>("ProductID") + "\tUserID: " + item.Field<int>("UserID") + "\tRating: " + item.Field<int>("Rating") + "\tReview: " + item.Field<string>("Review") + "\tisLike: " + item.Field<bool>("isLike"));
            }
        }
        // UC10 get average rating for all product ID in record.
        public void avgRatingOfProductID(DataTable table)
        {
            var result = table.AsEnumerable().GroupBy(table => table.Field<int>("ProductID")).Select(field => new
            {
                ProductID = field.Key,
                Average = field.Average(x => x.Field<int>("Rating"))
            });
            Console.WriteLine("Average rating of each product ID.");
            foreach (var item in result)
            {
                Console.WriteLine("ProductID: " + item.ProductID + "\tAverage: " + item.Average);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;

namespace ProductReviewManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------Product Review Management-------");
            //UC1 to create Product Review class and add default data in list of ProductReview Class
            List<ProductReview> productReviews = new List<ProductReview>()
            {
                new ProductReview() { ProductId = 1, UserId = 1, Rating = 2, Review = "Average", isLike = true },
                new ProductReview() { ProductId = 2, UserId = 2, Rating = 1, Review = "Bad", isLike = false }, 
                new ProductReview() { ProductId = 3, UserId = 3, Rating = 3, Review = "Nice", isLike = true },
                new ProductReview() { ProductId = 4, UserId = 4, Rating = 4, Review = "Good", isLike = false },
                new ProductReview() { ProductId = 5, UserId = 5, Rating = 5, Review = "Excelent", isLike = false },
                new ProductReview() { ProductId = 6, UserId = 3, Rating = 3, Review = "Nice", isLike = true }, 
                new ProductReview() { ProductId = 7, UserId = 6, Rating = 2, Review = "Average", isLike = true }, 
                new ProductReview() { ProductId = 8, UserId = 5, Rating = 1, Review = "Bad", isLike = true },
                new ProductReview() { ProductId = 5, UserId = 10, Rating = 4, Review = "Good", isLike = true },
                new ProductReview() { ProductId = 10, UserId = 23, Rating = 5, Review = "Excelent", isLike = false },
                new ProductReview() { ProductId = 11, UserId = 5, Rating = 4, Review = "Nice", isLike = false },
                new ProductReview() { ProductId = 12, UserId = 4, Rating = 1, Review = "Very Bad", isLike = true },
                new ProductReview() { ProductId = 13, UserId = 12, Rating = 5, Review = "Excelent", isLike = false },
                new ProductReview() { ProductId = 4, UserId =17, Rating = 2, Review = "Average", isLike = true }, 
                new ProductReview() { ProductId = 15, UserId = 13, Rating = 3, Review = "Nice", isLike = true },
                new ProductReview() { ProductId = 16, UserId = 8, Rating = 1, Review = "Very Bad", isLike = false }, 
                new ProductReview() { ProductId = 17, UserId = 18, Rating = 5, Review = "Excelent", isLike = true }, 
                new ProductReview() { ProductId = 18, UserId = 9, Rating = 4, Review = "Good", isLike = true }, 
                new ProductReview() { ProductId = 19, UserId = 10, Rating = 3, Review = "Nice", isLike = false }, 
                new ProductReview() { ProductId = 20, UserId = 7, Rating = 2, Review = "Average", isLike = true },
                new ProductReview() { ProductId = 21, UserId = 6, Rating = 1, Review = "Bad", isLike = true },
                new ProductReview() { ProductId = 22, UserId = 5, Rating = 1, Review = "Very Bad", isLike = false }, 
                new ProductReview() { ProductId = 23, UserId = 10, Rating = 4, Review = "Good", isLike = false },
                new ProductReview() { ProductId = 24, UserId = 8, Rating = 1, Review = "Bad", isLike = true }, 
                new ProductReview() { ProductId = 25, UserId = 12, Rating = 2, Review = "Average", isLike = false }, 
            };
            ProductReviewManagement.ReviewManagement reviewManagement = new ProductReviewManagement.ReviewManagement();
            Console.WriteLine("0.Exit\n1.View Reviews\n2.Top 3 High rated Records\n3.Ratings greater than 3\n4.Count of Reviews for Product ID\n5.Product ID and Review\n6.Skip 5 records\n7.Product ID and Review using select LINQ\n8.Records in DataTable\n9.Records who's isLike Value is true\n10.Average Rating of All Product ID\nEnter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        reviewManagement.getReview(productReviews);
                        break;
                    case 2:
                        reviewManagement.top3HighRatedRecords(productReviews);
                        break;
                    case 3:
                        reviewManagement.ratingsGreaterThan3(productReviews);
                        break;
                    case 4:
                        reviewManagement.countOFReviewForProductID(productReviews);
                        break;
                    case 5:
                        reviewManagement.productIDAndReview(productReviews);
                        break;
                    case 6:
                        reviewManagement.skipTop5Records(productReviews);
                        break;
                    case 7:
                        reviewManagement.productIDAndReviewUsingSelectLINQ(productReviews);
                        break;
                    case 8:
                        reviewManagement.createDatatable(productReviews);
                        break;
                    case 9:
                        DataTable  table = reviewManagement.createDatatable(productReviews);
                        reviewManagement.isLikeValueTrue(table);
                        break;
                    case 10:
                        table = reviewManagement.createDatatable(productReviews);
                        reviewManagement.avgRatingOfProductID(table);
                        break;
                    default:
                        Console.WriteLine("Enter valid choice.");
                        break;
                }
                Console.WriteLine("0.Exit\n1.View Reviews\n2.Top 3 High rated Records\n3.Ratings greater than 3\n4.Count of Reviews for Product ID\n5.Product ID and Review\n6.Skip 5 records\n7.Product ID and Review using select LINQ\n8.Records in DataTable\n9.Records who's isLike Value is true\n10.Average Rating of All Product ID\nEnter your choice:");
                choice = Convert.ToInt32(Console.ReadLine());
            }

        }
    }
}
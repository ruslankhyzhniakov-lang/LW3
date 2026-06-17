using Xunit;
namespace LW3.Recommendation.Tests
{
    public class RecommendationModuleTests
    {
        // Техніка: EP (Equivalence Partitioning) + Positive
        // Опис: Перевірка базового розрахунку з звичайними параметрами
        [Fact]
        public void TestSimpleScore()
        {
            var module = new RecommendationModule();
            double result = module.CalculateRecommendationScore(3, true, 15, 5);
            Assert.Equal(9.0, result);
        }

        // Техніка: BVA (Boundary Value Analysis) + Negative
        // Опис: Перевірка граничного випадку - 0 відзивів (reviewCount == 0)
        [Fact]
        public void TestScoreWithNoReviews()
        {
            var module = new RecommendationModule();
            double result = module.CalculateRecommendationScore(3, false, 12, 0);
            Assert.Equal(5.0, result);
        }

        // Техніка: EP (Equivalence Partitioning) + Positive
        // Опис: Перевірка класу еквівалентності - улюблена кухня (likedCuisine = true)
        [Fact]
        public void TestScoreLikedCuisine()
        {
            var module = new RecommendationModule();
            double result = module.CalculateRecommendationScore(4, true, 15, 2);
            Assert.Equal(11.0, result);
        }

        // Техніка: EP (Equivalence Partitioning) + Positive
        // Опис: Перевірка класу еквівалентності - неулюблена кухня (likedCuisine = false)
        [Fact]
        public void TestScoreNotLiked()
        {
            var module = new RecommendationModule();
            double result = module.CalculateRecommendationScore(2, false, 15, 3);
            Assert.Equal(5.0, result);
        }

        // Техніка: EP (Equivalence Partitioning) + Positive
        // Опис: Перевірка середньої оцінки в нормальному діапазоні
        [Fact]
        public void TestScoreMiddleRating()
        {
            var module = new RecommendationModule();
            double result = module.CalculateRecommendationScore(2, true, 15, 4);
            Assert.Equal(7.0, result);
        }

        // Техніка: Positive
        // Опис: Перевірка форматування інформації про ресторан
        [Fact]
        public void TestGetRestaurantInfo()
        {
            var module = new RecommendationModule();
            string result = module.GetRestaurantInfo("Pizza Place", "Italian", "Main St", 4.5, 4.2, "Margherita");
            Assert.Contains("Pizza Place", result);
        }

        // Техніка: Positive
        // Опис: Перевірка форматування з іншими параметрами
        [Fact]
        public void TestGetRestaurantInfoCuisine()
        {
            var module = new RecommendationModule();
            string result = module.GetRestaurantInfo("Sushi Bar", "Japanese", "Oak Ave", 4.8, 4.6, "Salmon Roll");
            Assert.Contains("Japanese", result);
        }

        // Техніка: BVA (Boundary Value Analysis) + Negative
        // Опис: Перевірка граничного випадку - null список (knownRestaurants == null)
        [Fact]
        public void TestSearchRestaurantsWithNullList()
        {
            var module = new RecommendationModule();
            List<Restaurant> result = module.SearchRestaurants(null, "Italian", 3.0);
            Assert.Empty(result);
        }

        // Техніка: BVA (Boundary Value Analysis) + Negative
        // Опис: Перевірка граничного випадку - порожній список
        [Fact]
        public void TestSearchRestaurantsEmpty()
        {
            var module = new RecommendationModule();
            var list = new List<Restaurant>();
            List<Restaurant> result = module.SearchRestaurants(list, "Italian", 3.0);
            Assert.Empty(result);
        }

        // Техніка: EP (Equivalence Partitioning) + Positive
        // Опис: Перевірка високої оцінки
        [Fact]
        public void TestScoreWithHighRating()
        {
            var module = new RecommendationModule();
            double result = module.CalculateRecommendationScore(5, true, 15, 10);
            Assert.Equal(13.0, result);
        }
    }
}

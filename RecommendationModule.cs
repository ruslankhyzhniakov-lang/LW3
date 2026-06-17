using System.Globalization;

namespace LW3.Recommendation
{
    public class Restaurant
    {
        public string Name;
        public string CuisineType;
        public double Rating;
    }

    public class RecommendationModule
    {
        // Обчислює рекомендаційний бал на основі рейтингу, відповідності кухні,
        // цінового діапазону та кількості відгуків.
        public double CalculateRecommendationScore(double averageRating, bool likedCuisine, decimal price, int reviewCount)
        {
            double score = averageRating * 2;

            // Якщо тип кухні відповідає уподобанням, додаємо додатковий бал.
            if (likedCuisine)
            {
                score = score + 3;
            }
            else
            {
                score = score + 1;
            }

            // Коригуємо бал залежно від ціни: дорогі ресторани трохи знижуються,
            // дешеві отримують невеликий бонус.
            if (price > 20)
            {
                score = score - 1;
            }
            if (price < 10)
            {
                score = score + 1;
            }

            // Якщо немає відгуків, зменшуємо надійність рекомендації.
            if (reviewCount == 0)
            {
                score = score - 2;
            }

            return score;
        }

        // Формує текстове подання інформації про ресторан.
        public string GetRestaurantInfo(string name, string cuisineType, string address, double rating, double averageReview, string mostExpensiveDish)
        {
            return name + " (" + cuisineType + ") at " + address + ". Rating " + rating.ToString(CultureInfo.InvariantCulture) + ". Average review " + averageReview.ToString(CultureInfo.InvariantCulture) + ". Most expensive dish " + mostExpensiveDish + ".";
        }

        // Виконує пошук ресторанів за заданим типом кухні та мінімальним рейтингом.
        public List<Restaurant> SearchRestaurants(List<Restaurant> knownRestaurants, string cuisineType, double minRating)
        {
            List<Restaurant> result = new List<Restaurant>();
            if (knownRestaurants == null)
            {
                return result;
            }

            for (int i = 0; i < knownRestaurants.Count; i++)
            {
                Restaurant restaurant = knownRestaurants[i];
                if (restaurant != null && restaurant.CuisineType == cuisineType && restaurant.Rating >= minRating)
                {
                    result.Add(restaurant);
                }
            }

            return result;
        }
    }
}


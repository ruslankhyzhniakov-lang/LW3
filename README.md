<table>
  <thead>
    <tr>
      <th>Метод</th>
      <th>Параметр</th>
      <th>Класи еквівалентності (EP)</th>
      <th>Граничні значення (BVA)</th>
      <th>Очікуваний результат</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>CalculateRecommendationScore</td>
      <td>averageRating</td>
      <td>EP1: нормальний рейтинг (2, 3, 4, 5)</td>
      <td>BVA: 0, 5</td>
      <td>score = averageRating * 2 + ...</td>
    </tr>
    <tr>
      <td>CalculateRecommendationScore</td>
      <td>likedCuisine</td>
      <td>EP1: true<br>EP2: false</td>
      <td>BVA: немає</td>
      <td>true додає 3, false додає 1</td>
    </tr>
    <tr>
      <td>CalculateRecommendationScore</td>
      <td>price</td>
      <td>EP1: низька ціна<br>EP2: середня ціна<br>EP3: висока ціна</td>
      <td>BVA: 10, 20</td>
      <td>price < 10 → +1, price > 20 → -1</td>
    </tr>
    <tr>
      <td>CalculateRecommendationScore</td>
      <td>reviewCount</td>
      <td>EP1: >0<br>EP2: 0</td>
      <td>BVA: 0</td>
      <td>0 → -2, >0 → без зниження</td>
    </tr>
    <tr>
      <td>GetRestaurantInfo</td>
      <td>name, cuisineType, address, mostExpensiveDish</td>
      <td>EP1: нормальні непорожні рядки</td>
      <td>BVA: порожній рядок</td>
      <td>Правильна конкатенація рядка</td>
    </tr>
    <tr>
      <td>GetRestaurantInfo</td>
      <td>rating, averageReview</td>
      <td>EP1: нормальні значення</td>
      <td>BVA: 0, дробові значення</td>
      <td>Форматування через InvariantCulture</td>
    </tr>
    <tr>
      <td>SearchRestaurants</td>
      <td>knownRestaurants</td>
      <td>EP1: список ресторанів<br>EP2: порожній список<br>EP3: null</td>
      <td>BVA: Count = 0, null</td>
      <td>Null/порожній → порожній результат</td>
    </tr>
    <tr>
      <td>SearchRestaurants</td>
      <td>cuisineType</td>
      <td>EP1: співпадає<br>EP2: не співпадає</td>
      <td>BVA: точний збіг</td>
      <td>Тільки співпадаючі кухні додаються</td>
    </tr>
    <tr>
      <td>SearchRestaurants</td>
      <td>minRating</td>
      <td>EP1: Rating >= minRating<br>EP2: Rating < minRating</td>
      <td>BVA: Rating = minRating</td>
      <td>Rating >= minRating → додається</td>
    </tr>
  </tbody>
</table>
Тести і покриття коду
<img width="1347" height="887" alt="testCoverage" src="https://github.com/user-attachments/assets/324825cd-e17c-4727-b9c1-d1f0f96d80b8" />

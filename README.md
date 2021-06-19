# Redlen
# Author: Alex Borjas
# Date: Wed Jun 18, 2021

# Content:
1. WebApp - Users and Favorites restaurants and Blacklist
2. Unit Tests
3. WebAPI
4. Data Persistence: JSON files (systemusers.json, restaurants.json)
5. Postman: Redlen.postman_collection.json
- Get all Users: Maintenance\Users-GetAll
- Get all Restaurants: Maintenance\Restaurants-GetAll

- Get User View: Client/User/{id}
- Search Restaurants by User: Client/User/{id}/search
- Add favorite Restaurant to User: Client/User/{id}/addfavorite/{hotelid}
- Remove favorite Restaurant from User: Client/User/{id}/removefavorite/{hotelid}
- Add Restaurant to User Blacklist: Client/User/{id}/addblacklist/{hotelid}
- Remove Restaurant from User Blacklist: Client/User/{id}/removeblacklist/{hotelid}

5. API Documentation: Swagger -> https://localhost:44380/swagger/index.html (WebAPI Default page)

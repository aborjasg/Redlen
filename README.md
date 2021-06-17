# Redlen
# Author: Alex Borjas
# Date: Wed Jun 16, 2021

# Contain:
1. WebAPI
2. Data Persistence: JSON files (systemusers.json, restaurants.json)
3. Unit Tests
4. Postman: Redlen.postman_collection.json
- Get all Users: Maintenance\Users-GetAll
- Get all Restaurants: Maintenance\Restaurants-GetAll

- Get User View: Client/User/{id}
- Search Restaurants by User: Client/User/{id}/search
- Add favorite Restaurant to User: Client/User/{id}/addfavorite/{hotelid}
- Remove favorite Restaurant from User: Client/User/{id}/removefavorite/{hotelid}
- Add Restaurant to User Blacklist: Client/User/{id}/addblacklist/{hotelid}
- Remove Restaurant from User Blacklist: Client/User/{id}/removeblacklist/{hotelid}


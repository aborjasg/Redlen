using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataPersistence.Database;
using DataPersistence.Models;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Restaurants_GetAll()
        {
            var obj = new DataPersistence.Database.RestaurantMaintenance();
            var list = obj.GetAll();
            Assert.AreEqual(10, list.Count);
        }

        [TestMethod]
        public void SystemUsers_GetAll()
        {
            var obj = new DataPersistence.Database.UserMaintenance();
            var list = obj.GetAll();
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void SystemUsers_Favorites()
        {
            var db = new DataPersistence.Database.UserMaintenance();
            var obj = db.GetOne(3);
            obj.FavoriteAdd(3);
            obj.FavoriteAdd(4);
            obj.FavoriteRemove(3);
            db.Update(obj);
            Assert.IsTrue(obj.Restaurant_Favorites.Count > 0);
        }

        [TestMethod]
        public void SystemUsers_Blacklist()
        {
            var db = new DataPersistence.Database.UserMaintenance();
            var obj = db.GetOne(1);
            obj.BlacklistAdd(6);
            obj.BlacklistAdd(7);
            obj.BlacklistRemove(6);
            db.Update(obj);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Restaurant_isOpen()
        {
            string time = "20:00";
            var db = new DataPersistence.Database.RestaurantMaintenance();
            var obj = db.GetOne(1);
            var result = obj.isOpen(time);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void UserView_SearchRestaurants()
        {
            int userId = 1;
            var list = new UserView().SearchRestaurants(userId, new RestaurantFilter("a", "", "", "14:00", 15, false, true));
            Assert.AreNotEqual(0, list.SearchResult.Count);
        }

        [TestMethod]
        public void UserView_Favorite()
        {
            int userId = 1;
            int hotelId = 10;
            var obj = new UserView(userId);

            new UserView().FavoriteAdd(userId, hotelId);
            new UserView().FavoriteRemove(userId, hotelId);

            Assert.IsTrue(obj.Favorites.Count > 0);
        }

        [TestMethod]
        public void UserView_Blacklist()
        {
            int userId = 1;
            int hotelId = 10;
            var obj = new UserView(userId);

            new UserView().BlacklistAdd(userId, hotelId);
            new UserView().BlacklistRemove(userId, hotelId);

            Assert.IsTrue(obj.Blacklist.Count > 0);
        }


    }
}

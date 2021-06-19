using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPersistence.Database;

namespace DataPersistence.Models
{
    /// <summary>
    /// Class: UserView
    /// </summary>
    public class UserView
    {
        private UserMaintenance _systemusers;
        private RestaurantMaintenance _restaurants;

        public SystemUser User { set; get; }
        public List<Restaurant> Favorites { set; get; }
        public List<Restaurant> Blacklist { set; get; }

        public string UserMessage { get; set; }

        public UserView()
        {
            _systemusers = new UserMaintenance();
            _restaurants = new RestaurantMaintenance();
            Favorites = new List<Restaurant>();
            Blacklist = new List<Restaurant>();
            UserMessage = "";
        }
        public UserView(int id) : this()
        {
            try
            {
                User = _systemusers.GetOne(id);

                if (User != null)
                {
                    if (User.Restaurant_Favorites != null)
                    {
                        foreach (var item in User.Restaurant_Favorites)
                        {
                            Favorites.Add(_restaurants.GetOne(Convert.ToInt32(item)));
                        }
                    }

                    if (User.Restaurant_BlackList != null)
                    {
                        foreach (var item in User.Restaurant_BlackList)
                        {
                            Blacklist.Add(_restaurants.GetOne(Convert.ToInt32(item)));
                        }
                    }                   
                }
                else
                    throw new Exception("User ID invalid!");
            }
            catch (Exception ex)
            {
                UserMessage = ex.Message;
            }
            finally
            {
                _systemusers = null;
                _restaurants = null;
            }

        }

        public RestaurantsView SearchRestaurants(int id, RestaurantFilter filter)
        {
            RestaurantsView result = new RestaurantsView(id, filter);

            try
            {
                if (filter.isValid())
                {
                    result.Filter = filter;
                    User = _systemusers.GetOne(id);

                    if (User != null)
                    {
                        var list = _restaurants.GetAll();

                        if (list != null)
                        {
                            if (User.Restaurant_BlackList != null)
                            {
                                foreach (var item in User.Restaurant_BlackList)
                                {
                                    list.Remove(list.Find(x => x.Id == Convert.ToInt32(item)));
                                }
                            }

                            if (User.Restaurant_Favorites != null)
                            {
                                foreach (var item in User.Restaurant_Favorites)
                                {
                                    list.Find(x => x.Id == Convert.ToInt32(item)).Favorite = true;
                                }
                            }

                            foreach (var item in list)
                            {
                                item.Open = item.isOpen(filter.Hour);
                            }

                            if (!string.IsNullOrEmpty(filter.Name))
                                list = list.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower())).ToList();

                            if (!string.IsNullOrEmpty(filter.Location))
                                list = list.Where(x => x.City == filter.Location).ToList();

                            if (!string.IsNullOrEmpty(filter.Country))
                                list = list.Where(x => x.Country == filter.Country).ToList();

                            if (filter.Distance >= 0)
                                list = list.Where(x => x.Distance <= filter.Distance).ToList();

                            result.SearchResult = list.Where(x => x.Favorite == filter.Favorite && x.Open == filter.Open).ToList();
                        }
                    }
                }
                else
                {
                    throw new Exception("Invalid Filter structure. Please review!");
                }
            }
           catch(Exception ex)
            {
                result.UserMessage = ex.Message;
            }
            finally
            {
                _systemusers = null;
                _restaurants = null;
            }            

            return result;
        }

        public void FavoriteAdd(int id, int hotelid)
        {
            if (_systemusers != null)
            {
                User = _systemusers.GetOne(id);
                if (User != null)
                {
                    User.FavoriteAdd(hotelid);
                    _systemusers.Update(User);
                }
                _systemusers = null;
            }           
        }

        public void FavoriteRemove(int id, int hotelid)
        {
            if (_systemusers != null)
            {
                User = _systemusers.GetOne(id);
                if (User != null)
                {
                    User.FavoriteRemove(hotelid);
                    _systemusers.Update(User);
                }
                _systemusers = null;
            }
        }

        public void BlacklistAdd(int id, int hotelid)
        {
            if (_systemusers != null)
            {
                User = _systemusers.GetOne(id);
                if (User != null)
                {
                    User.BlacklistAdd(hotelid);
                    _systemusers.Update(User);
                }
                _systemusers = null;
            }
        }

        public void BlacklistRemove(int id, int hotelid)
        {
            if (_systemusers != null)
            {
                User = _systemusers.GetOne(id);
                if (User != null)
                {
                    User.BlacklistRemove(hotelid);
                    _systemusers.Update(User);
                }
                _systemusers = null;
            }
        }
    }
}

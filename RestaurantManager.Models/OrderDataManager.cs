using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {
        private List<MenuItem> _menuItems = null;
        private List<MenuItem> _currentlySelectedMenuItems = null;

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                if (value != null)
                {
                    _menuItems = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get { return _currentlySelectedMenuItems; }
            set
            {
                if(value != null)
                {
                    _currentlySelectedMenuItems = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}

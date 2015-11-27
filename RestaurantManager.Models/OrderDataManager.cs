using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {
        private List<MenuItem> _menuItems;
        private List<MenuItem> _currentlySelectedMenuItems;

        protected override void OnDataLoaded()
        {
            this._menuItems = base.Repository.StandardMenuItems;

            this._currentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        public List<MenuItem> MenuItems
        {
            get { return this._menuItems; }
            set
            {
                if (value != _menuItems)
                {
                    this._menuItems = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get { return this._currentlySelectedMenuItems; }
            set
            {
                if(value != _currentlySelectedMenuItems)
                {
                    _currentlySelectedMenuItems = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}

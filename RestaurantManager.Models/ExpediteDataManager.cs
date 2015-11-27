using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {
        private List<Order> _orderItems;
         
        protected override void OnDataLoaded()
        {
            _orderItems = base.Repository.Orders;
        }

        public List<Order> OrderItems
        {
            get { return this._orderItems; }
            set
            {
                if (value != _orderItems)
                {
                    _orderItems = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}

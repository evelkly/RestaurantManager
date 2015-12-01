using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManager.Extensions;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        private ObservableCollection<Order> _orderItems;

        public ExpediteViewModel()
        {
            DeleteOrderCommand = new DelegateCommand<Order>(DeleteOrderExecute);
        }

        private async void DeleteOrderExecute(Order obj)
        {

            if (obj != null)
            {
                RestaurantContext repo = await RestaurantContextFactory.GetRestaurantContextAsync();
                repo.Orders.Remove(obj);
                OnDataLoaded();
            }
        }

        protected override void OnDataLoaded()
        {
            OrderItems = base.Repository.Orders;
        }

        public ObservableCollection<Order> OrderItems
        {
            get { return this._orderItems; }
            set
            {
                if (value != _orderItems)
                {
                    _orderItems = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public DelegateCommand<Order> DeleteOrderCommand { get; private set; }

    }
}

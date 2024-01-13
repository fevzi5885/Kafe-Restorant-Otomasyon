using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub:Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService ;
        private readonly INotificationService _notificationService ;
		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}
        public static int ClientCount { get; set; } = 0;
		public async Task SendStatistic()
		{
			var value = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount",value);

            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiverActiveCategoryCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceiverPassiveCategoryCount", value4);

            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiverProductCountByCategoryNameHamburger", value5);

            var value6= _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiverProductCountByCategoryNameDrink", value6);

            var value7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiverTProductPriceAvg", value7.ToString()+ "₺");

            var value8 = _productService.TProductNameBYPriceMax();
            await Clients.All.SendAsync("ReceiverProductNameBYPriceMax", value8);

            var value9 = _productService.TProductNameBYPriceMin();
            await Clients.All.SendAsync("ReceiverProductNameBYPriceMin", value9);

            var value10 = _productService.TProductIntPriceByHamburger();
            await Clients.All.SendAsync("ReceiverProductIntPriceByHamburger", value10.ToString() + "₺");

            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiverTotalOrderCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiverActiveOrderCount", value12);

            var value13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiverLastOrderPrice", value13.ToString() + "₺");

            var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiverTotalMoneyCaseAmount", value14.ToString() + "₺");

            var value15 = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiverTodayTotalPrice", value15.ToString() + "₺");

            var value16 = _menuTableService.TManuTableCount();
            await Clients.All.SendAsync("ReceiverManuTableCount", value16);
        }

        public async Task SendProgress()
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString() + "₺");

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value2);

            var value3 = _menuTableService.TManuTableCount();
            await Clients.All.SendAsync("ReceiveManuTableCount", value3);

            var value4 = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value4);

            var value5 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value5);

            var value6 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiverTotalOrderCount", value6);

            var value7 = _productService.TProductIntPriceByHamburger();
            await Clients.All.SendAsync("ReceiverProductIntPriceByHamburger", value7);
        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        public async Task SendNotification()
        {
			var value = _notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

            var notificationListByFalse=_notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("ReceiveNotificationByFalse", notificationListByFalse);
		}
        public async Task GetMenuTableStatus()
        {
            var value = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
        }
       public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user,message);

        }

       public override async Task OnConnectedAsync()
        {
            ClientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            ClientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
            await base.OnDisconnectedAsync(exception);

        }
    }
}

using Business.Abstract;
using Business.Concreate;
using Data.Abstract;
using Data.Concreate;
using Data.EntityFramework;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class HotelController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly Context _context;
        private readonly IOrderService _orderService;
        private readonly IHotelService _hotelService;
        //HotelManager _hotelManager = new HotelManager(new EFHotelDal());
        //CustomerManager _customerManager=new CustomerManager(new EFCustomerDal(),new Context());

        //public HotelController()
        //{
        //    _customerService = new CustomerManager(new EFCustomerDal(), new Context());
        //    _context = new Context();
        //}


        public HotelController(ICustomerService customerService, Context context, IOrderService orderService, IHotelService hotelService)
        {
            _customerService = customerService;
            _context = context;
            _orderService = orderService;
            _hotelService = hotelService;
        }
        public HotelController()
        {
            _customerService = new CustomerManager(new EFCustomerDal(), new Context());
            _context = new Context();
            _orderService = new OrderManager(new EFOrderDal());
            _hotelService = new HotelManager(new EFHotelDal());
        }

        // GET: Hotel
        public ActionResult Index()
        {
            var sonuc = _hotelService.Hotelliste();
            return View(sonuc);
        }
        //private bool IsUserLoggedIn()
        //{
        //    return Session["UserID"] != null;
        //}
        public ActionResult Booking(bool clearForm = false)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Hotel");
            }
            int userId = Convert.ToInt32(Session["UserID"]);
            var hotels = _hotelService.Hotelliste();
            ViewBag.Hotels = new SelectList(hotels, "HotelId", "HotelTopic");

            Order customerBooking;

            if (clearForm)
            {
                customerBooking = new Order();
                Session["BookingSummary"] = null; // Form temizlenirken sipariş özeti de silinmeli
            }
            else
            {
                customerBooking = Session["BookingSummary"] as Order ?? _orderService.GetById(userId) ?? new Order();
            }

            return View(customerBooking);

            //if (!IsUserLoggedIn())
            //{
            //    return RedirectToAction("Login", "Hotel");
            //}

            //int userId = Convert.ToInt32(Session["UserID"]);
            //var hotels = _hotelService.Hotelliste();

            //ViewBag.Hotels = new SelectList(hotels, "HotelId", "HotelTopic");

            //var customerBooking = clearForm ? new Order() : _orderService.GetById(userId) ?? new Order();

            //if (Session["BookingSummary"] != null)
            //{
            //    customerBooking = (Order)Session["BookingSummary"];
            //}

            //return View(customerBooking);
        }

        [HttpPost]
        public ActionResult Booking(Order order)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Hotel");
            }

            if (ModelState.IsValid)
            {
                order.CustomerId = Convert.ToInt32(Session["UserID"]);
                _orderService.OrderInsert(order);
                Session["BookingSummary"] = order; // Sipariş özetini sakla
                return RedirectToAction("Booking", new { clearForm = false }); // Sipariş özeti gösterilmeye devam etsin
            }

            var hotels = _hotelService.Hotelliste();
            ViewBag.Hotels = new SelectList(hotels, "HotelId", "HotelTopic");

            return View(order);


            //if (!IsUserLoggedIn())
            //{
            //    return RedirectToAction("Login", "Hotel");
            //}

            //if (ModelState.IsValid)
            //{
            //    order.CustomerId = Convert.ToInt32(Session["UserID"]);
            //    _orderService.OrderInsert(order);
            //    Session["BookingSummary"] = order;

            //    return RedirectToAction("Booking", new { clearForm = true });
            //}

            //var hotels = _hotelService.Hotelliste();
            //ViewBag.Hotels = new SelectList(hotels, "HotelId", "HotelTopic");

            //return View(order);
        }
        public ActionResult Amenities()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Rooms()
        {
            var sonuc = _hotelService.Hotelliste();
            return View(sonuc);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları eksiksiz doldurun!";
                return View();
            }
            var existingUser = _customerService.Customerliste().FirstOrDefault(x => x.Username == customer.Username);
            if (existingUser != null)
            {
                ViewBag.ErrorMessage = "Bu kullanıcı adı zaten kullanılıyor!";
                return View();
            }

            _customerService.CustomerInsert(customer);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Kayıt başarılı! Giriş yapabilirsiniz.";
            return RedirectToAction("Login", "Hotel");
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Hotel");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ViewBag.ErrorMessage = "Lütfen kullanıcı adı ve şifre giriniz!";
                return View();
            }

            var user = _customerService.Customerliste().FirstOrDefault(c => c.Username == Username && c.Password == Password);

            if (user != null)
            {
                Session["UserID"] = user.CustomerId;
                Session["Username"] = user.Username;
                Session["IsAdmin"] = user.IsAdmin;

                if (user.IsAdmin)
                {
                    return RedirectToAction("Dashboard", "Hotel");
                }
                else
                {
                    return RedirectToAction("Index", "Hotel");
                }
            }

            ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı!";
            return View("Login");
        }

        public ActionResult Logout()
        {
            if (Session["UserID"] != null)
            {
                var pastBookings = Session["PastBookings"] as List<Order> ?? new List<Order>();

                if (Session["BookingSummary"] != null)
                {
                    pastBookings.Add(Session["BookingSummary"] as Order);
                    Session["PastBookings"] = pastBookings;
                }

                Session.Clear();
            }

            return RedirectToAction("Login", "Hotel");
        }
        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { CustomerId = 1, Username = "admin", Password = "admin123", IsAdmin = true },
                new Customer { CustomerId = 2, Username = "user1", Password = "password1", IsAdmin = false },
                new Customer { CustomerId = 3, Username = "user2", Password = "password2", IsAdmin = false }
            };
        }

        public ActionResult Dashboard()
        {
            if (Session["UserID"] == null || Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
            {
                ViewBag.ErrorMessage = "Bu sayfaya yalnızca adminler erişebilir!";
                return RedirectToAction("Login", "Hotel");
            }

            return View();
        }
        //public ActionResult PastBookings()
        //{
        //    var pastBookings = Session["PastBookings"] as List<Order> ?? new List<Order>();
        //    return View(pastBookings);
        //}
        //public ActionResult HotelAdd()
        //{
        //    return View(new Hotel());
        //}
        [HttpGet]
        public ActionResult HotelAdd()
        {
            return View(new Hotel());
        }
        [HttpPost]
        public ActionResult HotelAdd(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _hotelService.HotelInsert(hotel);
                return RedirectToAction("HotelAdd");
            }
            return View(hotel);
        }

        public ActionResult ReservationIndex()
        {
            var sonuc = _orderService.Orderliste();
            return View(sonuc);
        }

        [HttpPost]
        public ActionResult Reservation(int id)
        {
            var order = _orderService.GetById(id); 
            if (order != null)
            {
                _orderService.OrderDelete(order);
                _context.SaveChanges();
            }

            return RedirectToAction("ReservationIndex");
        }

        public ActionResult UserListIndex()
        {
            var sonuc = _customerService.Customerliste();
            return View(sonuc);
        }
        [HttpPost]
        public ActionResult UserListDelete(int id)
        {
            var user = _customerService.GetById(id); // Kullanıcıyı id'ye göre al
            if (user != null)
            {
                _customerService.CustomerDelete(user); // Silme işlemi
                _context.SaveChanges(); // Değişiklikleri kaydet
            }

            return RedirectToAction("UserListIndex");
        }
    }
}
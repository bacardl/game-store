using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;
using GameStore.Domain.Entities;

namespace GameStore.WebUI.Controllers
{
    public class OrdersController : Controller
    {
        IOrderRepository orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public ActionResult Index()
        {
            return View(orderRepository.Orders);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = orderRepository.FindOrder((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,Date,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                orderRepository.CreateOrder(order);
                return RedirectToAction("Index");
            }

            return View(order);
        }

 
        public ActionResult Delete(int id)
        {
            Order order = orderRepository.FindOrder(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            orderRepository.DeleteOrder(order);

            return RedirectToAction("Index");
        }
    }
}

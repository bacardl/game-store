﻿using System.Linq;
using System.Web.Mvc;
using GameStore.Domain.Entities;
using GameStore.Domain.Abstract;
using GameStore.WebUI.Models;
using System.Collections.Generic;
using System;

namespace GameStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IGameRepository repository;
        private IOrderRepository orderRepository;
        private IOrderProcessor orderProcessor;
        public CartController(IGameRepository repository, IOrderProcessor orderProcessor, IOrderRepository orderRepository)
        {
            this.repository = repository;
            this.orderProcessor = orderProcessor;
            this.orderRepository = orderRepository;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int gameId, string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(g => g.GameId == gameId);

            if (game != null)
            {
                cart.AddItem(game, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int gameId, string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(g => g.GameId == gameId);

            if (game != null)
            {
                cart.RemoveLine(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
           
                Order order = new Order() 
                {
                    OrderItems = cart.Lines.Select(line => new OrderItem {GameId = line.Game.GameId, Quantity = line.Quantity }).ToList()
                };
                orderRepository.CreateOrder(order);
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}

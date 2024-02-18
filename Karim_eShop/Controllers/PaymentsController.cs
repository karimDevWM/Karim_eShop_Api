﻿//using api.Karim_eshop.Business.DTOs;
//using api.Karim_eshop.Business.Service;
//using api.Karim_eshop.Common.Extensions;
//using api.Karim_eshop.Data.Entity;
//using api.Karim_eshop.Data.Entity.Model.OrderAggregate;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Stripe;

//namespace Karim_eShop.Controllers
//{
//    public class PaymentsController : ControllerBase
//    {
//        private readonly PaymentService _paymentService;
//        private readonly KarimeshopDbContext _context;
//        private readonly IConfiguration _config;
//        public PaymentsController(PaymentService paymentService, KarimeshopDbContext context, IConfiguration config)
//        {
//            _config = config;
//            _context = context;
//            _paymentService = paymentService;
//        }

//        [Authorize]
//        [HttpPost]
//        public async Task<ActionResult<BasketDto>> CreateOrUpdatePaymentIntent()
//        {
//            var basket = await _context.Baskets
//                //.RetrieveBasketWithItems(User.Identity.Name)
//                .RetrieveBasketWithItems(User.Identity.Name)
//                .FirstOrDefaultAsync();

//            if (basket == null) return NotFound();

//            var intent = await _paymentService.CreateOrUpdatePaymentIntent(basket);

//            if (intent == null) return BadRequest(new ProblemDetails { Title = "Problem creating payment intent" });

//            basket.PaymentIntentId = basket.PaymentIntentId ?? intent.Id;
//            basket.ClientSecret = basket.ClientSecret ?? intent.ClientSecret;

//            _context.Update(basket);

//            var result = await _context.SaveChangesAsync() > 0;

//            if (!result) return BadRequest(new ProblemDetails { Title = "Problem updating basket with intent" });

//            return basket.MapBasketToDto();
//        }

//        [AllowAnonymous]
//        [HttpPost("webhook")]
//        public async Task<ActionResult> StripeWebhook()
//        {
//            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

//            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"],
//                _config["StripeSettings:WhSecret"]);

//            var charge = (Charge)stripeEvent.Data.Object;

//            var order = await _context.Orders.FirstOrDefaultAsync(x =>
//                x.PaymentIntentId == charge.PaymentIntentId);

//            if (charge.Status == "succeeded") order.OrderStatus = OrderStatus.PaymentReceived;

//            await _context.SaveChangesAsync();

//            return new EmptyResult();
//        }
//    }
//}

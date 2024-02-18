﻿//using api.Karim_eshop.Data.Entity.Model;
//using Microsoft.Extensions.Configuration;
//using Stripe;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace api.Karim_eshop.Business.Service
//{
//    public class PaymentService
//    {
//        private readonly IConfiguration _config;
//        public PaymentService(IConfiguration config)
//        {
//            _config = config;
//        }

//        public async Task<PaymentIntent> CreateOrUpdatePaymentIntent(Basket basket)
//        {
//            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];

//            var service = new PaymentIntentService();

//            var intent = new PaymentIntent();
//            var subtotal = basket.Items.Sum(i => i.Quantity * i.Product.Price);
//            var deliveryFee = subtotal > 10000 ? 0 : 500;

//            if (string.IsNullOrEmpty(basket.PaymentIntentId))
//            {
//                var options = new PaymentIntentCreateOptions
//                {
//                    Amount = subtotal + deliveryFee,
//                    Currency = "usd",
//                    PaymentMethodTypes = new List<string> { "card" }
//                };
//                intent = await service.CreateAsync(options);
//            }
//            else
//            {
//                var options = new PaymentIntentUpdateOptions
//                {
//                    Amount = subtotal + deliveryFee
//                };
//                await service.UpdateAsync(basket.PaymentIntentId, options);
//            }

//            return intent;
//        }
//    }
//}

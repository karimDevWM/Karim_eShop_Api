﻿using api.Karim_eshop.Business.Service.Email.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Karim_eshop.Business.Service.Email.Services
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}

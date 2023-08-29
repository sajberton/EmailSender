﻿using EmailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Services.Interfaces
{
    public interface IEmailSettingsService
    {
        Task<EmailSettingsModel> GetSettingsByClientIdAsync(int clientId);
    }
}

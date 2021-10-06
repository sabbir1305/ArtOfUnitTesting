﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
    public interface IWebService
    {
        void LogError(string error);
    }
    public class LogAnalyzer2
    {
        public LogAnalyzer2(IWebService service, IEmailService email)
        {
            Email = email;
            Service = service;
        }
        public IWebService Service
        {
            get;
            set;
        }
        public IEmailService Email
        {
            get;
            set;
        }
        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    Service.LogError("Filename too short:" + fileName);
                }
                catch (Exception e)
                {
                    Email.SendEmail("someone@somewhere.com",
                    "can't log", e.Message);
                }
            }
        }
    }
}

﻿using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Assignment.Models;
using Microsoft.AspNet.Identity;

namespace Assignment.Utils
{
    public class EmailSender
    {
        private AssignmentModel db = new AssignmentModel();
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("jackyray111@gmail.com", "JoinSwimming");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

        public void Send(Activity model, UserProfile user)
        {
            
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("jackyray111@gmail.com", "JoinSwimming");
            var to = new EmailAddress(user.Email, "");
            var subject = "Booking Confirmation";
            var plainTextContent = "";
            var htmlContent = "<h2>Hi! " + user.FirstName +" " + user.LastName + "</h2>" + "<h2> You have successfully book" +
                "the Activity: " + "<h1>" + model.ActivityName + "</h1>" + "</h2>" + "<p>" + "The Start Date will be " + model.ActivityStartDate.ToString("dd/mm/yyyy") +
                "<p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

    }
}
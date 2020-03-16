using System;
using System.Threading.Tasks;
using EntityModels.Enums;
using MailKit.Net.Smtp;
using MimeKit;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace ShopBLL.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, OrderViewModel model)
        {
            var text = $"Поступил заказ на сумму {model.FinalPrice} BYN.{Environment.NewLine}" +
                       $"Время доставки: {model.Date}.{Environment.NewLine}Адрес доставки: {model.Address}";

            await SendAsync(email, text);
        }

        public async Task SendEmailChangeStatusAsync(string email, OrderViewModel model)
        {
            var text = model.Status == OrderStatus.Sent ? "Ваш заказ отправлен" : "Ваш заказ доставлен";

            await SendAsync(email, text);
        }

        private async Task SendAsync(string email, string text)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("PiesShop", "buypie365@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));

            emailMessage.Subject = "Пироги";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = text
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("buypie365@gmail.com", "x32b258r");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}

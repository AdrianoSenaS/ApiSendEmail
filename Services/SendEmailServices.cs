﻿using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.SignalR.Protocol;
namespace ApiSendEmail.Services
{
    public class RegistrationForm
    {

        public string BirthCity { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthState { get; set; }
        public string City { get; set; }
        public string Complement { get; set; }
        public string Course { get; set; }
        public string CPF { get; set; }
        public string DueDate { get; set; }
        public string Email { get; set; }
        public string FatherName { get; set; }
        public string FullName { get; set; }
        public string MaritalStatus { get; set; }
        public string MotherName { get; set; }
        public string Neighborhood { get; set; }
        public string Number { get; set; }
        public string PaymentOption { get; set; }
        public string Phone { get; set; }
        public string RG { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
    }

    public class SendEmailServices
    {
        public static string Send(string form,string email, string name)
        {
            //Configuração do Servidor 
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,// Porta padrão para envio de e-mails com TLS
                Credentials = new NetworkCredential("hostsa45@gmail.com", "hamw qcfq ebbq trsw"), // Substitua pelo seu e-mail e senha
                EnableSsl = true,
            };

            //Configuração do email
            MailMessage mailMessage = new MailMessage()
            {
                From = new MailAddress(email, name),// Remetente
                Subject = "Formulário de Registro", // Assunto
                Body = form,
                IsBodyHtml = true // Define que o corpo do e-mail é em HTML
            };
            // Destinatário
            mailMessage.To.Add("melqueanalistadesistema@gmail.com"); // Substitua pelo destinatário
            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("E-mail enviado com sucesso!");
                return "E-mail enviado com sucesso!";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar o e-mail: {ex.Message}");
                return $"Erro ao enviar o e-mail: {ex.Message}";
            }
        }
        public static string GenerateEmailBody(RegistrationForm form)
        {
            string emailTemplate = File.ReadAllText("emailTemplate.html");
            return emailTemplate
                .Replace("{{CourseSelection}}", form.Course)
                .Replace("{{CPF}}", form.CPF)
                .Replace("{{FullName}}", form.FullName)
                .Replace("{{BirthDate}}", form.BirthDate.ToString("dd/MM/yyyy"))
                .Replace("{{BirthCity}}", form.BirthCity)
                .Replace("{{BirthState}}", form.BirthState)
                .Replace("{{MaritalStatus}}", form.MaritalStatus)
                .Replace("{{RG}}", form.RG)
                .Replace("{{FatherName}}", form.FatherName)
                .Replace("{{MotherName}}", form.MotherName)
                .Replace("{{Phone}}", form.Phone)
                .Replace("{{ZipCode}}", form.ZipCode)
                .Replace("{{Street}}", form.Street)
                .Replace("{{Number}}", form.Number)
                .Replace("{{Complement}}", form.Complement)
                .Replace("{{Neighborhood}}", form.Neighborhood)
                .Replace("{{Email}}", form.Email)
                .Replace("{{City}}", form.City)
                .Replace("{{State}}", form.State)
                .Replace("{{PaymentOption}}", form.PaymentOption)
                .Replace("{{DueDate}}", form.DueDate);
        }
    }
}
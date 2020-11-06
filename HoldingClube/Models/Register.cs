using HoldingClube.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HoldingClube.Models
{
    public class Register
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "{0} deve estar entre {2} e {1} caracteres")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Entre com um e-mail válido")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} deve estar entre {2} e {1} caracteres")]
        [Display(Name = "Organização")]
        public string Organization { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Cargo")]
        public PositionOffice PositionOffice { get; set; }

        public Register()
        {

        }

        public Register(int id, string name, string email, string phone, string organization, PositionOffice positionOffice)
        {
            Id             = id;
            Name           = name;
            Email          = email;
            Phone          = phone;
            Organization   = organization;
            PositionOffice = positionOffice;
        }

        public void SendMail(string name, string email, string basePath)
        {
            
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = Convert.ToInt32("587"),
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential("robles.holdingclube@gmail.com", "@HoldingClube")
            };

            MailMessage mail = new MailMessage
            {
                Sender = new System.Net.Mail.MailAddress("robles.holdingclube@gmail.com", "All In 2020 - Holding Clube"),
                From = new MailAddress("robles.holdingclube@gmail.com", "All In 2020 - Holding Clube")
            };

            mail.To.Add(new MailAddress(email, name));
            mail.Subject       = "Cadastro All In 2020 - Holding Clube";
            mail.Body          = "<br /> Mensagem de confirmação de cadastro <br /> <br /> Nome: " + name.ToString() + "<br />" + " E-mail: " + email.ToString()  + "<br /> Link para acesso a apresentação: <a href=" + basePath + "/Home/Privacy" + ">" + basePath + "/Home/Privacy</a>" + "<br /> <br /> Obrigado!";  
            mail.IsBodyHtml    = true;
            mail.Priority      = MailPriority.High;

            try
            {
                client.Send(mail);
            }
            catch (System.Exception e)
            {
                new Exception(e.Message);
            }
            finally
            {
                //mail = null;
            }
        }
    }
}

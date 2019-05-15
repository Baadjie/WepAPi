using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApplication.Models
{
    public class Client
    {

      
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string NewEmail { get; set; }
        public bool IsMale { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public int TitleId { get; set; }
        public DateTime DateOfBirth { get; set; }


        public int MaritalStatusId { get; set; }
        public string IdentityNo { get; set; }
        public string HomeAddress { get; set; }
        public string HomeSurburb { get; set; }
        public string HomePostalCode { get; set; }

        public string BusinessPhone { get; set; }
        public string MobilePhone { get; set; }
        public bool ITCCheck { get; set; }
        public string Employer { get; set; }
        public string Occupation { get; set; }


        public string Category { get; set; }
        public bool SequestratedOrLiquidated { get; set; }
        public bool Deleted { get; set; }
        public int LogUserId { get; set; }
        public DateTime LogDate { get; set; }

        public string City { get; set; }
        public string Comment { get; set; }
        public int ClientStatusId { get; set; }
        public string CompanyName { get; set; }
        public string PassportNumber { get; set; }
        public bool UnderDebtReview { get; set; }


    }
}
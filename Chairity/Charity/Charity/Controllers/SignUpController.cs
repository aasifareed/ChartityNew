using Charity_Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
namespace Charity.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SignUpNow(Member model)
        {
            using (var _Entity = new CharityEntities())
            {
                var obj = _Entity.Members.Where(x => x.Email == model.Email).FirstOrDefault();
                if (obj == null)
                {
                    model.CreatedOn = DateTime.Now;
                    _Entity.Entry(model).State = EntityState.Added;
                    _Entity.SaveChanges();
                    return Json("true", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("false", JsonRequestBehavior.AllowGet);
                }
            }
        }
  
        public JsonResult LoadCountry()
        {
            var list = new List<string>();
            list.Add("Select Country");
            list.Add("Afghanistan");
            list.Add("Albania");
            list.Add("Algeria");
            list.Add("Andorra");
            list.Add("Angola");
            list.Add("Antigua and Barbuda");
            list.Add("Argentina");
            list.Add("Armenia");
            list.Add("Australia");
            list.Add("Austria");
            list.Add("Azerbaijan");
            list.Add("The Bahamas");
            list.Add("Bahrain");
            list.Add("Bangladesh");
            list.Add("Barbados");
            list.Add("Belarus");
            list.Add("Belgium");
            list.Add("Belize");
            list.Add("Benin");
            list.Add("Bhutan");
            list.Add("Bolivia");
            list.Add("Bosnia and Herzegovina");
            list.Add("Botswana");
            list.Add("Brazil");
            list.Add("Brunei");
            list.Add("Bulgaria");
            list.Add("Burkina Faso");
            list.Add("Burundi");
            list.Add("Cabo Verde");
            list.Add("Cambodia");
            list.Add("Cameroon");
            list.Add("Canada");
            list.Add("Central African Republic");
            list.Add("Chad");
            list.Add("Chile");
            list.Add("China");
            list.Add("Colombia");
            list.Add("Comoros");
            list.Add("Congo, Democratic Republic of the");
            list.Add("Congo, Republic of the");
            list.Add("Costa Rica");
            list.Add("Côte d’Ivoire");
            list.Add("Croatia");
            list.Add("Cuba");
            list.Add("Cyprus");
            list.Add("Czech Republic");
            list.Add("Denmark");
            list.Add("Djibouti");
            list.Add("Dominica");
            list.Add("Dominican Republic");
            list.Add("East Timor (Timor-Leste)");
            list.Add("Ecuador");
            list.Add("Egypt");
            list.Add("El Salvador");
            list.Add("Equatorial Guinea");
            list.Add("Eritrea");
            list.Add("Estonia");
            list.Add("Eswatini");
            list.Add("Ethiopia");
            list.Add("Fiji");
            list.Add("Finland");
            list.Add("France");
            list.Add("Gabon");
            list.Add("Georgia");
            list.Add("Germany");
            list.Add("Ghana");
            list.Add("Greece");
            list.Add("Grenada");
            list.Add("Guatemala");
            list.Add("Guinea");
            list.Add("Guinea-Bissau");
            list.Add("Guyana");
            list.Add("Haiti");
            list.Add("Honduras");
            list.Add("Hungary");
            list.Add("Iceland");
            list.Add("India");
            list.Add("Indonesia");
            list.Add("Iran");
            list.Add("Iraq");
            list.Add("Ireland");
            list.Add("Israel");
            list.Add("Italy");
            list.Add("Jamaica");
            list.Add("Japan");
            list.Add("Jordan");
            list.Add("Kazakhstan");
            list.Add("Kenya");
            list.Add("Kiribati");
            list.Add("Korea, North");
            list.Add("Korea, South");
            list.Add("Kosovo");
            list.Add("Kuwait");
            list.Add("Kyrgyzstan");
            list.Add("Laos");
            list.Add("Latvia");
            list.Add("Lebanon");
            list.Add("Lesotho");
            list.Add("Liberia");
            list.Add("Libya");
            list.Add("Liechtenstein");
            list.Add("Lithuania");
            list.Add("Luxembourg");
            list.Add("Madagascar");
            list.Add("Malawi");
            list.Add("Malaysia");
            list.Add("Maldives");
            list.Add("Mali");
            list.Add("Malta");
            list.Add("Marshall Islands");
            list.Add("Mauritania");
            list.Add("Mauritius");
            list.Add("Mexico");
            list.Add("Micronesia, Federated States of");
            list.Add("Moldova");
            list.Add("Monaco");
            list.Add("Mongolia");
            list.Add("Montenegro");
            list.Add("Morocco");
            list.Add("Mozambique");
            list.Add("Myanmar (Burma)");
            list.Add("Namibia");
            list.Add("Nauru");
            list.Add("Nepal");
            list.Add("Netherlands");
            list.Add("New Zealand");
            list.Add("Nicaragua");
            list.Add("Niger");
            list.Add("Nigeria");
            list.Add("North Macedonia");
            list.Add("Norway");
            list.Add("Oman");
            list.Add("Pakistan");
            list.Add("Palau");
            list.Add("Panama");
            list.Add("Papua New Guinea");
            list.Add("Paraguay");
            list.Add("Peru");
            list.Add("Philippines");
            list.Add("Poland");
            list.Add("Portugal");
            list.Add("Qatar");
            list.Add("Romania");
            list.Add("Russia");
            list.Add("Rwanda");
            list.Add("Saint Kitts and Nevis");
            list.Add("Saint Lucia");
            list.Add("Saint Vincent and the Grenadines");
            list.Add("Samoa");
            list.Add("San Marino");
            list.Add("Sao Tome and Principe");
            list.Add("Saudi Arabia");
            list.Add("Senegal");
            list.Add("Serbia");
            list.Add("Seychelles");
            list.Add("Sierra Leone");
            list.Add("Singapore");
            list.Add("Slovakia");
            list.Add("Slovenia");
            list.Add("Solomon Islands");
            list.Add("Somalia");
            list.Add("South Africa");
            list.Add("Spain");
            list.Add("Sri Lanka");
            list.Add("Sudan");
            list.Add("Sudan, South");
            list.Add("Suriname");
            list.Add("Sweden");
            list.Add("Switzerland");
            list.Add("Syria");
            list.Add("Taiwan");
            list.Add("Tajikistan");
            list.Add("Tanzania");
            list.Add("Thailand");
            list.Add("Togo");
            list.Add("Tonga");
            list.Add("Trinidad and Tobago");
            list.Add("Tunisia");
            list.Add("Turkey");
            list.Add("Turkmenistan");
            list.Add("Tuvalu");
            list.Add("Uganda");
            list.Add("Ukraine");
            list.Add("United Arab Emirates");
            list.Add("United Kingdom");
            list.Add("United States");
            list.Add("Uruguay");
            list.Add("Uzbekistan");
            list.Add("Vanuatu");
            list.Add("Vatican City");
            list.Add("Venezuela");
            list.Add("Vietnam");
            list.Add("Yemen");
            list.Add("Zambia");
            list.Add("Zimbabwe");

            return Json(list, JsonRequestBehavior.AllowGet);
           
        }
       
    }
}
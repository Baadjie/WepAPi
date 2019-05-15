using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    public class VehicleController:ApiController
    {
        VehicleDbHelper vehicleDbHelper = new VehicleDbHelper();


          [HttpPost]

        public List<Vehicle> Details(Vehicle value)
        {
            VehicleDbHelper vehicleDbHelper = new VehicleDbHelper();
            return vehicleDbHelper.GetVehicleById(value.EmailAddress);
        }
        //https://www.c-sharpcorner.com/article/navigation-menu-with-syncfusion-in-xamarin-forms/
        //https://www.c-sharpcorner.com/article/how-to-display-items-in-card-view-xamarin-forms/
        [HttpGet]
        public Vehicle GetVehicles(int clientId)
        {
            VehicleDbHelper vehicleDbHelper = new VehicleDbHelper();
            return vehicleDbHelper.GetVehicleByClientId(clientId);
        }
    }
}

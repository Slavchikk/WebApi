using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CarsModel
    {
        public CarsModel(Cars cars)
        {
            id_cars = cars.id_cars;
            carsModel = cars.CarsModel;
            carsBrand = cars.CarsBrand;
            price = cars.Price;
            image = cars.image;
        }

        public int id_cars { get; set; }
        public string carsBrand { get; set; }
        public string carsModel { get; set; }
        public int price { get; set; }
        public string image { get; set; }

    }
}
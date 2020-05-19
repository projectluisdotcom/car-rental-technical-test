using System;
using System.Collections.Generic;
using Domain;

namespace Data
{
    public class PopulateDb
    {
        public static void Populate(FleetContext context)
        {
            var value150 = 150;
            var value100 = 100;
            
            var premiumPrice = new PricePolicy("premium", value150);
            var basicPrice = new PricePolicy("basic", value100);
            
            context.AddRange(new List<PricePolicy>{ premiumPrice, basicPrice });
            
            var convertible = new RentType("convertible", 2, premiumPrice);
            var miniVan = new RentType("miniVan", 1, basicPrice, TimeSpan.FromDays(5), 0.2m);
            var suv = new RentType("suv", 1, basicPrice, TimeSpan.FromDays(3), 0.3m);
            
            context.AddRange(new List<RentType>{ convertible, miniVan, suv });

            var jaguarFType = new CarModel("Jaguar", "F Type", convertible);
            var bmwX7 = new CarModel("BMW", "X7", miniVan);
            var audiQ7 = new CarModel("Audi", "Q7", miniVan);
            var lexusGx = new CarModel("Lexus", "GX", suv);
            
            context.AddRange(new List<CarModel>{ jaguarFType, bmwX7, audiQ7, lexusGx });
            
            var twt = new Car("TWT-4566", jaguarFType);
            var fcb = new Car("FCB-3456", jaguarFType);
            var lmn = new Car("LMN-1234", jaguarFType);

            var tko = new Car("TKO-5426", bmwX7);
            var jfk = new Car("JFK-7896", bmwX7);
            var bcn = new Car("BCN-5324", bmwX7);

            var gps = new Car("GPS-5678", audiQ7);
            var kjl = new Car("KJL-5545", audiQ7);
            var rrh = new Car("RRH-6789", audiQ7);

            var css = new Car("CSS-1256", lexusGx);
            var xml = new Car("XML-7890", lexusGx);
            var wdg = new Car("WDG-0086", lexusGx);

            context.AddRange(new List<Car>{ twt, fcb, lmn, tko, jfk, bcn, gps, kjl, rrh, css, xml, wdg });
            
            context.AddRange(new Customer("test"));

            context.SaveChanges();
        }
    }
}
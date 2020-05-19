using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Data
{
    public class DataStartup
    {
        public static void Migrate(FleetContext context, bool isDev)
        {
            if (isDev)
            {
                Console.WriteLine("Applying migrations...");   
                context.Database.Migrate();
                return;
            }
            
            var hasAlreadyData = context.Cars.Any();
            if (hasAlreadyData)
            {
                Console.WriteLine("Already have data");   
                return;
            }
            
            Console.WriteLine("Adding startup data"); 
            
            PopulateDb.Populate(context);
        }
    }
}
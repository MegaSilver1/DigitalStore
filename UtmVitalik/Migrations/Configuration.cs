
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace UtmVitalik.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<UtmVitalik.BusinessLogic.DB.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    } 
}
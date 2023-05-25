using System.Collections.Generic;
using System.Reflection;
using System;

namespace Ex03.GarageLogic.Models
{
    public class CustomerTicket
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        
        public eVehicleStatus VehicleStatus { get; set; }

        public override string ToString()
        {
            return $@"
Customer Name: {CustomerName}
Customer Phone number {CustomerPhone}";
        }

        public IEnumerable<string> GetPropertiesNames()
        {
            Type type = GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            List<string> propertiesNames = new List<string>();

            foreach (PropertyInfo property in properties)
            {
                propertiesNames.Add(property.Name);
            }

            return propertiesNames;
        }
    }
}
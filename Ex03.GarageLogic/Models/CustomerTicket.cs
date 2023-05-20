namespace Ex03.GarageLogic.Models
{
    public class CustomerTicket
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        
        public eVehicleStatuses VehicleStatus { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
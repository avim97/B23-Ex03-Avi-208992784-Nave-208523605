namespace Ex03.GarageLogic.Models
{
    public class CustomerTicket
    {
        public string LicensePlate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public eVehicleStatus VehicleStatus { get; set; }

        public override string ToString()
        {
            return $@"
Customer Name: {CustomerName}
Customer Phone number {CustomerPhone}
Vehicle Status in garage: {VehicleStatus}";
        }

        public override int GetHashCode()
        {
            return this.LicensePlate.GetHashCode();
        }
    }
}
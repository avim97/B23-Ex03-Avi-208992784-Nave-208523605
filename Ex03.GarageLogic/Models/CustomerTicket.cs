namespace Ex03.GarageLogic.Models
{
    public class CustomerTicket
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        
        public eVehicleStatuses VehicleStatus { get; set; }

        //todo: add get hashcode

    }
}
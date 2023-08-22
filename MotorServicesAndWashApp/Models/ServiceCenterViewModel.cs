namespace MotorServicesAndWashApp.Models
{
    public class ServiceCenterViewModel
    {
        public int ProvincesId { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public string? Address { get; set; }
        public string? Latitude { get; set; }
        public string? longitude { get; set; }
        public string? ServiceCenterName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Hotline { get; set; }
        public string? Email { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public string? Description { get; set; }
        public string? GoogleMapLink { get; set; }
        //Login Details
        public string? UserPhoneNumber { get; set; }
        public string? UserEmail { get; set; }
        public string? Passowrd { get; set; }
        public List<int>? VehicleSelectedValues { get; set; }
        public List<int>? DaysSelectedValue { get; set; }
    }
}

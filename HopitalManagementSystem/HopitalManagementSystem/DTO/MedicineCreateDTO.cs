namespace HospitalManagementSystem.DTO
{
    public class MedicineCreateDTO
    {
        public int medicineId { get; set; }  

        public string medicineName { get; set; }
        public float price { get; set; }
        public string company { get; set; }
        public string description { get; set; }
    }
}

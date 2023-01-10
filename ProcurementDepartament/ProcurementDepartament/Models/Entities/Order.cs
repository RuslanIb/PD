using ProcurementDepartament.Models.Enums;

namespace ProcurementDepartament.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public List<AssamblyPart> AssamblyParts { get; set; }
        public User User { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? PathDocument { get; set; }
        public Status Status { get; set; }
        public Department PerformerDepartment { get; set; }
    }
}

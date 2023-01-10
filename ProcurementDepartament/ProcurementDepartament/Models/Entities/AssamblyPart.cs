using ProcurementDepartament.Models.Enums;

namespace ProcurementDepartament.Models.Entities
{
    public class AssamblyPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DronCategory DronCategory { get; set; }
        public string Description { get; set; }
        public Vendor? Vendor { get; set; }
        public int Quantity { get; set; }
    }
}

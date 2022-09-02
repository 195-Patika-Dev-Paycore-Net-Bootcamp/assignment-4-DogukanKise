using Data.Model.Abstract;

namespace Data.Model.Concrete
{
    public class Vehicle : IEntity
    {
        // My Vehicle class and properties for the database table
        public virtual long id { get; set; }
        public virtual string vehicle_name { get; set; }
        public virtual string vehicle_plate { get; set; }
    }
}

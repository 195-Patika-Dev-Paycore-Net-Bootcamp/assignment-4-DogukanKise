using Data.Model.Abstract;

namespace Data.Model.Concrete
{
    public class Container : IEntity
    {
        // My Container class and properties for the database table
        public virtual long id { get; set; }
        public virtual string container_name { get; set; }
        public virtual double latitude { get; set; }
        public virtual double longitude { get; set; }
        public virtual long vehicle_id { get; set; }
    }
}

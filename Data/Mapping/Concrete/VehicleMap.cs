using Data.Model.Concrete;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Data.Mapping.Concrete
{
    public class VehicleMap : ClassMapping<Vehicle>
    {
        // Vehicle's mapping process Type,ColumnName, Nullable etc.
        public VehicleMap()
        {
            Id(x => x.id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("id");
                x.Generator(Generators.Increment);
            });

            Property(b => b.vehicle_name, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.Column("vehicle_name");
                x.NotNullable(true);
            });
            Property(b => b.vehicle_plate, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.Column("vehicle_plate");
                x.NotNullable(true);
            });
        }
    }
}

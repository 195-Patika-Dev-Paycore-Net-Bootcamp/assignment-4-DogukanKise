using Data.Model.Concrete;
using Dto.Concrete;
using Service.Base.Abstract;

namespace Service.Vehicles.Abstract
{
    public interface IVehicleService : IBaseService<VehicleDto, Vehicle>
    {
        //An interface which is implements an interface IBaseService with VehicleDto and Vehicle
    }
}

using Base.Response;
using System.Collections.Generic;

namespace Service.Base.Abstract
{
    public interface IBaseService<Dto, Entity>
    {
        //Generic interface which is required Dto and Entity(in this case for the Dto's: ContainerDto and VehicleDto.
        //for the entities: Vehicle and Container)
        BaseResponse<Dto> GetById(int id);
        BaseResponse<IEnumerable<Dto>> GetAll();
        BaseResponse<Dto> Insert(Dto insert);
        BaseResponse<Dto> Update(int id, Dto update);
        BaseResponse<Dto> Remove(int id);
    }
}

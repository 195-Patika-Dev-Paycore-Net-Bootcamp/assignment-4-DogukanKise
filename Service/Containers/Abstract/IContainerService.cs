using Data.Model.Concrete;
using Dto.Concrete;
using Service.Base.Abstract;

namespace Service.Containers.Abstract
{
    public interface IContainerService : IBaseService<ContainerDto, Container>
    {
        //An interface whichs is implements an interface IBaseService with ContainerDto and Container
    }
}

using AutoMapper;
using Base.Response;
using Data.Model.Concrete;
using Data.Repository.Abstract;
using Data.Repository.Concrete;
using Dto.Concrete;
using NHibernate;
using Service.Base.Concrete;
using Service.Vehicles.Abstract;
using System.Collections.Generic;

namespace Service.Vehicles.Concrete
{
    public class VehicleService : BaseService<VehicleDto, Vehicle>, IVehicleService
    {
        //Container service class implements BaseService<ContainerDto,Container> and IContainerService
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Vehicle> hibernateRepository;

        public VehicleService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            //injections
            hibernateRepository = new HibernateRepository<Vehicle>(session);
        }

        public override BaseResponse<IEnumerable<VehicleDto>> GetAll()
        {
            return base.GetAll();
        }

        public override BaseResponse<VehicleDto> GetById(int id)
        {
            return base.GetById(id);
        }
    }
}

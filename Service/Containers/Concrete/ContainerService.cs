using AutoMapper;
using Base.Response;
using Data.Model.Concrete;
using Data.Repository.Abstract;
using Data.Repository.Concrete;
using Dto.Concrete;
using NHibernate;
using Service.Base.Concrete;
using Service.Containers.Abstract;
using System.Collections.Generic;

namespace Service.Containers.Concrete
{
    public class ContainerService : BaseService<ContainerDto, Container>, IContainerService
    {
        //Container service class implements BaseService<ContainerDto,Container> and IContainerService
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Container> hibernateRepository;

        public ContainerService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            //injections

            hibernateRepository = new HibernateRepository<Container>(session);
        }

        public override BaseResponse<IEnumerable<ContainerDto>> GetAll()
        {
            return base.GetAll();
        }

        public override BaseResponse<ContainerDto> GetById(int id)
        {
            return base.GetById(id);
        }

    }
}

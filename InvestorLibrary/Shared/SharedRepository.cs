using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.Shared
{
    public interface ISharedRepository
    {
        Task<IEnumerable<InvestmentActionModel>> GetInvestmentActions();
    }


    public class SharedRepository : ISharedRepository
    {
        private readonly IDataAccessRepository _dataAccessRepository;
        public SharedRepository()
        {
            _dataAccessRepository = (IDataAccessRepository)ContainerConfig.ServiceProvider.GetService(typeof(IDataAccessRepository));
        }

        public async Task<IEnumerable<InvestmentActionModel>> GetInvestmentActions()
        {
            var param = new QueryParams();
            param.Query = "spInvestmentActions_GetAllList";

            var modelData = await _dataAccessRepository.GetWhere<InvestmentActionModel>(param);

            return modelData;
        }


        //public async Task<IEnumerable<KeyValueModel>> GetShipDirection()
        //{
        //    var param = new QueryParams();
        //    param.Query = "spKeyValues_GetShipDirection";

        //    var modelData = await _dataAccessRepository.GetWhere<KeyValueModel>(param);

        //    return modelData;
        //}

        //public async Task<IEnumerable<KeyValueModel>> GetPackSizes()
        //{
        //    var param = new QueryParams();
        //    param.Query = "spKeyValues_GetPackSizes";

        //    var modelData = await _dataAccessRepository.GetWhere<KeyValueModel>(param);

        //    return modelData;
        //}

        //public async Task<IEnumerable<KeyValueModel>> GetHazard()
        //{
        //    var param = new QueryParams();
        //    param.Query = "spKeyValues_GetHazard";

        //    var modelData = await _dataAccessRepository.GetWhere<KeyValueModel>(param);

        //    return modelData;
        //}

    }

    }

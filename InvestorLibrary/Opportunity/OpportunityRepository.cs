using System;
using InvestorLibrary.Opportunity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestorLibrary.Shared;
using InvestorLibrary.OpportunityCategory;

namespace InvestorLibrary.Opportunity
{
    public interface IOpportunityRepository
    {
        Task<IEnumerable<OpportunityListModel>> GetAllList();
        Task<IEnumerable<OpportunityViewModel>> GetAll();
        Task<IEnumerable<OpportunityViewModel>> GetWhere(string filter, string id);
        Task<OpportunityViewModel> GetById(string Id);
        Task<OpportunityViewModel> Add(OpportunityModel model);
        Task<OpportunityViewModel> Update(OpportunityModel model);
        Task<OpportunityViewModel> Remove(string id);
        Task AddUpdateBulk(IEnumerable<OpportunityModel> model);
        Task<IEnumerable<OpportunityReportModel>> ReportGetWhere(OpportunityReportQuery model);
    }


    public class OpportunityRepository : IOpportunityRepository
    {
        private readonly IDataAccessRepository _dataRepository;

        public OpportunityRepository()
        {
            _dataRepository = (IDataAccessRepository)ContainerConfig.ServiceProvider.GetService(typeof(IDataAccessRepository));
        }


        public async Task<IEnumerable<OpportunityListModel>> GetAllList()
        {
            var param = new QueryParams();
            param.Query = "spOpportunities_GetAllList";

            var modelData = await _dataRepository.GetAll<OpportunityListModel>(param);

            return modelData.OrderBy(x => x.CodeName).ToList();
        }


        public async Task<IEnumerable<OpportunityViewModel>> GetAll()
        {
            var param = new QueryParams();
            param.Query = "spOpportunities_GetAll";

            var modelData = await _dataRepository.GetAll<OpportunityViewModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<OpportunityViewModel>> GetWhere(string field, string val)
        {
            var param = new QueryParams();
            param.Query = "spOpportunities_GetWhere";
            param.Records.Add(new RecordValue { Name = "FilterBy", Value = field });
            param.Records.Add(new RecordValue { Name = field, Value = val });

            var modelData = await _dataRepository.GetWhere<OpportunityViewModel>(param);


            return modelData;
        }


        public async Task<OpportunityViewModel> GetById(string Id)
        {
            var param = new QueryParams();
            param.Query = "spOpportunities_GetById";
            param.Records.Add(new RecordValue { Name = _opportunity.opportunity_id, Value = Id });

            var modelData = await _dataRepository.GetById<OpportunityViewModel>(param);

            return modelData;
        }


        public async Task<OpportunityViewModel> Add(OpportunityModel model)
        {
            var param = new QueryParams();
            param.Query = "spOpportunities_Create";

            var modelData = await _dataRepository.Create<OpportunityModel>(param, model);

            return new OpportunityViewModel(modelData);
        }

        public async Task<OpportunityViewModel> Update(OpportunityModel model)
        {
            var param = new QueryParams();
            param.Query = "spOpportunities_Update";
            param.Records.Add(new RecordValue { Name = _opportunity.opportunity_id, Value = model.opportunity_id.ToString() });

            var modelData = await _dataRepository.Update<OpportunityModel>(param, model);

            return new OpportunityViewModel(modelData);
        }

        public async Task<OpportunityViewModel> Remove(string id)
        {
            var param = new QueryParams();
            param.Query = "spOpportunities_Delete";
            param.Records.Add(new RecordValue { Name = _opportunity.opportunity_id, Value = id });

            var modelData = await _dataRepository.Delete<OpportunityModel>(param);

            return new OpportunityViewModel(modelData);
        }

        public async Task AddUpdateBulk(IEnumerable<OpportunityModel> model)
        {
            foreach (var item in model)
            {
                if (item.opportunity_id <= 0)
                {
                    var param = new QueryParams();
                    param.Query = "spOpportunities_Create";
                    await _dataRepository.Create<OpportunityModel>(param, item);
                }
                else
                {
                    var param = new QueryParams();
                    param.Query = "spOpportunities_Update";
                    await _dataRepository.Update<OpportunityModel>(param, item);
                }
            }

        }


        public async Task<IEnumerable<OpportunityReportModel>> ReportGetWhere(OpportunityReportQuery model)
        {
            var param = new QueryParams();
            param.Query = "rpOpportunities_GetWhere";
            param.Records.Add(new RecordValue { Name = _opportunityCategory.CategoryCodeFrom, Value = model.CategoryCodeFrom });
            param.Records.Add(new RecordValue { Name = _opportunityCategory.CategoryCodeTo, Value = model.CategoryCodeTo });
            param.Records.Add(new RecordValue { Name = _opportunity.OpportunityCodeFrom, Value = model.OpportunityCodeFrom });
            param.Records.Add(new RecordValue { Name = _opportunity.OpportunityCodeTo, Value = model.OpportunityCodeTo });

            var modelData = await _dataRepository.GetWhere<OpportunityReportModel>(param);

            return modelData.OrderBy(x => x.opportunity_code).ToList();
        }

    }
}

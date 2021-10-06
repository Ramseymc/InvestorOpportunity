using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.OpportunityCategory
{
 
    public interface IOpportunityCategoryRepository
    {
        Task<IEnumerable<OpportunityCategoryListModel>> GetAllList();
        Task<IEnumerable<OpportunityCategoryViewModel>> GetAll();
        Task<IEnumerable<OpportunityCategoryViewModel>> GetWhere(string filter, string id);
        Task<OpportunityCategoryViewModel> GetById(string Id);
        Task<OpportunityCategoryViewModel> Add(OpportunityCategoryModel model);
        Task<OpportunityCategoryViewModel> Update(OpportunityCategoryModel model);
        Task<OpportunityCategoryViewModel> Remove(string id);
        Task AddUpdateBulk(IEnumerable<OpportunityCategoryModel> model);
    }


    public class OpportunityCategoryRepository : IOpportunityCategoryRepository
    {
        private readonly IDataAccessRepository _dataRepository;

        public OpportunityCategoryRepository()
        {
            _dataRepository = (IDataAccessRepository)ContainerConfig.ServiceProvider.GetService(typeof(IDataAccessRepository));
        }


        public async Task<IEnumerable<OpportunityCategoryListModel>> GetAllList()
        {
            var param = new QueryParams();
            param.Query = "spOpportunityCategories_GetAllList";

            var modelData = await _dataRepository.GetAll<OpportunityCategoryListModel>(param);

            return modelData.OrderBy(x => x.Description).ToList();
        }


        public async Task<IEnumerable<OpportunityCategoryViewModel>> GetAll()
        {
            var param = new QueryParams();
            param.Query = "spOpportunityCategories_GetAll";

            var modelData = await _dataRepository.GetAll<OpportunityCategoryViewModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<OpportunityCategoryViewModel>> GetWhere(string field, string val)
        {
            var param = new QueryParams();
            param.Query = "spOpportunityCategories_GetWhere";
            param.Records.Add(new RecordValue { Name = "FilterBy", Value = field });
            param.Records.Add(new RecordValue { Name = field, Value = val });

            var modelData = await _dataRepository.GetWhere<OpportunityCategoryViewModel>(param);


            return modelData;
        }


        public async Task<OpportunityCategoryViewModel> GetById(string Id)
        {
            var param = new QueryParams();
            param.Query = "spOpportunityCategories_GetById";
            param.Records.Add(new RecordValue { Name = _opportunityCategory.Id, Value = Id });

            var modelData = await _dataRepository.GetById<OpportunityCategoryViewModel>(param);

            return modelData;
        }


        public async Task<OpportunityCategoryViewModel> Add(OpportunityCategoryModel model)
        {
            var param = new QueryParams();
            param.Query = "spOpportunityCategories_Create";

            var modelData = await _dataRepository.Create<OpportunityCategoryModel>(param, model);

            return new OpportunityCategoryViewModel(modelData);
        }

        public async Task<OpportunityCategoryViewModel> Update(OpportunityCategoryModel model)
        {
            var param = new QueryParams();
            param.Query = "spOpportunityCategories_Update";
            param.Records.Add(new RecordValue { Name = _opportunityCategory.Id, Value = model.Id.ToString() });

            var modelData = await _dataRepository.Update<OpportunityCategoryModel>(param, model);

            return new OpportunityCategoryViewModel(modelData);
        }

        public async Task<OpportunityCategoryViewModel> Remove(string id)
        {
            var param = new QueryParams();
            param.Query = "spOpportunityCategories_Delete";
            param.Records.Add(new RecordValue { Name = _opportunityCategory.Id, Value = id });

            var modelData = await _dataRepository.Delete<OpportunityCategoryModel>(param);

            return new OpportunityCategoryViewModel(modelData);
        }

        public async Task AddUpdateBulk(IEnumerable<OpportunityCategoryModel> model)
        {
            foreach (var item in model)
            {
                if (item.Id <= 0)
                {
                    var param = new QueryParams();
                    param.Query = "spOpportunityCategories_Create";
                    await _dataRepository.Create<OpportunityCategoryModel>(param, item);
                }
                else
                {
                    var param = new QueryParams();
                    param.Query = "spOpportunityCategories_Update";
                    await _dataRepository.Update<OpportunityCategoryModel>(param, item);
                }
            }

        }


    }
}

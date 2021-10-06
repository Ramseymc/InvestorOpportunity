using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.TransactionType
{
  
    public interface ITransactionTypeRepository
    {
        Task<IEnumerable<TransactionTypeListModel>> GetAllList();
        Task<IEnumerable<TransactionTypeViewModel>> GetAll();
        Task<IEnumerable<TransactionTypeViewModel>> GetWhere(string filter, string id);
        Task<TransactionTypeViewModel> GetById(string Id);
        Task<TransactionTypeViewModel> Add(TransactionTypeModel model);
        Task<TransactionTypeViewModel> Update(TransactionTypeModel model);
        Task<TransactionTypeViewModel> Remove(string id);
        Task AddUpdateBulk(IEnumerable<TransactionTypeModel> model);
    }


    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly IDataAccessRepository _dataRepository;

        public TransactionTypeRepository()
        {
            _dataRepository = (IDataAccessRepository)ContainerConfig.ServiceProvider.GetService(typeof(IDataAccessRepository));
        }


        public async Task<IEnumerable<TransactionTypeListModel>> GetAllList()
        {
            var param = new QueryParams();
            param.Query = "spTransactionTypes_GetAllList";

            var modelData = await _dataRepository.GetAll<TransactionTypeListModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<TransactionTypeViewModel>> GetAll()
        {
            var param = new QueryParams();
            param.Query = "spTransactionTypes_GetAll";

            var modelData = await _dataRepository.GetAll<TransactionTypeViewModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<TransactionTypeViewModel>> GetWhere(string field, string val)
        {
            var param = new QueryParams();
            param.Query = "spTransactionTypes_GetWhere";
            param.Records.Add(new RecordValue { Name = "FilterBy", Value = field });
            param.Records.Add(new RecordValue { Name = field, Value = val });

            var modelData = await _dataRepository.GetWhere<TransactionTypeViewModel>(param);


            return modelData;
        }


        public async Task<TransactionTypeViewModel> GetById(string Id)
        {
            var param = new QueryParams();
            param.Query = "spTransactionTypes_GetById";
            param.Records.Add(new RecordValue { Name = _transactionType.Id, Value = Id });

            var modelData = await _dataRepository.GetById<TransactionTypeViewModel>(param);

            return modelData;
        }


        public async Task<TransactionTypeViewModel> Add(TransactionTypeModel model)
        {
            var param = new QueryParams();
            param.Query = "spTransactionTypes_Create";

            var modelData = await _dataRepository.Create<TransactionTypeModel>(param, model);

            return new TransactionTypeViewModel(modelData);
        }

        public async Task<TransactionTypeViewModel> Update(TransactionTypeModel model)
        {
            var param = new QueryParams();
            param.Query = "spTransactionTypes_Update";
            param.Records.Add(new RecordValue { Name = _transactionType.Id, Value = model.Id.ToString() });

            var modelData = await _dataRepository.Update<TransactionTypeModel>(param, model);

            return new TransactionTypeViewModel(modelData);
        }

        public async Task<TransactionTypeViewModel> Remove(string id)
        {
            var param = new QueryParams();
            param.Query = "spTransactionTypes_Delete";
            param.Records.Add(new RecordValue { Name = _transactionType.Id, Value = id });

            var modelData = await _dataRepository.Delete<TransactionTypeModel>(param);

            return new TransactionTypeViewModel(modelData);
        }

        public async Task AddUpdateBulk(IEnumerable<TransactionTypeModel> model)
        {
            foreach (var item in model)
            {
                if (item.Id <= 0)
                {
                    var param = new QueryParams();
                    param.Query = "spTransactionTypes_Create";
                    await _dataRepository.Create<TransactionTypeModel>(param, item);
                }
                else
                {
                    var param = new QueryParams();
                    param.Query = "spTransactionTypes_Update";
                    await _dataRepository.Update<TransactionTypeModel>(param, item);
                }
            }

        }


    }
}

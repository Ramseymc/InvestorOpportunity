using InvestorLibrary.Shared;
using InvestorLibrary.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.Investor
{
    public interface IInvestorRepository
    {
        Task<IEnumerable<InvestorListModel>> GetAllList();
        Task<IEnumerable<InvestorViewModel>> GetAll();
        Task<IEnumerable<InvestorViewModel>> GetWhere(string filter, string id);
        Task<InvestorViewModel> GetById(string Id);
        Task<InvestorViewModel> Add(InvestorModel model);
        Task<InvestorViewModel> Update(InvestorModel model);
        Task<InvestorViewModel> Remove(string id);
        Task AddUpdateBulk(IEnumerable<InvestorModel> model);
        Task<IEnumerable<InvestorReportModel>> ReportGetAll();
        Task<IEnumerable<InvestorReportModel>> ReportGetWhere(InvestorReportQuery model);
    }


    public class InvestorRepository : IInvestorRepository
    {
        private readonly IDataAccessRepository _dataRepository;

        public InvestorRepository()
        {
            _dataRepository = (IDataAccessRepository)ContainerConfig.ServiceProvider.GetService(typeof(IDataAccessRepository));
        }


        public async Task<IEnumerable<InvestorListModel>> GetAllList()
        {
            var param = new QueryParams();
            param.Query = "spInvestors_GetAllList";

            var modelData = await _dataRepository.GetAll<InvestorListModel>(param);

            return modelData.OrderBy(x => x.investor_acc_number).ToList();
        }


        public async Task<IEnumerable<InvestorViewModel>> GetAll()
        {
            var param = new QueryParams();
            param.Query = "spInvestors_GetAll";

            var modelData = await _dataRepository.GetAll<InvestorViewModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<InvestorViewModel>> GetWhere(string field, string val)
        {
            var param = new QueryParams();
            param.Query = "spInvestors_GetWhere";
            param.Records.Add(new RecordValue { Name = "FilterBy", Value = field });
            param.Records.Add(new RecordValue { Name = field, Value = val });

            var modelData = await _dataRepository.GetWhere<InvestorViewModel>(param);


            return modelData;
        }


        public async Task<InvestorViewModel> GetById(string Id)
        {
            var param = new QueryParams();
            param.Query = "spInvestors_GetById";
            param.Records.Add(new RecordValue { Name = _investor.investor_id, Value = Id });

            var modelData = await _dataRepository.GetById<InvestorViewModel>(param);

            return modelData;
        }


        public async Task<InvestorViewModel> Add(InvestorModel model)
        {
            var param = new QueryParams();
            param.Query = "spInvestors_Create";

            var modelData = await _dataRepository.Create<InvestorModel>(param, model);

            return new InvestorViewModel(modelData);
        }

        public async Task<InvestorViewModel> Update(InvestorModel model)
        {
            var param = new QueryParams();
            param.Query = "spInvestors_Update";
            param.Records.Add(new RecordValue { Name = _investor.investor_id, Value = model.investor_id.ToString() });

            var modelData = await _dataRepository.Update<InvestorModel>(param, model);

            return new InvestorViewModel(modelData);
        }

        public async Task<InvestorViewModel> Remove(string id)
        {
            var param = new QueryParams();
            param.Query = "spInvestors_Delete";
            param.Records.Add(new RecordValue { Name = _investor.investor_id, Value = id });

            var modelData = await _dataRepository.Delete<InvestorModel>(param);

            return new InvestorViewModel(modelData);
        }

        public async Task AddUpdateBulk(IEnumerable<InvestorModel> model)
        {
            foreach (var item in model)
            {
                if (item.investor_id <= 0)
                {
                    var param = new QueryParams();
                    param.Query = "spInvestors_Create";
                    await _dataRepository.Create<InvestorModel>(param, item);
                }
                else
                {
                    var param = new QueryParams();
                    param.Query = "spInvestors_Update";
                    await _dataRepository.Update<InvestorModel>(param, item);
                }
            }

        }


        public async Task<IEnumerable<InvestorReportModel>> ReportGetAll()
        {
            var param = new QueryParams();
            param.Query = "rpInvestors_GetAll";

            var modelData = await _dataRepository.GetAll<InvestorReportModel>(param);

            return modelData;
        }

        public async Task<IEnumerable<InvestorReportModel>> ReportGetWhere(InvestorReportQuery model)
        {
            var param = new QueryParams();
            param.Query = "rpInvestors_GetWhere";
            param.Records.Add(new RecordValue { Name = _user.PortalUserFrom, Value = model.UserCodeFrom });
            param.Records.Add(new RecordValue { Name = _user.PortalUserTo, Value = model.UserCodeTo });
            param.Records.Add(new RecordValue { Name = _investor.InvestorCodeFrom, Value = model.InvestorCodeFrom });
            param.Records.Add(new RecordValue { Name = _investor.InvestorCodeTo, Value = model.InvestorCodeTo });

            var modelData = await _dataRepository.GetWhere<InvestorReportModel>(param);

            return modelData.OrderBy(x => x.investor_acc_number).ToList();
        }

    }

}

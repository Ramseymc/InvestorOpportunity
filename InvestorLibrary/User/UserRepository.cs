using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.User
{

    public interface IUserRepository
    {
        Task<IEnumerable<UserListModel>> GetAllList();
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<IEnumerable<UserViewModel>> GetWhere(string filter, string id);
        Task<UserViewModel> GetById(string Id);
        Task<UserViewModel> Add(UserModel model);
        Task<UserViewModel> Update(UserModel model);
        Task<UserViewModel> Remove(string id);
        Task AddUpdateBulk(IEnumerable<UserModel> model);
    }


    public class UserRepository : IUserRepository
    {
        private readonly IDataAccessRepository _dataRepository;

        public UserRepository()
        {
            _dataRepository = (IDataAccessRepository)ContainerConfig.ServiceProvider.GetService(typeof(IDataAccessRepository));
        }


        public async Task<IEnumerable<UserListModel>> GetAllList()
        {
            var param = new QueryParams();
            param.Query = "spUsers_GetAllList";

            var modelData = await _dataRepository.GetAll<UserListModel>(param);

            return modelData.OrderBy(x => x.Username).ToList();
        }


        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var param = new QueryParams();
            param.Query = "spUsers_GetAll";

            var modelData = await _dataRepository.GetAll<UserViewModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<UserViewModel>> GetWhere(string field, string val)
        {
            var param = new QueryParams();
            param.Query = "spUsers_GetWhere";
            param.Records.Add(new RecordValue { Name = "FilterBy", Value = field });
            param.Records.Add(new RecordValue { Name = field, Value = val });

            var modelData = await _dataRepository.GetWhere<UserViewModel>(param);


            return modelData;
        }


        public async Task<UserViewModel> GetById(string Id)
        {
            var param = new QueryParams();
            param.Query = "spUsers_GetById";
            param.Records.Add(new RecordValue { Name = _user.Id, Value = Id });

            var modelData = await _dataRepository.GetById<UserViewModel>(param);

            return modelData;
        }


        public async Task<UserViewModel> Add(UserModel model)
        {
            var param = new QueryParams();
            param.Query = "spUsers_Create";

            var modelData = await _dataRepository.Create<UserModel>(param, model);

            return new UserViewModel(modelData);
        }

        public async Task<UserViewModel> Update(UserModel model)
        {
            var param = new QueryParams();
            param.Query = "spUsers_Update";
            param.Records.Add(new RecordValue { Name = _user.Id, Value = model.Id.ToString() });

            var modelData = await _dataRepository.Update<UserModel>(param, model);

            return new UserViewModel(modelData);
        }

        public async Task<UserViewModel> Remove(string id)
        {
            var param = new QueryParams();
            param.Query = "spUsers_Delete";
            param.Records.Add(new RecordValue { Name = _user.Id, Value = id });

            var modelData = await _dataRepository.Delete<UserModel>(param);

            return new UserViewModel(modelData);
        }

        public async Task AddUpdateBulk(IEnumerable<UserModel> model)
        {
            foreach (var item in model)
            {
                if (item.Id <= 0)
                {
                    var param = new QueryParams();
                    param.Query = "spUsers_Create";
                    await _dataRepository.Create<UserModel>(param, item);
                }
                else
                {
                    var param = new QueryParams();
                    param.Query = "spUsers_Update";
                    await _dataRepository.Update<UserModel>(param, item);
                }
            }

        }


    }
}

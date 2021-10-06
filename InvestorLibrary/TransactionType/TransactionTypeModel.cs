using InvestorLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.TransactionType
{
    public static class _transactionType
    {
        public const string Id = "Id";
        public const string Description = "Description";
        public const string Blocked = "Blocked";
    }

    public class TransactionTypeModel : BaseModel
    {
        public long? Id { get; set; }
        public string Description { get; set; }
        public bool? Blocked { get; set; }

        public TransactionTypeModel()
        {
        }

        public TransactionTypeModel(long? id, string description, bool blocked)
        {
            Id = id;
            Description = description;
            Blocked = blocked;
        }

        public TransactionTypeModel(TransactionTypeViewModel model)
        {
            Id = model.Id;
            Description = model.Description;
            Blocked = model.Blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }
    }

    public class TransactionTypeViewModel : BaseModel
    {
        public long? Id { get; set; }
        public string Description { get; set; }
        public bool? Blocked { get; set; }

        public TransactionTypeViewModel()
        {
        }

        public TransactionTypeViewModel(TransactionTypeModel model)
        {
            Id = model.Id;
            Description = model.Description;
            Blocked = model.Blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }

    }

    public class TransactionTypeListModel
    {
        public long? Id { get; set; }
        public string Description { get; set; }
    }


}

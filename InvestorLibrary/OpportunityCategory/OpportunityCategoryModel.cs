using InvestorLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.OpportunityCategory
{
    public static class _opportunityCategory
    {
        public const string Id = "Id";
        public const string Description = "Description";
        public const string Blocked = "Blocked";

        public const string CategoryCodeFrom = "CategoryCodeFrom";
        public const string CategoryCodeTo = "CategoryCodeTo";
    }

    public class OpportunityCategoryModel : BaseModel
    {
        public long? Id { get; set; }
        public string Description { get; set; }
        public bool? Blocked { get; set; }

        public OpportunityCategoryModel()
        {
        }

        public OpportunityCategoryModel(long? id, string description, bool blocked)
        {
            Id = id;
            Description = description;
            Blocked = blocked;
        }

        public OpportunityCategoryModel(OpportunityCategoryViewModel model)
        {
            Id = model.Id;
            Description = model.Description;
            Blocked = model.Blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }
    }

    public class OpportunityCategoryViewModel : BaseModel
    {
        public long? Id { get; set; }
        public string Description { get; set; }
        public bool? Blocked { get; set; }


        public OpportunityCategoryViewModel()
        {
        }

        public OpportunityCategoryViewModel(OpportunityCategoryModel model)
        {
            Id = model.Id;
            Description = model.Description;
            Blocked = model.Blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }
    }


    public class OpportunityCategoryListModel
    {
        public int? Id { get; set; }
        public string Description { get; set; }
    }

}





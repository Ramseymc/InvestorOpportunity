using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.Shared
{

    public class KeyValueModel
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public KeyValueModel()
        {
        }

        public KeyValueModel(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    public static class _investmentAction
    {
        public const string Id = "Id";
        public const string Description = "Description";
        public const string ExitRollover = "ExitRollover";

    }

    public class InvestmentActionModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }



    //public static class InputValue
    //{

    //    public const string Number = "number";
    //    public const string Decimal = "decimal";
    //    public const string Combo = "combo";
    //}


    public static class FormAction
    {
        public const string Selected = "Selected";
        public const string Save = "Save";
        public const string AddEdit = "AddEdit";
        public const string Undo = "Undo";
        public const string Delete = "Delete";
        public const string Other = "Default";

    }


}

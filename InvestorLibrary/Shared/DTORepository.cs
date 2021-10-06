using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.Shared
{
    //  public interface IDTORepository
    //{
    //    IEnumerable<T> DataTableToDTO<T>(DataTable table) where T : class, new();
    //    DataTable DTOToDataTable<T>(IEnumerable<T> data) where T : class;
    //    DataTable ViewModeltoDataTable<T, VM>(IEnumerable<VM> data) where T : class where VM : class;
    //    DataTable DTOToHeaderData<T>(T data) where T : class;
    //}


    public static class DTORepository
    {
        private static readonly IDictionary<Type, ICollection<PropertyInfo>> _Properties =
            new Dictionary<Type, ICollection<PropertyInfo>>();

        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static IEnumerable<T> DataTableToDTO<T>(this DataTable table) where T : class, new()
        {
            var objType = typeof(T);
            ICollection<PropertyInfo> properties;

            if (!_Properties.TryGetValue(objType, out properties))
            {
                properties = objType.GetProperties().Where(property => property.CanWrite).ToList();
                _Properties.Add(objType, properties);
            }

            var list = new List<T>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var obj = new T();

                foreach (var prop in properties)
                {
                    var propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    var safeValue = table.Rows[i][prop.Name] == null ?
                                null : Convert.ChangeType(table.Rows[i][prop.Name], propType);
                    prop.SetValue(obj, safeValue, null);
                }

                list.Add(obj);
            }

            return list;
        }


        public static DataTable DTOToDataTable<T>(this IEnumerable<T> data) where T : class
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            DataTable dataTable = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = dataTable.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }


        //public static DataTable ViewModeltoDataTable<T, VM>(IEnumerable<VM> data) where T : class where VM : class
        //{
        //    var modelData = _iMapper.Map<IEnumerable<VM>, IEnumerable<T>>(data);

        //    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

        //    DataTable dataTable = new DataTable();

        //    foreach (PropertyDescriptor prop in properties)
        //        dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

        //    foreach (T item in modelData)
        //    {
        //        DataRow row = dataTable.NewRow();
        //        foreach (PropertyDescriptor prop in properties)
        //            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
        //        dataTable.Rows.Add(row);
        //    }

        //    return dataTable;
        //}


        //public DataTable DTOToHeaderData<T>(T data) where T : class
        //{
        //    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

        //    DataTable dataTable = new DataTable();

        //    foreach (PropertyDescriptor prop in properties)
        //        dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

        //    // foreach (T item in data)
        //    // {
        //    DataRow row = dataTable.NewRow();
        //    foreach (PropertyDescriptor prop in properties)
        //        row[prop.Name] = prop.GetValue(data) ?? DBNull.Value;
        //    dataTable.Rows.Add(row);
        //    // }

        //    return dataTable;
        //}

    }

}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public static class ExtensionMethods
    {
        public static List<T> ToList<T>(this DataSet dt) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();
            foreach (DataTable table in dt.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    var item = CreateItemFromRow<T>(row, properties);
                    result.Add(item);
                }
            }

            return result;
        }
        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                property.SetValue(item, row[property.Name], null);
            }
            return item;
        }
        /*We first read all the property names from the class T(Member class) using reflection then we iterate through all the rows in dataset and create new object of T
         * then we set the properties of the newly created object using reflection. 
         * The property values are picked from the row's matching column cell.*/
        public static ObservableCollection<T> ToObservableList<T>(this IEnumerable<T> data)
        {
            ObservableCollection<T> dataToReturn = new ObservableCollection<T>();

            foreach (T t in data)
                dataToReturn.Add(t);

            return dataToReturn;
        }
        /* this extension method will translate any IEnumerable type, in our case a List to an Observable Collection.
           it is creating a new instance of ObservableCollection that will hold the data that will be returned, then will check the List passed as parameter
           and each item found in list will pe added to the "dataToReturn" collection and returned afterwards*/
    }
}

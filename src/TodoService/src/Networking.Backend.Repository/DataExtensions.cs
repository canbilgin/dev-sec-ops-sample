using Networking.Backend.Client;
using System.Data;

namespace Networking.Backend.Repository
{
    public static class DataExtensions
    {
        public static IEnumerable<Todo> ToEnumerableDto(this DataTable table)
        {
            if (table == null)
            {
                yield break;
            }

            foreach (DataRow tableRow in table.Rows)
            {
                yield return tableRow.ToDto();
            }
        }

        public static Todo ToDto(this DataRow row)
        {
            Todo todoItem = new Todo();

            todoItem.Id = row.Field<int>("Id");
            todoItem.Name = row.Field<string>("Name");
            todoItem.Description = row.Field<string>("Description");
            todoItem.Date = row.Field<DateTime>("Date");

            return todoItem;
        }
    }
}
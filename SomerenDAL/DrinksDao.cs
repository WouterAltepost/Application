using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class DrinksDao : BaseDao
    {
        public List<Drinks> GetAllDrinks()
        {
            string query = "SELECT id,name,price,stock, isalcoholic FROM [drinks]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drinks> ReadTables(DataTable dataTable)
        {
            List<Drinks> drink = new List<Drinks>();

            foreach (DataRow dr in dataTable.Rows)
            {
                drink.Add(
                    new Drinks()
                    {
                        Id = (int)dr["id"],
                        Name = (string)dr["name"],
                        Price = (double)dr["price"],
                        Stock = (int)dr["stock"],
                        IsAlcoholic = (bool)dr["isalcholic"]
                    }
                );;
            };
            return drink;
        }
    }
}

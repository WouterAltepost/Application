using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;
using System;

namespace SomerenDAL
{
    public class RoomDao : BaseDao
    {
        public List<Room> GetAllRooms()
        {
            string query = "SELECT id,type,capacity,room_number FROM [room]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> rooms = new List<Room>();

            foreach (DataRow dr in dataTable.Rows)
            {
                rooms.Add(
                    new Room()
                    {
                        Id = (int)dr["id"],
                        Type = (RoomType)(int)dr["type"],
                        Capacity = (int)dr["capacity"],
                        Number = (int)dr["room_number"],
                    }
                );
            };
            return rooms;
        }
    }
}
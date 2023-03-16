using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class TeacherDao : BaseDao
    {
        public List<Teacher> GetAllTeachers()
        {
            string query = "SELECT * FROM [teacher]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();
            int current_teacher_id = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                current_teacher_id = (int)dr["id"];

                string query = $"SELECT * FROM [human] WHERE id={current_teacher_id}";
                SqlParameter[] sqlParameters = new SqlParameter[0];
                DataRow dt_current_teacher = ExecuteSelectQuery(query, sqlParameters).Rows[0];

                Teacher teacher = new Teacher()
                {
                    Number = (int)dr["id"],
                    Name = dt_current_teacher["first_name"].ToString() + " " +
                            dt_current_teacher["last_name"].ToString()
                };
                teachers.Add(teacher);
            }
            return teachers;
        }
    }
}
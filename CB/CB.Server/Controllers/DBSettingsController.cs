using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CB.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CB.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DBSettingsController : ControllerBase
    {
        public DBSettingsController()
        {

        }
        [HttpGet]
        public List<CBTable> Get()
        {
            //return new List<DBLink>() { new DBLink {  IP = "10.50.132.10", UserName = "sa", PWD = "1234.com" ,Name ="acs",DBName="fastdev"},
            // new DBLink {  IP = "10.50.132.10", UserName = "sa", PWD = "1234.com" ,Name ="acsorder",DBName="acsorder"}}.ToArray();
            List<CBTable> cBTables = new List<CBTable>();
            SqlConnection conn = new SqlConnection("server=devsqldb;database=fastdev;uid=sa;pwd=1234.com;ApplicationIntent=ReadOnly;");
            conn.Open();
            using (var da = new SqlDataAdapter())
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM dbo.BSMODULE SELECT * FROM dbo.BSMODULE";
                da.SelectCommand =cmd;
                DataSet ds = new DataSet();

                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(ds);

                    conn.Close();
                // Return the dataset

                foreach(DataTable tb in ds.Tables)
                {
                    CBTable table = new CBTable() { TableName = tb.TableName };
                    foreach(DataColumn col in tb.Columns)
                    {
                        table.Columns.Add(new CBDataColumn { Name = col.ColumnName, Type = col.DataType.Name });
                    }
                    foreach (DataRow row in tb.Rows)
                    {
                        CBDataRow dataRow = new CBDataRow();
                        for(int i=0;i< row.ItemArray.Length;i++)
                        {

                            dataRow.Cells.Add(new Cell { Column = table.Columns[i], Value = row.ItemArray[i] });
                        }
                        table.DataRows.Add(dataRow);
                    }
                    cBTables.Add(table);
                }
                return cBTables;
            }
        }
    }
}
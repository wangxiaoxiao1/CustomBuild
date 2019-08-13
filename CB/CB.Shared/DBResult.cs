using System;
using System.Collections.Generic;
using System.Text;

namespace CB.Shared
{
    public class CBTable
    {
        public CBTable()
        {
            Columns = new List<CBDataColumn>();
            DataRows = new List<CBDataRow>();
        }
        public string TableName { get; set; }
        public List<CBDataColumn> Columns { get; set; }

        public List<CBDataRow> DataRows { get; set; }
    }
    public class CBDataRow
    {
        public CBDataRow()
        {
            Cells = new List<Cell>();
        }
        public List<Cell> Cells { get; set; }
    }
    public class Cell
    {
        public object Value { get; set; }
        public CBDataColumn Column { get; set; }
    }
    public class CBDataColumn
    {
        public string Name { get; set; }
        public string    Type { get; set; }
    }
}

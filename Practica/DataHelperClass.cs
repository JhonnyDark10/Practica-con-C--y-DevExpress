using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Helpers
{
    public class DataHelper
    {
        private DataSet _DataSet;
        private string _DataMember = "FirstTable";

        /*funcion para seleccionar un tipo de extraccion de datos*/
        public DataHelper(DSparametr param)
        {
            switch (param)
            {
                case DSparametr.simpleDS:
                    {
                        MakeFirstTable();
                        break;
                    }
             
            }
            DataSet.AcceptChanges();
        }

        /*funcion para llenar una tablas de prueba*/
        private void MakeFirstTable()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "value1";
            column.AutoIncrement = false;
            column.Caption = "Producto";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);


            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "value2";
            column.AutoIncrement = false;
            column.Caption = "Cantidad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(float);
            column.ColumnName = "value3";
            column.AutoIncrement = false;
            column.Caption = "Precio";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(float);
            column.ColumnName = "value4";
            column.AutoIncrement = false;
            column.Caption = "Subtotal";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            DataSet = new DataSet();
            DataSet.Tables.Add(table);

            for (int i = 0; i <= 0; i++)
            {
                row = table.NewRow();
                row["value1"] = i;
                row["value2"] = i;
                row["value3"] = i;
                row["value4"] = i;
                table.Rows.Add(row);
            }
        }

      

      
       


        public DataSet DataSet
        {
            get { return _DataSet; }
            set { _DataSet = value; }
        }

        public string DataMember
        {
            get { return _DataMember; }
            set
            {
                _DataMember = value;
            }
        }


        public static void CommitTransactionStub()
        {
            throw new InvalidOperationException("Fake exception");
        }

    }

    public enum DSparametr
    {
        simpleDS = 0
    }
}

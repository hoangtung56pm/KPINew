using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace VmgPortal.Library.Helper
{
	/// <summary>
	/// Descrizione di riepilogo per DataReaderConverters.
	/// </summary>
	public class DataReaderConverters
	{
		/// <summary>
		/// [static] PAB.Data.Utils.DataReaderConverters.ConvertDataReaderToDataSet:
		/// Converts one or more resultsets returned in a SqlDataReader to a DataSet
		/// </summary>
		/// <param name="reader">SqlDataReader</param>
		/// <returns>System.Data.DataSet</returns>
		public static DataSet ConvertDataReaderToDataSet(SqlDataReader reader)
		{
			DataSet dataSet = new DataSet();
			do
			{
				// Create new data table
				DataTable schemaTable = reader.GetSchemaTable();
				DataTable dataTable = new DataTable();

				if ( schemaTable != null )
				{
					for ( int i = 0; i < schemaTable.Rows.Count; i++ )
					{
						DataRow dataRow = schemaTable.Rows[ i ];
						// Create a column name that is unique in the data table
						string columnName = ( string )dataRow[ "ColumnName" ]; 
						// Add the column definition to the data table
						DataColumn column = new DataColumn( columnName, ( Type )dataRow[ "DataType" ] );
						dataTable.Columns.Add( column );
					}

					dataSet.Tables.Add( dataTable ); 

					while ( reader.Read() )
					{
						DataRow dataRow = dataTable.NewRow();

						for ( int i = 0; i < reader.FieldCount; i++ )
							dataRow[ i ] = reader.GetValue( i );

						dataTable.Rows.Add( dataRow );
					}
				}
				else
				{
					// No records returned

					DataColumn column = new DataColumn("RowsAffected");
					dataTable.Columns.Add(column);
					dataSet.Tables.Add( dataTable );
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = reader.RecordsAffected;
					dataTable.Rows.Add( dataRow );
				}
			}
			while ( reader.NextResult() );
			return dataSet;
		}

		/// <summary>
		/// [static] PAB.Data.Utils.DataReaderConverters.ConvertDataReaderToDataTable
		/// converts SqlDataReader to a DataTable
		/// </summary>
		/// <param name="reader">SqlDataReader</param>
		/// <returns>System.Data.DataTable</returns>
		public static DataTable ConvertDataReaderToDataTable(SqlDataReader reader) 
		{
			System.Data.DataTable table = reader.GetSchemaTable();
			System.Data.DataTable dt = new System.Data.DataTable();
			System.Data.DataColumn dc;
			System.Data.DataRow row;
			System.Collections.ArrayList al = new System.Collections.ArrayList();

			for (int i = 0; i < table.Rows.Count; i ++) 
			{
				dc = new System.Data.DataColumn();
				if (! dt.Columns.Contains(table.Rows[i]["ColumnName"].ToString()))
				{
					dc.ColumnName = table.Rows[i]["ColumnName"].ToString();
					dc.Unique = Convert.ToBoolean(table.Rows[i]["IsUnique"]);
					dc.AllowDBNull = Convert.ToBoolean(table.Rows[i]["AllowDBNull"]); 
					dc.ReadOnly = Convert.ToBoolean(table.Rows[i]["IsReadOnly"]);
					al.Add(dc.ColumnName);
					dt.Columns.Add(dc);
				}
			}
			while (reader.Read()) 
			{
				row = dt.NewRow();
				for ( int i = 0; i < al.Count; i++) 
				{
					row[((System.String) al[i])] = reader[(System.String) al[i]];
				} 
				dt.Rows.Add(row);
			}
			return dt;
		}

	}
}


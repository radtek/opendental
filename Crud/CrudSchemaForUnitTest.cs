﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using OpenDentBusiness;

namespace Crud {
	///<summary>See UnitTests.SchemaT.cs.  This class generates the SchemaCrudTest file.</summary>
	public class CrudSchemaForUnitTest {
		public static string Create() {
			StringBuilder strb=new StringBuilder();
			//This is a stub that is to be replaced with some good code generation:
			strb.Append(@"using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDentBusiness {
	///<summary>Please ignore this class.  It's used only for testing.</summary>
	public class SchemaCrudTest {
		///<summary>Example only</summary>
		public static void AddTableTempcore() {
			string command="""";");
			Type typeClass=typeof(SchemaTable);
			FieldInfo[] fields=typeClass.GetFields();
			FieldInfo priKey=CrudGenHelper.GetPriKey(fields,typeClass.Name);
			List<FieldInfo> fieldsExceptPri=CrudGenHelper.GetFieldsExceptPriKey(fields,priKey);
			List<DbSchemaCol> cols=CrudQueries.GetListColumns(priKey.Name,null,fieldsExceptPri,false);
			strb.Append("\r\n"+CrudSchemaRaw.AddTable("tempcore",cols,3));
			strb.Append(@"
		}

		///<summary>Example only</summary>
		public static void AddColumnEndClob() {
			string command="""";");
			DbSchemaCol col=new DbSchemaCol("ColEndClob",OdDbType.Text,TextSizeMySqlOracle.Medium);
			strb.Append("\r\n"+CrudSchemaRaw.AddColumnEnd("tempcore",col,3));
			strb.Append(@"
		}

		///<summary>Example only</summary>
		public static void AddColumnEndInt() {
			string command="""";");
			col = new DbSchemaCol("ColEndInt",OdDbType.Int);
			strb.Append("\r\n"+CrudSchemaRaw.AddColumnEnd("tempcore",col,3));
			strb.Append(@"
		}

		///<summary>Example only</summary>
		public static void AddIndex() {
			string command="""";");
			strb.Append("\r\n"+CrudSchemaRaw.AddIndex("tempcore","tempCoreNum",3));
			strb.Append(@"
		}

		//AddColumnEndTimeStamp
		//AddColumnAfter
		//DropColumn
		//DropColumnTimeStamp
		//DropIndex
		//etc.


	}
}");
			return strb.ToString();
		}



	}
}

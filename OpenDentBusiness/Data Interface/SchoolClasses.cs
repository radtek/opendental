using System;
using System.Collections;
using System.Data;
using System.Reflection;

namespace OpenDentBusiness{
	///<summary></summary>
	public class SchoolClasses {
		///<summary>A list of all classes, ordered by year and descript.</summary>
		private static SchoolClass[] list;

		public static SchoolClass[] List {
			get {
				if(list==null) {
					RefreshCache();
				}
				return list;
			}
			set {
				list=value;
			}
		}

		public static DataTable RefreshCache() {
			string command=
				"SELECT * FROM schoolclass "
				+"ORDER BY GradYear,Descript";
			DataTable table=Cache.GetTableRemotelyIfNeeded(MethodBase.GetCurrentMethod(),command);
			table.TableName="SchoolClass";
			FillCache(table);
			return table;
		}

		///<summary></summary>
		public static void FillCache(DataTable table) {
			List=new SchoolClass[table.Rows.Count];
			for(int i=0;i<table.Rows.Count;i++) {
				List[i]=new SchoolClass();
				List[i].SchoolClassNum=PIn.PInt(table.Rows[i][0].ToString());
				List[i].GradYear=PIn.PInt(table.Rows[i][1].ToString());
				List[i].Descript=PIn.PString(table.Rows[i][2].ToString());
			}
		}


		///<summary></summary>
		private static void Update(SchoolClass sc){
			string command= "UPDATE schoolclass SET " 
				+"SchoolClassNum = '" +POut.PInt   (sc.SchoolClassNum)+"'"
				+",GradYear = '"      +POut.PInt   (sc.GradYear)+"'"
				+",Descript = '"      +POut.PString(sc.Descript)+"'"
				+" WHERE SchoolClassNum = '"+POut.PInt(sc.SchoolClassNum)+"'";
 			Db.NonQ(command);
		}

		///<summary></summary>
		private static void Insert(SchoolClass sc){
			if(PrefC.RandomKeys){
				sc.SchoolClassNum=MiscData.GetKey("schoolclass","SchoolClassNum");
			}
			string command= "INSERT INTO schoolclass (";
			if(PrefC.RandomKeys){
				command+="SchoolClassNum,";
			}
			command+="GradYear,Descript) VALUES(";
			if(PrefC.RandomKeys){
				command+="'"+POut.PInt(sc.SchoolClassNum)+"', ";
			}
			command+=
				 "'"+POut.PInt   (sc.GradYear)+"', "
				+"'"+POut.PString(sc.Descript)+"')";
 			if(PrefC.RandomKeys){
				Db.NonQ(command);
			}
			else{
 				sc.SchoolClassNum=Db.NonQ(command,true);
			}
		}

		///<summary></summary>
		public static void InsertOrUpdate(SchoolClass sc, bool isNew){
			//if(IsRepeating && DateTask.Year>1880){
			//	throw new Exception(Lan.g(this,"Task cannot be tagged repeating and also have a date."));
			//}
			if(isNew){
				Insert(sc);
			}
			else{
				Update(sc);
			}
		}

		///<summary>Surround by a try/catch in case there are dependencies.</summary>
		public static void Delete(int classNum){
			//check for attached providers
			string  command="SELECT COUNT(*) FROM provider WHERE SchoolClassNum = '"
				+POut.PInt(classNum)+"'";
			DataTable table=Db.GetTable(command);
			if(PIn.PString(table.Rows[0][0].ToString())!="0"){
				throw new Exception(Lan.g("SchoolClasses","Class already in use by providers."));
			}
			//check for attached reqneededs.
			command="SELECT COUNT(*) FROM reqneeded WHERE SchoolClassNum = '"
				+POut.PInt(classNum)+"'";
			table=Db.GetTable(command);
			if(PIn.PString(table.Rows[0][0].ToString())!="0") {
				throw new Exception(Lan.g("SchoolClasses","Class already in use by 'requirements needed' table."));
			}
			command= "DELETE from schoolclass WHERE SchoolClassNum = '"
				+POut.PInt(classNum)+"'";
 			Db.NonQ(command);
		}

		public static string GetDescript(int SchoolClassNum){
			for(int i=0;i<List.Length;i++){
				if(List[i].SchoolClassNum==SchoolClassNum){
					return GetDescript(List[i]);
				}
			}
			return "";
		}

		public static string GetDescript(SchoolClass schoolClass) {
			return schoolClass.GradYear+"-"+schoolClass.Descript;
		}


	
	}

	

	


}





















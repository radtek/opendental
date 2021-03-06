//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class SchoolCourseCrud {
		///<summary>Gets one SchoolCourse object from the database using the primary key.  Returns null if not found.</summary>
		public static SchoolCourse SelectOne(long schoolCourseNum){
			string command="SELECT * FROM schoolcourse "
				+"WHERE SchoolCourseNum = "+POut.Long(schoolCourseNum);
			List<SchoolCourse> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one SchoolCourse object from the database using a query.</summary>
		public static SchoolCourse SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SchoolCourse> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of SchoolCourse objects from the database using a query.</summary>
		public static List<SchoolCourse> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SchoolCourse> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<SchoolCourse> TableToList(DataTable table){
			List<SchoolCourse> retVal=new List<SchoolCourse>();
			SchoolCourse schoolCourse;
			for(int i=0;i<table.Rows.Count;i++) {
				schoolCourse=new SchoolCourse();
				schoolCourse.SchoolCourseNum= PIn.Long  (table.Rows[i]["SchoolCourseNum"].ToString());
				schoolCourse.CourseID       = PIn.String(table.Rows[i]["CourseID"].ToString());
				schoolCourse.Descript       = PIn.String(table.Rows[i]["Descript"].ToString());
				retVal.Add(schoolCourse);
			}
			return retVal;
		}

		///<summary>Inserts one SchoolCourse into the database.  Returns the new priKey.</summary>
		public static long Insert(SchoolCourse schoolCourse){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				schoolCourse.SchoolCourseNum=DbHelper.GetNextOracleKey("schoolcourse","SchoolCourseNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(schoolCourse,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							schoolCourse.SchoolCourseNum++;
							loopcount++;
						}
						else{
							throw ex;
						}
					}
				}
				throw new ApplicationException("Insert failed.  Could not generate primary key.");
			}
			else {
				return Insert(schoolCourse,false);
			}
		}

		///<summary>Inserts one SchoolCourse into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(SchoolCourse schoolCourse,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				schoolCourse.SchoolCourseNum=ReplicationServers.GetKey("schoolcourse","SchoolCourseNum");
			}
			string command="INSERT INTO schoolcourse (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SchoolCourseNum,";
			}
			command+="CourseID,Descript) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(schoolCourse.SchoolCourseNum)+",";
			}
			command+=
				 "'"+POut.String(schoolCourse.CourseID)+"',"
				+"'"+POut.String(schoolCourse.Descript)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				schoolCourse.SchoolCourseNum=Db.NonQ(command,true);
			}
			return schoolCourse.SchoolCourseNum;
		}

		///<summary>Updates one SchoolCourse in the database.</summary>
		public static void Update(SchoolCourse schoolCourse){
			string command="UPDATE schoolcourse SET "
				+"CourseID       = '"+POut.String(schoolCourse.CourseID)+"', "
				+"Descript       = '"+POut.String(schoolCourse.Descript)+"' "
				+"WHERE SchoolCourseNum = "+POut.Long(schoolCourse.SchoolCourseNum);
			Db.NonQ(command);
		}

		///<summary>Updates one SchoolCourse in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		public static void Update(SchoolCourse schoolCourse,SchoolCourse oldSchoolCourse){
			string command="";
			if(schoolCourse.CourseID != oldSchoolCourse.CourseID) {
				if(command!=""){ command+=",";}
				command+="CourseID = '"+POut.String(schoolCourse.CourseID)+"'";
			}
			if(schoolCourse.Descript != oldSchoolCourse.Descript) {
				if(command!=""){ command+=",";}
				command+="Descript = '"+POut.String(schoolCourse.Descript)+"'";
			}
			if(command==""){
				return;
			}
			command="UPDATE schoolcourse SET "+command
				+" WHERE SchoolCourseNum = "+POut.Long(schoolCourse.SchoolCourseNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one SchoolCourse from the database.</summary>
		public static void Delete(long schoolCourseNum){
			string command="DELETE FROM schoolcourse "
				+"WHERE SchoolCourseNum = "+POut.Long(schoolCourseNum);
			Db.NonQ(command);
		}

	}
}
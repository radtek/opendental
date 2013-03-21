//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class TimeCardRuleCrud {
		///<summary>Gets one TimeCardRule object from the database using the primary key.  Returns null if not found.</summary>
		public static TimeCardRule SelectOne(long timeCardRuleNum){
			string command="SELECT * FROM timecardrule "
				+"WHERE TimeCardRuleNum = "+POut.Long(timeCardRuleNum);
			List<TimeCardRule> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one TimeCardRule object from the database using a query.</summary>
		public static TimeCardRule SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<TimeCardRule> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of TimeCardRule objects from the database using a query.</summary>
		public static List<TimeCardRule> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<TimeCardRule> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<TimeCardRule> TableToList(DataTable table){
			List<TimeCardRule> retVal=new List<TimeCardRule>();
			TimeCardRule timeCardRule;
			for(int i=0;i<table.Rows.Count;i++) {
				timeCardRule=new TimeCardRule();
				timeCardRule.TimeCardRuleNum= PIn.Long  (table.Rows[i]["TimeCardRuleNum"].ToString());
				timeCardRule.EmployeeNum    = PIn.Long  (table.Rows[i]["EmployeeNum"].ToString());
				timeCardRule.OverHoursPerDay= PIn.Time(table.Rows[i]["OverHoursPerDay"].ToString());
				timeCardRule.AfterTimeOfDay = PIn.Time(table.Rows[i]["AfterTimeOfDay"].ToString());
				timeCardRule.BeforeTimeOfDay= PIn.Time(table.Rows[i]["BeforeTimeOfDay"].ToString());
				timeCardRule.AmtDiff        = PIn.Double(table.Rows[i]["AmtDiff"].ToString());
				retVal.Add(timeCardRule);
			}
			return retVal;
		}

		///<summary>Inserts one TimeCardRule into the database.  Returns the new priKey.</summary>
		public static long Insert(TimeCardRule timeCardRule){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				timeCardRule.TimeCardRuleNum=DbHelper.GetNextOracleKey("timecardrule","TimeCardRuleNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(timeCardRule,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							timeCardRule.TimeCardRuleNum++;
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
				return Insert(timeCardRule,false);
			}
		}

		///<summary>Inserts one TimeCardRule into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(TimeCardRule timeCardRule,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				timeCardRule.TimeCardRuleNum=ReplicationServers.GetKey("timecardrule","TimeCardRuleNum");
			}
			string command="INSERT INTO timecardrule (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="TimeCardRuleNum,";
			}
			command+="EmployeeNum,OverHoursPerDay,AfterTimeOfDay,BeforeTimeOfDay,AmtDiff) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(timeCardRule.TimeCardRuleNum)+",";
			}
			command+=
				     POut.Long  (timeCardRule.EmployeeNum)+","
				+    POut.Time  (timeCardRule.OverHoursPerDay)+","
				+    POut.Time  (timeCardRule.AfterTimeOfDay)+","
				+    POut.Time  (timeCardRule.BeforeTimeOfDay)+","
				+"'"+POut.Double(timeCardRule.AmtDiff)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				timeCardRule.TimeCardRuleNum=Db.NonQ(command,true);
			}
			return timeCardRule.TimeCardRuleNum;
		}

		///<summary>Updates one TimeCardRule in the database.</summary>
		public static void Update(TimeCardRule timeCardRule){
			string command="UPDATE timecardrule SET "
				+"EmployeeNum    =  "+POut.Long  (timeCardRule.EmployeeNum)+", "
				+"OverHoursPerDay=  "+POut.Time  (timeCardRule.OverHoursPerDay)+", "
				+"AfterTimeOfDay =  "+POut.Time  (timeCardRule.AfterTimeOfDay)+", "
				+"BeforeTimeOfDay=  "+POut.Time  (timeCardRule.BeforeTimeOfDay)+", "
				+"AmtDiff        = '"+POut.Double(timeCardRule.AmtDiff)+"' "
				+"WHERE TimeCardRuleNum = "+POut.Long(timeCardRule.TimeCardRuleNum);
			Db.NonQ(command);
		}

		///<summary>Updates one TimeCardRule in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		public static void Update(TimeCardRule timeCardRule,TimeCardRule oldTimeCardRule){
			string command="";
			if(timeCardRule.EmployeeNum != oldTimeCardRule.EmployeeNum) {
				if(command!=""){ command+=",";}
				command+="EmployeeNum = "+POut.Long(timeCardRule.EmployeeNum)+"";
			}
			if(timeCardRule.OverHoursPerDay != oldTimeCardRule.OverHoursPerDay) {
				if(command!=""){ command+=",";}
				command+="OverHoursPerDay = "+POut.Time  (timeCardRule.OverHoursPerDay)+"";
			}
			if(timeCardRule.AfterTimeOfDay != oldTimeCardRule.AfterTimeOfDay) {
				if(command!=""){ command+=",";}
				command+="AfterTimeOfDay = "+POut.Time  (timeCardRule.AfterTimeOfDay)+"";
			}
			if(timeCardRule.BeforeTimeOfDay != oldTimeCardRule.BeforeTimeOfDay) {
				if(command!=""){ command+=",";}
				command+="BeforeTimeOfDay = "+POut.Time  (timeCardRule.BeforeTimeOfDay)+"";
			}
			if(timeCardRule.AmtDiff != oldTimeCardRule.AmtDiff) {
				if(command!=""){ command+=",";}
				command+="AmtDiff = '"+POut.Double(timeCardRule.AmtDiff)+"'";
			}
			if(command==""){
				return;
			}
			command="UPDATE timecardrule SET "+command
				+" WHERE TimeCardRuleNum = "+POut.Long(timeCardRule.TimeCardRuleNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one TimeCardRule from the database.</summary>
		public static void Delete(long timeCardRuleNum){
			string command="DELETE FROM timecardrule "
				+"WHERE TimeCardRuleNum = "+POut.Long(timeCardRuleNum);
			Db.NonQ(command);
		}

	}
}
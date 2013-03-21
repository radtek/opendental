//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class PhoneEmpDefaultCrud {
		///<summary>Gets one PhoneEmpDefault object from the database using the primary key.  Returns null if not found.</summary>
		public static PhoneEmpDefault SelectOne(long employeeNum){
			string command="SELECT * FROM phoneempdefault "
				+"WHERE EmployeeNum = "+POut.Long(employeeNum);
			List<PhoneEmpDefault> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one PhoneEmpDefault object from the database using a query.</summary>
		public static PhoneEmpDefault SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<PhoneEmpDefault> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of PhoneEmpDefault objects from the database using a query.</summary>
		public static List<PhoneEmpDefault> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<PhoneEmpDefault> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<PhoneEmpDefault> TableToList(DataTable table){
			List<PhoneEmpDefault> retVal=new List<PhoneEmpDefault>();
			PhoneEmpDefault phoneEmpDefault;
			for(int i=0;i<table.Rows.Count;i++) {
				phoneEmpDefault=new PhoneEmpDefault();
				phoneEmpDefault.EmployeeNum     = PIn.Long  (table.Rows[i]["EmployeeNum"].ToString());
				phoneEmpDefault.NoGraph         = PIn.Bool  (table.Rows[i]["NoGraph"].ToString());
				phoneEmpDefault.NoColor         = PIn.Bool  (table.Rows[i]["NoColor"].ToString());
				phoneEmpDefault.RingGroups      = (AsteriskRingGroups)PIn.Int(table.Rows[i]["RingGroups"].ToString());
				phoneEmpDefault.EmpName         = PIn.String(table.Rows[i]["EmpName"].ToString());
				phoneEmpDefault.PhoneExt        = PIn.Int   (table.Rows[i]["PhoneExt"].ToString());
				phoneEmpDefault.StatusOverride  = (PhoneEmpStatusOverride)PIn.Int(table.Rows[i]["StatusOverride"].ToString());
				phoneEmpDefault.Notes           = PIn.String(table.Rows[i]["Notes"].ToString());
				phoneEmpDefault.ComputerName    = PIn.String(table.Rows[i]["ComputerName"].ToString());
				phoneEmpDefault.IsPrivateScreen = PIn.Bool  (table.Rows[i]["IsPrivateScreen"].ToString());
				phoneEmpDefault.IsTriageOperator= PIn.Bool  (table.Rows[i]["IsTriageOperator"].ToString());
				retVal.Add(phoneEmpDefault);
			}
			return retVal;
		}

		///<summary>Inserts one PhoneEmpDefault into the database.  Returns the new priKey.</summary>
		public static long Insert(PhoneEmpDefault phoneEmpDefault){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				phoneEmpDefault.EmployeeNum=DbHelper.GetNextOracleKey("phoneempdefault","EmployeeNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(phoneEmpDefault,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							phoneEmpDefault.EmployeeNum++;
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
				return Insert(phoneEmpDefault,false);
			}
		}

		///<summary>Inserts one PhoneEmpDefault into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(PhoneEmpDefault phoneEmpDefault,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				phoneEmpDefault.EmployeeNum=ReplicationServers.GetKey("phoneempdefault","EmployeeNum");
			}
			string command="INSERT INTO phoneempdefault (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EmployeeNum,";
			}
			command+="NoGraph,NoColor,RingGroups,EmpName,PhoneExt,StatusOverride,Notes,ComputerName,IsPrivateScreen,IsTriageOperator) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(phoneEmpDefault.EmployeeNum)+",";
			}
			command+=
				     POut.Bool  (phoneEmpDefault.NoGraph)+","
				+    POut.Bool  (phoneEmpDefault.NoColor)+","
				+    POut.Int   ((int)phoneEmpDefault.RingGroups)+","
				+"'"+POut.String(phoneEmpDefault.EmpName)+"',"
				+    POut.Int   (phoneEmpDefault.PhoneExt)+","
				+    POut.Int   ((int)phoneEmpDefault.StatusOverride)+","
				+"'"+POut.String(phoneEmpDefault.Notes)+"',"
				+"'"+POut.String(phoneEmpDefault.ComputerName)+"',"
				+    POut.Bool  (phoneEmpDefault.IsPrivateScreen)+","
				+    POut.Bool  (phoneEmpDefault.IsTriageOperator)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				phoneEmpDefault.EmployeeNum=Db.NonQ(command,true);
			}
			return phoneEmpDefault.EmployeeNum;
		}

		///<summary>Updates one PhoneEmpDefault in the database.</summary>
		public static void Update(PhoneEmpDefault phoneEmpDefault){
			string command="UPDATE phoneempdefault SET "
				+"NoGraph         =  "+POut.Bool  (phoneEmpDefault.NoGraph)+", "
				+"NoColor         =  "+POut.Bool  (phoneEmpDefault.NoColor)+", "
				+"RingGroups      =  "+POut.Int   ((int)phoneEmpDefault.RingGroups)+", "
				+"EmpName         = '"+POut.String(phoneEmpDefault.EmpName)+"', "
				+"PhoneExt        =  "+POut.Int   (phoneEmpDefault.PhoneExt)+", "
				+"StatusOverride  =  "+POut.Int   ((int)phoneEmpDefault.StatusOverride)+", "
				+"Notes           = '"+POut.String(phoneEmpDefault.Notes)+"', "
				+"ComputerName    = '"+POut.String(phoneEmpDefault.ComputerName)+"', "
				+"IsPrivateScreen =  "+POut.Bool  (phoneEmpDefault.IsPrivateScreen)+", "
				+"IsTriageOperator=  "+POut.Bool  (phoneEmpDefault.IsTriageOperator)+" "
				+"WHERE EmployeeNum = "+POut.Long(phoneEmpDefault.EmployeeNum);
			Db.NonQ(command);
		}

		///<summary>Updates one PhoneEmpDefault in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		public static void Update(PhoneEmpDefault phoneEmpDefault,PhoneEmpDefault oldPhoneEmpDefault){
			string command="";
			if(phoneEmpDefault.NoGraph != oldPhoneEmpDefault.NoGraph) {
				if(command!=""){ command+=",";}
				command+="NoGraph = "+POut.Bool(phoneEmpDefault.NoGraph)+"";
			}
			if(phoneEmpDefault.NoColor != oldPhoneEmpDefault.NoColor) {
				if(command!=""){ command+=",";}
				command+="NoColor = "+POut.Bool(phoneEmpDefault.NoColor)+"";
			}
			if(phoneEmpDefault.RingGroups != oldPhoneEmpDefault.RingGroups) {
				if(command!=""){ command+=",";}
				command+="RingGroups = "+POut.Int   ((int)phoneEmpDefault.RingGroups)+"";
			}
			if(phoneEmpDefault.EmpName != oldPhoneEmpDefault.EmpName) {
				if(command!=""){ command+=",";}
				command+="EmpName = '"+POut.String(phoneEmpDefault.EmpName)+"'";
			}
			if(phoneEmpDefault.PhoneExt != oldPhoneEmpDefault.PhoneExt) {
				if(command!=""){ command+=",";}
				command+="PhoneExt = "+POut.Int(phoneEmpDefault.PhoneExt)+"";
			}
			if(phoneEmpDefault.StatusOverride != oldPhoneEmpDefault.StatusOverride) {
				if(command!=""){ command+=",";}
				command+="StatusOverride = "+POut.Int   ((int)phoneEmpDefault.StatusOverride)+"";
			}
			if(phoneEmpDefault.Notes != oldPhoneEmpDefault.Notes) {
				if(command!=""){ command+=",";}
				command+="Notes = '"+POut.String(phoneEmpDefault.Notes)+"'";
			}
			if(phoneEmpDefault.ComputerName != oldPhoneEmpDefault.ComputerName) {
				if(command!=""){ command+=",";}
				command+="ComputerName = '"+POut.String(phoneEmpDefault.ComputerName)+"'";
			}
			if(phoneEmpDefault.IsPrivateScreen != oldPhoneEmpDefault.IsPrivateScreen) {
				if(command!=""){ command+=",";}
				command+="IsPrivateScreen = "+POut.Bool(phoneEmpDefault.IsPrivateScreen)+"";
			}
			if(phoneEmpDefault.IsTriageOperator != oldPhoneEmpDefault.IsTriageOperator) {
				if(command!=""){ command+=",";}
				command+="IsTriageOperator = "+POut.Bool(phoneEmpDefault.IsTriageOperator)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE phoneempdefault SET "+command
				+" WHERE EmployeeNum = "+POut.Long(phoneEmpDefault.EmployeeNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one PhoneEmpDefault from the database.</summary>
		public static void Delete(long employeeNum){
			string command="DELETE FROM phoneempdefault "
				+"WHERE EmployeeNum = "+POut.Long(employeeNum);
			Db.NonQ(command);
		}

	}
}
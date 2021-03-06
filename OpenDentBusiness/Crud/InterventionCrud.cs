//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class InterventionCrud {
		///<summary>Gets one Intervention object from the database using the primary key.  Returns null if not found.</summary>
		public static Intervention SelectOne(long interventionNum){
			string command="SELECT * FROM intervention "
				+"WHERE InterventionNum = "+POut.Long(interventionNum);
			List<Intervention> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Intervention object from the database using a query.</summary>
		public static Intervention SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Intervention> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Intervention objects from the database using a query.</summary>
		public static List<Intervention> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Intervention> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Intervention> TableToList(DataTable table){
			List<Intervention> retVal=new List<Intervention>();
			Intervention intervention;
			for(int i=0;i<table.Rows.Count;i++) {
				intervention=new Intervention();
				intervention.InterventionNum= PIn.Long  (table.Rows[i]["InterventionNum"].ToString());
				intervention.PatNum         = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				intervention.ProvNum        = PIn.Long  (table.Rows[i]["ProvNum"].ToString());
				intervention.CodeValue      = PIn.String(table.Rows[i]["CodeValue"].ToString());
				intervention.CodeSystem     = PIn.String(table.Rows[i]["CodeSystem"].ToString());
				intervention.Note           = PIn.String(table.Rows[i]["Note"].ToString());
				intervention.DateEntry      = PIn.Date  (table.Rows[i]["DateEntry"].ToString());
				intervention.CodeSet        = (InterventionCodeSet)PIn.Int(table.Rows[i]["CodeSet"].ToString());
				retVal.Add(intervention);
			}
			return retVal;
		}

		///<summary>Inserts one Intervention into the database.  Returns the new priKey.</summary>
		public static long Insert(Intervention intervention){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				intervention.InterventionNum=DbHelper.GetNextOracleKey("intervention","InterventionNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(intervention,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							intervention.InterventionNum++;
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
				return Insert(intervention,false);
			}
		}

		///<summary>Inserts one Intervention into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Intervention intervention,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				intervention.InterventionNum=ReplicationServers.GetKey("intervention","InterventionNum");
			}
			string command="INSERT INTO intervention (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="InterventionNum,";
			}
			command+="PatNum,ProvNum,CodeValue,CodeSystem,Note,DateEntry,CodeSet) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(intervention.InterventionNum)+",";
			}
			command+=
				     POut.Long  (intervention.PatNum)+","
				+    POut.Long  (intervention.ProvNum)+","
				+"'"+POut.String(intervention.CodeValue)+"',"
				+"'"+POut.String(intervention.CodeSystem)+"',"
				+"'"+POut.String(intervention.Note)+"',"
				+    POut.Date  (intervention.DateEntry)+","
				+    POut.Int   ((int)intervention.CodeSet)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				intervention.InterventionNum=Db.NonQ(command,true);
			}
			return intervention.InterventionNum;
		}

		///<summary>Updates one Intervention in the database.</summary>
		public static void Update(Intervention intervention){
			string command="UPDATE intervention SET "
				+"PatNum         =  "+POut.Long  (intervention.PatNum)+", "
				+"ProvNum        =  "+POut.Long  (intervention.ProvNum)+", "
				+"CodeValue      = '"+POut.String(intervention.CodeValue)+"', "
				+"CodeSystem     = '"+POut.String(intervention.CodeSystem)+"', "
				+"Note           = '"+POut.String(intervention.Note)+"', "
				+"DateEntry      =  "+POut.Date  (intervention.DateEntry)+", "
				+"CodeSet        =  "+POut.Int   ((int)intervention.CodeSet)+" "
				+"WHERE InterventionNum = "+POut.Long(intervention.InterventionNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Intervention in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		public static void Update(Intervention intervention,Intervention oldIntervention){
			string command="";
			if(intervention.PatNum != oldIntervention.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(intervention.PatNum)+"";
			}
			if(intervention.ProvNum != oldIntervention.ProvNum) {
				if(command!=""){ command+=",";}
				command+="ProvNum = "+POut.Long(intervention.ProvNum)+"";
			}
			if(intervention.CodeValue != oldIntervention.CodeValue) {
				if(command!=""){ command+=",";}
				command+="CodeValue = '"+POut.String(intervention.CodeValue)+"'";
			}
			if(intervention.CodeSystem != oldIntervention.CodeSystem) {
				if(command!=""){ command+=",";}
				command+="CodeSystem = '"+POut.String(intervention.CodeSystem)+"'";
			}
			if(intervention.Note != oldIntervention.Note) {
				if(command!=""){ command+=",";}
				command+="Note = '"+POut.String(intervention.Note)+"'";
			}
			if(intervention.DateEntry != oldIntervention.DateEntry) {
				if(command!=""){ command+=",";}
				command+="DateEntry = "+POut.Date(intervention.DateEntry)+"";
			}
			if(intervention.CodeSet != oldIntervention.CodeSet) {
				if(command!=""){ command+=",";}
				command+="CodeSet = "+POut.Int   ((int)intervention.CodeSet)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE intervention SET "+command
				+" WHERE InterventionNum = "+POut.Long(intervention.InterventionNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one Intervention from the database.</summary>
		public static void Delete(long interventionNum){
			string command="DELETE FROM intervention "
				+"WHERE InterventionNum = "+POut.Long(interventionNum);
			Db.NonQ(command);
		}

	}
}
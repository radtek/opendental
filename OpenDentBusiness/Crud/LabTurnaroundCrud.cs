//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class LabTurnaroundCrud {
		///<summary>Gets one LabTurnaround object from the database using the primary key.  Returns null if not found.</summary>
		public static LabTurnaround SelectOne(long labTurnaroundNum){
			string command="SELECT * FROM labturnaround "
				+"WHERE LabTurnaroundNum = "+POut.Long(labTurnaroundNum);
			List<LabTurnaround> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one LabTurnaround object from the database using a query.</summary>
		public static LabTurnaround SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<LabTurnaround> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of LabTurnaround objects from the database using a query.</summary>
		public static List<LabTurnaround> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<LabTurnaround> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<LabTurnaround> TableToList(DataTable table){
			List<LabTurnaround> retVal=new List<LabTurnaround>();
			LabTurnaround labTurnaround;
			for(int i=0;i<table.Rows.Count;i++) {
				labTurnaround=new LabTurnaround();
				labTurnaround.LabTurnaroundNum= PIn.Long  (table.Rows[i]["LabTurnaroundNum"].ToString());
				labTurnaround.LaboratoryNum   = PIn.Long  (table.Rows[i]["LaboratoryNum"].ToString());
				labTurnaround.Description     = PIn.String(table.Rows[i]["Description"].ToString());
				labTurnaround.DaysPublished   = PIn.Int   (table.Rows[i]["DaysPublished"].ToString());
				labTurnaround.DaysActual      = PIn.Int   (table.Rows[i]["DaysActual"].ToString());
				retVal.Add(labTurnaround);
			}
			return retVal;
		}

		///<summary>Inserts one LabTurnaround into the database.  Returns the new priKey.</summary>
		public static long Insert(LabTurnaround labTurnaround){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				labTurnaround.LabTurnaroundNum=DbHelper.GetNextOracleKey("labturnaround","LabTurnaroundNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(labTurnaround,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							labTurnaround.LabTurnaroundNum++;
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
				return Insert(labTurnaround,false);
			}
		}

		///<summary>Inserts one LabTurnaround into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(LabTurnaround labTurnaround,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				labTurnaround.LabTurnaroundNum=ReplicationServers.GetKey("labturnaround","LabTurnaroundNum");
			}
			string command="INSERT INTO labturnaround (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="LabTurnaroundNum,";
			}
			command+="LaboratoryNum,Description,DaysPublished,DaysActual) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(labTurnaround.LabTurnaroundNum)+",";
			}
			command+=
				     POut.Long  (labTurnaround.LaboratoryNum)+","
				+"'"+POut.String(labTurnaround.Description)+"',"
				+    POut.Int   (labTurnaround.DaysPublished)+","
				+    POut.Int   (labTurnaround.DaysActual)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				labTurnaround.LabTurnaroundNum=Db.NonQ(command,true);
			}
			return labTurnaround.LabTurnaroundNum;
		}

		///<summary>Updates one LabTurnaround in the database.</summary>
		public static void Update(LabTurnaround labTurnaround){
			string command="UPDATE labturnaround SET "
				+"LaboratoryNum   =  "+POut.Long  (labTurnaround.LaboratoryNum)+", "
				+"Description     = '"+POut.String(labTurnaround.Description)+"', "
				+"DaysPublished   =  "+POut.Int   (labTurnaround.DaysPublished)+", "
				+"DaysActual      =  "+POut.Int   (labTurnaround.DaysActual)+" "
				+"WHERE LabTurnaroundNum = "+POut.Long(labTurnaround.LabTurnaroundNum);
			Db.NonQ(command);
		}

		///<summary>Updates one LabTurnaround in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		public static void Update(LabTurnaround labTurnaround,LabTurnaround oldLabTurnaround){
			string command="";
			if(labTurnaround.LaboratoryNum != oldLabTurnaround.LaboratoryNum) {
				if(command!=""){ command+=",";}
				command+="LaboratoryNum = "+POut.Long(labTurnaround.LaboratoryNum)+"";
			}
			if(labTurnaround.Description != oldLabTurnaround.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(labTurnaround.Description)+"'";
			}
			if(labTurnaround.DaysPublished != oldLabTurnaround.DaysPublished) {
				if(command!=""){ command+=",";}
				command+="DaysPublished = "+POut.Int(labTurnaround.DaysPublished)+"";
			}
			if(labTurnaround.DaysActual != oldLabTurnaround.DaysActual) {
				if(command!=""){ command+=",";}
				command+="DaysActual = "+POut.Int(labTurnaround.DaysActual)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE labturnaround SET "+command
				+" WHERE LabTurnaroundNum = "+POut.Long(labTurnaround.LabTurnaroundNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one LabTurnaround from the database.</summary>
		public static void Delete(long labTurnaroundNum){
			string command="DELETE FROM labturnaround "
				+"WHERE LabTurnaroundNum = "+POut.Long(labTurnaroundNum);
			Db.NonQ(command);
		}

	}
}
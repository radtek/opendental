//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class EhrQuarterlyKeyCrud {
		///<summary>Gets one EhrQuarterlyKey object from the database using the primary key.  Returns null if not found.</summary>
		public static EhrQuarterlyKey SelectOne(long ehrQuarterlyKeyNum){
			string command="SELECT * FROM ehrquarterlykey "
				+"WHERE EhrQuarterlyKeyNum = "+POut.Long(ehrQuarterlyKeyNum);
			List<EhrQuarterlyKey> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EhrQuarterlyKey object from the database using a query.</summary>
		public static EhrQuarterlyKey SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrQuarterlyKey> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EhrQuarterlyKey objects from the database using a query.</summary>
		public static List<EhrQuarterlyKey> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EhrQuarterlyKey> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EhrQuarterlyKey> TableToList(DataTable table){
			List<EhrQuarterlyKey> retVal=new List<EhrQuarterlyKey>();
			EhrQuarterlyKey ehrQuarterlyKey;
			for(int i=0;i<table.Rows.Count;i++) {
				ehrQuarterlyKey=new EhrQuarterlyKey();
				ehrQuarterlyKey.EhrQuarterlyKeyNum= PIn.Long  (table.Rows[i]["EhrQuarterlyKeyNum"].ToString());
				ehrQuarterlyKey.YearValue         = PIn.Int   (table.Rows[i]["YearValue"].ToString());
				ehrQuarterlyKey.QuarterValue      = PIn.Int   (table.Rows[i]["QuarterValue"].ToString());
				ehrQuarterlyKey.PracticeName      = PIn.String(table.Rows[i]["PracticeName"].ToString());
				ehrQuarterlyKey.KeyValue          = PIn.String(table.Rows[i]["KeyValue"].ToString());
				ehrQuarterlyKey.PatNum            = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				ehrQuarterlyKey.Notes             = PIn.String(table.Rows[i]["Notes"].ToString());
				retVal.Add(ehrQuarterlyKey);
			}
			return retVal;
		}

		///<summary>Inserts one EhrQuarterlyKey into the database.  Returns the new priKey.</summary>
		public static long Insert(EhrQuarterlyKey ehrQuarterlyKey){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				ehrQuarterlyKey.EhrQuarterlyKeyNum=DbHelper.GetNextOracleKey("ehrquarterlykey","EhrQuarterlyKeyNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(ehrQuarterlyKey,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							ehrQuarterlyKey.EhrQuarterlyKeyNum++;
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
				return Insert(ehrQuarterlyKey,false);
			}
		}

		///<summary>Inserts one EhrQuarterlyKey into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EhrQuarterlyKey ehrQuarterlyKey,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				ehrQuarterlyKey.EhrQuarterlyKeyNum=ReplicationServers.GetKey("ehrquarterlykey","EhrQuarterlyKeyNum");
			}
			string command="INSERT INTO ehrquarterlykey (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EhrQuarterlyKeyNum,";
			}
			command+="YearValue,QuarterValue,PracticeName,KeyValue,PatNum,Notes) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(ehrQuarterlyKey.EhrQuarterlyKeyNum)+",";
			}
			command+=
				     POut.Int   (ehrQuarterlyKey.YearValue)+","
				+    POut.Int   (ehrQuarterlyKey.QuarterValue)+","
				+"'"+POut.String(ehrQuarterlyKey.PracticeName)+"',"
				+"'"+POut.String(ehrQuarterlyKey.KeyValue)+"',"
				+    POut.Long  (ehrQuarterlyKey.PatNum)+","
				+"'"+POut.String(ehrQuarterlyKey.Notes)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				ehrQuarterlyKey.EhrQuarterlyKeyNum=Db.NonQ(command,true);
			}
			return ehrQuarterlyKey.EhrQuarterlyKeyNum;
		}

		///<summary>Updates one EhrQuarterlyKey in the database.</summary>
		public static void Update(EhrQuarterlyKey ehrQuarterlyKey){
			string command="UPDATE ehrquarterlykey SET "
				+"YearValue         =  "+POut.Int   (ehrQuarterlyKey.YearValue)+", "
				+"QuarterValue      =  "+POut.Int   (ehrQuarterlyKey.QuarterValue)+", "
				+"PracticeName      = '"+POut.String(ehrQuarterlyKey.PracticeName)+"', "
				+"KeyValue          = '"+POut.String(ehrQuarterlyKey.KeyValue)+"', "
				+"PatNum            =  "+POut.Long  (ehrQuarterlyKey.PatNum)+", "
				+"Notes             = '"+POut.String(ehrQuarterlyKey.Notes)+"' "
				+"WHERE EhrQuarterlyKeyNum = "+POut.Long(ehrQuarterlyKey.EhrQuarterlyKeyNum);
			Db.NonQ(command);
		}

		///<summary>Updates one EhrQuarterlyKey in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		public static void Update(EhrQuarterlyKey ehrQuarterlyKey,EhrQuarterlyKey oldEhrQuarterlyKey){
			string command="";
			if(ehrQuarterlyKey.YearValue != oldEhrQuarterlyKey.YearValue) {
				if(command!=""){ command+=",";}
				command+="YearValue = "+POut.Int(ehrQuarterlyKey.YearValue)+"";
			}
			if(ehrQuarterlyKey.QuarterValue != oldEhrQuarterlyKey.QuarterValue) {
				if(command!=""){ command+=",";}
				command+="QuarterValue = "+POut.Int(ehrQuarterlyKey.QuarterValue)+"";
			}
			if(ehrQuarterlyKey.PracticeName != oldEhrQuarterlyKey.PracticeName) {
				if(command!=""){ command+=",";}
				command+="PracticeName = '"+POut.String(ehrQuarterlyKey.PracticeName)+"'";
			}
			if(ehrQuarterlyKey.KeyValue != oldEhrQuarterlyKey.KeyValue) {
				if(command!=""){ command+=",";}
				command+="KeyValue = '"+POut.String(ehrQuarterlyKey.KeyValue)+"'";
			}
			if(ehrQuarterlyKey.PatNum != oldEhrQuarterlyKey.PatNum) {
				if(command!=""){ command+=",";}
				command+="PatNum = "+POut.Long(ehrQuarterlyKey.PatNum)+"";
			}
			if(ehrQuarterlyKey.Notes != oldEhrQuarterlyKey.Notes) {
				if(command!=""){ command+=",";}
				command+="Notes = '"+POut.String(ehrQuarterlyKey.Notes)+"'";
			}
			if(command==""){
				return;
			}
			command="UPDATE ehrquarterlykey SET "+command
				+" WHERE EhrQuarterlyKeyNum = "+POut.Long(ehrQuarterlyKey.EhrQuarterlyKeyNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one EhrQuarterlyKey from the database.</summary>
		public static void Delete(long ehrQuarterlyKeyNum){
			string command="DELETE FROM ehrquarterlykey "
				+"WHERE EhrQuarterlyKeyNum = "+POut.Long(ehrQuarterlyKeyNum);
			Db.NonQ(command);
		}

	}
}
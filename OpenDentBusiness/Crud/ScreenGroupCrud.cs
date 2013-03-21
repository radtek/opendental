//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ScreenGroupCrud {
		///<summary>Gets one ScreenGroup object from the database using the primary key.  Returns null if not found.</summary>
		public static ScreenGroup SelectOne(long screenGroupNum){
			string command="SELECT * FROM screengroup "
				+"WHERE ScreenGroupNum = "+POut.Long(screenGroupNum);
			List<ScreenGroup> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ScreenGroup object from the database using a query.</summary>
		public static ScreenGroup SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ScreenGroup> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ScreenGroup objects from the database using a query.</summary>
		public static List<ScreenGroup> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ScreenGroup> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ScreenGroup> TableToList(DataTable table){
			List<ScreenGroup> retVal=new List<ScreenGroup>();
			ScreenGroup screenGroup;
			for(int i=0;i<table.Rows.Count;i++) {
				screenGroup=new ScreenGroup();
				screenGroup.ScreenGroupNum= PIn.Long  (table.Rows[i]["ScreenGroupNum"].ToString());
				screenGroup.Description   = PIn.String(table.Rows[i]["Description"].ToString());
				screenGroup.SGDate        = PIn.Date  (table.Rows[i]["SGDate"].ToString());
				retVal.Add(screenGroup);
			}
			return retVal;
		}

		///<summary>Inserts one ScreenGroup into the database.  Returns the new priKey.</summary>
		public static long Insert(ScreenGroup screenGroup){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				screenGroup.ScreenGroupNum=DbHelper.GetNextOracleKey("screengroup","ScreenGroupNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(screenGroup,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							screenGroup.ScreenGroupNum++;
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
				return Insert(screenGroup,false);
			}
		}

		///<summary>Inserts one ScreenGroup into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ScreenGroup screenGroup,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				screenGroup.ScreenGroupNum=ReplicationServers.GetKey("screengroup","ScreenGroupNum");
			}
			string command="INSERT INTO screengroup (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ScreenGroupNum,";
			}
			command+="Description,SGDate) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(screenGroup.ScreenGroupNum)+",";
			}
			command+=
				 "'"+POut.String(screenGroup.Description)+"',"
				+    POut.Date  (screenGroup.SGDate)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				screenGroup.ScreenGroupNum=Db.NonQ(command,true);
			}
			return screenGroup.ScreenGroupNum;
		}

		///<summary>Updates one ScreenGroup in the database.</summary>
		public static void Update(ScreenGroup screenGroup){
			string command="UPDATE screengroup SET "
				+"Description   = '"+POut.String(screenGroup.Description)+"', "
				+"SGDate        =  "+POut.Date  (screenGroup.SGDate)+" "
				+"WHERE ScreenGroupNum = "+POut.Long(screenGroup.ScreenGroupNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ScreenGroup in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		public static void Update(ScreenGroup screenGroup,ScreenGroup oldScreenGroup){
			string command="";
			if(screenGroup.Description != oldScreenGroup.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(screenGroup.Description)+"'";
			}
			if(screenGroup.SGDate != oldScreenGroup.SGDate) {
				if(command!=""){ command+=",";}
				command+="SGDate = "+POut.Date(screenGroup.SGDate)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE screengroup SET "+command
				+" WHERE ScreenGroupNum = "+POut.Long(screenGroup.ScreenGroupNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one ScreenGroup from the database.</summary>
		public static void Delete(long screenGroupNum){
			string command="DELETE FROM screengroup "
				+"WHERE ScreenGroupNum = "+POut.Long(screenGroupNum);
			Db.NonQ(command);
		}

	}
}
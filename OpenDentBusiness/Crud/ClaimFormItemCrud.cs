//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ClaimFormItemCrud {
		///<summary>Gets one ClaimFormItem object from the database using the primary key.  Returns null if not found.</summary>
		public static ClaimFormItem SelectOne(long claimFormItemNum){
			string command="SELECT * FROM claimformitem "
				+"WHERE ClaimFormItemNum = "+POut.Long(claimFormItemNum);
			List<ClaimFormItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ClaimFormItem object from the database using a query.</summary>
		public static ClaimFormItem SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ClaimFormItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ClaimFormItem objects from the database using a query.</summary>
		public static List<ClaimFormItem> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ClaimFormItem> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ClaimFormItem> TableToList(DataTable table){
			List<ClaimFormItem> retVal=new List<ClaimFormItem>();
			ClaimFormItem claimFormItem;
			for(int i=0;i<table.Rows.Count;i++) {
				claimFormItem=new ClaimFormItem();
				claimFormItem.ClaimFormItemNum= PIn.Long  (table.Rows[i]["ClaimFormItemNum"].ToString());
				claimFormItem.ClaimFormNum    = PIn.Long  (table.Rows[i]["ClaimFormNum"].ToString());
				claimFormItem.ImageFileName   = PIn.String(table.Rows[i]["ImageFileName"].ToString());
				claimFormItem.FieldName       = PIn.String(table.Rows[i]["FieldName"].ToString());
				claimFormItem.FormatString    = PIn.String(table.Rows[i]["FormatString"].ToString());
				claimFormItem.XPos            = PIn.Float (table.Rows[i]["XPos"].ToString());
				claimFormItem.YPos            = PIn.Float (table.Rows[i]["YPos"].ToString());
				claimFormItem.Width           = PIn.Float (table.Rows[i]["Width"].ToString());
				claimFormItem.Height          = PIn.Float (table.Rows[i]["Height"].ToString());
				retVal.Add(claimFormItem);
			}
			return retVal;
		}

		///<summary>Inserts one ClaimFormItem into the database.  Returns the new priKey.</summary>
		public static long Insert(ClaimFormItem claimFormItem){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				claimFormItem.ClaimFormItemNum=DbHelper.GetNextOracleKey("claimformitem","ClaimFormItemNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(claimFormItem,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							claimFormItem.ClaimFormItemNum++;
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
				return Insert(claimFormItem,false);
			}
		}

		///<summary>Inserts one ClaimFormItem into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ClaimFormItem claimFormItem,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				claimFormItem.ClaimFormItemNum=ReplicationServers.GetKey("claimformitem","ClaimFormItemNum");
			}
			string command="INSERT INTO claimformitem (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ClaimFormItemNum,";
			}
			command+="ClaimFormNum,ImageFileName,FieldName,FormatString,XPos,YPos,Width,Height) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(claimFormItem.ClaimFormItemNum)+",";
			}
			command+=
				     POut.Long  (claimFormItem.ClaimFormNum)+","
				+"'"+POut.String(claimFormItem.ImageFileName)+"',"
				+"'"+POut.String(claimFormItem.FieldName)+"',"
				+"'"+POut.String(claimFormItem.FormatString)+"',"
				+    POut.Float (claimFormItem.XPos)+","
				+    POut.Float (claimFormItem.YPos)+","
				+    POut.Float (claimFormItem.Width)+","
				+    POut.Float (claimFormItem.Height)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				claimFormItem.ClaimFormItemNum=Db.NonQ(command,true);
			}
			return claimFormItem.ClaimFormItemNum;
		}

		///<summary>Updates one ClaimFormItem in the database.</summary>
		public static void Update(ClaimFormItem claimFormItem){
			string command="UPDATE claimformitem SET "
				+"ClaimFormNum    =  "+POut.Long  (claimFormItem.ClaimFormNum)+", "
				+"ImageFileName   = '"+POut.String(claimFormItem.ImageFileName)+"', "
				+"FieldName       = '"+POut.String(claimFormItem.FieldName)+"', "
				+"FormatString    = '"+POut.String(claimFormItem.FormatString)+"', "
				+"XPos            =  "+POut.Float (claimFormItem.XPos)+", "
				+"YPos            =  "+POut.Float (claimFormItem.YPos)+", "
				+"Width           =  "+POut.Float (claimFormItem.Width)+", "
				+"Height          =  "+POut.Float (claimFormItem.Height)+" "
				+"WHERE ClaimFormItemNum = "+POut.Long(claimFormItem.ClaimFormItemNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ClaimFormItem in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		public static void Update(ClaimFormItem claimFormItem,ClaimFormItem oldClaimFormItem){
			string command="";
			if(claimFormItem.ClaimFormNum != oldClaimFormItem.ClaimFormNum) {
				if(command!=""){ command+=",";}
				command+="ClaimFormNum = "+POut.Long(claimFormItem.ClaimFormNum)+"";
			}
			if(claimFormItem.ImageFileName != oldClaimFormItem.ImageFileName) {
				if(command!=""){ command+=",";}
				command+="ImageFileName = '"+POut.String(claimFormItem.ImageFileName)+"'";
			}
			if(claimFormItem.FieldName != oldClaimFormItem.FieldName) {
				if(command!=""){ command+=",";}
				command+="FieldName = '"+POut.String(claimFormItem.FieldName)+"'";
			}
			if(claimFormItem.FormatString != oldClaimFormItem.FormatString) {
				if(command!=""){ command+=",";}
				command+="FormatString = '"+POut.String(claimFormItem.FormatString)+"'";
			}
			if(claimFormItem.XPos != oldClaimFormItem.XPos) {
				if(command!=""){ command+=",";}
				command+="XPos = "+POut.Float(claimFormItem.XPos)+"";
			}
			if(claimFormItem.YPos != oldClaimFormItem.YPos) {
				if(command!=""){ command+=",";}
				command+="YPos = "+POut.Float(claimFormItem.YPos)+"";
			}
			if(claimFormItem.Width != oldClaimFormItem.Width) {
				if(command!=""){ command+=",";}
				command+="Width = "+POut.Float(claimFormItem.Width)+"";
			}
			if(claimFormItem.Height != oldClaimFormItem.Height) {
				if(command!=""){ command+=",";}
				command+="Height = "+POut.Float(claimFormItem.Height)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE claimformitem SET "+command
				+" WHERE ClaimFormItemNum = "+POut.Long(claimFormItem.ClaimFormItemNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one ClaimFormItem from the database.</summary>
		public static void Delete(long claimFormItemNum){
			string command="DELETE FROM claimformitem "
				+"WHERE ClaimFormItemNum = "+POut.Long(claimFormItemNum);
			Db.NonQ(command);
		}

	}
}
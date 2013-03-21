//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class EobAttachCrud {
		///<summary>Gets one EobAttach object from the database using the primary key.  Returns null if not found.</summary>
		public static EobAttach SelectOne(long eobAttachNum){
			string command="SELECT * FROM eobattach "
				+"WHERE EobAttachNum = "+POut.Long(eobAttachNum);
			List<EobAttach> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EobAttach object from the database using a query.</summary>
		public static EobAttach SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EobAttach> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EobAttach objects from the database using a query.</summary>
		public static List<EobAttach> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EobAttach> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EobAttach> TableToList(DataTable table){
			List<EobAttach> retVal=new List<EobAttach>();
			EobAttach eobAttach;
			for(int i=0;i<table.Rows.Count;i++) {
				eobAttach=new EobAttach();
				eobAttach.EobAttachNum   = PIn.Long  (table.Rows[i]["EobAttachNum"].ToString());
				eobAttach.ClaimPaymentNum= PIn.Long  (table.Rows[i]["ClaimPaymentNum"].ToString());
				eobAttach.DateTCreated   = PIn.DateT (table.Rows[i]["DateTCreated"].ToString());
				eobAttach.FileName       = PIn.String(table.Rows[i]["FileName"].ToString());
				eobAttach.RawBase64      = PIn.String(table.Rows[i]["RawBase64"].ToString());
				retVal.Add(eobAttach);
			}
			return retVal;
		}

		///<summary>Inserts one EobAttach into the database.  Returns the new priKey.</summary>
		public static long Insert(EobAttach eobAttach){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				eobAttach.EobAttachNum=DbHelper.GetNextOracleKey("eobattach","EobAttachNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(eobAttach,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							eobAttach.EobAttachNum++;
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
				return Insert(eobAttach,false);
			}
		}

		///<summary>Inserts one EobAttach into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EobAttach eobAttach,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				eobAttach.EobAttachNum=ReplicationServers.GetKey("eobattach","EobAttachNum");
			}
			string command="INSERT INTO eobattach (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EobAttachNum,";
			}
			command+="ClaimPaymentNum,DateTCreated,FileName,RawBase64) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(eobAttach.EobAttachNum)+",";
			}
			command+=
				     POut.Long  (eobAttach.ClaimPaymentNum)+","
				+    POut.DateT (eobAttach.DateTCreated)+","
				+"'"+POut.String(eobAttach.FileName)+"',"
				+DbHelper.ParamChar+"paramRawBase64)";
			if(eobAttach.RawBase64==null) {
				eobAttach.RawBase64="";
			}
			OdSqlParameter paramRawBase64=new OdSqlParameter("paramRawBase64",OdDbType.Text,eobAttach.RawBase64);
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramRawBase64);
			}
			else {
				eobAttach.EobAttachNum=Db.NonQ(command,true,paramRawBase64);
			}
			return eobAttach.EobAttachNum;
		}

		///<summary>Updates one EobAttach in the database.</summary>
		public static void Update(EobAttach eobAttach){
			string command="UPDATE eobattach SET "
				+"ClaimPaymentNum=  "+POut.Long  (eobAttach.ClaimPaymentNum)+", "
				+"DateTCreated   =  "+POut.DateT (eobAttach.DateTCreated)+", "
				+"FileName       = '"+POut.String(eobAttach.FileName)+"', "
				+"RawBase64      =  "+DbHelper.ParamChar+"paramRawBase64 "
				+"WHERE EobAttachNum = "+POut.Long(eobAttach.EobAttachNum);
			if(eobAttach.RawBase64==null) {
				eobAttach.RawBase64="";
			}
			OdSqlParameter paramRawBase64=new OdSqlParameter("paramRawBase64",OdDbType.Text,eobAttach.RawBase64);
			Db.NonQ(command,paramRawBase64);
		}

		///<summary>Updates one EobAttach in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		public static void Update(EobAttach eobAttach,EobAttach oldEobAttach){
			string command="";
			if(eobAttach.ClaimPaymentNum != oldEobAttach.ClaimPaymentNum) {
				if(command!=""){ command+=",";}
				command+="ClaimPaymentNum = "+POut.Long(eobAttach.ClaimPaymentNum)+"";
			}
			if(eobAttach.DateTCreated != oldEobAttach.DateTCreated) {
				if(command!=""){ command+=",";}
				command+="DateTCreated = "+POut.DateT(eobAttach.DateTCreated)+"";
			}
			if(eobAttach.FileName != oldEobAttach.FileName) {
				if(command!=""){ command+=",";}
				command+="FileName = '"+POut.String(eobAttach.FileName)+"'";
			}
			if(eobAttach.RawBase64 != oldEobAttach.RawBase64) {
				if(command!=""){ command+=",";}
				command+="RawBase64 = "+DbHelper.ParamChar+"paramRawBase64";
			}
			if(command==""){
				return;
			}
			if(eobAttach.RawBase64==null) {
				eobAttach.RawBase64="";
			}
			OdSqlParameter paramRawBase64=new OdSqlParameter("paramRawBase64",OdDbType.Text,eobAttach.RawBase64);
			command="UPDATE eobattach SET "+command
				+" WHERE EobAttachNum = "+POut.Long(eobAttach.EobAttachNum);
			Db.NonQ(command,paramRawBase64);
		}

		///<summary>Deletes one EobAttach from the database.</summary>
		public static void Delete(long eobAttachNum){
			string command="DELETE FROM eobattach "
				+"WHERE EobAttachNum = "+POut.Long(eobAttachNum);
			Db.NonQ(command);
		}

	}
}
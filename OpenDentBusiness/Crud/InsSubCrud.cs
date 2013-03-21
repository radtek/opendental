//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class InsSubCrud {
		///<summary>Gets one InsSub object from the database using the primary key.  Returns null if not found.</summary>
		public static InsSub SelectOne(long insSubNum){
			string command="SELECT * FROM inssub "
				+"WHERE InsSubNum = "+POut.Long(insSubNum);
			List<InsSub> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one InsSub object from the database using a query.</summary>
		public static InsSub SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<InsSub> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of InsSub objects from the database using a query.</summary>
		public static List<InsSub> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<InsSub> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<InsSub> TableToList(DataTable table){
			List<InsSub> retVal=new List<InsSub>();
			InsSub insSub;
			for(int i=0;i<table.Rows.Count;i++) {
				insSub=new InsSub();
				insSub.InsSubNum    = PIn.Long  (table.Rows[i]["InsSubNum"].ToString());
				insSub.PlanNum      = PIn.Long  (table.Rows[i]["PlanNum"].ToString());
				insSub.Subscriber   = PIn.Long  (table.Rows[i]["Subscriber"].ToString());
				insSub.DateEffective= PIn.Date  (table.Rows[i]["DateEffective"].ToString());
				insSub.DateTerm     = PIn.Date  (table.Rows[i]["DateTerm"].ToString());
				insSub.ReleaseInfo  = PIn.Bool  (table.Rows[i]["ReleaseInfo"].ToString());
				insSub.AssignBen    = PIn.Bool  (table.Rows[i]["AssignBen"].ToString());
				insSub.SubscriberID = PIn.String(table.Rows[i]["SubscriberID"].ToString());
				insSub.BenefitNotes = PIn.String(table.Rows[i]["BenefitNotes"].ToString());
				insSub.SubscNote    = PIn.String(table.Rows[i]["SubscNote"].ToString());
				retVal.Add(insSub);
			}
			return retVal;
		}

		///<summary>Inserts one InsSub into the database.  Returns the new priKey.</summary>
		public static long Insert(InsSub insSub){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				insSub.InsSubNum=DbHelper.GetNextOracleKey("inssub","InsSubNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(insSub,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							insSub.InsSubNum++;
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
				return Insert(insSub,false);
			}
		}

		///<summary>Inserts one InsSub into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(InsSub insSub,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				insSub.InsSubNum=ReplicationServers.GetKey("inssub","InsSubNum");
			}
			string command="INSERT INTO inssub (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="InsSubNum,";
			}
			command+="PlanNum,Subscriber,DateEffective,DateTerm,ReleaseInfo,AssignBen,SubscriberID,BenefitNotes,SubscNote) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(insSub.InsSubNum)+",";
			}
			command+=
				     POut.Long  (insSub.PlanNum)+","
				+    POut.Long  (insSub.Subscriber)+","
				+    POut.Date  (insSub.DateEffective)+","
				+    POut.Date  (insSub.DateTerm)+","
				+    POut.Bool  (insSub.ReleaseInfo)+","
				+    POut.Bool  (insSub.AssignBen)+","
				+"'"+POut.String(insSub.SubscriberID)+"',"
				+DbHelper.ParamChar+"paramBenefitNotes,"
				+"'"+POut.String(insSub.SubscNote)+"')";
			if(insSub.BenefitNotes==null) {
				insSub.BenefitNotes="";
			}
			OdSqlParameter paramBenefitNotes=new OdSqlParameter("paramBenefitNotes",OdDbType.Text,insSub.BenefitNotes);
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramBenefitNotes);
			}
			else {
				insSub.InsSubNum=Db.NonQ(command,true,paramBenefitNotes);
			}
			return insSub.InsSubNum;
		}

		///<summary>Updates one InsSub in the database.</summary>
		public static void Update(InsSub insSub){
			string command="UPDATE inssub SET "
				+"PlanNum      =  "+POut.Long  (insSub.PlanNum)+", "
				+"Subscriber   =  "+POut.Long  (insSub.Subscriber)+", "
				+"DateEffective=  "+POut.Date  (insSub.DateEffective)+", "
				+"DateTerm     =  "+POut.Date  (insSub.DateTerm)+", "
				+"ReleaseInfo  =  "+POut.Bool  (insSub.ReleaseInfo)+", "
				+"AssignBen    =  "+POut.Bool  (insSub.AssignBen)+", "
				+"SubscriberID = '"+POut.String(insSub.SubscriberID)+"', "
				+"BenefitNotes =  "+DbHelper.ParamChar+"paramBenefitNotes, "
				+"SubscNote    = '"+POut.String(insSub.SubscNote)+"' "
				+"WHERE InsSubNum = "+POut.Long(insSub.InsSubNum);
			if(insSub.BenefitNotes==null) {
				insSub.BenefitNotes="";
			}
			OdSqlParameter paramBenefitNotes=new OdSqlParameter("paramBenefitNotes",OdDbType.Text,insSub.BenefitNotes);
			Db.NonQ(command,paramBenefitNotes);
		}

		///<summary>Updates one InsSub in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		public static void Update(InsSub insSub,InsSub oldInsSub){
			string command="";
			if(insSub.PlanNum != oldInsSub.PlanNum) {
				if(command!=""){ command+=",";}
				command+="PlanNum = "+POut.Long(insSub.PlanNum)+"";
			}
			if(insSub.Subscriber != oldInsSub.Subscriber) {
				if(command!=""){ command+=",";}
				command+="Subscriber = "+POut.Long(insSub.Subscriber)+"";
			}
			if(insSub.DateEffective != oldInsSub.DateEffective) {
				if(command!=""){ command+=",";}
				command+="DateEffective = "+POut.Date(insSub.DateEffective)+"";
			}
			if(insSub.DateTerm != oldInsSub.DateTerm) {
				if(command!=""){ command+=",";}
				command+="DateTerm = "+POut.Date(insSub.DateTerm)+"";
			}
			if(insSub.ReleaseInfo != oldInsSub.ReleaseInfo) {
				if(command!=""){ command+=",";}
				command+="ReleaseInfo = "+POut.Bool(insSub.ReleaseInfo)+"";
			}
			if(insSub.AssignBen != oldInsSub.AssignBen) {
				if(command!=""){ command+=",";}
				command+="AssignBen = "+POut.Bool(insSub.AssignBen)+"";
			}
			if(insSub.SubscriberID != oldInsSub.SubscriberID) {
				if(command!=""){ command+=",";}
				command+="SubscriberID = '"+POut.String(insSub.SubscriberID)+"'";
			}
			if(insSub.BenefitNotes != oldInsSub.BenefitNotes) {
				if(command!=""){ command+=",";}
				command+="BenefitNotes = "+DbHelper.ParamChar+"paramBenefitNotes";
			}
			if(insSub.SubscNote != oldInsSub.SubscNote) {
				if(command!=""){ command+=",";}
				command+="SubscNote = '"+POut.String(insSub.SubscNote)+"'";
			}
			if(command==""){
				return;
			}
			if(insSub.BenefitNotes==null) {
				insSub.BenefitNotes="";
			}
			OdSqlParameter paramBenefitNotes=new OdSqlParameter("paramBenefitNotes",OdDbType.Text,insSub.BenefitNotes);
			command="UPDATE inssub SET "+command
				+" WHERE InsSubNum = "+POut.Long(insSub.InsSubNum);
			Db.NonQ(command,paramBenefitNotes);
		}

		///<summary>Deletes one InsSub from the database.</summary>
		public static void Delete(long insSubNum){
			string command="DELETE FROM inssub "
				+"WHERE InsSubNum = "+POut.Long(insSubNum);
			Db.NonQ(command);
		}

	}
}
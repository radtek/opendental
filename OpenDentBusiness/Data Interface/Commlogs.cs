using System;
using System.Collections;
using System.Data;
using System.Reflection;

namespace OpenDentBusiness{
	///<summary></summary>
	public class Commlogs {

		///<summary>Gets all items for the current patient ordered by date.</summary>
		public static Commlog[] Refresh(long patNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<Commlog[]>(MethodBase.GetCurrentMethod(),patNum);
			}
			string command=
				"SELECT * FROM commlog"
				+" WHERE PatNum = '"+patNum+"'"
				+" ORDER BY CommDateTime";
			return RefreshAndFill(Db.GetTable(command));
		}

		///<summary>Gets one commlog item from database.</summary>
		public static Commlog GetOne(long commlogNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<Commlog>(MethodBase.GetCurrentMethod(),commlogNum);
			}
			string command=
				"SELECT * FROM commlog"
				+" WHERE CommlogNum = "+POut.PLong(commlogNum);
			Commlog[] commList=RefreshAndFill(Db.GetTable(command));
			if(commList.Length==0) {
				return null;
			}
			return commList[0];
		}

		private static Commlog[] RefreshAndFill(DataTable table) {
			//No need to check RemotingRole; no call to db.
			Commlog[] List=new Commlog[table.Rows.Count];
			for(int i=0;i<List.Length;i++) {
				List[i]=new Commlog();
				List[i].CommlogNum     = PIn.PLong(table.Rows[i][0].ToString());
				List[i].PatNum         = PIn.PLong(table.Rows[i][1].ToString());
				List[i].CommDateTime   = PIn.PDate(table.Rows[i][2].ToString());
				List[i].CommType       = PIn.PLong(table.Rows[i][3].ToString());
				List[i].Note           = PIn.PString(table.Rows[i][4].ToString());
				List[i].Mode_          = (CommItemMode)PIn.PLong(table.Rows[i][5].ToString());
				List[i].SentOrReceived = (CommSentOrReceived)PIn.PLong(table.Rows[i][6].ToString());
				//List[i].IsStatementSent= PIn.PBool(table.Rows[i][7].ToString());
				List[i].UserNum        = PIn.PLong(table.Rows[i][8].ToString());
			}
			return List;
		}

		///<summary></summary>
		public static long Insert(Commlog comm) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				comm.CommlogNum=Meth.GetInt(MethodBase.GetCurrentMethod(),comm);
				return comm.CommlogNum;
			}
			if(PrefC.RandomKeys) {
				comm.CommlogNum=ReplicationServers.GetKey("commlog","CommlogNum");
			}
			string command="INSERT INTO commlog (";
			if(PrefC.RandomKeys) {
				command+="CommlogNum,";
			}
			command+="PatNum,CommDateTime,CommType,Note,Mode_,SentOrReceived,UserNum) VALUES(";
			if(PrefC.RandomKeys) {
				command+="'"+POut.PLong(comm.CommlogNum)+"', ";
			}
			command+=
				 "'"+POut.PLong   (comm.PatNum)+"', "
				+POut.PDateT (comm.CommDateTime)+", "
				+"'"+POut.PLong   (comm.CommType)+"', "
				+"'"+POut.PString(comm.Note)+"', "
				+"'"+POut.PLong   ((int)comm.Mode_)+"', "
				+"'"+POut.PLong   ((int)comm.SentOrReceived)+"', "
				//+"'"+POut.PBool  (comm.IsStatementSent)+"', "
				+"'"+POut.PLong   (comm.UserNum)+"')";
			if(PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				comm.CommlogNum=Db.NonQ(command,true);
			}
			return comm.CommlogNum;
		}

		///<summary></summary>
		public static void Update(Commlog comm) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),comm);
				return;
			}
			string command= "UPDATE commlog SET "
				+"PatNum = '"         +POut.PLong   (comm.PatNum)+"', "
				+"CommDateTime= "     +POut.PDateT (comm.CommDateTime)+", "
				+"CommType = '"       +POut.PLong   (comm.CommType)+"', "
				+"Note = '"           +POut.PString(comm.Note)+"', "
				+"Mode_ = '"          +POut.PLong   ((int)comm.Mode_)+"', "
				+"SentOrReceived = '" +POut.PLong   ((int)comm.SentOrReceived)+"', "
				//+"IsStatementSent = '"+POut.PBool  (comm.IsStatementSent)+"', "
				+"UserNum = '"        +POut.PLong   (comm.UserNum)+"' "
				+"WHERE commlognum = '"+POut.PLong(comm.CommlogNum)+"'";
			Db.NonQ(command);
		}

		///<summary></summary>
		public static void Delete(Commlog comm) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),comm);
				return;
			}
			string command= "DELETE FROM commlog WHERE CommLogNum = '"+POut.PLong(comm.CommlogNum)+"'";
			Db.NonQ(command);
		}

		///<summary>Used when printing or emailing recall to make a commlog entry without any display.</summary>
		public static void InsertForRecall(long patNum,CommItemMode _mode,int numberOfReminders,long defNumNewStatus) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),patNum,_mode,numberOfReminders,defNumNewStatus);
				return;
			}
			long recallType=Commlogs.GetTypeAuto(CommItemTypeAuto.RECALL);
			string command;
			if(recallType!=0){
				command="SELECT COUNT(*) FROM commlog WHERE ";
				if(DataConnection.DBtype==DatabaseType.Oracle){
					command+="TO_DATE(CommDateTime) = "+POut.PDate(MiscData.GetNowDateTime());
				}
				else{//MySQL
					command+="DATE(CommDateTime) = CURDATE()";
				}
				command+=" AND PatNum="+POut.PLong(patNum)+" AND CommType="+POut.PLong(recallType)
					+" AND Mode_="+POut.PLong((int)_mode)
					+" AND SentOrReceived=1";
				if(Db.GetCount(command)!="0"){
					return;
				}
			}
			Commlog com=new Commlog();
			com.PatNum=patNum;
			com.CommDateTime=DateTime.Now;
			com.CommType=recallType;
			com.Mode_=_mode;
			com.SentOrReceived=CommSentOrReceived.Sent;
			com.Note="";
			if(numberOfReminders==0){
				com.Note=Lans.g("FormRecallList","Recall reminder.");
			}
			else if(numberOfReminders==1) {
				com.Note=Lans.g("FormRecallList","Second recall reminder.");
			}
			else if(numberOfReminders==2) {
				com.Note=Lans.g("FormRecallList","Third recall reminder.");
			}
			else {
				com.Note=Lans.g("FormRecallList","Recall reminder:")+" "+(numberOfReminders+1).ToString();
			}
			if(defNumNewStatus==0) {
				com.Note+="  "+Lans.g("Commlogs","Status None");
			}
			else {
				com.Note+="  "+DefC.GetName(DefCat.RecallUnschedStatus,defNumNewStatus);
			}
			com.UserNum=Security.CurUser.UserNum;
			Insert(com);
		}

		///<Summary>Returns a defnum.  If no match, then it returns the first one in the list in that category.</Summary>
		public static long GetTypeAuto(CommItemTypeAuto typeauto) {
			//No need to check RemotingRole; no call to db.
			for(int i=0;i<DefC.Long[(int)DefCat.CommLogTypes].Length;i++){
				if(DefC.Long[(int)DefCat.CommLogTypes][i].ItemValue==typeauto.ToString()){
					return DefC.Long[(int)DefCat.CommLogTypes][i].DefNum;
				}
			}
			if(DefC.Long[(int)DefCat.CommLogTypes].Length>0){
				return DefC.Long[(int)DefCat.CommLogTypes][0].DefNum;
			}
			return 0;
		}

	}

	///<summary></summary>
	public enum CommItemTypeAuto {
		APPT,
		FIN,
		RECALL,
		MISC
	}




}


















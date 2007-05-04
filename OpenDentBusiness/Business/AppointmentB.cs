using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OpenDentBusiness{
	public class AppointmentB {
		public static Appointment TableToObject(DataTable table) {
			if(table.Rows.Count==0) {
				return null;
			}
			return TableToObjects(table)[0];
		}

		public static Appointment[] TableToObjects(DataTable table) {
			Appointment[] list=new Appointment[table.Rows.Count];
			for(int i=0;i<table.Rows.Count;i++) {
				list[i]=new Appointment();
				list[i].AptNum         =PIn.PInt(table.Rows[i][0].ToString());
				list[i].PatNum         =PIn.PInt(table.Rows[i][1].ToString());
				list[i].AptStatus      =(ApptStatus)PIn.PInt(table.Rows[i][2].ToString());
				list[i].Pattern        =PIn.PString(table.Rows[i][3].ToString());
				list[i].Confirmed      =PIn.PInt(table.Rows[i][4].ToString());
				list[i].AddTime        =PIn.PInt(table.Rows[i][5].ToString());
				list[i].Op             =PIn.PInt(table.Rows[i][6].ToString());
				list[i].Note           =PIn.PString(table.Rows[i][7].ToString());
				list[i].ProvNum        =PIn.PInt(table.Rows[i][8].ToString());
				list[i].ProvHyg        =PIn.PInt(table.Rows[i][9].ToString());
				list[i].AptDateTime    =PIn.PDateT(table.Rows[i][10].ToString());
				list[i].NextAptNum     =PIn.PInt(table.Rows[i][11].ToString());
				list[i].UnschedStatus  =PIn.PInt(table.Rows[i][12].ToString());
				list[i].Lab            =(LabCaseOld)PIn.PInt(table.Rows[i][13].ToString());
				list[i].IsNewPatient   =PIn.PBool(table.Rows[i][14].ToString());
				list[i].ProcDescript   =PIn.PString(table.Rows[i][15].ToString());
				list[i].Assistant      =PIn.PInt(table.Rows[i][16].ToString());
				list[i].InstructorNum  =PIn.PInt(table.Rows[i][17].ToString());
				list[i].SchoolClassNum =PIn.PInt(table.Rows[i][18].ToString());
				list[i].SchoolCourseNum=PIn.PInt(table.Rows[i][19].ToString());
				list[i].GradePoint     =PIn.PFloat(table.Rows[i][20].ToString());
				list[i].ClinicNum      =PIn.PInt(table.Rows[i][21].ToString());
				list[i].IsHygiene      =PIn.PBool(table.Rows[i][22].ToString());
			}
			return list;
		}

		///<Summary>Parameters: 1:AptNum</Summary>
		public static DataSet GetApptEdit(string[] parameters){
			DataSet retVal=new DataSet();
			retVal.Tables.Add(GetApptTable(parameters[0]));
			retVal.Tables.Add(GetPatTable(retVal.Tables["Appointment"].Rows[0]["PatNum"].ToString()));
			retVal.Tables.Add(GetProcTable(retVal.Tables["Appointment"].Rows[0]["PatNum"].ToString(),parameters[0],
				retVal.Tables["Appointment"].Rows[0]["AptStatus"].ToString()));
			retVal.Tables.Add(GetCommTable(retVal.Tables["Appointment"].Rows[0]["PatNum"].ToString()));
			return retVal;
		}

		private static DataTable GetApptTable(string aptNum){
			DataConnection dcon=new DataConnection();
			string command="SELECT * FROM appointment WHERE AptNum="+aptNum;
			DataTable table=dcon.GetTable(command);
			table.TableName="Appointment";
			return table;
		}

		private static DataTable GetPatTable(string patNum) {
			DataConnection dcon=new DataConnection();
			DataTable table=new DataTable("Patient");
			//columns that start with lowercase are altered for display rather than being raw data.
			table.Columns.Add("Field");
			table.Columns.Add("Value");
			string command="SELECT * FROM patient WHERE PatNum="+patNum;
			DataTable rawPat=dcon.GetTable(command);
			DataRow row;
			//Patient Name--------------------------------------------------------------------------
			row=table.NewRow();
			row["Field"]=Lan.g("FormApptEdit","Name");
			row["Value"]=PatientB.GetNameLF(rawPat.Rows[0]["LName"].ToString(),rawPat.Rows[0]["FName"].ToString(),
				rawPat.Rows[0]["Preferred"].ToString(),rawPat.Rows[0]["MiddleI"].ToString());
			table.Rows.Add(row);
			//Patient First Name--------------------------------------------------------------------
			row=table.NewRow();
			row["Field"]=Lan.g("FormAppEdit","First Name");
			row["Value"]=rawPat.Rows[0]["FName"];
			table.Rows.Add(row);
			//Patient Last name---------------------------------------------------------------------
			row=table.NewRow();
			row["Field"]=Lan.g("FormAppEdit","Last Name");
			row["Value"]=rawPat.Rows[0]["LName"];
			table.Rows.Add(row);
			//Patient middle initial----------------------------------------------------------------
			row=table.NewRow();
			row["Field"]=Lan.g("FormAppEdit","Middle Initial");
			row["Value"]=rawPat.Rows[0]["MiddleI"];
			table.Rows.Add(row);
			//Patient home phone--------------------------------------------------------------------
			row=table.NewRow();
			row["Field"]=Lan.g("FormAppEdit","Home Phone");
			row["Value"]=rawPat.Rows[0]["HmPhone"];
			table.Rows.Add(row);
			//Patient work phone--------------------------------------------------------------------
			row=table.NewRow();
			row["Field"]=Lan.g("FormAppEdit","Work Phone");
			row["Value"]=rawPat.Rows[0]["WkPhone"];
			table.Rows.Add(row);
			//Patient wireless phone----------------------------------------------------------------
			row=table.NewRow();
			row["Field"]=Lan.g("FormAppEdit","Wireless Phone");
			row["Value"]=rawPat.Rows[0]["WirelessPhone"];
			table.Rows.Add(row);
			//Patient credit type-------------------------------------------------------------------
			row=table.NewRow();
			row["Field"]=Lan.g("FormAppEdit","Credit Type");
			row["Value"]=rawPat.Rows[0]["CreditType"];
			table.Rows.Add(row);
			//Patient billing type------------------------------------------------------------------
			row=table.NewRow();
			row["Field"]=Lan.g("FormAppEdit","Billing Type");
			row["Value"]=DefB.GetName(DefCat.BillingTypes,PIn.PInt(rawPat.Rows[0]["BillingType"].ToString()));
			table.Rows.Add(row);
			//Patient total balance-----------------------------------------------------------------
			row=table.NewRow();
			row["Field"]=Lan.g("FormAppEdit","Total Balance");
			double totalBalance=PIn.PDouble(rawPat.Rows[0]["EstBalance"].ToString());
			row["Value"]=totalBalance.ToString("F");
			table.Rows.Add(row);
			//Patient address and phone notes-------------------------------------------------------
			row=table.NewRow();
			row["Field"]=Lan.g("FormAppEdit","Address and Phone Notes");
			row["Value"]=rawPat.Rows[0]["AddrNote"];
			table.Rows.Add(row);
			//Patient family balance----------------------------------------------------------------
			command="SELECT BalTotal,InsEst FROM patient WHERE Guarantor='"
				+rawPat.Rows[0]["Guarantor"].ToString()+"'";
			DataTable familyBalance=dcon.GetTable(command);
			row=table.NewRow();
			row["Field"]=Lan.g("FormAppEdit","Family Balance");
			double balance=PIn.PDouble(familyBalance.Rows[0]["BalTotal"].ToString())
				-PIn.PDouble(familyBalance.Rows[0]["InsEst"].ToString());
			row["Value"]=balance.ToString("F");
			table.Rows.Add(row);
			return table;
		}

		private static DataTable GetProcTable(string patNum,string aptNum,string apptStatus) {
			DataConnection dcon=new DataConnection();
			DataTable table=new DataTable("Procedure");
			DataRow row;
			//columns that start with lowercase are altered for display rather than being raw data.
			table.Columns.Add("attached");//0 or 1
			table.Columns.Add("CodeNum");
			table.Columns.Add("descript");
			table.Columns.Add("fee");
			table.Columns.Add("priority");
			table.Columns.Add("ProcCode");
			table.Columns.Add("ProcNum");
			table.Columns.Add("ProcStatus");
			table.Columns.Add("status");
			table.Columns.Add("toothNum");
			table.Columns.Add("Surf");
			string command="SELECT procedurecode.ProcCode,AptNum,PlannedAptNum,Priority,ProcFee,ProcNum,ProcStatus,Surf,ToothNum, "
				+"procedurecode.Descript,procedurelog.CodeNum "
				+"FROM procedurelog LEFT JOIN procedurecode ON procedurelog.CodeNum=procedurecode.CodeNum "
				+"WHERE PatNum="+patNum//sort later
				+" AND (ProcStatus=1 OR ";//tp
			if(apptStatus=="6"){//planned
				command+="PlannedAptNum="+aptNum+")";
			}
			else{
				command+="AptNum="+aptNum+")";
			}
			DataTable rawProc=dcon.GetTable(command);
			for(int i=0;i<rawProc.Rows.Count;i++) {
				row=table.NewRow();
				if(apptStatus=="6"){//planned
					row["attached"]=(rawProc.Rows[i]["PlannedAptNum"].ToString()==aptNum) ? "1" : "0";
				}
				else{
					row["attached"]=(rawProc.Rows[i]["AptNum"].ToString()==aptNum) ? "1" : "0";
				}
				row["CodeNum"]=rawProc.Rows[i]["CodeNum"].ToString();
				row["descript"]=rawProc.Rows[i]["Descript"].ToString();
				row["fee"]=PIn.PDouble(rawProc.Rows[i]["ProcFee"].ToString()).ToString("F");
				row["priority"]=DefB.GetName(DefCat.TxPriorities,PIn.PInt(rawProc.Rows[i]["Priority"].ToString()));
				row["ProcCode"]=rawProc.Rows[i]["ProcCode"].ToString();
				row["ProcNum"]=rawProc.Rows[i]["ProcNum"].ToString();
				row["ProcStatus"]=rawProc.Rows[i]["ProcStatus"].ToString();
				row["status"]=((ProcStat)PIn.PInt(rawProc.Rows[i]["ProcStatus"].ToString())).ToString();
				row["toothNum"]=Tooth.ToInternat(rawProc.Rows[i]["ToothNum"].ToString());
				row["Surf"]=rawProc.Rows[i]["Surf"].ToString();
				table.Rows.Add(row);
			}
			return table;
		}

		private static DataTable GetCommTable(string patNum) {
			DataConnection dcon=new DataConnection();
			DataTable table=new DataTable("Comm");
			DataRow row;
			//columns that start with lowercase are altered for display rather than being raw data.
			table.Columns.Add("commDateTime");
			table.Columns.Add("CommlogNum");
			table.Columns.Add("CommType");
			table.Columns.Add("Note");
			string command="SELECT * FROM commlog WHERE PatNum="+patNum+" AND CommType !=1 "//don't include StatementSent
				+"ORDER BY CommDateTime";
			DataTable rawComm=dcon.GetTable(command);
			for(int i=0;i<rawComm.Rows.Count;i++) {
				row=table.NewRow();
				row["commDateTime"]=PIn.PDateT(rawComm.Rows[i]["commDateTime"].ToString()).ToShortDateString();
				row["CommlogNum"]=rawComm.Rows[i]["CommlogNum"].ToString();
				row["CommType"]=rawComm.Rows[i]["CommType"].ToString();
				row["Note"]=rawComm.Rows[i]["Note"].ToString();
				table.Rows.Add(row);
			}
			return table;
		}

	}
}

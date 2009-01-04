﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OpenDentMobile.UI;

namespace OpenDentMobile {
	public partial class ContrAppt:UserControl {
		private int PatCurNum;
		private DataTable tableApt;
		///<summary>Occurs when user changes current patient, usually by clicking on the Select Patient button.</summary>
		public event PatientSelectedEventHandler PatientSelected=null;

		public ContrAppt() {
			InitializeComponent();
		}

		///<summary></summary>
		public void ModuleSelected(int patNum){
			RefreshModulePatient(patNum);
			RefreshPeriod();
		}
		///<summary></summary>
		private void RefreshModulePatient(int patNum){
			PatCurNum=patNum;//might be zero
		}

		///<summary>Sends the PatientSelected event on up to the main form.</summary>
		private void OnPatientSelected(int patNum,string patName) {
			PatientSelectedEventArgs eArgs=new PatientSelectedEventArgs(patNum,patName);
			if(PatientSelected!=null){
				PatientSelected(this,eArgs);
			}
		}

		///<summary>Important.  Gets all new day info from db and redraws screen</summary>
		public void RefreshPeriod(){
			tableApt=Appointments.RefreshPeriod(dateTPicker.Value);
			gridMain.BeginUpdate();
			gridMain.Columns.Clear();
			ODGridColumn col=new ODGridColumn("Time",55);
			gridMain.Columns.Add(col);
			col=new ODGridColumn("Patient",90);
			gridMain.Columns.Add(col);
			col=new ODGridColumn("Procedures",90);
			gridMain.Columns.Add(col);
			col=new ODGridColumn("Len",30);
			gridMain.Columns.Add(col);
			col=new ODGridColumn("Note",150);
			gridMain.Columns.Add(col);
			gridMain.Rows.Clear();
			ODGridRow row;
			for(int i=0;i<tableApt.Rows.Count;i++){
				row=new ODGridRow();
				row.Cells.Add(tableApt.Rows[i]["time"].ToString());
				row.Cells.Add(tableApt.Rows[i]["patient"].ToString());
				row.Cells.Add(tableApt.Rows[i]["ProcDescript"].ToString());
				row.Cells.Add(tableApt.Rows[i]["length"].ToString());
				row.Cells.Add(tableApt.Rows[i]["Note"].ToString());
				gridMain.Rows.Add(row);
			}
			gridMain.EndUpdate();
		}

		private void butBack_Click(object sender,EventArgs e) {
			dateTPicker.Value=dateTPicker.Value.AddDays(-1);
		}

		private void butFwd_Click(object sender,EventArgs e) {
			dateTPicker.Value=dateTPicker.Value.AddDays(1);
			
		}

		private void dateTPicker_ValueChanged(object sender,EventArgs e) {
			RefreshPeriod();
		}

		private void gridMain_CellClick(object sender,ODGridClickEventArgs e) {
			int patNum=PIn.PInt(tableApt.Rows[e.Row]["PatNum"].ToString());
			string patName=tableApt.Rows[e.Row]["patient"].ToString();
			OnPatientSelected(patNum,patName);
		}





	}
}

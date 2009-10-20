using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using OpenDentBusiness;

namespace OpenDental{
///<summary></summary>
	public class FormRpOutInsClaims : System.Windows.Forms.Form{
		private OpenDental.UI.Button butOK;
		private OpenDental.UI.Button butCancel;
		private FormQuery FormQuery2;
		private System.Windows.Forms.Label labelDaysOld;
		//private int daysOld=0;
		private OpenDental.ValidNum textDaysOld;
		private System.Windows.Forms.Label label1;
		private CheckBox checkProvAll;
		private ListBox listProv;
		private Label label3;
		private CheckBox checkPreauth;
		private System.ComponentModel.Container components = null;

		///<summary></summary>
		public FormRpOutInsClaims(){
			InitializeComponent();
 			Lan.F(this); 
		}

		///<summary></summary>
		protected override void Dispose( bool disposing ){
			if( disposing ){
				if(components != null){
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code

		private void InitializeComponent(){
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRpOutInsClaims));
			this.butOK = new OpenDental.UI.Button();
			this.butCancel = new OpenDental.UI.Button();
			this.labelDaysOld = new System.Windows.Forms.Label();
			this.textDaysOld = new OpenDental.ValidNum();
			this.label1 = new System.Windows.Forms.Label();
			this.checkProvAll = new System.Windows.Forms.CheckBox();
			this.listProv = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.checkPreauth = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// butOK
			// 
			this.butOK.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butOK.Autosize = true;
			this.butOK.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOK.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butOK.CornerRadius = 4F;
			this.butOK.Location = new System.Drawing.Point(510,281);
			this.butOK.Name = "butOK";
			this.butOK.Size = new System.Drawing.Size(75,26);
			this.butOK.TabIndex = 1;
			this.butOK.Text = "&OK";
			this.butOK.Click += new System.EventHandler(this.butOK_Click);
			// 
			// butCancel
			// 
			this.butCancel.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butCancel.Autosize = true;
			this.butCancel.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butCancel.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butCancel.CornerRadius = 4F;
			this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butCancel.Location = new System.Drawing.Point(510,321);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(75,26);
			this.butCancel.TabIndex = 2;
			this.butCancel.Text = "&Cancel";
			// 
			// labelDaysOld
			// 
			this.labelDaysOld.Location = new System.Drawing.Point(30,90);
			this.labelDaysOld.Name = "labelDaysOld";
			this.labelDaysOld.Size = new System.Drawing.Size(98,18);
			this.labelDaysOld.TabIndex = 3;
			this.labelDaysOld.Text = "Days Old";
			this.labelDaysOld.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textDaysOld
			// 
			this.textDaysOld.Location = new System.Drawing.Point(132,89);
			this.textDaysOld.MaxVal = 255;
			this.textDaysOld.MinVal = 0;
			this.textDaysOld.Name = "textDaysOld";
			this.textDaysOld.Size = new System.Drawing.Size(60,20);
			this.textDaysOld.TabIndex = 4;
			this.textDaysOld.Text = "30";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(31,9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(533,56);
			this.label1.TabIndex = 5;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// checkProvAll
			// 
			this.checkProvAll.Checked = true;
			this.checkProvAll.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkProvAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkProvAll.Location = new System.Drawing.Point(273,91);
			this.checkProvAll.Name = "checkProvAll";
			this.checkProvAll.Size = new System.Drawing.Size(145,18);
			this.checkProvAll.TabIndex = 43;
			this.checkProvAll.Text = "All";
			this.checkProvAll.Click += new System.EventHandler(this.checkProvAll_Click);
			// 
			// listProv
			// 
			this.listProv.Location = new System.Drawing.Point(273,114);
			this.listProv.Name = "listProv";
			this.listProv.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listProv.Size = new System.Drawing.Size(163,186);
			this.listProv.TabIndex = 42;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(270,70);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104,16);
			this.label3.TabIndex = 41;
			this.label3.Text = "Providers";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// checkPreauth
			// 
			this.checkPreauth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkPreauth.Checked = true;
			this.checkPreauth.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkPreauth.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkPreauth.Location = new System.Drawing.Point(0,123);
			this.checkPreauth.Name = "checkPreauth";
			this.checkPreauth.Size = new System.Drawing.Size(145,18);
			this.checkPreauth.TabIndex = 44;
			this.checkPreauth.Text = "Include Preauths";
			this.checkPreauth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FormRpOutInsClaims
			// 
			this.AcceptButton = this.butOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5,13);
			this.CancelButton = this.butCancel;
			this.ClientSize = new System.Drawing.Size(597,359);
			this.Controls.Add(this.checkPreauth);
			this.Controls.Add(this.checkProvAll);
			this.Controls.Add(this.listProv);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textDaysOld);
			this.Controls.Add(this.labelDaysOld);
			this.Controls.Add(this.butCancel);
			this.Controls.Add(this.butOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormRpOutInsClaims";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Oustanding Insurance Claims Report";
			this.Load += new System.EventHandler(this.FormOutstandingInsuranceClaims_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void FormOutstandingInsuranceClaims_Load(object sender, System.EventArgs e) {
			for(int i=0;i<ProviderC.List.Length;i++) {
				listProv.Items.Add(ProviderC.List[i].GetLongDesc());
			}
			if(listProv.Items.Count>0) {
				listProv.SelectedIndex=0;
			}
			checkProvAll.Checked=true;
			listProv.Visible=false;
		}

		private void checkProvAll_Click(object sender,EventArgs e) {
			if(checkProvAll.Checked) {
				listProv.Visible=false;
			}
			else {
				listProv.Visible=true;
			}
		}

		private void butOK_Click(object sender, System.EventArgs e) {
			if(textDaysOld.errorProvider1.GetError(textDaysOld) != ""){
				MessageBox.Show(Lan.g("All","Please correct data entry errors first."));
				return;
			}
			if(!checkProvAll.Checked && listProv.SelectedIndices.Count==0) {
				MsgBox.Show(this,"At least one provider must be selected.");
				return;
			}
			int daysOld=PIn.PInt(textDaysOld.Text);
			//FormQuery2.ResetGrid();//this is a method in FormQuery2;
			ReportSimpleGrid report=new ReportSimpleGrid();
			DateTime startQDate = DateTime.Today.AddDays(-daysOld);
			report.Query = "SELECT carrier.CarrierName,claim.ClaimNum"
				+",claim.ClaimType,claim.DateService,"
				+"CONCAT(CONCAT(CONCAT(CONCAT(patient.LName,', '),patient.FName),' '),patient.MiddleI), claim.DateSent"
				+",claim.ClaimFee,carrier.Phone "
				+"FROM claim,insplan,patient,carrier "
				+"WHERE claim.PlanNum = insplan.PlanNum "
				+"AND claim.PatNum = patient.PatNum "
				+"AND carrier.CarrierNum = insplan.CarrierNum "
				+"AND claim.ClaimStatus='S' && claim.DateSent <= "+POut.PDate(startQDate)+" ";
			if(!checkPreauth.Checked){
				report.Query+="AND claim.ClaimType != 'PreAuth' ";
			}
			if(!checkProvAll.Checked){
				for(int i=0;i<listProv.SelectedIndices.Count;i++) {
					if(i==0) {
						report.Query+=" AND (";
					}
					else {
						report.Query+=" OR ";
					}
					report.Query+=	"(claim.ProvBill="+POut.PLong(ProviderC.List[listProv.SelectedIndices[i]].ProvNum)
						+" OR claim.ProvTreat="+POut.PLong(ProviderC.List[listProv.SelectedIndices[i]].ProvNum)+")";
				}
				report.Query+=") ";
			}
			report.Query+="ORDER BY carrier.Phone,insplan.PlanNum";
			FormQuery2=new FormQuery(report);
			FormQuery2.IsReport=true;
			DataTable tableTemp= report.GetTempTable();
			report.TableQ=new DataTable(null);//new table no name
			for(int i=0;i<6;i++){//add columns
				report.TableQ.Columns.Add(new System.Data.DataColumn());//blank columns
			}
			report.InitializeColumns();
			for(int i=0;i<tableTemp.Rows.Count;i++){//loop through data rows
				DataRow row = report.TableQ.NewRow();//create new row called 'row' based on structure of TableQ
				//start filling 'row'. First column is carrier:
				row[0]=tableTemp.Rows[i][0];
				row[1]=tableTemp.Rows[i][7];
				if(PIn.PString(tableTemp.Rows[i][2].ToString())=="P")
          row[2]="Primary";
				if(PIn.PString(tableTemp.Rows[i][2].ToString())=="S")
          row[2]="Secondary";
				if(PIn.PString(tableTemp.Rows[i][2].ToString())=="PreAuth")
          row[2]="PreAuth";
				if(PIn.PString(tableTemp.Rows[i][2].ToString())=="Other")
          row[2]="Other";
				row[3]=tableTemp.Rows[i][4];
				row[4]=(PIn.PDate(tableTemp.Rows[i][3].ToString())).ToString("d");
				row[5]=PIn.PDouble(tableTemp.Rows[i][6].ToString()).ToString("F");
        //TimeSpan d = DateTime.Today.Subtract((PIn.PDate(tableTemp.Rows[i][5].ToString())));
				//if(d.Days>5000)
				//	row[4]="";
				//else
				//	row[4]=d.Days.ToString();
				report.ColTotal[5]+=PIn.PDouble(tableTemp.Rows[i][6].ToString());
				report.TableQ.Rows.Add(row);
      }
			FormQuery2.ResetGrid();//this is a method in FormQuery;
			report.Title="OUTSTANDING INSURANCE CLAIMS";
			report.SubTitle.Add(PrefC.GetString(PrefName.PracticeTitle));
			report.SubTitle.Add("Days Outstanding: " + daysOld);			
			report.ColPos[0]=20;
			report.ColPos[1]=210;
			report.ColPos[2]=330;
			report.ColPos[3]=430;
			report.ColPos[4]=600;
			report.ColPos[5]=690;
			report.ColPos[6]=770;
			report.ColCaption[0]=Lan.g(this,"Carrier");
			report.ColCaption[1]=Lan.g(this,"Phone");
			report.ColCaption[2]=Lan.g(this,"Type");
			report.ColCaption[3]=Lan.g(this,"Patient Name");
			report.ColCaption[4]=Lan.g(this,"Date of Service");
			report.ColCaption[5]=Lan.g(this,"Amount");
			report.ColAlign[5]=HorizontalAlignment.Right;
			FormQuery2.ShowDialog();
			DialogResult=DialogResult.OK;
		}

		
	}
}

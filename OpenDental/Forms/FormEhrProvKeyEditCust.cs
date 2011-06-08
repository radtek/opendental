using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;
#if DEBUG
using EHR;
#endif

namespace OpenDental {
	public partial class FormEhrProvKeyEditCust:Form {
		public EhrProvKey KeyCur;

		public FormEhrProvKeyEditCust() {
			InitializeComponent();
			Lan.F(this);
		}

		private void FormEhrProvKeyEditCust_Load(object sender,EventArgs e) {
			textLName.Text=KeyCur.LName;
			textFName.Text=KeyCur.FName;
			textEhrKey.Text=KeyCur.ProvKey;
			FillProcedure();
			textFullTimeEquiv.Text=KeyCur.FullTimeEquiv.ToString();
			textNotes.Text=KeyCur.Notes;
		}

		private void FillProcedure() {
			if(KeyCur.ProcNum==0) {
				textProcDate.Text="";
				textCustomer.Text="";
				textDescription.Text="";
				textFee.Text="";
				return;
			}
			Procedure ProcCur=Procedures.GetOneProc(KeyCur.ProcNum,false);
			Patient cust=Patients.GetLim(ProcCur.PatNum);
			textProcDate.Text=ProcCur.ProcDate.ToShortDateString();
			textCustomer.Text=cust.GetNameLF();
			textDescription.Text=ProcedureCodes.GetProcCode(ProcCur.CodeNum).Descript;
			textFee.Text=ProcCur.ProcFee.ToString("n");
		}

		private void butGenerate_Click(object sender,EventArgs e) {
			if(textLName.Text=="" || textFName.Text=="") {
				MessageBox.Show("Please enter firstname and lastname.");
				return;
			}
			//Path for testing:
			//@"E:\My Documents\Shared Projects Subversion\EhrProvKeyGenerator\EhrProvKeyGenerator\bin\Debug\EhrProvKeyGenerator.exe"
			string progPath=PrefC.GetString(PrefName.EhrProvKeyGeneratorPath);
			ProcessStartInfo startInfo=new ProcessStartInfo(progPath);
			startInfo.Arguments="\""+textLName.Text.Replace("\"","")+"\" \""+textFName.Text.Replace("\"","")+"\"";
			startInfo.UseShellExecute=false;
			startInfo.RedirectStandardOutput=true;
			Process process=Process.Start(startInfo);
			string result=process.StandardOutput.ReadToEnd();
			result=result.Trim();//remove \r\n from the end
			//process.WaitForExit();
			textEhrKey.Text=result;
		}

		private void butAttach_Click(object sender,EventArgs e) {
			FormProcSelect FormPS=new FormProcSelect(KeyCur.PatNum);
			FormPS.IsForProvKeys=true;
			FormPS.ShowDialog();
			if(FormPS.DialogResult!=DialogResult.OK) {
				return;
			}
			KeyCur.ProcNum=FormPS.SelectedProcNum;
			FillProcedure();
		}

		private void butDetach_Click(object sender,EventArgs e) {
			if(!MsgBox.Show(this,MsgBoxButtons.OKCancel,"Detach procedure from provkey?")) {
				return;
			}
			KeyCur.ProcNum=0;
			FillProcedure();
		}

		private void butEdit_Click(object sender,EventArgs e) {
			if(KeyCur.ProcNum==0){
				MessageBox.Show("No procedure to edit.");
				return;
			}
			Family fam=Patients.GetFamily(KeyCur.PatNum);
			Patient pat=fam.GetPatient(KeyCur.PatNum);
			Procedure proc=Procedures.GetOneProc(KeyCur.ProcNum,false);
			FormProcEdit FormP=new FormProcEdit(proc,pat,fam);
			FormP.ShowDialog();
			//user might have deleted proc
			proc=Procedures.GetOneProc(KeyCur.ProcNum,false);
			if(proc.ProcNum==0) {
				KeyCur.ProcNum=0;
			}
			FillProcedure();
		}

		private void butDelete_Click(object sender,EventArgs e) {
			if(KeyCur.IsNew) {
				DialogResult=DialogResult.Cancel;
				return;
			}
			if(!MsgBox.Show(this,MsgBoxButtons.OKCancel,"Delete?")) {
				return;
			}
			EhrProvKeys.Delete(KeyCur.EhrProvKeyNum);
			DialogResult=DialogResult.OK;
		}

		private void butOK_Click(object sender,EventArgs e) {
			//if(textEhrKey.Text=="") {
			//	MessageBox.Show("Key must not be blank");
			//	return;
			//}
			try{
				float fte=float.Parse(textFullTimeEquiv.Text);
				if(fte<=0) {
					MessageBox.Show("FTE must be greater than 0.");
					return;
				}
				if(fte>1) {
					MessageBox.Show("FTE must be 1 or less.");
					return;
				}
			}
			catch{
				//not allowed to be blank. Usually 1.
				MessageBox.Show("Invalid FTE.");
				return;
			}
			if(textEhrKey.Text!="") {
				bool provKeyIsValid=false;
				#if DEBUG
					provKeyIsValid=((FormEHR)FormOpenDental.FormEHR).ProvKeyIsValid(textLName.Text,textFName.Text,textEhrKey.Text);
				#else
					Type type=FormOpenDental.AssemblyEHR.GetType("EHR.FormEHR");//namespace.class
					object[] args=new object[] { textLName.Text,textFName.Text,textEhrKey.Text };
					provKeyIsValid=(bool)type.InvokeMember("ProvKeyIsValid",System.Reflection.BindingFlags.InvokeMethod,null,FormOpenDental.FormEHR,args);
				#endif
				if(!provKeyIsValid) {
					MessageBox.Show("Invalid provider key");
					return;
				}
			}
			KeyCur.LName=textLName.Text;
			KeyCur.FName=textFName.Text;
			KeyCur.ProvKey=textEhrKey.Text;
			//KeyCur.ProcNum already handled.
			KeyCur.FullTimeEquiv=PIn.Float(textFullTimeEquiv.Text);
			KeyCur.Notes=textNotes.Text;
			if(KeyCur.IsNew) {
				EhrProvKeys.Insert(KeyCur);
			}
			else {
				EhrProvKeys.Update(KeyCur);
			}
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}

	

		

		

		
	}
}
using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using OpenDentBusiness;
using CodeBase;

namespace OpenDental{
	/// <summary>
	/// Summary description for FormBasicTemplate.
	/// </summary>
	public class FormUpdate : System.Windows.Forms.Form{
		private OpenDental.UI.Button butClose;
		private System.Windows.Forms.Button butReset;
		private System.Windows.Forms.Label labelVersion;
		private OpenDental.UI.Button butDownload;
		private OpenDental.UI.Button butCheck;
		private System.Windows.Forms.TextBox textUpdateCode;
		private System.Windows.Forms.TextBox textWebsitePath;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private IContainer components;
		//private WebClient myWebClient;
		private string myStringWebResource;
		private TextBox textResult;
		private TextBox textResult2;
		private Label label4;
		private Label label6;
		private Panel panel1;
		private FormProgress FormP;
		string BackgroundImg;//ADA2006.jpg
		string OldClaimFormID;
		private Label label9;
		private Label label10;
		private Label label7;
		private Label label8;
		private MainMenu mainMenu1;
		private MenuItem menuItemSetup;
		private Panel panelClassic;
		private OpenDental.UI.Button butLicense;//OD1
		///<summary>Includes path</summary>
		string WriteToFile;

		///<summary></summary>
		public FormUpdate()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			Lan.F(this);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUpdate));
			this.butReset = new System.Windows.Forms.Button();
			this.labelVersion = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textUpdateCode = new System.Windows.Forms.TextBox();
			this.textWebsitePath = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textResult = new System.Windows.Forms.TextBox();
			this.textResult2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.butDownload = new OpenDental.UI.Button();
			this.butCheck = new OpenDental.UI.Button();
			this.butClose = new OpenDental.UI.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
			this.menuItemSetup = new System.Windows.Forms.MenuItem();
			this.panelClassic = new System.Windows.Forms.Panel();
			this.butLicense = new OpenDental.UI.Button();
			this.panelClassic.SuspendLayout();
			this.SuspendLayout();
			// 
			// butReset
			// 
			this.butReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butReset.ForeColor = System.Drawing.SystemColors.Control;
			this.butReset.Location = new System.Drawing.Point(830,0);
			this.butReset.Name = "butReset";
			this.butReset.Size = new System.Drawing.Size(13,12);
			this.butReset.TabIndex = 6;
			this.butReset.Click += new System.EventHandler(this.butReset_Click);
			// 
			// labelVersion
			// 
			this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif",8.25F,System.Drawing.FontStyle.Bold,System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.labelVersion.Location = new System.Drawing.Point(9,9);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(176,20);
			this.labelVersion.TabIndex = 10;
			this.labelVersion.Text = "Using Version ";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0,0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100,23);
			this.label1.TabIndex = 0;
			// 
			// textUpdateCode
			// 
			this.textUpdateCode.Location = new System.Drawing.Point(234,182);
			this.textUpdateCode.Name = "textUpdateCode";
			this.textUpdateCode.Size = new System.Drawing.Size(113,20);
			this.textUpdateCode.TabIndex = 19;
			// 
			// textWebsitePath
			// 
			this.textWebsitePath.Location = new System.Drawing.Point(234,159);
			this.textWebsitePath.Name = "textWebsitePath";
			this.textWebsitePath.Size = new System.Drawing.Size(388,20);
			this.textWebsitePath.TabIndex = 24;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(129,160);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(105,19);
			this.label3.TabIndex = 26;
			this.label3.Text = "Website Path";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textResult
			// 
			this.textResult.AcceptsReturn = true;
			this.textResult.BackColor = System.Drawing.SystemColors.Window;
			this.textResult.Location = new System.Drawing.Point(234,238);
			this.textResult.Name = "textResult";
			this.textResult.ReadOnly = true;
			this.textResult.Size = new System.Drawing.Size(388,20);
			this.textResult.TabIndex = 34;
			// 
			// textResult2
			// 
			this.textResult2.AcceptsReturn = true;
			this.textResult2.BackColor = System.Drawing.SystemColors.Window;
			this.textResult2.Location = new System.Drawing.Point(234,261);
			this.textResult2.Multiline = true;
			this.textResult2.Name = "textResult2";
			this.textResult2.ReadOnly = true;
			this.textResult2.Size = new System.Drawing.Size(388,66);
			this.textResult2.TabIndex = 35;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(111,182);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120,19);
			this.label4.TabIndex = 34;
			this.label4.Text = "Update Code";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(97,90);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(586,48);
			this.label6.TabIndex = 40;
			this.label6.Text = resources.GetString("label6.Text");
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(5,557);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(824,4);
			this.panel1.TabIndex = 42;
			// 
			// butDownload
			// 
			this.butDownload.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butDownload.Autosize = true;
			this.butDownload.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butDownload.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butDownload.CornerRadius = 4F;
			this.butDownload.Location = new System.Drawing.Point(234,333);
			this.butDownload.Name = "butDownload";
			this.butDownload.Size = new System.Drawing.Size(83,25);
			this.butDownload.TabIndex = 20;
			this.butDownload.Text = "Download";
			this.butDownload.Click += new System.EventHandler(this.butDownload_Click);
			// 
			// butCheck
			// 
			this.butCheck.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butCheck.Autosize = true;
			this.butCheck.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butCheck.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butCheck.CornerRadius = 4F;
			this.butCheck.Location = new System.Drawing.Point(234,207);
			this.butCheck.Name = "butCheck";
			this.butCheck.Size = new System.Drawing.Size(117,25);
			this.butCheck.TabIndex = 21;
			this.butCheck.Text = "Check for Updates";
			this.butCheck.Click += new System.EventHandler(this.butCheck_Click);
			// 
			// butClose
			// 
			this.butClose.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butClose.Autosize = true;
			this.butClose.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butClose.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butClose.CornerRadius = 4F;
			this.butClose.Location = new System.Drawing.Point(716,626);
			this.butClose.Name = "butClose";
			this.butClose.Size = new System.Drawing.Size(75,25);
			this.butClose.TabIndex = 0;
			this.butClose.Text = "&Close";
			this.butClose.Click += new System.EventHandler(this.butClose_Click);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(12,607);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(491,23);
			this.label9.TabIndex = 47;
			this.label9.Text = "All CDT codes are Copyrighted by the ADA.";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(12,585);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(550,23);
			this.label10.TabIndex = 44;
			this.label10.Text = "This program Copyright 2003-2007, Jordan S. Sparks, D.M.D., Frederik Carlier, and" +
    " others.";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(12,566);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(549,20);
			this.label7.TabIndex = 46;
			this.label7.Text = "This software is licensed under the GPL, www.opensource.org/licenses/gpl-license." +
    "php";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(12,629);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(491,20);
			this.label8.TabIndex = 45;
			this.label8.Text = "MySQL - Copyright 1995-2007, www.mysql.com";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSetup});
			// 
			// menuItemSetup
			// 
			this.menuItemSetup.Index = 0;
			this.menuItemSetup.Text = "Setup";
			this.menuItemSetup.Click += new System.EventHandler(this.menuItemSetup_Click);
			// 
			// panelClassic
			// 
			this.panelClassic.Controls.Add(this.textWebsitePath);
			this.panelClassic.Controls.Add(this.textUpdateCode);
			this.panelClassic.Controls.Add(this.butCheck);
			this.panelClassic.Controls.Add(this.label3);
			this.panelClassic.Controls.Add(this.textResult);
			this.panelClassic.Controls.Add(this.label4);
			this.panelClassic.Controls.Add(this.label6);
			this.panelClassic.Controls.Add(this.textResult2);
			this.panelClassic.Controls.Add(this.butDownload);
			this.panelClassic.Location = new System.Drawing.Point(12,32);
			this.panelClassic.Name = "panelClassic";
			this.panelClassic.Size = new System.Drawing.Size(814,519);
			this.panelClassic.TabIndex = 48;
			this.panelClassic.Visible = false;
			// 
			// butLicense
			// 
			this.butLicense.AdjustImageLocation = new System.Drawing.Point(0,0);
			this.butLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butLicense.Autosize = true;
			this.butLicense.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butLicense.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butLicense.CornerRadius = 4F;
			this.butLicense.Location = new System.Drawing.Point(525,626);
			this.butLicense.Name = "butLicense";
			this.butLicense.Size = new System.Drawing.Size(88,25);
			this.butLicense.TabIndex = 49;
			this.butLicense.Text = "View Licenses";
			this.butLicense.Click += new System.EventHandler(this.butLicense_Click);
			// 
			// FormUpdate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5,13);
			this.ClientSize = new System.Drawing.Size(841,669);
			this.Controls.Add(this.butLicense);
			this.Controls.Add(this.panelClassic);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.butClose);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.butReset);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "FormUpdate";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Update";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUpdate_FormClosing);
			this.Load += new System.EventHandler(this.FormUpdate_Load);
			this.panelClassic.ResumeLayout(false);
			this.panelClassic.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		private void FormUpdate_Load(object sender, System.EventArgs e) {
			labelVersion.Text=Lan.g(this,"Using Version:")+" "+Application.ProductVersion;
			if(PrefB.GetBool("UpdateWindowShowsClassicView")){
				panelClassic.Visible=true;
				panelClassic.Location=new Point(12,32);
				textUpdateCode.Text=PrefB.GetString("UpdateCode");
				textWebsitePath.Text=PrefB.GetString("UpdateWebsitePath");//should include trailing /
				butDownload.Enabled=false;
			}
			if(!Security.IsAuthorized(Permissions.Setup)) {
				butCheck.Enabled=false;
				//butOK.Enabled=false;
			}
		}

		private void menuItemSetup_Click(object sender,EventArgs e) {
			if(PrefB.GetBool("UpdateWindowShowsClassicView")){
				return;
			}
			FormUpdateSetup FormU=new FormUpdateSetup();
			FormU.ShowDialog();
		}

		private void butReset_Click(object sender, System.EventArgs e) {
			FormPasswordReset FormPR=new FormPasswordReset();
			FormPR.ShowDialog();
			DialogResult=DialogResult.OK;
		}

		//private void butLicense_Click(object sender, System.EventArgs e) {
		//	Height=label8.Bottom+50;
		//}

		private void butCheck_Click(object sender, System.EventArgs e) {
			Cursor=Cursors.WaitCursor;
			SavePrefs();
			CheckMain();
			//CheckClaimForm();
			Cursor=Cursors.Default;
		}

		private void CheckMain(){
			butDownload.Enabled=false;
			textResult.Text="";
			textResult2.Text="";
			if(textUpdateCode.Text.Length==0){
				textResult.Text+=Lan.g(this,"Registration number not valid.");
				return;
			}
			string updateInfoMajor="";
			string updateInfoMinor="";
			butDownload.Enabled=ShouldDownloadUpdate(textWebsitePath.Text,textUpdateCode.Text,
							out updateInfoMajor,out updateInfoMinor);
			textResult.Text=updateInfoMajor;
			textResult2.Text=updateInfoMinor;
		}

		///<summary>Returns true if the download at the specified remoteUri with the given registration code should be
		///downloaded and installed as an update, and false is returned otherwise. Also, information about the decision
		///making process is stored in the updateInfoMajor and updateInfoMinor strings, but only holds significance 
		///to a human user.</summary>
		public static bool ShouldDownloadUpdate(string remoteUri,string registrationCode,
			out string updateInfoMajor,out string updateInfoMinor) 
		{
			updateInfoMajor="";
			updateInfoMinor="";
			bool shouldDownload=false;
			string fileName="Manifest.txt";
			WebClient myWebClient=new WebClient();
			string myStringWebResource=remoteUri+registrationCode+"/"+fileName;
			Version versionNewBuild=null;
			string strNewVersion="";
			string newBuild="";
			bool buildIsBeta=false;
			bool versionIsBeta=false;
			try{
				using(StreamReader sr=new StreamReader(myWebClient.OpenRead(myStringWebResource))){
					newBuild=sr.ReadLine();//must be be 3 or 4 components (revision is optional)
					strNewVersion=sr.ReadLine();//returns null if no second line
				}
				if(newBuild.EndsWith("b")){
					buildIsBeta=true;
					newBuild=newBuild.Replace("b","");
				}
				versionNewBuild=new Version(newBuild);
				if(versionNewBuild.Revision==-1){
					versionNewBuild=new Version(versionNewBuild.Major,versionNewBuild.Minor,versionNewBuild.Build,0);
				}
				if(strNewVersion!=null && strNewVersion.EndsWith("b")){
					versionIsBeta=true;
					strNewVersion=strNewVersion.Replace("b","");
				}
			}catch{
				updateInfoMajor+=Lan.g("FormUpdate","Registration number not valid, or internet connection failed.  ");
				return false;
			}
			if(versionNewBuild==new Version(Application.ProductVersion)){
				updateInfoMajor+=Lan.g("FormUpdate","You are using the most current build of this version.  ");
			}else{
				//this also allows users to install previous versions.
				updateInfoMajor+=Lan.g("FormUpdate","A new build of this version is available for download:  ")
					+versionNewBuild.ToString();
				if(buildIsBeta){
					updateInfoMajor+=Lan.g("FormUpdate","(beta)  ");
				}
				shouldDownload=true;
			}
			//Whether or not build is current, we want to inform user about the next minor version
			if(strNewVersion!=null){//we don't really care what it is.
				updateInfoMinor+=Lan.g("FormUpdate","A newer version is also available.  ");
				if(versionIsBeta) {//(checkNewBuild.Checked || checkNewVersion.Checked) && versionIsBeta){
					updateInfoMinor+=Lan.g("FormUpdate","It is beta (test), so it has some bugs and "+
						"you will need to update it frequently.  ");
				}
				updateInfoMinor+=Lan.g("FormUpdate","Contact us for a new Registration number if you wish to use it.  ");
			}
			return shouldDownload;
		}

		private void butDownload_Click(object sender, System.EventArgs e){
			string patchName="Setup.exe";
			string destDir=FormPath.GetPreferredImagePath();
			if(destDir==null){//Not using A to Z folders?
				destDir=Path.GetTempPath();
			}
			DownloadInstallPatchFromURI(textWebsitePath.Text+textUpdateCode.Text+"/"+patchName,//Source URI
				ODFileUtils.CombinePaths(destDir,patchName));//Local destination file.
		}

		public static void DownloadInstallPatchFromURI(string downloadUri,string destinationPath){
			File.Delete(destinationPath);//fixes a minor bug
			WebRequest wr=WebRequest.Create(downloadUri);
			WebResponse webResp=wr.GetResponse();
			int fileSize=(int)webResp.ContentLength/1024;
			FormProgress FormP=new FormProgress();
			//start the thread that will perform the download
			System.Threading.ThreadStart downloadDelegate=
					delegate { DownloadInstallPatchWorker(downloadUri,destinationPath,ref FormP); };
			Thread workerThread=new System.Threading.Thread(downloadDelegate);
			workerThread.Start();
			//display the progress dialog to the user:
			FormP.MaxVal=(double)fileSize/1024;
			FormP.NumberMultiplication=100;
			FormP.DisplayText="?currentVal MB of ?maxVal MB copied";
			FormP.NumberFormat="F";
			FormP.ShowDialog();
			if(FormP.DialogResult==DialogResult.Cancel) {
				workerThread.Abort();
				return;
			}
			MsgBox.Show(FormP,"Download succeeded.  Setup program will now begin."+
				"When done, restart the program on this computer, then on the other computers.");
			try{
				Process.Start(destinationPath);
				Application.Exit();
			}catch{
				MsgBox.Show(FormP,"Could not launch setup");
			}
		}

		///<summary>This is the function that the worker thread uses to actually perform the download.  Can also call this method in the ordinary way if the file to be transferred is short.</summary>
		private static void DownloadInstallPatchWorker(string downloadUri,string destinationPath,ref FormProgress progressIndicator){
			int chunk=10;//KB
			byte[] buffer;
			int i=0;
			WebClient myWebClient=new WebClient();
			Stream readStream=myWebClient.OpenRead(downloadUri);
			BinaryReader br=new BinaryReader(readStream);
			FileStream writeStream=new FileStream(destinationPath,FileMode.Create);
			BinaryWriter bw=new BinaryWriter(writeStream);
			try{
				while(true){
					buffer=br.ReadBytes(chunk*1024);
					if(buffer.Length==0){
						break;
					}
					double curVal=((double)(chunk*i)+((double)buffer.Length/1024))/1024;
					progressIndicator.CurrentVal=curVal;
					bw.Write(buffer);
					i++;
				}
			}
			catch{//for instance, if abort.
				br.Close();
				bw.Close();
				File.Delete(destinationPath);
			}
			finally{
				br.Close();
				bw.Close();
			}
			//myWebClient.DownloadFile(downloadUri,ODFileUtils.CombinePaths(FormPath.GetPreferredImagePath(),"Setup.exe"));
		}

		/*
		private void butDownloadClaimform_Click(object sender,EventArgs e) {
			Cursor=Cursors.WaitCursor;
			FormP=new FormProgress();//just so the InstanceMethod won't crash.  We won't be telling user about progress.
			FormP.DisplayText="";
			//Application.DoEvents();
			string remoteUri=textWebsitePath.Text+textRegClaimform.Text+"/";
			WebRequest wr;
			WebResponse webResp;
			//int fileSize;
			//copy image file if one is specified-------------------------------------------------------------------------------
			if(BackgroundImg!=""){
				myStringWebResource=remoteUri+BackgroundImg;
				WriteToFile=ODFileUtils.CombinePaths(FormPath.GetPreferredImagePath(),BackgroundImg);
				if(File.Exists(WriteToFile)){
					File.Delete(WriteToFile);
				}
				wr= WebRequest.Create(myStringWebResource);
				int fileSize;
				try{
					webResp= wr.GetResponse();
					fileSize=(int)webResp.ContentLength/1024;
				}
				catch(Exception ex){
					Cursor=Cursors.Default;
					MessageBox.Show("Error downloading "+BackgroundImg+". "+ex.Message);
					return;
					//fileSize=0;
				}
				if(fileSize>0){
					//start the thread that will perform the download
					System.Threading.ThreadStart downloadDelegate=
						delegate { DownloadInstallPatchWorker(myStringWebResource,WriteToFile,ref FormP); };
					Thread workerThread=new System.Threading.Thread(downloadDelegate);
					workerThread.Start();
					//display the progress dialog to the user:
					FormP.MaxVal=(double)fileSize/1024;
					FormP.NumberMultiplication=100;
					FormP.DisplayText="?currentVal MB of ?maxVal MB copied";
					FormP.NumberFormat="F";
					FormP.ShowDialog();
					if(FormP.DialogResult==DialogResult.Cancel) {
						workerThread.Abort();
						Cursor=Cursors.Default;
						return;
					}
					MsgBox.Show(this,"Image file downloaded successfully.");
				}
			}
			Cursor=Cursors.WaitCursor;//have to do this again for some reason.
			//Import ClaimForm.xml----------------------------------------------------------------------------------
			myStringWebResource=remoteUri+"ClaimForm.xml";
			WriteToFile=ODFileUtils.CombinePaths(FormPath.GetPreferredImagePath(),"ClaimForm.xml");
			if(File.Exists(WriteToFile)){
				File.Delete(WriteToFile);
			}
			try{
				DownloadInstallPatchWorker(myStringWebResource,WriteToFile,ref FormP);
			}
			catch{
			}
			int rowsAffected;
			if(File.Exists(WriteToFile)){
				int newclaimformnum=0;
				try{
					newclaimformnum=FormClaimForms.ImportForm(WriteToFile,true);
				}
				catch(ApplicationException ex){
					Cursor=Cursors.Default;
					MessageBox.Show(ex.Message);
					return;
				}
				finally{
					File.Delete(WriteToFile);
				}
				if(newclaimformnum!=0){
					Prefs.UpdateInt("DefaultClaimForm",newclaimformnum);
				}
				//switch all insplans over to new claimform
				ClaimForm oldform=null;
				for(int i=0;i<ClaimForms.ListLong.Length;i++){
					if(ClaimForms.ListLong[i].UniqueID==OldClaimFormID){
						oldform=ClaimForms.ListLong[i];
					}
				}
				if(oldform!=null){
					rowsAffected=InsPlans.ConvertToNewClaimform(oldform.ClaimFormNum,newclaimformnum);
					MessageBox.Show("Number of insurance plans changed to new form: "+rowsAffected.ToString());
				}
				DataValid.SetInvalid(InvalidTypes.ClaimForms | InvalidTypes.Prefs);
			}
			//Import ProcCodes.xml------------------------------------------------------------------------------------
			myStringWebResource=remoteUri+"ProcCodes.xml";
			WriteToFile=ODFileUtils.CombinePaths(FormPath.GetPreferredImagePath(),"ProcCodes.xml");
			if(File.Exists(WriteToFile)) {
				File.Delete(WriteToFile);
			}
			try {
				DownloadInstallPatchWorker(myStringWebResource,WriteToFile,ref FormP);
			}
			catch {
			}
			if(File.Exists(WriteToFile)){
				//move T codes over to a new "Obsolete" category which is hidden
				ProcedureCodes.TcodesMove();
				rowsAffected=0;
				try {
					rowsAffected=FormProcCodes.ImportProcCodes(WriteToFile,false);
				}
				catch(ApplicationException ex) {
					Cursor=Cursors.Default;
					MessageBox.Show(ex.Message);
					return;
				}
				finally {
					File.Delete(WriteToFile);
				}
				ProcedureCodes.Refresh();//?
				MessageBox.Show("Procedure codes inserted: "+rowsAffected.ToString());
				//Change all procbuttons and autocodes from T to D.
				ProcedureCodes.TcodesAlter();
				DataValid.SetInvalid(InvalidTypes.AutoCodes | InvalidTypes.Defs | InvalidTypes.ProcCodes | InvalidTypes.ProcButtons);
			}
			MsgBox.Show(this,"Done");
			Cursor=Cursors.Default;
		}*/

		private void SavePrefs(){
			bool changed=false;
			if(Prefs.UpdateString("UpdateCode",textUpdateCode.Text)){
				changed=true;
			}
			if(Prefs.UpdateString("UpdateWebsitePath",textWebsitePath.Text)){
				changed=true;
			}
			if(changed){
				DataValid.SetInvalid(InvalidTypes.Prefs);
			}
		}

		private void butLicense_Click(object sender,EventArgs e) {
			FormLicense FormL=new FormLicense();
			FormL.ShowDialog();
		}

		private void butClose_Click(object sender, System.EventArgs e) {
			Close();
		}

		private void FormUpdate_FormClosing(object sender,FormClosingEventArgs e) {
			if(Security.IsAuthorized(Permissions.Setup,DateTime.Now,true)
				&& PrefB.GetBool("UpdateWindowShowsClassicView"))			
			{
				SavePrefs();
			}
		}

		

		

		

	

	

		

	

	}

	
}






















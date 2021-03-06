using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;
using System.Net;
using System.Xml;

namespace OpenDental {
	public partial class FormPatientPortalSetup:Form {
		public FormPatientPortalSetup() {
			InitializeComponent();
			Lan.F(this);
		}

		private void FormPatientPortalSetup_Load(object sender,EventArgs e) {
			textPatientPortalURL.Text=PrefC.GetString(PrefName.PatientPortalURL);
			textBoxNotificationSubject.Text=PrefC.GetString(PrefName.PatientPortalNotifySubject);
			textBoxNotificationBody.Text=PrefC.GetString(PrefName.PatientPortalNotifyBody);
			if(!Security.IsAuthorized(Permissions.Setup)) {
				butOK.Enabled=false;
				buttonGetURL.Enabled=false;
				groupBoxNotification.Enabled=false;
			}
		}

		private void buttonGetURL_Click(object sender,EventArgs e) {
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.IndentChars = ("    ");
			StringBuilder strbuild=new StringBuilder();
			using(XmlWriter writer=XmlWriter.Create(strbuild,settings)) {
				writer.WriteStartElement("CustomerIdRequest");
				writer.WriteStartElement("RegistrationKey");
				writer.WriteString(PrefC.GetString(PrefName.RegistrationKey));
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
#if DEBUG
			OpenDental.localhost.Service1 portalService=new OpenDental.localhost.Service1();
#else
				OpenDental.customerUpdates.Service1 portalService=new OpenDental.customerUpdates.Service1();
				portalService.Url=PrefC.GetString(PrefName.UpdateServerAddress);
#endif
			if(PrefC.GetString(PrefName.UpdateWebProxyAddress) !="") {
				IWebProxy proxy = new WebProxy(PrefC.GetString(PrefName.UpdateWebProxyAddress));
				ICredentials cred=new NetworkCredential(PrefC.GetString(PrefName.UpdateWebProxyUserName),PrefC.GetString(PrefName.UpdateWebProxyPassword));
				proxy.Credentials=cred;
				portalService.Proxy=proxy;
			}
			string patNum="";
			string result=portalService.RequestCustomerID(strbuild.ToString());//may throw error
			XmlDocument doc=new XmlDocument();
			doc.LoadXml(result);
			XmlNode node=doc.SelectSingleNode("//CustomerIdResponse");
			if(node!=null) {
				patNum=node.InnerText;
				textOpenDentalURl.Text="https://www.opendentalsoft.com/PatientPortal/PatientPortal.html?ID="+patNum;
				if(textPatientPortalURL.Text=="") {
					textPatientPortalURL.Text="https://www.opendentalsoft.com/PatientPortal/PatientPortal.html?ID="+patNum;
				}
			}
			if(patNum=="") {
				MsgBox.Show(sender,"You are not currently registered for support with Open Dental Software.");
			}

		}

		private void butOK_Click(object sender,EventArgs e) {
#if !DEBUG
			if(!textPatientPortalURL.Text.ToUpper().StartsWith("HTTPS")) {
				MsgBox.Show(this,"Patient Portal URL must start with HTTPS.");
				return;
			}
#endif
			if(textBoxNotificationSubject.Text=="") {
				MsgBox.Show(this,"Notification Subject is empty");
				textBoxNotificationSubject.Focus();
				return;
			}
			if(textBoxNotificationBody.Text=="") {
				MsgBox.Show(this,"Notification Body is empty");
				textBoxNotificationBody.Focus();
				return;
			}
			if(!textBoxNotificationBody.Text.Contains("[URL]")) { //prompt user that they omitted the URL field but don't prevent them from continuing
				if(!MsgBox.Show(this,MsgBoxButtons.YesNo,"[URL] not included in notification body. Continue without setting the [URL] field?")) {
					textBoxNotificationBody.Focus();
					return;
				}
			}
			if(Prefs.UpdateString(PrefName.PatientPortalURL,textPatientPortalURL.Text)
				| Prefs.UpdateString(PrefName.PatientPortalNotifySubject,textBoxNotificationSubject.Text)
				| Prefs.UpdateString(PrefName.PatientPortalNotifyBody,textBoxNotificationBody.Text)) 
			{
				DataValid.SetInvalid(InvalidType.Prefs);
			}
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}


	}
}
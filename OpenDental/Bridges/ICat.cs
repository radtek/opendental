using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using OpenDentBusiness;

namespace OpenDental.Bridges{
	/// <summary></summary>
	public class ICat{

		/// <summary></summary>
		public ICat() {
			
		}

		///<summary>Command line.</summary>
		public static void SendData(Program ProgramCur, Patient pat){
			if(pat==null) {
				try {
					Process.Start(ProgramCur.Path);//Start iCat without bringing up a pt.
				}
				catch {
					MessageBox.Show(ProgramCur.Path+" is not available.");
				}
				return;
			}
			ArrayList ForProgram=ProgramProperties.GetForProgram(ProgramCur.ProgramNum);
			ProgramProperty PPCur=ProgramProperties.GetCur(ForProgram,"Acquisition computer name");
			//try {
				if(Environment.MachineName.ToUpper()==PPCur.PropertyValue.ToUpper()) {
					SendDataServer(ProgramCur,ForProgram,pat);
				}
				else {
					SendDataWorkstation(ProgramCur,ForProgram,pat);
				}
			//}
			//catch(Exception e) {
			//	MessageBox.Show("Error: "+e.Message);
			//}
		}

		///<summary>XML file.</summary>
		private static void SendDataServer(Program ProgramCur,ArrayList ForProgram,Patient pat) {
			ProgramProperty PPCur=ProgramProperties.GetCur(ForProgram,"Enter 0 to use PatientNum, or 1 to use ChartNum");
			string id="";
			if(PPCur.PropertyValue=="0") {
				id=pat.PatNum.ToString();
			}
			else {
				id=pat.ChartNumber;
			}
			PPCur=ProgramProperties.GetCur(ForProgram,"XML output file path");
			string xmlOutputFile=PPCur.PropertyValue;
			XmlDocument doc=new XmlDocument();
			if(File.Exists(xmlOutputFile)) {
				try {
					doc.Load(xmlOutputFile);
				}
				catch {

				}
			}
			else {
				if(!Directory.Exists(Path.GetDirectoryName(xmlOutputFile))) {
					Directory.CreateDirectory(Path.GetDirectoryName(xmlOutputFile));
				}
			}
			XmlElement elementPatients=doc.DocumentElement;
			if(elementPatients==null) {//if no Patients element, then document is corrupt or new
				doc=new XmlDocument();
				elementPatients=doc.CreateElement("Patients");
				doc.AppendChild(elementPatients);
			}
			//figure out if patient is already in the list------------------------------------------
			bool patAlreadyExists=false;
			XmlElement elementPat=null;
			for(int i=0;i<elementPatients.ChildNodes.Count;i++) {
				if(elementPatients.ChildNodes[i].SelectSingleNode("ID").InnerXml==id) {
					patAlreadyExists=true;
					elementPat=(XmlElement)elementPatients.ChildNodes[i];
				}
			}
			if(patAlreadyExists) {
				elementPat.RemoveAll();//clear it out.
			}
			else {
				elementPat=doc.CreateElement("Patient");
			}
			//add or edit patient-------------------------------------------------------------------------
			XmlElement el=doc.CreateElement("ID");
			el.InnerXml=id;
			elementPat.AppendChild(el);
			//LastName
			el=doc.CreateElement("LastName");
			el.InnerXml=pat.LName;
			elementPat.AppendChild(el);
			//FirstName
			el=doc.CreateElement("FirstName");
			el.InnerXml=pat.FName;
			elementPat.AppendChild(el);
			//MiddleName
			el=doc.CreateElement("MiddleName");
			el.InnerXml=pat.MiddleI;
			elementPat.AppendChild(el);
			//Birthdate
			el=doc.CreateElement("Birthdate");
			el.InnerXml=pat.Birthdate.ToString("yyyy/MM/dd");
			elementPat.AppendChild(el);
			//Gender
			el=doc.CreateElement("Gender");
			if(pat.Gender==PatientGender.Female){
				el.InnerXml="Female";
			}
			else{
				el.InnerXml="Male";
			}
			elementPat.AppendChild(el);
			//Remarks
			el=doc.CreateElement("Remarks");
			el.InnerXml="";
			elementPat.AppendChild(el);
			//ReturnPath
			el=doc.CreateElement("ReturnPath");
			PPCur=ProgramProperties.GetCur(ForProgram,"Return folder path");
			string returnFolder=PPCur.PropertyValue;
			if(!Directory.Exists(returnFolder)) {
				Directory.CreateDirectory(returnFolder);
			}
			el.InnerXml=returnFolder.Replace(@"\","/");
			elementPat.AppendChild(el);
			if(!patAlreadyExists) {
				elementPatients.AppendChild(elementPat);
			}
			//lock file--------------------------------------------------------------------------
			//they say to lock the file.  But I'm the only one writing to it.
			//write text-----------------------------------------------------------------------
			XmlWriterSettings settings=new XmlWriterSettings();
			settings.Indent=true;
			settings.IndentChars="   ";
			XmlWriter writer=XmlWriter.Create(xmlOutputFile,settings);
			doc.Save(writer);
			writer.Close();//This probably "unlocks" the file.
			//unlock file----------------------------------------------------------------------
			//They say to unlock the file here
			Process.Start(xmlOutputFile);
			//MessageBox.Show(
			//MessageBox.Show("Done.");
		}

		///<summary>Command line.</summary>
		private static void SendDataWorkstation(Program ProgramCur,ArrayList ForProgram,Patient pat) {
			ProgramProperty PPCur=ProgramProperties.GetCur(ForProgram,"Enter 0 to use PatientNum, or 1 to use ChartNum");
			string id="";
			if(PPCur.PropertyValue=="0") {
				id=pat.PatNum.ToString();
			} else {
				id=pat.ChartNumber;
			}
			//We are actually supposed to get the program path from the registry. We can enhance that later.
			Process.Start(ProgramCur.Path,"PatientID"+id);
		}

		///<summary></summary>
		public static void StartFileWatcher() {
			ArrayList ForProgram=ProgramProperties.GetForProgram(Programs.GetProgramNum("iCat"));
			ProgramProperty PPCur=ProgramProperties.GetCur(ForProgram,"Return folder path");
			string returnFolder=PPCur.PropertyValue;
			if(!Directory.Exists(returnFolder)) {
				return;
			}
			FileSystemWatcher watcher=new FileSystemWatcher();
			watcher.Created += new FileSystemEventHandler(OnCreated);
			watcher.Renamed += new RenamedEventHandler(OnRenamed);
			watcher.EnableRaisingEvents=true;
			//process all waiting files
			string[] existingFiles=Directory.GetFiles(PPCur.PropertyValue);
			for(int i=0;i<existingFiles.Length;i++) {
				ProcessFile(existingFiles[i]);
			}
		}

		private static void OnCreated(object source,FileSystemEventArgs e) {
			int i=0;
			while(i<5) {
				try {
					ProcessFile(e.FullPath);
					break;
				}
				catch { }
				i++;
			}
		}

		private static void OnRenamed(object source,RenamedEventArgs e) {
			int i=0;
			while(i<5) {
				try {
					ProcessFile(e.FullPath);
					break;
				}
				catch { }
				i++;
			}
		}

		private static void ProcessFile(string fullPath) {
			string filename=Path.GetFileName(fullPath);
			ArrayList ForProgram=ProgramProperties.GetForProgram(Programs.GetProgramNum("iCat"));
			ProgramProperty PPCur=ProgramProperties.GetCur(ForProgram,"XML output file path");
			string xmlOutputFile=PPCur.PropertyValue;
			if(!File.Exists(xmlOutputFile)){
				//No xml file, so nothing to process.
				return;
			}
			XmlDocument docOut=new XmlDocument();
			try {
				docOut.Load(xmlOutputFile);
			}
			catch {
				return;
			}
			/*
				
				=File.ReadAllText(fullPath);
			MessageHL7 msg=new MessageHL7(msgtext);//this creates an entire heirarchy of objects.
			if(msg.MsgType==MessageType.ADT) {
				ADT.ProcessMessage(msg);
			}
			else if(msg.MsgType==MessageType.SIU) {
				SIU.ProcessMessage(msg);
			}
			//we won't be processing DFT messages.
			//else if(msg.MsgType==MessageType.DFT) {
			//ADT.ProcessMessage(msg);
			//}
			File.Delete(fullPath);*/
		}




	}
}











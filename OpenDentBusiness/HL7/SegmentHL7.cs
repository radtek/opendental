﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDentBusiness.HL7 {
	///<summary>A 'row' in the message.  Composed of fields</summary>
	public class SegmentHL7 {
		public List<FieldHL7> Fields;
		///<summary>The name</summary>
		public SegmentName Name;
		///<summary>The original full text of the segment.</summary>
		private string fullText;

		///<summary>Only use this constructor when generating a message instead of parsing a message.</summary>
		internal SegmentHL7(SegmentName name) {
			fullText="";
			Name=name;
			Fields=new List<FieldHL7>();
			//remember that the "field quantity" is one more than the last index, because 0-based.
			//All fields are initially added with just one component
			if(name==SegmentName.MSH) {
				AddFields(12);
			}
			if(name==SegmentName.EVN) {
				AddFields(4);
			}
			if(name==SegmentName.PID) {
				AddFields(20);
			}
			if(name==SegmentName.PV1) {
				AddFields(51);
			}
			if(name==SegmentName.FT1) {
				AddFields(27);
			}
			if(name==SegmentName.DG1) {
				AddFields(5);
			}
			if(name==SegmentName.ZX1){
				AddFields(5);
			}
		}

		private void AddFields(int quantity) {
			FieldHL7 field;
			for(int i=0;i<quantity;i++) {
				field=new FieldHL7();
				Fields.Add(field);
			}
		}

		///<summary>Use this constructor when we have a message to parse.</summary>
		public SegmentHL7(string rowtext) {
			FullText=rowtext;
			
		}

		public override string ToString() {
			return fullText;
		}

		///<summary>Setting the FullText resets all the child fields.</summary>
		public string FullText {
			get {
				return fullText;
			}
			set {
				fullText=value;
				Fields=new List<FieldHL7>();
				string[] fields=fullText.Split(new string[] { "|" },StringSplitOptions.None);
				FieldHL7 field;
				for(int i=0;i<fields.Length;i++) {
					field=new FieldHL7(fields[i]);
					Fields.Add(field);
				}
				switch(Fields[0].FullText) {
					default:
						Name=SegmentName.Unknown;
						break;
					case "MSH":
						Name=SegmentName.MSH;
						break;
					case "EVN":
						Name=SegmentName.EVN;
						break;
					case "PID":
						Name=SegmentName.PID;
						break;
					case "PV1":
						Name=SegmentName.PV1;
						break;
					case "PD1":
						Name=SegmentName.PD1;
						break;
					case "GT1":
						Name=SegmentName.GT1;
						break;
					case "IN1":
						Name=SegmentName.IN1;
						break;
					case "SCH":
						Name=SegmentName.SCH;
						break;
					case "AIG":
						Name=SegmentName.AIG;
						break;
					case "AIL":
						Name=SegmentName.AIL;
						break;
					case "AIP":
						Name=SegmentName.AIP;
						break;
					case "FT1":
						Name=SegmentName.FT1;
						break;
					case "DG1":
						Name=SegmentName.DG1;
						break;
					case "ZX1":
						Name=SegmentName.ZX1;
						break;
				}
			}
		}

		///<summary></summary>
		public string GetFieldFullText(int indexPos) {
			if(indexPos > Fields.Count-1) {
				return "";
			}
			return Fields[indexPos].FullText;
		}

		///<summary>Really just a handy shortcut.  Identical to getting segment 0 or to GetFieldFullText.</summary>
		public string GetFieldComponent(int fieldIndex) {
			return GetFieldFullText(fieldIndex);
		}

		public string GetFieldComponent(int fieldIndex,int segIndex) {
			if(fieldIndex > Fields.Count-1) {
				return "";
			}
			return Fields[fieldIndex].GetComponentVal(segIndex);
		}

		///<summary></summary>
		public FieldHL7 GetField(int indexPos) {
			if(indexPos > Fields.Count-1) {
				return null;
			}
			return Fields[indexPos];
		}

		///<summary>Pass in one val to set the whole field.  Pass in multiple vals to set multiple components.  It also sets the fullText of the segment.</summary>
		public void SetField(int fieldIndex,params string[] vals) {
			Fields[fieldIndex].SetVals(vals);
			//kind of repetitive to recalc the whole segment again here, but it goes very fast.
			fullText="";
			for(int i=0;i<Fields.Count;i++) {
				if(i>0) {
					fullText+="|";
				}
				fullText+=Fields[i].FullText;
			}
		}

	}

	public enum SegmentName {
		///<summary>This can happen for unsupported segments.</summary>
		Unknown,
		///<summary>Message Header</summary>
		MSH,
		///<summary>Event Type</summary>
		EVN,
		///<summary>Patient Identification</summary>
		PID,
		///<summary>Patient Visit</summary>
		PV1,
		///<summary>Patient additional demographics</summary>
		PD1,
		///<summary>Guarantor Information</summary>
		GT1,
		///<summary>Insurance Information</summary>
		IN1,
		///<summary>Scheduling Activity Information</summary>
		SCH,
		///<summary>Db Resource Appointment Information</summary>
		AIG,
		///<summary>Location Resource Appointment Information</summary>
		AIL,
		///<summary>Personnel Resource Appointment Information</summary>
		AIP,
		///<summary>Financial Transaction Information</summary>
		FT1,
		///<summary>Diagnosis Information</summary>
		DG1,
		///<summary>PDF Data</summary>
		ZX1,
	}
}

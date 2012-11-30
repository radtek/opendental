package com.opendental.odweb.client.tabletypes;

import com.google.gwt.xml.client.Document;
import com.google.gwt.xml.client.XMLParser;
import com.opendental.odweb.client.remoting.Serializing;

public class RecallType {
		/** Primary key. */
		public int RecallTypeNum;
		/** . */
		public String Description;
		/** The interval between recalls.  The Interval struct combines years, months, weeks, and days into a single integer value. */
		public int DefaultInterval;
		/** For scheduling the appointment. */
		public String TimePattern;
		/** What procedures to put on the recall appointment.  Comma delimited set of ProcCodes.  (We may change this to CodeNums). */
		public String Procedures;

		/** Deep copy of object. */
		public RecallType Copy() {
			RecallType recalltype=new RecallType();
			recalltype.RecallTypeNum=this.RecallTypeNum;
			recalltype.Description=this.Description;
			recalltype.DefaultInterval=this.DefaultInterval;
			recalltype.TimePattern=this.TimePattern;
			recalltype.Procedures=this.Procedures;
			return recalltype;
		}

		/** Serialize the object into XML. */
		public String SerializeToXml() {
			StringBuilder sb=new StringBuilder();
			sb.append("<RecallType>");
			sb.append("<RecallTypeNum>").append(RecallTypeNum).append("</RecallTypeNum>");
			sb.append("<Description>").append(Serializing.EscapeForXml(Description)).append("</Description>");
			sb.append("<DefaultInterval>").append(DefaultInterval).append("</DefaultInterval>");
			sb.append("<TimePattern>").append(Serializing.EscapeForXml(TimePattern)).append("</TimePattern>");
			sb.append("<Procedures>").append(Serializing.EscapeForXml(Procedures)).append("</Procedures>");
			sb.append("</RecallType>");
			return sb.toString();
		}

		/** Sets the variables for this object based on the values from the XML.
		 * @param xml The XML passed in must be valid and contain a node for every variable on this object.
		 * @throws Exception Deserialize is encased in a try catch and will pass any thrown exception on. */
		public void DeserializeFromXml(String xml) throws Exception {
			try {
				Document doc=XMLParser.parse(xml);
				if(Serializing.GetXmlNodeValue(doc,"RecallTypeNum")!=null) {
					RecallTypeNum=Integer.valueOf(Serializing.GetXmlNodeValue(doc,"RecallTypeNum"));
				}
				if(Serializing.GetXmlNodeValue(doc,"Description")!=null) {
					Description=Serializing.GetXmlNodeValue(doc,"Description");
				}
				if(Serializing.GetXmlNodeValue(doc,"DefaultInterval")!=null) {
					DefaultInterval=Integer.valueOf(Serializing.GetXmlNodeValue(doc,"DefaultInterval"));
				}
				if(Serializing.GetXmlNodeValue(doc,"TimePattern")!=null) {
					TimePattern=Serializing.GetXmlNodeValue(doc,"TimePattern");
				}
				if(Serializing.GetXmlNodeValue(doc,"Procedures")!=null) {
					Procedures=Serializing.GetXmlNodeValue(doc,"Procedures");
				}
			}
			catch(Exception e) {
				throw e;
			}
		}


}
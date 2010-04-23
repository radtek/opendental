//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class SheetFieldDefCrud {
		///<summary>Gets one SheetFieldDef object from the database using the primary key.  Returns null if not found.</summary>
		internal static SheetFieldDef SelectOne(long sheetFieldDefNum){
			string command="SELECT * FROM sheetfielddef "
				+"WHERE SheetFieldDefNum = "+POut.Long(sheetFieldDefNum);
			List<SheetFieldDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one SheetFieldDef object from the database using a query.</summary>
		internal static SheetFieldDef SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SheetFieldDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one SheetFieldDef object from the database using a query.</summary>
		internal static List<SheetFieldDef> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SheetFieldDef> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<SheetFieldDef> TableToList(DataTable table){
			List<SheetFieldDef> retVal=new List<SheetFieldDef>();
			SheetFieldDef sheetFieldDef;
			for(int i=0;i<table.Rows.Count;i++) {
				sheetFieldDef=new SheetFieldDef();
				sheetFieldDef.SheetFieldDefNum= PIn.Long  (table.Rows[i]["SheetFieldDefNum"].ToString());
				sheetFieldDef.SheetDefNum     = PIn.Long  (table.Rows[i]["SheetDefNum"].ToString());
				sheetFieldDef.FieldType       = (SheetFieldType)PIn.Int(table.Rows[i]["FieldType"].ToString());
				sheetFieldDef.FieldName       = PIn.String(table.Rows[i]["FieldName"].ToString());
				sheetFieldDef.FieldValue      = PIn.String(table.Rows[i]["FieldValue"].ToString());
				sheetFieldDef.FontSize        = PIn.Float (table.Rows[i]["FontSize"].ToString());
				sheetFieldDef.FontName        = PIn.String(table.Rows[i]["FontName"].ToString());
				sheetFieldDef.FontIsBold      = PIn.Bool  (table.Rows[i]["FontIsBold"].ToString());
				sheetFieldDef.XPos            = PIn.Int   (table.Rows[i]["XPos"].ToString());
				sheetFieldDef.YPos            = PIn.Int   (table.Rows[i]["YPos"].ToString());
				sheetFieldDef.Width           = PIn.Int   (table.Rows[i]["Width"].ToString());
				sheetFieldDef.Height          = PIn.Int   (table.Rows[i]["Height"].ToString());
				sheetFieldDef.GrowthBehavior  = (GrowthBehaviorEnum)PIn.Int(table.Rows[i]["GrowthBehavior"].ToString());
				sheetFieldDef.RadioButtonValue= PIn.String(table.Rows[i]["RadioButtonValue"].ToString());
				retVal.Add(sheetFieldDef);
			}
			return retVal;
		}

		///<summary>Inserts one SheetFieldDef into the database.  Returns the new priKey.</summary>
		internal static long Insert(SheetFieldDef sheetFieldDef){
			return Insert(sheetFieldDef,false);
		}

		///<summary>Inserts one SheetFieldDef into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(SheetFieldDef sheetFieldDef,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				sheetFieldDef.SheetFieldDefNum=ReplicationServers.GetKey("sheetfielddef","SheetFieldDefNum");
			}
			string command="INSERT INTO sheetfielddef (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SheetFieldDefNum,";
			}
			command+="SheetDefNum,FieldType,FieldName,FieldValue,FontSize,FontName,FontIsBold,XPos,YPos,Width,Height,GrowthBehavior,RadioButtonValue) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(sheetFieldDef.SheetFieldDefNum)+",";
			}
			command+=
				     POut.Long  (sheetFieldDef.SheetDefNum)+","
				+    POut.Int   ((int)sheetFieldDef.FieldType)+","
				+"'"+POut.String(sheetFieldDef.FieldName)+"',"
				+"'"+POut.String(sheetFieldDef.FieldValue)+"',"
				+    POut.Float (sheetFieldDef.FontSize)+","
				+"'"+POut.String(sheetFieldDef.FontName)+"',"
				+    POut.Bool  (sheetFieldDef.FontIsBold)+","
				+    POut.Int   (sheetFieldDef.XPos)+","
				+    POut.Int   (sheetFieldDef.YPos)+","
				+    POut.Int   (sheetFieldDef.Width)+","
				+    POut.Int   (sheetFieldDef.Height)+","
				+    POut.Int   ((int)sheetFieldDef.GrowthBehavior)+","
				+"'"+POut.String(sheetFieldDef.RadioButtonValue)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				sheetFieldDef.SheetFieldDefNum=Db.NonQ(command,true);
			}
			return sheetFieldDef.SheetFieldDefNum;
		}

		///<summary>Updates one SheetFieldDef in the database.</summary>
		internal static void Update(SheetFieldDef sheetFieldDef){
			string command="UPDATE sheetfielddef SET "
				+"SheetDefNum     =  "+POut.Long  (sheetFieldDef.SheetDefNum)+", "
				+"FieldType       =  "+POut.Int   ((int)sheetFieldDef.FieldType)+", "
				+"FieldName       = '"+POut.String(sheetFieldDef.FieldName)+"', "
				+"FieldValue      = '"+POut.String(sheetFieldDef.FieldValue)+"', "
				+"FontSize        =  "+POut.Float (sheetFieldDef.FontSize)+", "
				+"FontName        = '"+POut.String(sheetFieldDef.FontName)+"', "
				+"FontIsBold      =  "+POut.Bool  (sheetFieldDef.FontIsBold)+", "
				+"XPos            =  "+POut.Int   (sheetFieldDef.XPos)+", "
				+"YPos            =  "+POut.Int   (sheetFieldDef.YPos)+", "
				+"Width           =  "+POut.Int   (sheetFieldDef.Width)+", "
				+"Height          =  "+POut.Int   (sheetFieldDef.Height)+", "
				+"GrowthBehavior  =  "+POut.Int   ((int)sheetFieldDef.GrowthBehavior)+", "
				+"RadioButtonValue= '"+POut.String(sheetFieldDef.RadioButtonValue)+"' "
				+"WHERE SheetFieldDefNum = "+POut.Long(sheetFieldDef.SheetFieldDefNum);
			Db.NonQ(command);
		}

		///<summary>Updates one SheetFieldDef in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(SheetFieldDef sheetFieldDef,SheetFieldDef oldSheetFieldDef){
			string command="";
			if(sheetFieldDef.SheetDefNum != oldSheetFieldDef.SheetDefNum) {
				if(command!=""){ command+=",";}
				command+="SheetDefNum = "+POut.Long(sheetFieldDef.SheetDefNum)+"";
			}
			if(sheetFieldDef.FieldType != oldSheetFieldDef.FieldType) {
				if(command!=""){ command+=",";}
				command+="FieldType = "+POut.Int   ((int)sheetFieldDef.FieldType)+"";
			}
			if(sheetFieldDef.FieldName != oldSheetFieldDef.FieldName) {
				if(command!=""){ command+=",";}
				command+="FieldName = '"+POut.String(sheetFieldDef.FieldName)+"'";
			}
			if(sheetFieldDef.FieldValue != oldSheetFieldDef.FieldValue) {
				if(command!=""){ command+=",";}
				command+="FieldValue = '"+POut.String(sheetFieldDef.FieldValue)+"'";
			}
			if(sheetFieldDef.FontSize != oldSheetFieldDef.FontSize) {
				if(command!=""){ command+=",";}
				command+="FontSize = "+POut.Float(sheetFieldDef.FontSize)+"";
			}
			if(sheetFieldDef.FontName != oldSheetFieldDef.FontName) {
				if(command!=""){ command+=",";}
				command+="FontName = '"+POut.String(sheetFieldDef.FontName)+"'";
			}
			if(sheetFieldDef.FontIsBold != oldSheetFieldDef.FontIsBold) {
				if(command!=""){ command+=",";}
				command+="FontIsBold = "+POut.Bool(sheetFieldDef.FontIsBold)+"";
			}
			if(sheetFieldDef.XPos != oldSheetFieldDef.XPos) {
				if(command!=""){ command+=",";}
				command+="XPos = "+POut.Int(sheetFieldDef.XPos)+"";
			}
			if(sheetFieldDef.YPos != oldSheetFieldDef.YPos) {
				if(command!=""){ command+=",";}
				command+="YPos = "+POut.Int(sheetFieldDef.YPos)+"";
			}
			if(sheetFieldDef.Width != oldSheetFieldDef.Width) {
				if(command!=""){ command+=",";}
				command+="Width = "+POut.Int(sheetFieldDef.Width)+"";
			}
			if(sheetFieldDef.Height != oldSheetFieldDef.Height) {
				if(command!=""){ command+=",";}
				command+="Height = "+POut.Int(sheetFieldDef.Height)+"";
			}
			if(sheetFieldDef.GrowthBehavior != oldSheetFieldDef.GrowthBehavior) {
				if(command!=""){ command+=",";}
				command+="GrowthBehavior = "+POut.Int   ((int)sheetFieldDef.GrowthBehavior)+"";
			}
			if(sheetFieldDef.RadioButtonValue != oldSheetFieldDef.RadioButtonValue) {
				if(command!=""){ command+=",";}
				command+="RadioButtonValue = '"+POut.String(sheetFieldDef.RadioButtonValue)+"'";
			}
			if(command==""){
				return;
			}
			command="UPDATE sheetfielddef SET "+command
				+" WHERE SheetFieldDefNum = "+POut.Long(sheetFieldDef.SheetFieldDefNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one SheetFieldDef from the database.</summary>
		internal static void Delete(long sheetFieldDefNum){
			string command="DELETE FROM sheetfielddef "
				+"WHERE SheetFieldDefNum = "+POut.Long(sheetFieldDefNum);
			Db.NonQ(command);
		}

				/*
				command="DROP TABLE IF EXISTS sheetfielddef";
				Db.NonQ(command);
				command=@"CREATE TABLE sheetfielddef (
					SheetFieldDefNum bigint NOT NULL auto_increment,
					SheetDefNum bigint NOT NULL,
					FieldType tinyint NOT NULL,
					FieldName varchar(255) NOT NULL,
					FieldValue varchar(255) NOT NULL,
					FontSize float NOT NULL,
					FontName varchar(255) NOT NULL,
					FontIsBold tinyint NOT NULL,
					XPos int NOT NULL,
					YPos int NOT NULL,
					Width int NOT NULL,
					Height int NOT NULL,
					GrowthBehavior tinyint NOT NULL,
					RadioButtonValue varchar(255) NOT NULL,
					PRIMARY KEY (SheetFieldDefNum),
					INDEX(?)
					) DEFAULT CHARSET=utf8";
				*/

	}
}
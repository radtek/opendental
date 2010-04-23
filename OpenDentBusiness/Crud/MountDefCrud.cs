//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	internal class MountDefCrud {
		///<summary>Gets one MountDef object from the database using the primary key.  Returns null if not found.</summary>
		internal static MountDef SelectOne(long mountDefNum){
			string command="SELECT * FROM mountdef "
				+"WHERE MountDefNum = "+POut.Long(mountDefNum);
			List<MountDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one MountDef object from the database using a query.</summary>
		internal static MountDef SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<MountDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one MountDef object from the database using a query.</summary>
		internal static List<MountDef> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<MountDef> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<MountDef> TableToList(DataTable table){
			List<MountDef> retVal=new List<MountDef>();
			MountDef mountDef;
			for(int i=0;i<table.Rows.Count;i++) {
				mountDef=new MountDef();
				mountDef.MountDefNum = PIn.Long  (table.Rows[i]["MountDefNum"].ToString());
				mountDef.Description = PIn.String(table.Rows[i]["Description"].ToString());
				mountDef.ItemOrder   = PIn.Int   (table.Rows[i]["ItemOrder"].ToString());
				mountDef.IsRadiograph= PIn.Bool  (table.Rows[i]["IsRadiograph"].ToString());
				mountDef.Width       = PIn.Int   (table.Rows[i]["Width"].ToString());
				mountDef.Height      = PIn.Int   (table.Rows[i]["Height"].ToString());
				retVal.Add(mountDef);
			}
			return retVal;
		}

		///<summary>Inserts one MountDef into the database.  Returns the new priKey.</summary>
		internal static long Insert(MountDef mountDef){
			return Insert(mountDef,false);
		}

		///<summary>Inserts one MountDef into the database.  Provides option to use the existing priKey.</summary>
		internal static long Insert(MountDef mountDef,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				mountDef.MountDefNum=ReplicationServers.GetKey("mountdef","MountDefNum");
			}
			string command="INSERT INTO mountdef (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="MountDefNum,";
			}
			command+="Description,ItemOrder,IsRadiograph,Width,Height) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(mountDef.MountDefNum)+",";
			}
			command+=
				 "'"+POut.String(mountDef.Description)+"',"
				+    POut.Int   (mountDef.ItemOrder)+","
				+    POut.Bool  (mountDef.IsRadiograph)+","
				+    POut.Int   (mountDef.Width)+","
				+    POut.Int   (mountDef.Height)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				mountDef.MountDefNum=Db.NonQ(command,true);
			}
			return mountDef.MountDefNum;
		}

		///<summary>Updates one MountDef in the database.</summary>
		internal static void Update(MountDef mountDef){
			string command="UPDATE mountdef SET "
				+"Description = '"+POut.String(mountDef.Description)+"', "
				+"ItemOrder   =  "+POut.Int   (mountDef.ItemOrder)+", "
				+"IsRadiograph=  "+POut.Bool  (mountDef.IsRadiograph)+", "
				+"Width       =  "+POut.Int   (mountDef.Width)+", "
				+"Height      =  "+POut.Int   (mountDef.Height)+" "
				+"WHERE MountDefNum = "+POut.Long(mountDef.MountDefNum);
			Db.NonQ(command);
		}

		///<summary>Updates one MountDef in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		internal static void Update(MountDef mountDef,MountDef oldMountDef){
			string command="";
			if(mountDef.Description != oldMountDef.Description) {
				if(command!=""){ command+=",";}
				command+="Description = '"+POut.String(mountDef.Description)+"'";
			}
			if(mountDef.ItemOrder != oldMountDef.ItemOrder) {
				if(command!=""){ command+=",";}
				command+="ItemOrder = "+POut.Int(mountDef.ItemOrder)+"";
			}
			if(mountDef.IsRadiograph != oldMountDef.IsRadiograph) {
				if(command!=""){ command+=",";}
				command+="IsRadiograph = "+POut.Bool(mountDef.IsRadiograph)+"";
			}
			if(mountDef.Width != oldMountDef.Width) {
				if(command!=""){ command+=",";}
				command+="Width = "+POut.Int(mountDef.Width)+"";
			}
			if(mountDef.Height != oldMountDef.Height) {
				if(command!=""){ command+=",";}
				command+="Height = "+POut.Int(mountDef.Height)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE mountdef SET "+command
				+" WHERE MountDefNum = "+POut.Long(mountDef.MountDefNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one MountDef from the database.</summary>
		internal static void Delete(long mountDefNum){
			string command="DELETE FROM mountdef "
				+"WHERE MountDefNum = "+POut.Long(mountDefNum);
			Db.NonQ(command);
		}

				/*
				command="DROP TABLE IF EXISTS mountdef";
				Db.NonQ(command);
				command=@"CREATE TABLE mountdef (
					MountDefNum bigint NOT NULL auto_increment,
					Description varchar(255) NOT NULL,
					ItemOrder int NOT NULL,
					IsRadiograph tinyint NOT NULL,
					Width int NOT NULL,
					Height int NOT NULL,
					PRIMARY KEY (MountDefNum),
					INDEX(?)
					) DEFAULT CHARSET=utf8";
				*/

	}
}
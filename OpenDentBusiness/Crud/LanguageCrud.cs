//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class LanguageCrud {
		///<summary>Gets one Language object from the database using the primary key.  Returns null if not found.</summary>
		public static Language SelectOne(long languageNum){
			string command="SELECT * FROM language "
				+"WHERE LanguageNum = "+POut.Long(languageNum);
			List<Language> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Language object from the database using a query.</summary>
		public static Language SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Language> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Language objects from the database using a query.</summary>
		public static List<Language> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Language> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Language> TableToList(DataTable table){
			List<Language> retVal=new List<Language>();
			Language language;
			for(int i=0;i<table.Rows.Count;i++) {
				language=new Language();
				language.LanguageNum    = PIn.Long  (table.Rows[i]["LanguageNum"].ToString());
				language.EnglishComments= PIn.String(table.Rows[i]["EnglishComments"].ToString());
				language.ClassType      = PIn.String(table.Rows[i]["ClassType"].ToString());
				language.English        = PIn.String(table.Rows[i]["English"].ToString());
				language.IsObsolete     = PIn.Bool  (table.Rows[i]["IsObsolete"].ToString());
				retVal.Add(language);
			}
			return retVal;
		}

		///<summary>Inserts one Language into the database.  Returns the new priKey.</summary>
		public static long Insert(Language language){
			if(DataConnection.DBtype==DatabaseType.Oracle) {
				language.LanguageNum=DbHelper.GetNextOracleKey("language","LanguageNum");
				int loopcount=0;
				while(loopcount<100){
					try {
						return Insert(language,true);
					}
					catch(Oracle.DataAccess.Client.OracleException ex){
						if(ex.Number==1 && ex.Message.ToLower().Contains("unique constraint") && ex.Message.ToLower().Contains("violated")){
							language.LanguageNum++;
							loopcount++;
						}
						else{
							throw ex;
						}
					}
				}
				throw new ApplicationException("Insert failed.  Could not generate primary key.");
			}
			else {
				return Insert(language,false);
			}
		}

		///<summary>Inserts one Language into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Language language,bool useExistingPK){
			if(!useExistingPK && PrefC.RandomKeys) {
				language.LanguageNum=ReplicationServers.GetKey("language","LanguageNum");
			}
			string command="INSERT INTO language (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="LanguageNum,";
			}
			command+="EnglishComments,ClassType,English,IsObsolete) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(language.LanguageNum)+",";
			}
			command+=
				 "'"+POut.String(language.EnglishComments)+"',"
				+"'"+POut.String(language.ClassType)+"',"
				+"'"+POut.String(language.English)+"',"
				+    POut.Bool  (language.IsObsolete)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				language.LanguageNum=Db.NonQ(command,true);
			}
			return language.LanguageNum;
		}

		///<summary>Updates one Language in the database.</summary>
		public static void Update(Language language){
			string command="UPDATE language SET "
				+"EnglishComments= '"+POut.String(language.EnglishComments)+"', "
				+"ClassType      = '"+POut.String(language.ClassType)+"', "
				+"English        = '"+POut.String(language.English)+"', "
				+"IsObsolete     =  "+POut.Bool  (language.IsObsolete)+" "
				+"WHERE LanguageNum = "+POut.Long(language.LanguageNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Language in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.</summary>
		public static void Update(Language language,Language oldLanguage){
			string command="";
			if(language.EnglishComments != oldLanguage.EnglishComments) {
				if(command!=""){ command+=",";}
				command+="EnglishComments = '"+POut.String(language.EnglishComments)+"'";
			}
			if(language.ClassType != oldLanguage.ClassType) {
				if(command!=""){ command+=",";}
				command+="ClassType = '"+POut.String(language.ClassType)+"'";
			}
			if(language.English != oldLanguage.English) {
				if(command!=""){ command+=",";}
				command+="English = '"+POut.String(language.English)+"'";
			}
			if(language.IsObsolete != oldLanguage.IsObsolete) {
				if(command!=""){ command+=",";}
				command+="IsObsolete = "+POut.Bool(language.IsObsolete)+"";
			}
			if(command==""){
				return;
			}
			command="UPDATE language SET "+command
				+" WHERE LanguageNum = "+POut.Long(language.LanguageNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one Language from the database.</summary>
		public static void Delete(long languageNum){
			string command="DELETE FROM language "
				+"WHERE LanguageNum = "+POut.Long(languageNum);
			Db.NonQ(command);
		}

	}
}
using System;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;

namespace Assignment1_UI_Design
{
    class DbHelper : SQLiteOpenHelper
    {
        Context myContex;  // Step 4

        public static string DBName = "myDatabse.db";
        public static string tableName = "User";
        public static string nameFiled = "names";
        public static string id = "id";

        public static string emailValue = "email", nameValue = "name", passwordValue = "password", ageValue = "age";


        public string creatTable = string.Format("Create table {0} ({1} text Primary Key, {2} text, {3} text, {4} Integer)"
            , tableName, emailValue, nameValue, passwordValue, ageValue);


        SQLiteDatabase connectionObj;

        public DbHelper(Context context) : base(context, name: DBName, factory: null, version: 1)
        {
            myContex = context;
            connectionObj = WritableDatabase;
        }


        public override void OnCreate(SQLiteDatabase db)
        {
            Console.WriteLine("My Create Table STM \n \n" + creatTable);
            db.ExecSQL(creatTable);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {

        }

        //Duplicate User check in database while Registering

        public bool duplicateCheck(string emailid, string passwordid)
        {
            bool flag = true;
            // {0}tableName {1}emailValue {2} emailid {3} passwordValue (4) passwordid
            string checkStm = string.Format("Select * from {0} where {1} = '{2}' and {3} = '{4}' ", tableName, emailValue, emailid, passwordValue, passwordid);

            ICursor myresult = connectionObj.RawQuery(checkStm, null);
            if (myresult.Count > 0)
            {
                flag = false;
            }
            return flag;
        }

        //My insert function to insert new user in database
        public void insertValue(string emailValue, string nameValue, string passwordValue, int ageValue)
        {
            string insertStm = string.Format("Insert into {0} values ( '{1}', '{2}', '{3}', {4});",
            tableName, emailValue, nameValue, passwordValue, ageValue);

            Console.WriteLine("My SQL  Insert STM \n  \n" + insertStm);

            connectionObj.ExecSQL(insertStm);

        }

        //My Update Function to update user data 
        public void updateValue(string nameid, int ageid, string emailid)
        {
            //{0} tableName {1}nameValue {2} nameid {3} ageValue {4}ageid {5} emailValue {6}emailid

            string updateStm = string.Format("Update {0} Set {1} = '{2}', {3} = {4} where {5} = '{6}' ", tableName, nameValue, nameid, ageValue, ageid, emailValue, emailid);
            connectionObj.ExecSQL(updateStm);
        }

        //My delete Function to delete user

            public void deleteValue(string emailid)
        {
            //{0} tableName, {1} emailValue {2} emailid
            string deleteStm = string.Format("Delete from {0} where {1}= '{2}'",tableName,emailValue,emailid);
            connectionObj.ExecSQL(deleteStm);
        }

        // My Select data from table function   General Function
        public void selectMydata(string emailid, string passwordid)
        {
            //{0} tableName, {1} emailValue {2} emailid {3} passwordValue {4} passwordid
            string selectStm = string.Format("Select * from {0} where {1} = '{2}' and {3} = '{4}' ", tableName, emailValue, emailid, passwordValue, passwordid);

            ICursor myresut = connectionObj.RawQuery(selectStm, null);

            while (myresut.MoveToNext())
            {
                var myEmail = myresut.GetString(myresut.GetColumnIndexOrThrow(emailValue));
                Console.WriteLine("email from Database :" + myEmail);

                var myName = myresut.GetString(myresut.GetColumnIndexOrThrow(nameValue));
                Console.WriteLine("name from Database :" + myName);

                var myAge = myresut.GetString(myresut.GetColumnIndexOrThrow(ageValue));
                Console.WriteLine("Age from Database :" + myAge);

                var myPassword = myresut.GetString(myresut.GetColumnIndexOrThrow(passwordValue));
                Console.WriteLine("Password from Database :" + myPassword);

            }
        }

        // Funtion to print value and welcome screen returning Icursor
        public ICursor Print2Welcome(string emailid, string passwordid)
        {
            //{0} tableName, {1} emailValue {2} emailid {3} passwordValue {4} passwordid
            string selectStm = string.Format("Select * from {0} where {1} = '{2}' and {3} = '{4}' ", tableName, emailValue, emailid, passwordValue, passwordid);

            ICursor myresut = connectionObj.RawQuery(selectStm, null);

            return myresut;
        }
        public ICursor Print2UserList()
        {
            //{0} tableName, {1} emailValue {2} emailid {3} passwordValue {4} passwordid
            string selectStm1 = string.Format("Select * from {0} ", tableName);

            ICursor myresut1 = connectionObj.RawQuery(selectStm1, null);

            return myresut1;
        }

        public ICursor userData(string emailid)
        {
            //{0} tableName, {1} emailValue {2} emailid
            string selectStm = string.Format("Select * from {0} where {1} = '{2}'", tableName, emailValue, emailid);
            ICursor myresut2 = connectionObj.RawQuery(selectStm, null);

            return myresut2;


        }


    }
}
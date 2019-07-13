using System;
using System.Collections;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Widget;

namespace Assignment1_UI_Design
{
    [Activity(Label = "UserDataActivity")]
    public class UserDataActivity : Activity
    {
        ListView lv1;
        ArrayAdapter myAdaptor;
        DbHelper myDB;
        ArrayList listItem = new ArrayList();

        // Custom Adaptor edited thing
        List<UserObject> myUsersList = new List<UserObject>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            myDB = new DbHelper(this);

            SetContentView(Resource.Layout.activity_userdata);
            string valueFromUserList = Intent.GetStringExtra("email");
            string valueFromUserList1 = Intent.GetStringExtra("name");
            lv1 = FindViewById<ListView>(Resource.Id.listView1);
            Console.WriteLine("Age is $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$" + valueFromUserList1);
            ICursor cs = myDB.userData(valueFromUserList);
            while (cs.MoveToNext())
            {
                // working code
                //listItem.Add(cs.GetString(cs.GetColumnIndexOrThrow("name")));
                //listItem.Add(cs.GetString(cs.GetColumnIndexOrThrow("age")));
                //listItem.Add(cs.GetString(cs.GetColumnIndexOrThrow("password")));

                //custom Adaptor addition
                myUsersList.Add(new UserObject(cs.GetString(cs.GetColumnIndexOrThrow("email")), cs.GetString(cs.GetColumnIndexOrThrow("name")), Resource.Drawable.google_icon));
            }
            //working code
            //myAdaptor = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, listItem);
            //lv1.Adapter = myAdaptor;

            // custom adapton code added
            MyCustomAdapter myAdapter = new MyCustomAdapter(this, myUsersList);
            lv1.Adapter = myAdapter;
        }
    }
}
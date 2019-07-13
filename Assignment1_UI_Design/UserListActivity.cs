using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Widget;

namespace Assignment1_UI_Design
{
    [Activity(Label = "UserListActivity")]
    public class UserListActivity : Activity
    {
        ListView lv1;
        SearchView sv1;
        //ArrayAdapter myAdapterarray;
        DbHelper myDB;

        //ArrayList listUserMail = new ArrayList();


        // Custom Adaptor edited thing
        string emailPrint;

        List<UserObject> myUsersList = new List<UserObject>();

        public static string emailValue = "email";

        //string[] myArray = new string[] { "Sandeep", "Sukhveer" };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_userlist);
            myDB = new DbHelper(this);

            lv1 = FindViewById<ListView>(Resource.Id.listView1);
            sv1 = FindViewById<SearchView>(Resource.Id.searchView1);

            emailPrint = Intent.GetStringExtra("mail");

            // myAdapterarray = Android.Widget.ArrayAdapter( myDB.Print2UserList());
            // ICursor myresult = myDB.Print2UserList();

            // Custom Adaptor Editing
            ICursor cs = myDB.Print2UserList();
            //var myEmail = "";

            while (cs.MoveToNext())
            {
                //myEmail = myresult.GetString(myresult.GetColumnIndexOrThrow(emailValue));
                // working code
                // listUserMail.Add(myresult.GetString(myresult.GetColumnIndexOrThrow(emailValue)));

                //custom Adaptor addition
                myUsersList.Add(new UserObject(cs.GetString(cs.GetColumnIndexOrThrow("email")), cs.GetString(cs.GetColumnIndexOrThrow("name")), Resource.Drawable.google_icon));

            }
            //working Code
            //myAdapterarray = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, listUserMail);
            //lv1.Adapter = myAdapterarray;
            //lv1.ItemClick += Lv1_ItemClick;
            //sv1.QueryTextChange += Sv1_QueryTextChange;


            // custom adapton code added
            MyCustomAdapter myAdapter = new MyCustomAdapter(this, myUsersList);
            lv1.Adapter = myAdapter;
            lv1.ItemClick += Lv1_ItemClick;
            sv1.QueryTextChange += Sv1_QueryTextChange;

        }

        private void Lv1_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
            Console.WriteLine("*******************/n *******************" + index);
            //string myvalue = (string)listUserMail[index];
            //Console.WriteLine("*******************/n *******************" + myvalue);

            //Intent newScreen = new Intent(this, typeof(UserDataActivity));
            //newScreen.PutExtra("email", myvalue);
            //StartActivity(newScreen);

            // custom adaptor code edit

            var myvalue = myUsersList[index];

            Intent newScreen = new Intent(this, typeof(UserDataActivity));
            newScreen.PutExtra("email", myvalue.email);
            newScreen.PutExtra("name", myvalue.name);
            StartActivity(newScreen);
        }

        private void Sv1_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            //var mySearchValue = e.NewText;
            //myAdapterarray.Filter.InvokeFilter(mySearchValue);

            // Searchview after custom adaptor

            if (string.IsNullOrWhiteSpace(e.NewText))
            {
                MyCustomAdapter myAdapter = new MyCustomAdapter(this, myUsersList);
                lv1.Adapter = myAdapter;
            }
            else
            {
                MyCustomAdapter myAdapter = new MyCustomAdapter(this, myUsersList.Where(us => us.email.StartsWith(e.NewText)).ToList());
                lv1.Adapter = myAdapter;
            }
        }
    }
}
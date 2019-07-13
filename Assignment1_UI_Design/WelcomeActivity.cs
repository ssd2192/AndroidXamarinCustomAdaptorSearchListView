using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Assignment1_UI_Design
{
    [Activity(Label = "WelcomeActivity")]
    public class WelcomeActivity : Activity
    {
        //DbHelper class Object
        DbHelper myDB;
        string namePrint, emailPrint;
        int agePrint;
        TextView txt1, txt2, txt3;
        Button updatebtn, deletebtn, userlistbtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_welcome);

            myDB = new DbHelper(this);

            txt1 = FindViewById<TextView>(Resource.Id.textView1);
            txt2 = FindViewById<EditText>(Resource.Id.editText1);
            txt3 = FindViewById<EditText>(Resource.Id.editText2);
            updatebtn = FindViewById<Button>(Resource.Id.button_update);
            deletebtn = FindViewById<Button>(Resource.Id.button_delete);
            userlistbtn = FindViewById<Button>(Resource.Id.button_listuser);

            emailPrint = Intent.GetStringExtra("mail");
            namePrint = Intent.GetStringExtra("name");
            agePrint = Intent.GetIntExtra("age", 0);

            txt1.Text = emailPrint;
            txt2.Text = namePrint;
            txt3.Text = Convert.ToString(agePrint);

            txt2.Enabled = false;
            txt3.Enabled = false;
            updatebtn.Click += editBtnClicEvent;

            userlistbtn.Click += Userlistbtn_Click;



            //Delete button code 

            deletebtn.Click += delegate
            {
                var email = txt1.Text;
                myDB.deleteValue(email);
                new Utils().alertFunction("Delete User", "Delete Succesfull", this);

                Intent newScreen = new Intent(this, typeof(MainActivity));
                StartActivity(newScreen);
            };

            //User List Button
            userlistbtn.Click += delegate
             {
                 //Intent newScreen = new Intent(this, typeof(UserListActivity));
                 //StartActivity(newScreen);

                 // Adaptor Code Edit
                 var email = txt1.Text;
                 var activity2 = new Intent(this, typeof(UserListActivity));
                 activity2.PutExtra("mail", email);
                 StartActivity(activity2);
             };

        }

        private void Userlistbtn_Click(object sender, EventArgs e)
        {
            Intent newWelcome = new Intent(this, typeof(UserListActivity));
            StartActivity(newWelcome);
           
        }

        public void editBtnClicEvent(object sender, EventArgs e)
        {
            if (updatebtn.Text == "Edit")
            {
                txt2.Enabled = true;
                txt3.Enabled = true;
                updatebtn.Text = "Save";
            }
            else 
            {
                var name = txt2.Text;
                int age = Convert.ToInt32(txt3.Text);
                var email = emailPrint;
                myDB.updateValue(name, age, email);
                new Utils().alertFunction("Update", "Successfull", this);
                txt2.Enabled = false;
                txt3.Enabled = false;
                updatebtn.Text = "Edit";

            }
        }
    }
}
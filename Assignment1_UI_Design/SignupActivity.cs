using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace Assignment1_UI_Design
{
    [Activity(Label = "SignupActivity")]
    class SignupActivity : Activity
    {
        EditText name, email, password, age;
        Button btn_submit;

        DbHelper myDB;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_signup);

            name = FindViewById<EditText>(Resource.Id.textInputEditText1);
            email = FindViewById<EditText>(Resource.Id.editText1);
            password = FindViewById<EditText>(Resource.Id.editText2);
            age = FindViewById<EditText>(Resource.Id.editText3);

            btn_submit = FindViewById<Button>(Resource.Id.button1);

           
            myDB = new DbHelper(this);

            btn_submit.Click += delegate
            {
                var nameValue = name.Text;
                var emailValue = email.Text;
                var passwordValue = password.Text;
                var ageValue = age.Text;

                if ((nameValue.Trim().Equals("") || nameValue.Length < 0) ||
                (emailValue.Trim().Equals("") || emailValue.Length < 0) ||
                (passwordValue.Trim().Equals("") || passwordValue.Length < 0) || 
                (ageValue.Trim().Equals("") || ageValue.Length < 0))
                {
                    new Utils().alertFunction("Error", "Please Complete all the fields", this);
                   
                }
                else
                {
                    Console.WriteLine("Inside else of submit");
                    bool flag = myDB.duplicateCheck(emailValue,passwordValue);
                    if (flag==false)
                    {
                        new Utils().alertFunction("Duplicate Value", "Email Already registered", this);
                    }
                    else
                    {
                        myDB.insertValue(emailValue, nameValue, passwordValue, Convert.ToInt32(ageValue));

                        new UtilsSignup().alertFunction("Registration Successfull", "Click Ok to Login", this);
                        //Intent newScreen = new Intent(this, typeof(MainActivity));
                        //StartActivity(newScreen);
                    }
                    
                }

            };
        }
       
    }
}
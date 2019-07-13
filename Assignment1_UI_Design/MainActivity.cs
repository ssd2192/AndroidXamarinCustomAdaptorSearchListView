using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Widget;

namespace Assignment1_UI_Design
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText editText1_email, editText2_pass;
        Button button1_login, signup_button;
        DbHelper myDB;
        
        public static string emailValue = "email", nameValue = "name", passwordValue = "password", ageValue = "age";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

           
            myDB = new DbHelper(this);

            editText1_email = FindViewById<EditText>(Resource.Id.editText1_email);
            editText2_pass = FindViewById<EditText>(Resource.Id.editText2_pass);
            button1_login = FindViewById<Button>(Resource.Id.button1_login);
            signup_button = FindViewById<Button>(Resource.Id.signup_button);

            button1_login.Click += delegate
            {
                var username = editText1_email.Text;
                var password = editText2_pass.Text;

                if ((username.Trim().Equals("") || username.Length < 0) ||
                (password.Trim().Equals("") || password.Length < 0))
                {
                    new Utils().alertFunction("Error", "Please Fill All Fields", this);
                }
                else if (myDB.duplicateCheck(username, password))
                {
                    new Utils().alertFunction("Error", "User Does Not Exist", this);
                }
                else
                {
                    ICursor myresult = myDB.Print2Welcome(username, password);
                    var myEmail = "";
                    var myName = "";
                    var myAge = 0;
                    var myPassword = "";

                    while (myresult.MoveToNext())
                    {
                        myEmail = myresult.GetString(myresult.GetColumnIndexOrThrow(emailValue));
                        myName = myresult.GetString(myresult.GetColumnIndexOrThrow(nameValue));
                        myAge = myresult.GetInt(myresult.GetColumnIndexOrThrow(ageValue));
                        myPassword = myresult.GetString(myresult.GetColumnIndexOrThrow(passwordValue));
                    }

                    var activity2 = new Intent(this, typeof(WelcomeActivity));
                    activity2.PutExtra("mail", myEmail);
                    activity2.PutExtra("name", myName);
                    activity2.PutExtra("age", myAge);
                    StartActivity(activity2);
                }
            };

            signup_button.Click += delegate
            {
                Intent newScreen = new Intent(this, typeof(SignupActivity));
                StartActivity(newScreen);
            };
        }

    }
}
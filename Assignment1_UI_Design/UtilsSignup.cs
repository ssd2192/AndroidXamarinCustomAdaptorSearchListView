using Android.App;
using Android.Content;

namespace Assignment1_UI_Design
{
    class UtilsSignup
    {
        Context myContex;
        AlertDialog.Builder alert;

        public void alertFunction( string title, string message, Context myContex)
        {
            this.myContex = myContex;
            
            alert = new AlertDialog.Builder(myContex);
            
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetPositiveButton("OK", alertOKButtonSignup);
            alert.SetNegativeButton("Cancel", alertOKButtonSignup);
            Dialog myDialog = alert.Create();
            myDialog.Show();

        }

        public void alertOKButtonSignup(object sender, DialogClickEventArgs e)
        {
            Intent newScreen = new Intent(this.myContex, typeof(MainActivity));
            myContex.StartActivity(newScreen);
        }

    }
}
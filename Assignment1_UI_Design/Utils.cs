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
    class Utils
    {
        Context myContex;

        AlertDialog.Builder alert;
        //Context myContex;

        public void alertFunction( string title, string message, Context myContex)
        {
            this.myContex = myContex;
            alert = new Android.App.AlertDialog.Builder(myContex);

            //EventHandler<DialogClickEventArgs> ao = alertOption;
            //DialogClickEventArgs ao = (DialogClickEventArgs)alertOption;

            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetPositiveButton("OK", alertOKButton);
            alert.SetNegativeButton("Cancel", alertOKButton);
            Dialog myDialog = alert.Create();
            myDialog.Show();

        }

        public void alertOKButton(object sender, Android.Content.DialogClickEventArgs e)
        {
        }

    }
}


//IDialogInterfaceOnClickListener
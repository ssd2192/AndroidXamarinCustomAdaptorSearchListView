package md50cf2b8ed417df6c5b92dc7025d6ae81e;


public class MyCustomAdapter
	extends android.widget.BaseAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getItem:(I)Ljava/lang/Object;:GetGetItem_IHandler\n" +
			"n_getCount:()I:GetGetCountHandler\n" +
			"n_getItemId:(I)J:GetGetItemId_IHandler\n" +
			"n_getView:(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;:GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler\n" +
			"";
		mono.android.Runtime.register ("Assignment1_UI_Design.MyCustomAdapter, Assignment1_UI_Design", MyCustomAdapter.class, __md_methods);
	}


	public MyCustomAdapter ()
	{
		super ();
		if (getClass () == MyCustomAdapter.class)
			mono.android.TypeManager.Activate ("Assignment1_UI_Design.MyCustomAdapter, Assignment1_UI_Design", "", this, new java.lang.Object[] {  });
	}


	public java.lang.Object getItem (int p0)
	{
		return n_getItem (p0);
	}

	private native java.lang.Object n_getItem (int p0);


	public int getCount ()
	{
		return n_getCount ();
	}

	private native int n_getCount ();


	public long getItemId (int p0)
	{
		return n_getItemId (p0);
	}

	private native long n_getItemId (int p0);


	public android.view.View getView (int p0, android.view.View p1, android.view.ViewGroup p2)
	{
		return n_getView (p0, p1, p2);
	}

	private native android.view.View n_getView (int p0, android.view.View p1, android.view.ViewGroup p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

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
using Newtonsoft.Json;

namespace App1
{
    [Activity(Label = "CommentActivity")]
    public class CommentActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            List<Comment> Comments = JsonConvert.DeserializeObject<List<Comment>>(Intent.GetStringExtra("Comments"));
            int position = Intent.GetIntExtra("PostPosition", -1);

            ListAdapter = new CommentAdapter(this, Comments, position);
        }
    }
}
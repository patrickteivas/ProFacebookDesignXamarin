using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
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

            SetContentView(Resource.Layout.CommentsAddCommentRow);
            ListAdapter = new CommentAdapter(this, Comments, position);

            Button commentButton = FindViewById<Button>(Resource.Id.addComment);
            commentButton.Click += CommentActivity_Click;
            commentButton.Tag = position;

        }

        public void CommentActivity_Click(object sender, EventArgs e)
        {
            Button commentButton = (Button)sender;
            int position = (int)commentButton.Tag;
            EditText editText = FindViewById<EditText>(Resource.Id.content);

            MainActivity.posts[position].Comments.Add(new Comment
            {
                Name = "TestUser",
                Message = editText.Text,
                Likes = 0
            });
            editText.Text = "";
            ListAdapter = new CommentAdapter(this, MainActivity.posts[position].Comments, position);
        }
    }
}
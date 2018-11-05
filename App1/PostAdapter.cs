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
    class PostAdapter : BaseAdapter<string>
    {
        readonly List<SocialPost> items;
        readonly Activity context;

        public PostAdapter(Activity context, List<SocialPost> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override string this[int position]
        {
            get { return items[position].Name.ToString(); }
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);

            view.FindViewById<TextView>(Resource.Id.name).Text = " " + items[position].Name;
            view.FindViewById<TextView>(Resource.Id.date).Text = " " + items[position].Date;
            view.FindViewById<TextView>(Resource.Id.msg).Text = items[position].Message;
            view.FindViewById<TextView>(Resource.Id.likes).Text = items[position].Likes.ToString() + " Likes";
            view.FindViewById<TextView>(Resource.Id.comments).Text = items[position].Comments.Count() + " Comments";

            view.FindViewById<TextView>(Resource.Id.comments).Click += (sender, e) => CustomAdapter_Comments(position);
            view.FindViewById<TextView>(Resource.Id.likes).Click += (sender, e) => CustomAdapter_Likes(position);

            return view;
        }

        private void CustomAdapter_Likes(int position)
        {
            items[position].Likes++;

        }

        private void CustomAdapter_Comments(int Position)
        {
            Intent commentsActivity = new Intent(context, typeof(CommentActivity));
            commentsActivity.PutExtra("Comments", JsonConvert.SerializeObject(items[Position].Comments));
            context.StartActivity(commentsActivity);
        }
    }
}
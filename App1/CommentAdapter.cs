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

namespace App1
{
    class CommentAdapter : BaseAdapter<string>
    {
        readonly List<Comment> items;
        readonly Activity context;

        public CommentAdapter(Activity context, List<Comment> items) : base()
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
                view = context.LayoutInflater.Inflate(Resource.Layout.CommentsRow, null);

            view.FindViewById<TextView>(Resource.Id.name).Text = " " + items[position].Name;
            view.FindViewById<TextView>(Resource.Id.msg).Text = items[position].Message;
            view.FindViewById<TextView>(Resource.Id.likes).Text = items[position].Likes.ToString() + " Likes";

            view.FindViewById<TextView>(Resource.Id.likes).Click += (sender, e) =>
            {
                if (!items[position].IsLiked) items[position].Likes++;
                else items[position].Likes--;
                //MainActivity.posts[position].Comments[].Likes = items[position].Likes;
                items[position].IsLiked = !items[position].IsLiked;
                view.FindViewById<TextView>(Resource.Id.likes).Text = items[position].Likes.ToString() + " Likes";
            };
            return view;
        }
    }
}
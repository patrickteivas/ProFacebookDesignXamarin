﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
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
            view.FindViewById<TextView>(Resource.Id.date).Text = " " + items[position].Date.ToString("HH:mm");
            view.FindViewById<TextView>(Resource.Id.msg).Text = items[position].Message;

            if(items[position].ContainsPic)
                view.FindViewById<ImageView>(Resource.Id.img).SetImageResource(items[position].Pic);


            view.FindViewById<TextView>(Resource.Id.likes).Text = items[position].Likes.ToString() + " Likes";
            view.FindViewById<TextView>(Resource.Id.comments).Text = items[position].Comments.Count() + " Comments";

            view.FindViewById<TextView>(Resource.Id.comments).Click += (sender, e) => // CustomAdapter_Comments(position);
            {
                Intent commentsActivity = new Intent(context, typeof(CommentActivity));
                commentsActivity.PutExtra("Comments", JsonConvert.SerializeObject(items[position].Comments));
                context.StartActivity(commentsActivity);
            };
            view.FindViewById<TextView>(Resource.Id.likes).Click += (sender, e) => // CustomAdapter_Likes(position);
            {
                if (!items[position].IsLiked) items[position].Likes++;
                else items[position].Likes--;

                MainActivity.posts[position].Likes = items[position].Likes;
                items[position].IsLiked = !items[position].IsLiked;

                MainActivity.posts[position].IsLiked = items[position].IsLiked;
                view.FindViewById<TextView>(Resource.Id.likes).Text = items[position].Likes.ToString() + " Likes";
            };

            return view;
        }

        //public void CustomAdapter_Likes(int position)
        //{
        //    if (!MainActivity.posts[position].IsLiked) MainActivity.posts[position].Likes++;
        //    else  MainActivity.posts[position].Likes--;
        //    MainActivity.posts[position].IsLiked = !MainActivity.posts[position].IsLiked;
        //
        //    Intent mainActivity = new Intent(context, typeof(MainActivity));
        //    mainActivity.SetFlags(ActivityFlags.ClearTop);
        //    mainActivity.SetFlags(ActivityFlags.NoAnimation);
        //    context.StartActivity(mainActivity);
        //}

        //private void CustomAdapter_Comments(int position)
        //{
        //    Intent commentsActivity = new Intent(context, typeof(CommentActivity));
        //    commentsActivity.PutExtra("Comments", JsonConvert.SerializeObject(items[position].Comments));
        //    context.StartActivity(commentsActivity);
        //}
    }
}
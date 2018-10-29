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
    class CustomAdapter : BaseAdapter<string>
    {
        readonly List<Person> items;
        readonly Activity context;

        public CustomAdapter(Activity context, List<Person> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override string this[int position]
        {
            get { return items[position].ToString(); }
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

            view.FindViewById<TextView>(Resource.Id.minMaxTemp).Text = items[position].Temperature;
            MainActivity.SetIcon(items[position].WeatherType, view.FindViewById<ImageView>(Resource.Id.icon));
            return view;
        }
    }
}
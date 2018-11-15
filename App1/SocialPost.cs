﻿using System;
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
    public class SocialPost
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public int Likes { get; set; }
        public DateTimeOffset Date { get; set; }
        public List<Comment> Comments { get; set; }
        public bool IsLiked { get; set; } = false;
        public int Pic { get; set; } = 0;
    }
}
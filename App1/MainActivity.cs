using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.activity_main);

            List<Person> Persons = new List<Person>();

            var person = new Person { Name = "Test1", Message = "See sonum on tekkinud siia ns", Likes = 300, Comments = 400 };
            Persons.Add(person);
            person = new Person { Name = "Test2", Message = "Tahaks kodus olla", Likes = 1, Comments = 54 };
            Persons.Add(person);
            person = new Person { Name = "Test3", Message = "Minecraft on lahe", Likes = 5, Comments = 87 };
            Persons.Add(person);
            person = new Person { Name = "Test4", Message = "SSoon prg hessis", Likes = 10, Comments = 98 };
            Persons.Add(person);
            person = new Person { Name = "Test5", Message = "Pole elu", Likes = 20, Comments = 45 };
            Persons.Add(person);

            ListAdapter = new CustomAdapter(this, Persons);
        }
    }
}
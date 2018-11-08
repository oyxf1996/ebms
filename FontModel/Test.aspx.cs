using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FontModel
{
    public class Person
    {
        public int age;
        public string name;
        public Person(int i, string name)
        {
            this.age = i;
            this.name = name;
        }
    }
    public delegate Person FirstDele(int i);
    public partial class Test : System.Web.UI.Page
    {
        protected int age = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = form1.Controls.Count;
            age = i;
            Person p = f(1);

        }
        protected void show1()
        {
            HttpContext.Current.Response.Write("hello1");
        }

        protected void show2()
        {
            HttpContext.Current.Response.Write("hello2");
        }
        public string getStr()
        {
            return "red";
        }
        public T Get<T>(int num) where T : class,new()
        {
            T t = new T();
            return t;
        }

        Func<int, Person> f = new Func<int, Person>(o => new Person(11, "ww") { age = 10, name = "qq" });
        FirstDele f2 = new FirstDele(o => new Person(11, "ww"));
    }

}
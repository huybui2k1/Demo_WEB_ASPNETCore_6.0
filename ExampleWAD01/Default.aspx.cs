using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExampleWAD01
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (btnClick.Text == "OK")
            //{
            //    btnClick.Text = "Hãy click vào đây !";
            //}
            //else
            //{
            //    btnClick.Text = "OK";
            //}


            //HelloWorldLabel.Text = "Hello, " + TextInput.Text;
        }

        protected void GreetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //HelloWorldLabel.Text = "Hello, " + GreetList.SelectedValue;
        }
    }
}
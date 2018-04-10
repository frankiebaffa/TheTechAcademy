using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TAChallengeEpicSpiesAssetTracker
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] name = new string[0];
                int[] rig = new int[0];
                double[] sub = new double[0];
                ViewState.Add("Name", name);
                ViewState.Add("Rig", rig);
                ViewState.Add("Sub", sub);
            }
            if (Page.IsPostBack)
            {
                //
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string[] name = (string[])ViewState["Name"];
            int[] rig = (int[])ViewState["Rig"];
            double[] sub = (double[])ViewState["Sub"];

            Array.Resize(ref name, name.Length + 1);
            Array.Resize(ref rig, rig.Length + 1);
            Array.Resize(ref sub, sub.Length + 1);

            int newestName = name.GetUpperBound(0);
            int newestRig = rig.GetUpperBound(0);
            int newestSub = sub.GetUpperBound(0);

            name[newestName] = nameBox.Text;
            rig[newestRig] = int.Parse(rigBox.Text);
            sub[newestSub] = double.Parse(subBox.Text);

            ViewState["Name"] = name;
            ViewState["Rig"] = rig;
            ViewState["Sub"] = sub;


            resultLabel.Text = String.Format(
                "Total Elections Rigged: {0}<br />" +
                "Average Acts of Subterfuge per Asset: {1}<br />" +
                "(Last Asset you Added: {2})",
                rig.Sum(),
                sub.Average(),
                name[newestName]);

            nameBox.Text = "";
            rigBox.Text = "";
            subBox.Text = "";
        }
    }
}
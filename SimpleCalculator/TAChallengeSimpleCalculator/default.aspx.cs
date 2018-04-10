using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TAChallengeSimpleCalculator
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            float myResult;
            myResult = float.Parse(oneValue.Text) + float.Parse(twoValue.Text);

            resultLabel.Text = myResult.ToString();
        }

        protected void subtractButton_Click(object sender, EventArgs e)
        {
            float myResult;
            myResult = float.Parse(oneValue.Text) - float.Parse(twoValue.Text);

            resultLabel.Text = myResult.ToString();
        }

        protected void multiplyButton_Click(object sender, EventArgs e)
        {
            float myResult;
            myResult = float.Parse(oneValue.Text) * float.Parse(twoValue.Text);

            resultLabel.Text = myResult.ToString();
        }

        protected void divideButton_Click(object sender, EventArgs e)
        {
            float myResult;
            myResult = float.Parse(oneValue.Text) / float.Parse(twoValue.Text);

            resultLabel.Text = myResult.ToString();
        }
    }
}
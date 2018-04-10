using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TAChallengeConditionRadioButton
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "";
            resultPhoto.ImageUrl = "";

            if (pencilRadio.Checked)
            {
                resultPhoto.ImageUrl = "pencil.png";
                resultLabel.Text = "You have selected Pencil";
            }
            else if (penRadio.Checked)
            {
                resultPhoto.ImageUrl = "pen.png";
                resultLabel.Text = "You have selected Pen";
            }
            else if (phoneRadio.Checked)
            {
                resultPhoto.ImageUrl = "phone.png";
                resultLabel.Text = "You have selected Phone";
            }
            else if (tabletRadio.Checked)
            {
                resultPhoto.ImageUrl = "tablet.png";
                resultLabel.Text = "You have selected Tablet";
            }
            else
            {
                resultLabel.Text = "You need to make a selection.";
            }
        }
    }
}
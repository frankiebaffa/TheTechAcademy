using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TAChallengePostageCalculator
{
    public partial class _default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        protected void handleChange(object sender, EventArgs e)
        {
            change();
        }

        private void change()
        {
            //  check if values in boxes and radios exist
            if (!valuesExist()) return;

            //  determine volume height/width necessary, length optional
            int volume = 0;
            if (!attemptVolume(out volume)) return;

            //  determine postageMultiplier
            double postageMultiplier = getPostageMultiplier();

            //  determine cost of shipping
            double cost = volume * postageMultiplier;

            //  print the result
            resultLabel.Text = String.Format(
                "Your parcel will cost {0:C} to ship",
                cost);
        }

        private bool valuesExist()
        {
            if (!airRadio.Checked
                && !groundRadio.Checked
                && !nextDayRadio.Checked)
                return false;

            if (widthBox.Text.Trim().Length == 0
                || heightBox.Text.Trim().Length == 0)
                return false;
            return true;
        }

        private bool attemptVolume(out int volume)
        {
            volume = 0;
            int width = 0;
            int height = 0;
            int length = 0;

            if (!int.TryParse(widthBox.Text.Trim(), out width))
                return false;
            if(!int.TryParse(heightBox.Text.Trim(), out height))
                return false;
            if (!int.TryParse(lengthBox.Text.Trim(), out length))
                length = 1;

            volume = width * height * length;
            return true;
        }

        private double getPostageMultiplier()
        {
            if (groundRadio.Checked)
                return .15;
            else if (airRadio.Checked)
                return .25;
            else if (nextDayRadio.Checked)
                return .45;
            else
                return 0;
        }
    }
}
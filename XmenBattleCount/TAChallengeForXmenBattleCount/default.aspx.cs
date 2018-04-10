using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TAChallengeForXmenBattleCount
{
    public partial class _default : System.Web.UI.Page
    {    
        protected void Page_Load(object sender, EventArgs e)
        {
            // Wolverine fewest battles
            // Pheonix most battles

            string[] names = new string[] { "Professor X", "Iceman", "Angel", "Beast", "Pheonix", "Cyclops", "Wolverine", "Nightcrawler", "Storm", "Colossus" };
            int[] numbers = new int[] { 7, 9, 12, 15, 17, 13, 2, 6, 8, 13 };

            string result = "";
            int most = 0;
            int least = 0;

            // Your Code Here!
            for (int i = 0; i < numbers.Length; i++)
            {  
                if (numbers[i] > numbers[most])
                {
                    most = i;
                }
                if (numbers[i] < numbers[least])
                {
                    least = i;
                }
            }
            result = String.Format(
                "Most battles belongs to " +
                    "{0} (Value: " +
                    "{1})<br />",
                    names[most],
                    numbers[most].ToString());
            result += String.Format(
                "Least battles belongs to " +
                    "{0} (Value: " +
                    "{1})",
                    names[least],
                    numbers[least].ToString());

            resultLabel.Text = result;
        }
    }
}
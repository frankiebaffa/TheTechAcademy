using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePhunWithStrings
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1.  Reverse your name
            string name = "Frankie Baffa";
            // In my case, the result would be:
            // affaB eiknarF
            string oneOutput = "";
            for (int i = name.Length - 1; i >= 0; i--)
            {
                oneOutput += name[i];
            }


            // 2.  Reverse this sequence:
            string names = "Luke,Leia,Han,Chewbacca";
            // When you're finished it should look like this:
            // Chewbacca,Han,Leia,Luke
            string[] splitString = names.Split(',');
            string twoOutput = "";
            for (int i = splitString.Length - 1; i >= 0; i--)
            {
                twoOutput += splitString[i] + ",";
            }
            twoOutput = twoOutput.Remove(twoOutput.Length - 1);




            // 3. Use the sequence to create ascii art:
            // *****luke*****
            // *****leia*****
            // *****han******
            // **Chewbacca***
            string[] twoSplitString = names.Split(',');
            string threeOutput = "";
            for (int i = 0; i < twoSplitString.Length; i++)
            {
                int x = (twoSplitString[i].Length + 14) / 2;
                threeOutput += twoSplitString[i].PadLeft(x, '*').PadRight(14, '*') + "<br/>";
            }




            // 4. Solve this puzzle:

            string puzzle = "NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNZRY.";

            // Once you fix it with string helper methods, it should read:
            // Now is the time for all good men to come to the aid of their country.

            string fourOutput = "";
            
            fourOutput = puzzle.Replace("Z", "T");
            fourOutput = fourOutput.Replace("remove-me", "");
            fourOutput = fourOutput.ToLower();
            fourOutput = char.ToUpper(fourOutput[0]).ToString() + fourOutput.Substring(1);

            resultLabel.Text = String.Format(
                "{0}<br />" +
                "{1}<br />" +
                "{2}<br />" +
                "{3}",
                oneOutput,
                twoOutput,
                threeOutput,
                fourOutput);
        }
    }
}
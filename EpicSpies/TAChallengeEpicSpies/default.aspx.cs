using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TAChallengeEpicSpies
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //  Load defaults when page is not post back
            if (!Page.IsPostBack)
            {
                //  set variable prevAssignment to today's date and default prevCalendar
                //  to prevAssingment
                prevCalendar.SelectedDate = DateTime.Today;
                prevCalendar.VisibleDate = DateTime.Today;

                //  set variable startAssignment to 14 days after today and default
                //  startCalendar to startAssignment
                startCalendar.SelectedDate = DateTime.Today.AddDays(14);
                startCalendar.VisibleDate = DateTime.Today.AddDays(14);

                //  set variable endAssignment to 21 days after today and default
                //  endCalendar to endAssignment
                endCalendar.SelectedDate = DateTime.Today.AddDays(21);
                endCalendar.VisibleDate = DateTime.Today.AddDays(21);
            }
        }

        protected void assignButton_Click(object sender, EventArgs e)
        {
            //  reset result label when assignButton is clicked
            resultLabel.Text = "";

            DateTime prevAssignment = prevCalendar.SelectedDate;
            DateTime startAssignment = startCalendar.SelectedDate;
            DateTime endAssignment = endCalendar.SelectedDate;

            int prevDay = prevCalendar.SelectedDate.DayOfYear;
            int startDay = startCalendar.SelectedDate.DayOfYear;
            int endDay = endCalendar.SelectedDate.DayOfYear;
            int breakLength = startDay - prevDay;
            int assignmentLength = endDay - startDay;

            //  if break is less than 14 days, return error message and set startCalendar
            //  to 14 days after prevCalendar
            if (breakLength < 14)
            {
                resultLabel.Text = "Error:  Spies require at least 14 days off before re-assignment!";
                startCalendar.SelectedDate = prevCalendar.SelectedDate.AddDays(14);
                startCalendar.VisibleDate = startCalendar.SelectedDate;
            }

            //  if break is 14 days or more, calculate budget and print
            else
            {
                int budget;

                //  if assignment is less than 3 weeks
                if (assignmentLength < 21)
                {
                    budget = assignmentLength * 500;

                    string result = String.Format
                    (
                        "Spy:       {0}" +
                        "<br />Assignment: {1}" +
                        "<br />Budget: {2:C}",
                        nameBox.Text,
                        assignName.Text,
                        budget
                    );

                    resultLabel.Text = result;
                }

                //  if assignment is 3 weeks or longer
                else if (assignmentLength >= 21)
                {
                    budget = (assignmentLength * 500) + 1000;

                    string result = String.Format
                    (
                        "Spy:       {0}" +
                        "<br />Assignment: {1}" +
                        "<br />Budget: {2:C}",
                        nameBox.Text,
                        assignName.Text,
                        budget
                    );

                    resultLabel.Text = result;
                }
            }
        }
    }
}
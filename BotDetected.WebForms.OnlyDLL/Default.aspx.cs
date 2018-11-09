using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BotDetected.WebForms.OnlyDLL
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                bool isHuman = ExampleCaptcha.Validate(CaptchaCodeTextBox.Text);
                CaptchaCodeTextBox.Text = null;

                if (!isHuman)
                {
                    LabelStateCaptcha.Text = "FALIED";
                }
                else
                {
                    LabelStateCaptcha.Text = "SUCCESS";
                }
            }
        }
    }
}
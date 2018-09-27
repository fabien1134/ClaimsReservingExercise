using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClaimsReservingExercise.frmClaimsReservingTool;

namespace ClaimsReservingExercise.Forms
{
    public partial class InputContentModifier : Form
    {
        #region Event and Delegates
        public delegate void UpdateContentHandler(string modifiedInputContent);
        public delegate void InputContentModifierGUIClosingHandler();

        public UpdateContentHandler SaveModifiedFileContent { get; set; }
        public InputContentModifierGUIClosingHandler CloseCleanly { get; set; }
        #endregion

        public InputContentModifier(string m_inputTextContents)
        {
            InitializeComponent();
            rtInputContent.Text = m_inputTextContents;
        }

        //Will ensure the GUI is updated if the input file has been loaded after the GUI has been opened
        public void UpdateGUI(string loadedContent)
        {
            //Ensure the control is manipulated in the main form thread
            if (rtInputContent.InvokeRequired)
            {
                rtInputContent.Invoke(new InputFileLoadedHandler(UpdateGUI), loadedContent);
            }
            else
            {   //controls thread context
                rtInputContent.Text = loadedContent;
                //Display Message when GUI has been updated
                DisplayToolStripLabelMessage("Input File Content Loaded");
            }
        }

        //Ensure the contents are stored in the ClaimsReservingTool's variable
        private void btnUpdateContent_Click(object sender, EventArgs e)
        {
            SaveModifiedFileContent?.Invoke(rtInputContent.Text);
            //Display message stating it has been updated
            DisplayToolStripLabelMessage("Input Content Updated");
        }


        //This method will display a message to the tool strip
        private void DisplayToolStripLabelMessage(string message) => tsslMessage.Text = $"{DateTime.Now} - {message}";

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseCleanly?.Invoke();
            Close();
        }

        //Disable the default close(X) button
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}

using ClaimsReservingExercise.Entities;
using ClaimsReservingExercise.Forms;
using ClaimsReservingExercise.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClaimsReservingExercise.Forms.InputContentModifier;

namespace ClaimsReservingExercise
{
    public partial class frmClaimsReservingTool : Form
    {
        #region Member Variables
        private string m_inputTextContents = default;
        private InputContentModifier m_inputContentModifier = default;
        #endregion

        #region Events Delegates
        public delegate void InputFileLoadedHandler(string loadedContent);
        public InputFileLoadedHandler InputFileLoaded;
        #endregion


        public frmClaimsReservingTool() => InitializeComponent();

        //This method will be responsible for browsing for the file containing the data to be processed
        private async void btnLoadInputFile_Click(object sender, EventArgs e)
        {   //Let the user know the application is processing 
            tspbAppExecutionStatus.Value = 0;
            tspbAppExecutionStatus.Increment(1);
            try
            {
                //Continue processing if a valid file path has been returned
                if (GetPathOfInputFile(out string filePath) == DialogResult.OK)
                {
                    //Store the contents of the file  asynchronously
                    await Task.Run(() => m_inputTextContents = File.ReadAllText(filePath));
                    lblFilePath.Text = $"Loaded File Path: {filePath}";
                    DisplayToolStripLabelMessage("File Loaded");
                    btnViewEdit.Visible = true;
                    //Provide the subscribed input content modifier GUI the loaded contents if subscribed
                    await Task.Run(() => InputFileLoaded?.Invoke(m_inputTextContents));
                }
            }
            catch (Exception ex)
            {
                DisplayToolStripLabelMessage("File Failed To Load");
                MessageBox.Show(this, ex.Message, "Issue Occurred During Loading File");
            }

            //Let the user know the application is processing has stopped
            tspbAppExecutionStatus.Value = 0;
        }

        //Will get the file path of the input text that should be loaded
        private DialogResult GetPathOfInputFile(out string filePath)
        {
            filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select CSV Input File"
            })
            {   //Only continue processing if the result is OK
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    return DialogResult.OK;
                }
            }

            return DialogResult.Cancel;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {   //Close the form
            Close();
        }

        private void frmClaimsReservingTool_Load(object sender, EventArgs e)
        {
            btnViewEdit.Visible = false;
            SetToolStripProgressBar(tspbAppExecutionStatus, 1);
        }

        //Will be used to set tool strip progress bar controls
        private void SetToolStripProgressBar(ToolStripProgressBar toolStripProgressBar, int upperBound)
        {
            toolStripProgressBar.Maximum = upperBound;
        }

        private void btnViewEdit_Click(object sender, EventArgs e)
        {   //Only create a new instance of the form if it has not been already created
            if (m_inputContentModifier == default)
            {   //Ensure the GUI can callback to overwrite input file contents when required
                m_inputContentModifier = new InputContentModifier(m_inputTextContents)
                {
                    SaveModifiedFileContent = new UpdateContentHandler(SaveModifiedContentsHandler),
                    CloseCleanly = new InputContentModifierGUIClosingHandler(InputContentModifierFormClosingHandler)
                };

                //Subscribe the GUI to the event to ensure it control will be updated with the latest
                //Contents from the input file
                InputFileLoaded += m_inputContentModifier.UpdateGUI;

                m_inputContentModifier.Show(this);
                m_inputContentModifier.Visible = true;
                DisplayToolStripLabelMessage("InputContentModifier Opened");
            }
        }

        //This method will ensure the GUI un-subscribes from events and a new GUI
        //and a new instance can be re-opened
        private void InputContentModifierFormClosingHandler()
        {
            InputFileLoaded -= m_inputContentModifier.UpdateGUI;
            //Remove reference to the GUI instance
            m_inputContentModifier = default;
        }


        private void SaveModifiedContentsHandler(string modifiedContents)
        {
            m_inputTextContents = modifiedContents;
            DisplayToolStripLabelMessage("Input File Content Modified");
        }

        //This method will display a message to the tool strip
        private void DisplayToolStripLabelMessage(string message) => tsslMessage.Text = $"{DateTime.Now} - {message}";

        private void btnExecute_Click(object sender, EventArgs e)
        {   //Clear previous results
            rtResult.Text = string.Empty;
            try
            {
                ITextInputValidatingParser inputContentProcessor = new InputContentProcessor();
                var processedInput = inputContentProcessor.ParseTextInput(m_inputTextContents);

                IAccumulator triangeAccumulator = new TriangleAccumalator();
                string result = triangeAccumulator.PresentAccumulatedData(processedInput);
                rtResult.Text = result;
            }
            catch (Exception ex)
            {
                const string errorCaption = "Issue during execution";
                MessageBox.Show(this, ex.Message, errorCaption);
                DisplayToolStripLabelMessage(errorCaption);
            }
        }
    }
}

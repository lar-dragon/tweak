using System;
using System.Windows.Forms;

namespace Tweak
{
    public partial class PromptForm : Form
    {
        public static DialogResult GetText(out string input)
        {
            var promptForm = new PromptForm();
            var dialogResult = promptForm.ShowDialog();
            input = promptForm.Input;
            promptForm.Hide();
            promptForm.Dispose();
            
            return dialogResult;
        }

        private string Input => textBox.Text;

        private PromptForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
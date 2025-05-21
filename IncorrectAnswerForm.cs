using System.Windows.Forms;

namespace Vocabulary
{
    public partial class IncorrectAnswerForm : Form
    {
        public IncorrectAnswerForm()
        {
            InitializeComponent();
        }

        public void SetWord(string word)
        {
            wordBox.Text = word;
        }
    }
}

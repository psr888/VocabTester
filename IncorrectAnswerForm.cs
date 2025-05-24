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

        public void SetCorrectIndex(int index)
        {
            CorrectIndexBox.Text = index.ToString();
        }

        public void SetCorrectDefintion(string defintion)
        {
            CorrectDefintionBox.Text = defintion;
        }
        public void SetCorrectSentence(string sentence)
        {
            CorrectSentenceBox.Text = sentence;
        }
        public void SetWrongIndex(int index)
        {
            WrongIndexBox.Text = index.ToString();
        }
        public void SetWrongDefintion(string defintion)
        {
            WrongDefinitionBox.Text = defintion;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Vocabulary
{
    enum TestMode
    {
        Random,
        Ordered,
        Reverse,
        Alphabetical,
        ReverseAlphabetical,
    }

    public partial class VocabMainForm : Form
    {
        private List<WordEntry> _wordEntries = new List<WordEntry>();
        private List<WordEntry> _workingEntries = new List<WordEntry>();
        private bool _testRunning = false;
        private TestMode _testMode = TestMode.Random;
        private int _currentEntryIndex = 0;
        WordEntry _currentEntry;

        public VocabMainForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (WordBox.Text.Length == 0) { return; }
            if (DefintionBox_1.Text.Length == 0) { return; }

            var word = new WordEntry();
            word.Word = WordBox.Text;

            var def1 = new Defintion();

            def1.Partofspeech = PartOfSpeech1.Text;
            def1.Meaning = DefintionBox_1.Text;
            def1.Sentence = SentenceBox1.Text;

            word.Definitions.Add(def1);

            if (DefintionBox_2.Text.Length != 0)
            {
                var def2 = new Defintion();
                def2.Partofspeech = PartOfSpeech2.Text;
                def2.Meaning = DefintionBox_2.Text;
                def2.Sentence = SentenceBox2.Text;

                word.Definitions.Add(def2);
            }

            if (DefintionBox_3.Text.Length != 0)
            {
                var def3 = new Defintion();
                def3.Partofspeech = PartOfSpeech3.Text;
                def3.Meaning = DefintionBox_3.Text;
                def3.Sentence = SentenceBox3.Text;
                word.Definitions.Add(def3);
            }

            _wordEntries.Add(word);
            NumberofEntriesBox.Text = _wordEntries.Count.ToString();

            WordBox.Text = "";

            PartOfSpeech1.Text = "";
            PartOfSpeech2.Text = "";
            PartOfSpeech3.Text = "";
            DefintionBox_1.Text = "";
            DefintionBox_2.Text = "";
            DefintionBox_3.Text = "";
            SentenceBox1.Text = "";
            SentenceBox2.Text = "";
            SentenceBox3.Text = "";

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var index = int.Parse(SelectEntryBox.Text);

                if (index < 0 || index >= _wordEntries.Count)
                {
                    return;
                }

                var word = _wordEntries[index];
                WordBox.Text = word.Word;

                PartOfSpeech1.Text = word.Definitions[0].Partofspeech;
                DefintionBox_1.Text = word.Definitions[0].Meaning;
                SentenceBox1.Text = word.Definitions[0].Sentence;

                if (word.Definitions.Count > 1)
                {
                    PartOfSpeech2.Text = word.Definitions[1].Partofspeech;
                    DefintionBox_2.Text = word.Definitions[1].Meaning;
                    SentenceBox2.Text = word.Definitions[1].Sentence;
                }
                else
                {
                    PartOfSpeech2.Text = "";
                    DefintionBox_2.Text = "";
                    SentenceBox2.Text = "";
                    DefintionBox_3.Text = "";
                    SentenceBox3.Text = "";
                    return;
                }

                if (word.Definitions.Count > 2)
                {
                    PartOfSpeech3.Text = word.Definitions[2].Partofspeech;
                    DefintionBox_3.Text = word.Definitions[2].Meaning;
                    SentenceBox3.Text = word.Definitions[2].Sentence;
                }
                else
                {
                    PartOfSpeech3.Text = "";
                    DefintionBox_3.Text = "";
                    SentenceBox3.Text = "";
                    return;
                }
            }
            catch (Exception)
            {

            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (_wordEntries.Count == 0) return;
            var saveFileDialog = new SaveFileDialog()
            {
                Filter = string.Format("Vocab File (*{0})|*{0}", ".vocab")
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            try
            {
                string jsonstring = JsonConvert.SerializeObject(_wordEntries);
                File.WriteAllText(saveFileDialog.FileName, jsonstring);
                FileNameBox.Text = saveFileDialog.FileName;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Can't save file.");
            }
        }

        private static List<WordEntry> ReadWordEntries(string filename)
        {
            string jsonString = File.ReadAllText(filename);

            var results = JsonConvert.DeserializeObject<List<WordEntry>>(jsonString);
            return results;
        }

        private async void OpenButton_Click(object sender, EventArgs e)
        {
            _wordEntries.Clear();

            var openFileDialog = new OpenFileDialog
            {
                Filter = string.Format("Vocab file (*{0})|*{0}|All Files (*.*)|*.*", ".vocab")
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            string filename = openFileDialog.FileName;
            string ext = Path.GetExtension(filename);

            var results = await Task.Run(() => ReadWordEntries(filename));
            FileNameBox.Text = openFileDialog.FileName;

            _wordEntries = results;
            NumberofEntriesBox.Text = _wordEntries.Count.ToString();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            if (_testRunning)
                return;
            DisableMode();
            SetUpTest();
        }
        private void DisableMode()
        {
            RandomMode.Enabled = false;
            OrderMode.Enabled = false;
            ReverseOrderMode.Enabled = false;
            AlphabeticalMode.Enabled = false;
            ReverseAlphabeticalMode.Enabled = false;
        }

        private void EnableMode()
        {
            RandomMode.Enabled = true;
            OrderMode.Enabled = true;
            ReverseOrderMode.Enabled = true;
            AlphabeticalMode.Enabled = true;
            ReverseAlphabeticalMode.Enabled = true;
        }

        // TEST CODE
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // The code below is specific for the test

        int _correctBoxIndex = -1;
        int _numberOfTest = 0;
        int _currentTest = 0;
        int _numberCorrect = 0;
        /// </summary>


        private void SetUpTest()
        {
            _workingEntries = new List<WordEntry>(_wordEntries);

            if (_testMode == TestMode.Reverse)
            {
                _workingEntries.Reverse();
            }
            else if (_testMode == TestMode.Alphabetical)
            {
                _workingEntries.Sort((x, y) => string.Compare(x.Word, y.Word));
            }
            else if (_testMode == TestMode.ReverseAlphabetical)
            {
                _workingEntries.Sort((y, x) => string.Compare(x.Word, y.Word));
            }


            var nEntries = _workingEntries.Count;
            if (nEntries < 1)
                return;

            _numberOfTest = nEntries;
            _currentEntryIndex = 0;

            EnableButtonsForTest(true);
            _testRunning = true;
            _currentTest = 0;
            _numberCorrect = 0;
            PercentCorrectBox.Text = " ";
            NumberCorrectBox.Text = "";
            Result_Box.Text = "Starting...";
            SetEntry();
        }

        private void EnableButtonsForTest(bool value)
        {
            AButton.Enabled = value;
            BButton.Enabled = value;
            CButton.Enabled = value;
            DButton.Enabled = value;
        }

        private static string ConstructDefinitions(List<Defintion> defs)
        {
            if (defs.Count == 1)
            {
                var def = defs[0];
                if (def.Partofspeech.Length == 0)
                {
                    return def.Meaning;
                }
                else
                {
                    return string.Format("({0}) {1}", def.Partofspeech, def.Meaning);
                }
            }
            else
            {
                string result = "";
                int count = 1;
                foreach (var def in defs)
                {
                    if (def.Partofspeech.Length == 0)
                    {
                        result += string.Format("{0}. {1}\n", count, def.Meaning);
                    }
                    else
                    {
                        result += string.Format("{0}. ({1}) {2}\n ", count, def.Partofspeech, def.Meaning);
                    }
                    count++;
                }
                return result;
            }
        }

        private void SetEntry()
        {
            if (_testRunning == false || _workingEntries.Count == -1) return;

            string questionCount = String.Format("{0} out of {1}", _currentTest, _numberOfTest);
            QuestionCountBox.Text = questionCount;

            if (_currentTest == _numberOfTest)
            {
                _testRunning = false;
                Result_Box.Text = "Done!";
                EnableButtonsForTest(false);
                EnableMode();
                return;
            }

            // temporary code
            AnswerA.Text = "";
            AnswerB.Text = "";
            AnswerC.Text = "";
            AnswerD.Text = "";
            var nEntries = _workingEntries.Count;
            var rnd = new Random();

            if (_testMode == TestMode.Random)
            {
                var nextEntryIndex = rnd.Next(nEntries);
                _currentEntry = _workingEntries[nextEntryIndex];
                _workingEntries.RemoveAt(nextEntryIndex);
            }
            else // if (_testMode == TestMode.Ordered) or Reverse or Alphabetical
            {
                _currentEntry = _workingEntries[_currentEntryIndex++];
            }

            TestWordBox.Text = _currentEntry.Word;
            _currentTest++;

            _correctBoxIndex = rnd.Next(4);
            switch (_correctBoxIndex)
            {
                case 0:
                    AnswerA.Text = ConstructDefinitions(_currentEntry.Definitions);
                    break;
                case 1:
                    AnswerB.Text = ConstructDefinitions(_currentEntry.Definitions);
                    break;
                case 2:
                    AnswerC.Text = ConstructDefinitions(_currentEntry.Definitions);
                    break;
                case 3:
                    AnswerD.Text = ConstructDefinitions(_currentEntry.Definitions);
                    break;
            }

            var originalIndex = _wordEntries.FindIndex(e => e.Word == _currentEntry.Word);

            List<int> usedEntryIndexes = new List<int>
            {
                originalIndex
            };

            FillEmptyDefinitions(usedEntryIndexes, _correctBoxIndex, _wordEntries.Count);
        }

        private void ShowWrongAnswerForm(int correctIndex, int wrongIndex, string wrongDefinition)
        {
            // Currently the form only shows the word.             
            // You also need to show the correct answer and the sentence.
            // Also show the index of the wrong and correct answer, and the wrongdefinition
            var word = _currentEntry.Word;
            var correctAnswer = ConstructDefinitions(_currentEntry.Definitions);
            var correctSentence = _currentEntry.Definitions[correctIndex].Sentence;
            var form = new IncorrectAnswerForm();
            form.SetWord(word);
        }

        private void AButton_Click(object sender, EventArgs e)
        {
            // Check the correct Index if it = 0, then it's correct
            if (_correctBoxIndex == 0)
            {
                // if correct increase number correct , and put correct in the box
                ++_numberCorrect;
                Result_Box.Text = "Correct!";
            }
            else
            {
                // After testing add this to the other Button_Click methods
                // Also display the other fields
                Result_Box.Text = "Wrong!";
                ShowWrongAnswerForm(_correctBoxIndex, 0, AnswerA.Text);
            }

            // update the % correct
            var percentage = 100 * (double)_numberCorrect / _currentTest;
            PercentCorrectBox.Text = String.Format("{0:0.00}", percentage);
            NumberCorrectBox.Text = String.Format("{0} out of {1}", _numberCorrect, _currentTest);
            // call setEntry
            SetEntry();
        }

        private void BButton_Click(object sender, EventArgs e)
        {
            // Check the correct Index if it = 0, then it's correct
            if (_correctBoxIndex == 1)
            {
                // if correct increase number correct , and put correct in the box
                ++_numberCorrect;
                Result_Box.Text = "Correct!";
            }
            else
            {
                // if wrong, then put incorrect in the box.
                Result_Box.Text = "Wrong!";
            }

            // update the % correct
            var percentage = 100 * (double)_numberCorrect / _currentTest;
            PercentCorrectBox.Text = String.Format("{0:0.00}", percentage);
            NumberCorrectBox.Text = String.Format("{0} out of {1}", _numberCorrect, _currentTest);
            // call setEntry
            SetEntry();

        }

        private void CButton_Click(object sender, EventArgs e)
        {
            // Check the correct Index if it = 0, then it's correct
            if (_correctBoxIndex == 2)
            {
                // if correct increase number correct , and put correct in the box
                ++_numberCorrect;
                Result_Box.Text = "Correct!";
            }
            else
            {
                // if wrong, then put incorrect in the box.
                Result_Box.Text = "Wrong!";
            }

            // update the % correct
            var percentage = 100 * (double)_numberCorrect / _currentTest;
            PercentCorrectBox.Text = String.Format("{0:0.00}", percentage);
            NumberCorrectBox.Text = String.Format("{0} out of {1}", _numberCorrect, _currentTest);
            // call setEntry
            SetEntry();

        }

        private void DButton_Click(object sender, EventArgs e)
        {
            // Check the correct Index if it = 0, then it's correct
            if (_correctBoxIndex == 3)
            {
                // if correct increase number correct , and put correct in the box
                ++_numberCorrect;
                Result_Box.Text = "Correct!";
            }
            else
            {
                // if wrong, then put incorrect in the box.
                Result_Box.Text = "Wrong!";
            }

            // update the % correct
            var percentage = 100 * (double)_numberCorrect / _currentTest;
            PercentCorrectBox.Text = String.Format("{0:0.00}", percentage);
            NumberCorrectBox.Text = String.Format("{0} out of {1}", _numberCorrect, _currentTest);
            // call setEntry
            SetEntry();

        }

        private static int GetNextUnusedEntry(List<int> usedDefinitions, int numberofEntries)
        {
            int count = 0;
            var rnd = new Random();
            int value;

            do
            {
                if (count > 1000)
                    return 0;

                value = rnd.Next(numberofEntries);
                count++;
            } while (usedDefinitions.Contains(value) == true && count < 1000);

            return value;
        }

        private void FillEmptyDefinitions(List<int> usedDefinitions, int correctIndex, int numberOfEntries)
        {
            if (correctIndex != 0)  // A box
            {
                var newIndex = GetNextUnusedEntry(usedDefinitions, numberOfEntries);
                AnswerA.Text = ConstructDefinitions(_wordEntries[newIndex].Definitions);
                usedDefinitions.Add(newIndex);
            }

            if (correctIndex != 1)
            {
                var newIndex = GetNextUnusedEntry(usedDefinitions, numberOfEntries);
                AnswerB.Text = ConstructDefinitions(_wordEntries[newIndex].Definitions);
                usedDefinitions.Add(newIndex);
            }

            if (correctIndex != 2)
            {
                var newIndex = GetNextUnusedEntry(usedDefinitions, numberOfEntries);
                AnswerC.Text = ConstructDefinitions(_wordEntries[newIndex].Definitions);
                usedDefinitions.Add(newIndex);
            }

            if (correctIndex != 3)
            {
                var newIndex = GetNextUnusedEntry(usedDefinitions, numberOfEntries);
                AnswerD.Text = ConstructDefinitions(_wordEntries[newIndex].Definitions);
                usedDefinitions.Add(newIndex);
            }

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            EnableButtonsForTest(false);
            _testRunning = false;
            EnableMode();
            TestWordBox.Text = "";
            Result_Box.Text = "";
            PercentCorrectBox.Text = "";
            AnswerA.Text = "";
            AnswerB.Text = "";
            AnswerC.Text = "";
            AnswerD.Text = "";
            NumberCorrectBox.Text = "";
        }

        private void RandomMode_Click(object sender, EventArgs e)
        {
            _testMode = TestMode.Random;
        }

        private void OrderMode_Click(object sender, EventArgs e)
        {
            _testMode = TestMode.Ordered;
        }

        private void ReverseOrderMode_Click(object sender, EventArgs e)
        {
            _testMode = TestMode.Reverse;
        }

        private void AlphabeticalMode_Click(object sender, EventArgs e)
        {
            _testMode = TestMode.Alphabetical;
        }

        private void ReverseAlphabeticalMode_Click(object sender, EventArgs e)
        {
            _testMode = TestMode.ReverseAlphabetical;
        }
    }
}

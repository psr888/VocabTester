namespace Vocabulary
{
    partial class IncorrectAnswerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            wordBox = new System.Windows.Forms.TextBox();
            Wlabel = new System.Windows.Forms.Label();
            CDlabel = new System.Windows.Forms.Label();
            CorrectDefintionBox = new System.Windows.Forms.TextBox();
            CILabel = new System.Windows.Forms.Label();
            CorrectIndexBox = new System.Windows.Forms.TextBox();
            CSLabel = new System.Windows.Forms.Label();
            CorrectSentenceBox = new System.Windows.Forms.TextBox();
            WIlabel = new System.Windows.Forms.Label();
            WrongIndexBox = new System.Windows.Forms.TextBox();
            WDlabel = new System.Windows.Forms.Label();
            WrongDefinitionBox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // wordBox
            // 
            wordBox.Location = new System.Drawing.Point(54, 6);
            wordBox.Name = "wordBox";
            wordBox.ReadOnly = true;
            wordBox.Size = new System.Drawing.Size(102, 23);
            wordBox.TabIndex = 0;
            // 
            // Wlabel
            // 
            Wlabel.AutoSize = true;
            Wlabel.Location = new System.Drawing.Point(12, 9);
            Wlabel.Name = "Wlabel";
            Wlabel.Size = new System.Drawing.Size(36, 15);
            Wlabel.TabIndex = 1;
            Wlabel.Text = "Word";
            // 
            // CDlabel
            // 
            CDlabel.AutoSize = true;
            CDlabel.Location = new System.Drawing.Point(8, 70);
            CDlabel.Name = "CDlabel";
            CDlabel.Size = new System.Drawing.Size(101, 15);
            CDlabel.TabIndex = 2;
            CDlabel.Text = "Correct Definition";
            // 
            // CorrectDefintionBox
            // 
            CorrectDefintionBox.Location = new System.Drawing.Point(8, 89);
            CorrectDefintionBox.Multiline = true;
            CorrectDefintionBox.Name = "CorrectDefintionBox";
            CorrectDefintionBox.ReadOnly = true;
            CorrectDefintionBox.Size = new System.Drawing.Size(639, 102);
            CorrectDefintionBox.TabIndex = 3;
            // 
            // CILabel
            // 
            CILabel.AutoSize = true;
            CILabel.Location = new System.Drawing.Point(9, 41);
            CILabel.Name = "CILabel";
            CILabel.Size = new System.Drawing.Size(78, 15);
            CILabel.TabIndex = 4;
            CILabel.Text = "Correct Index";
            // 
            // CorrectIndexBox
            // 
            CorrectIndexBox.Location = new System.Drawing.Point(93, 38);
            CorrectIndexBox.Name = "CorrectIndexBox";
            CorrectIndexBox.ReadOnly = true;
            CorrectIndexBox.Size = new System.Drawing.Size(63, 23);
            CorrectIndexBox.TabIndex = 5;
            // 
            // CSLabel
            // 
            CSLabel.AutoSize = true;
            CSLabel.Location = new System.Drawing.Point(8, 201);
            CSLabel.Name = "CSLabel";
            CSLabel.Size = new System.Drawing.Size(97, 15);
            CSLabel.TabIndex = 6;
            CSLabel.Text = "Correct Sentence";
            // 
            // CorrectSentenceBox
            // 
            CorrectSentenceBox.Location = new System.Drawing.Point(9, 219);
            CorrectSentenceBox.Multiline = true;
            CorrectSentenceBox.Name = "CorrectSentenceBox";
            CorrectSentenceBox.ReadOnly = true;
            CorrectSentenceBox.Size = new System.Drawing.Size(638, 51);
            CorrectSentenceBox.TabIndex = 7;
            // 
            // WIlabel
            // 
            WIlabel.AutoSize = true;
            WIlabel.Location = new System.Drawing.Point(7, 299);
            WIlabel.Name = "WIlabel";
            WIlabel.Size = new System.Drawing.Size(75, 15);
            WIlabel.TabIndex = 8;
            WIlabel.Text = "Wrong Index";
            // 
            // WrongIndexBox
            // 
            WrongIndexBox.Location = new System.Drawing.Point(88, 296);
            WrongIndexBox.Name = "WrongIndexBox";
            WrongIndexBox.ReadOnly = true;
            WrongIndexBox.Size = new System.Drawing.Size(66, 23);
            WrongIndexBox.TabIndex = 9;
            // 
            // WDlabel
            // 
            WDlabel.AutoSize = true;
            WDlabel.Location = new System.Drawing.Point(7, 338);
            WDlabel.Name = "WDlabel";
            WDlabel.Size = new System.Drawing.Size(98, 15);
            WDlabel.TabIndex = 10;
            WDlabel.Text = "Wrong Definition";
            // 
            // WrongDefinitionBox
            // 
            WrongDefinitionBox.Location = new System.Drawing.Point(9, 365);
            WrongDefinitionBox.Multiline = true;
            WrongDefinitionBox.Name = "WrongDefinitionBox";
            WrongDefinitionBox.ReadOnly = true;
            WrongDefinitionBox.Size = new System.Drawing.Size(638, 112);
            WrongDefinitionBox.TabIndex = 11;
            // 
            // IncorrectAnswerForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(671, 493);
            Controls.Add(WrongDefinitionBox);
            Controls.Add(WDlabel);
            Controls.Add(WrongIndexBox);
            Controls.Add(WIlabel);
            Controls.Add(CorrectSentenceBox);
            Controls.Add(CSLabel);
            Controls.Add(CorrectIndexBox);
            Controls.Add(CILabel);
            Controls.Add(CorrectDefintionBox);
            Controls.Add(CDlabel);
            Controls.Add(Wlabel);
            Controls.Add(wordBox);
            Name = "IncorrectAnswerForm";
            Text = "Incorrect Answer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox wordBox;
        private System.Windows.Forms.Label Wlabel;
        private System.Windows.Forms.Label CDlabel;
        private System.Windows.Forms.TextBox CorrectDefintionBox;
        private System.Windows.Forms.Label CILabel;
        private System.Windows.Forms.TextBox CorrectIndexBox;
        private System.Windows.Forms.Label CSLabel;
        private System.Windows.Forms.TextBox CorrectSentenceBox;
        private System.Windows.Forms.Label WIlabel;
        private System.Windows.Forms.TextBox WrongIndexBox;
        private System.Windows.Forms.Label WDlabel;
        private System.Windows.Forms.TextBox WrongDefinitionBox;
    }
}
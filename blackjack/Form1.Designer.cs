namespace blackjack
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private System.Windows.Forms.ListBox deckList;

        private void InitializeComponent()
        {
            deckList = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // deckList
            // 
            deckList.ItemHeight = 25;
            deckList.Location = new Point(0, 0);
            deckList.Margin = new Padding(4, 5, 4, 5);
            deckList.Name = "deckList";
            deckList.Size = new Size(170, 154);
            deckList.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(552, 120);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(button1);
            Controls.Add(deckList);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Blackjack";
            ResumeLayout(false);
        }


        #endregion

        private Button button1;
    }
}
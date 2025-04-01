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
        /// 

        private System.Windows.Forms.ListBox deckList;
        private System.Windows.Forms.Button btnShuffle;

        private void InitializeComponent()
        {
            this.btnShuffle = new System.Windows.Forms.Button();
            this.deckList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnShuffle
            // 
            this.btnShuffle.Location = new System.Drawing.Point(12, 12);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(75, 23);
            this.btnShuffle.TabIndex = 0;
            this.btnShuffle.Text = "Shuffle";
            this.btnShuffle.UseVisualStyleBackColor = true;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffleClick);
            // 
            // lstDeck
            // 
            this.deckList.FormattingEnabled = true;
            this.deckList.Location = new System.Drawing.Point(12, 41);
            this.deckList.Name = "deckList";
            this.deckList.Size = new System.Drawing.Size(260, 199);
            this.deckList.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.deckList);
            this.Controls.Add(this.btnShuffle);
            this.Name = "Form1";
            this.Text = "Blackjack";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
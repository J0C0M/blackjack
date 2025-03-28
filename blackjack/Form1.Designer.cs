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
            this.deckList = new ListBox();
            btnShuffle = new Button();
            SuspendLayout();
            // 
            // deckList
            // 
            deckList.ItemHeight = 25;
            deckList.Location = new Point(0, 0);
            deckList.Margin = new Padding(4, 5, 4, 5);
            deckList.Name = "deckList";
            deckList.Size = new Size(166, 179);
            deckList.TabIndex = 0;
            deckList.SelectedIndexChanged += deckList_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(deckList);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Blackjack";
            ResumeLayout(false);
            //
            // btnShuffle
            //
            btnShuffle.Location = new System.Drawing.Point(12, 12);
            btnShuffle.Name = "btnShuffle";
            btnShuffle.Size = new System.Drawing.Size(100, 30);
            btnShuffle.TabIndex = 0;
            btnShuffle.Text = "Shuffle";
            btnShuffle.UseVisualStyleBackColor = true;
            btnShuffle.Click += new System.EventHandler(btnShuffleClick);
        }

        #endregion
    }
}
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
        private System.Windows.Forms.Button btnDeal;  // Added deal button declaration
        private System.Windows.Forms.ListBox playersList;


        private void InitializeComponent()
        {
            btnShuffle = new Button();
            btnDeal = new Button();  // Initialize the deal button
            deckList = new ListBox();
            playersList = new ListBox();
            SuspendLayout();
            // 
            // btnShuffle
            // 
            btnShuffle.Location = new Point(12, 12);
            btnShuffle.Name = "btnShuffle";
            btnShuffle.Size = new Size(75, 23);
            btnShuffle.TabIndex = 0;
            btnShuffle.Text = "Shuffle";
            btnShuffle.UseVisualStyleBackColor = true;
            btnShuffle.Click += btnShuffleClick;
            // 
            // btnDeal
            // 
            btnDeal.Location = new Point(93, 12);
            btnDeal.Name = "btnDeal";
            btnDeal.Size = new Size(75, 23);
            btnDeal.TabIndex = 2;
            btnDeal.Text = "Deal";
            btnDeal.UseVisualStyleBackColor = true;
            btnDeal.Click += btnDealClick;
            // 
            // deckList
            // 
            deckList.FormattingEnabled = true;
            deckList.ItemHeight = 15;
            deckList.Location = new Point(12, 41);
            deckList.Name = "deckList";
            deckList.Size = new Size(400, 199);  
            deckList.TabIndex = 1;
            // 
            // playersList
            // 
            playersList.FormattingEnabled = true;
            playersList.ItemHeight = 15;
            playersList.Location = new Point(12, 250);
            playersList.Name = "playersList";
            playersList.Size = new Size(400, 150);  
            playersList.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 420); 
            Controls.Add(playersList);
            Controls.Add(deckList);
            Controls.Add(btnDeal);
            Controls.Add(btnShuffle);
            Name = "Form1";
            Text = "Blackjack";
            ResumeLayout(false);
        }

        #endregion
    }
}
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
        private System.Windows.Forms.ListBox playersList;
        private System.Windows.Forms.Button btnDeal;


        private void InitializeComponent()
        {
            btnShuffle = new System.Windows.Forms.Button();
            deckList = new System.Windows.Forms.ListBox();
            playersList = new System.Windows.Forms.ListBox();
            btnDeal = new System.Windows.Forms.Button();
            SuspendLayout();
            //
            // btnShuffle
            //
            btnShuffle.Location = new System.Drawing.Point(12, 12);
            btnShuffle.Name = "btnShuffle";
            btnShuffle.Size = new System.Drawing.Size(75, 23);
            btnShuffle.TabIndex = 0;
            btnShuffle.Text = "Shuffle";
            btnShuffle.UseVisualStyleBackColor = true;
            btnShuffle.Click += new System.EventHandler(btnShuffleClick);
            //
            // deckList
            //
            deckList.FormattingEnabled = true;
            deckList.Location = new System.Drawing.Point(12, 41);
            deckList.Name = "deckList";
            deckList.Size = new System.Drawing.Size(260, 199);
            deckList.TabIndex = 1;
            //
            // playersList
            //
            playersList.FormattingEnabled = true;
            playersList.Location = new System.Drawing.Point(12, 250);
            playersList.Name = "playersList";
            playersList.Size = new System.Drawing.Size(260, 100);
            playersList.TabIndex = 3;
            //
            // btnDeal
            //
            btnDeal.Location = new System.Drawing.Point(93, 12);
            btnDeal.Name = "btnDeal";
            btnDeal.Size = new System.Drawing.Size(75, 23);
            btnDeal.TabIndex = 2;
            btnDeal.Text = "Deal";
            btnDeal.UseVisualStyleBackColor = true;
            btnDeal.Click += new System.EventHandler(btnDealClick);

            //
            // Form1
            //
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(284, 361);
            Controls.Add(playersList);
            Controls.Add(deckList);
            Controls.Add(btnShuffle);
            Name = "Form1";
            Text = "Blackjack";
            ResumeLayout(false);
        }

        #endregion
    }
}
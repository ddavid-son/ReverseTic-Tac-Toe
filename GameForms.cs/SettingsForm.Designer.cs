
namespace GameForms
{
    partial class SettingsForm
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
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player2CheckBox = new System.Windows.Forms.CheckBox();
            this.Player1TextBox = new System.Windows.Forms.TextBox();
            this.Player2TextBox = new System.Windows.Forms.TextBox();
            this.BoardSizeLabel = new System.Windows.Forms.Label();
            this.UpDownRows = new System.Windows.Forms.NumericUpDown();
            this.UpDownCols = new System.Windows.Forms.NumericUpDown();
            this.ColsLabel = new System.Windows.Forms.Label();
            this.RowsLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.PlayersLabel.ForeColor = System.Drawing.Color.Black;
            this.PlayersLabel.Location = new System.Drawing.Point(37, 24);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(53, 20);
            this.PlayersLabel.TabIndex = 0;
            this.PlayersLabel.Text = "Players:";
            this.PlayersLabel.UseCompatibleTextRendering = true;
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.Player1Label.ForeColor = System.Drawing.Color.Black;
            this.Player1Label.Location = new System.Drawing.Point(55, 57);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(64, 17);
            this.Player1Label.TabIndex = 1;
            this.Player1Label.Text = "Player 1:";
            // 
            // Player2CheckBox
            // 
            this.Player2CheckBox.AutoSize = true;
            this.Player2CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.Player2CheckBox.ForeColor = System.Drawing.Color.Black;
            this.Player2CheckBox.Location = new System.Drawing.Point(33, 89);
            this.Player2CheckBox.Name = "Player2CheckBox";
            this.Player2CheckBox.Size = new System.Drawing.Size(86, 21);
            this.Player2CheckBox.TabIndex = 2;
            this.Player2CheckBox.Text = "Player 2:";
            this.Player2CheckBox.UseVisualStyleBackColor = true;
            this.Player2CheckBox.CheckedChanged += new System.EventHandler(this.Player2CheckBox_CheckedChanged);
            // 
            // Player1TextBox
            // 
            this.Player1TextBox.BackColor = System.Drawing.Color.White;
            this.Player1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.Player1TextBox.Location = new System.Drawing.Point(146, 57);
            this.Player1TextBox.MaxLength = 10;
            this.Player1TextBox.Name = "Player1TextBox";
            this.Player1TextBox.Size = new System.Drawing.Size(100, 22);
            this.Player1TextBox.TabIndex = 3;
            this.Player1TextBox.Text = "Player 1";
            this.Player1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Player2TextBox
            // 
            this.Player2TextBox.BackColor = System.Drawing.Color.White;
            this.Player2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player2TextBox.Enabled = false;
            this.Player2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.Player2TextBox.Location = new System.Drawing.Point(146, 89);
            this.Player2TextBox.MaxLength = 10;
            this.Player2TextBox.Name = "Player2TextBox";
            this.Player2TextBox.Size = new System.Drawing.Size(100, 22);
            this.Player2TextBox.TabIndex = 4;
            this.Player2TextBox.Text = "[Computer]";
            this.Player2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BoardSizeLabel
            // 
            this.BoardSizeLabel.AutoSize = true;
            this.BoardSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.BoardSizeLabel.ForeColor = System.Drawing.Color.Black;
            this.BoardSizeLabel.Location = new System.Drawing.Point(37, 157);
            this.BoardSizeLabel.Name = "BoardSizeLabel";
            this.BoardSizeLabel.Size = new System.Drawing.Size(81, 17);
            this.BoardSizeLabel.TabIndex = 5;
            this.BoardSizeLabel.Text = "Board Size:";
            // 
            // UpDownRows
            // 
            this.UpDownRows.BackColor = System.Drawing.Color.White;
            this.UpDownRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.UpDownRows.Location = new System.Drawing.Point(96, 183);
            this.UpDownRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.UpDownRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.UpDownRows.Name = "UpDownRows";
            this.UpDownRows.Size = new System.Drawing.Size(44, 22);
            this.UpDownRows.TabIndex = 6;
            this.UpDownRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UpDownRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.UpDownRows.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // UpDownCols
            // 
            this.UpDownCols.BackColor = System.Drawing.Color.White;
            this.UpDownCols.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.UpDownCols.Location = new System.Drawing.Point(202, 183);
            this.UpDownCols.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.UpDownCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.UpDownCols.Name = "UpDownCols";
            this.UpDownCols.Size = new System.Drawing.Size(44, 22);
            this.UpDownCols.TabIndex = 7;
            this.UpDownCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UpDownCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.UpDownCols.ValueChanged += new System.EventHandler(this.UpDownCols_ValueChanged);
            // 
            // ColsLabel
            // 
            this.ColsLabel.AutoSize = true;
            this.ColsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.ColsLabel.ForeColor = System.Drawing.Color.Black;
            this.ColsLabel.Location = new System.Drawing.Point(161, 188);
            this.ColsLabel.Name = "ColsLabel";
            this.ColsLabel.Size = new System.Drawing.Size(35, 17);
            this.ColsLabel.TabIndex = 8;
            this.ColsLabel.Text = "Cols";
            // 
            // RowsLabel
            // 
            this.RowsLabel.AutoSize = true;
            this.RowsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.RowsLabel.ForeColor = System.Drawing.Color.Black;
            this.RowsLabel.Location = new System.Drawing.Point(48, 188);
            this.RowsLabel.Name = "RowsLabel";
            this.RowsLabel.Size = new System.Drawing.Size(42, 17);
            this.RowsLabel.TabIndex = 9;
            this.RowsLabel.Text = "Rows";
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.SystemColors.Control;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.StartButton.ForeColor = System.Drawing.Color.Black;
            this.StartButton.Location = new System.Drawing.Point(51, 223);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(213, 37);
            this.StartButton.TabIndex = 10;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(305, 272);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.RowsLabel);
            this.Controls.Add(this.ColsLabel);
            this.Controls.Add(this.UpDownCols);
            this.Controls.Add(this.UpDownRows);
            this.Controls.Add(this.BoardSizeLabel);
            this.Controls.Add(this.Player2TextBox);
            this.Controls.Add(this.Player1TextBox);
            this.Controls.Add(this.Player2CheckBox);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.PlayersLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.UpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PlayersLabel;
        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.CheckBox Player2CheckBox;
        private System.Windows.Forms.TextBox Player1TextBox;
        private System.Windows.Forms.TextBox Player2TextBox;
        private System.Windows.Forms.Label BoardSizeLabel;
        private System.Windows.Forms.NumericUpDown UpDownRows;
        private System.Windows.Forms.NumericUpDown UpDownCols;
        private System.Windows.Forms.Label ColsLabel;
        private System.Windows.Forms.Label RowsLabel;
        private System.Windows.Forms.Button StartButton;
    }
}
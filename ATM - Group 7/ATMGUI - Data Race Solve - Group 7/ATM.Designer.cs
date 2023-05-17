
namespace ATM
{
    partial class ATM
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
            this.displayText = new System.Windows.Forms.TextBox();
            this.Balance = new System.Windows.Forms.Button();
            this.Withdraw = new System.Windows.Forms.Button();
            this.insert1 = new System.Windows.Forms.Button();
            this.insert2 = new System.Windows.Forms.Button();
            this.insert3 = new System.Windows.Forms.Button();
            this.insert4 = new System.Windows.Forms.Button();
            this.insert5 = new System.Windows.Forms.Button();
            this.insert6 = new System.Windows.Forms.Button();
            this.insert7 = new System.Windows.Forms.Button();
            this.insert8 = new System.Windows.Forms.Button();
            this.insert9 = new System.Windows.Forms.Button();
            this.insert0 = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.Deposit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // displayText
            // 
            this.displayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayText.Location = new System.Drawing.Point(116, 68);
            this.displayText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.displayText.Multiline = true;
            this.displayText.Name = "displayText";
            this.displayText.ReadOnly = true;
            this.displayText.Size = new System.Drawing.Size(439, 161);
            this.displayText.TabIndex = 0;
            // 
            // Balance
            // 
            this.Balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Balance.Location = new System.Drawing.Point(559, 68);
            this.Balance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(100, 51);
            this.Balance.TabIndex = 3;
            this.Balance.Text = "Balance";
            this.Balance.UseVisualStyleBackColor = true;
            this.Balance.Click += new System.EventHandler(this.balance_Click);
            // 
            // Withdraw
            // 
            this.Withdraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Withdraw.Location = new System.Drawing.Point(559, 123);
            this.Withdraw.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Withdraw.Name = "Withdraw";
            this.Withdraw.Size = new System.Drawing.Size(100, 50);
            this.Withdraw.TabIndex = 4;
            this.Withdraw.Text = "Withdraw";
            this.Withdraw.UseVisualStyleBackColor = true;
            this.Withdraw.Click += new System.EventHandler(this.withdraw_Click);
            // 
            // insert1
            // 
            this.insert1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert1.Location = new System.Drawing.Point(164, 238);
            this.insert1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.insert1.Name = "insert1";
            this.insert1.Size = new System.Drawing.Size(88, 64);
            this.insert1.TabIndex = 7;
            this.insert1.Text = "1";
            this.insert1.UseVisualStyleBackColor = true;
            this.insert1.Click += new System.EventHandler(this.insert1_Click);
            // 
            // insert2
            // 
            this.insert2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert2.Location = new System.Drawing.Point(256, 238);
            this.insert2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.insert2.Name = "insert2";
            this.insert2.Size = new System.Drawing.Size(88, 64);
            this.insert2.TabIndex = 8;
            this.insert2.Text = "2";
            this.insert2.UseVisualStyleBackColor = true;
            this.insert2.Click += new System.EventHandler(this.insert2_Click);
            // 
            // insert3
            // 
            this.insert3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert3.Location = new System.Drawing.Point(348, 238);
            this.insert3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.insert3.Name = "insert3";
            this.insert3.Size = new System.Drawing.Size(88, 64);
            this.insert3.TabIndex = 9;
            this.insert3.Text = "3";
            this.insert3.UseVisualStyleBackColor = true;
            this.insert3.Click += new System.EventHandler(this.insert3_Click);
            // 
            // insert4
            // 
            this.insert4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert4.Location = new System.Drawing.Point(164, 306);
            this.insert4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.insert4.Name = "insert4";
            this.insert4.Size = new System.Drawing.Size(88, 64);
            this.insert4.TabIndex = 10;
            this.insert4.Text = "4";
            this.insert4.UseVisualStyleBackColor = true;
            this.insert4.Click += new System.EventHandler(this.insert4_Click);
            // 
            // insert5
            // 
            this.insert5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert5.Location = new System.Drawing.Point(256, 306);
            this.insert5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.insert5.Name = "insert5";
            this.insert5.Size = new System.Drawing.Size(88, 64);
            this.insert5.TabIndex = 11;
            this.insert5.Text = "5";
            this.insert5.UseVisualStyleBackColor = true;
            this.insert5.Click += new System.EventHandler(this.insert5_Click);
            // 
            // insert6
            // 
            this.insert6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert6.Location = new System.Drawing.Point(348, 306);
            this.insert6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.insert6.Name = "insert6";
            this.insert6.Size = new System.Drawing.Size(88, 64);
            this.insert6.TabIndex = 12;
            this.insert6.Text = "6";
            this.insert6.UseVisualStyleBackColor = true;
            this.insert6.Click += new System.EventHandler(this.insert6_Click);
            // 
            // insert7
            // 
            this.insert7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert7.Location = new System.Drawing.Point(164, 374);
            this.insert7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.insert7.Name = "insert7";
            this.insert7.Size = new System.Drawing.Size(88, 64);
            this.insert7.TabIndex = 13;
            this.insert7.Text = "7";
            this.insert7.UseVisualStyleBackColor = true;
            this.insert7.Click += new System.EventHandler(this.insert7_Click);
            // 
            // insert8
            // 
            this.insert8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert8.Location = new System.Drawing.Point(256, 374);
            this.insert8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.insert8.Name = "insert8";
            this.insert8.Size = new System.Drawing.Size(88, 64);
            this.insert8.TabIndex = 14;
            this.insert8.Text = "8";
            this.insert8.UseVisualStyleBackColor = true;
            this.insert8.Click += new System.EventHandler(this.insert8_Click);
            // 
            // insert9
            // 
            this.insert9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert9.Location = new System.Drawing.Point(348, 374);
            this.insert9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.insert9.Name = "insert9";
            this.insert9.Size = new System.Drawing.Size(88, 64);
            this.insert9.TabIndex = 15;
            this.insert9.Text = "9";
            this.insert9.UseVisualStyleBackColor = true;
            this.insert9.Click += new System.EventHandler(this.insert9_Click);
            // 
            // insert0
            // 
            this.insert0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert0.Location = new System.Drawing.Point(256, 442);
            this.insert0.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.insert0.Name = "insert0";
            this.insert0.Size = new System.Drawing.Size(88, 64);
            this.insert0.TabIndex = 16;
            this.insert0.Text = "0";
            this.insert0.UseVisualStyleBackColor = true;
            this.insert0.Click += new System.EventHandler(this.insert0_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.confirmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmBtn.Location = new System.Drawing.Point(452, 238);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(88, 64);
            this.confirmBtn.TabIndex = 17;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = false;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.Location = new System.Drawing.Point(452, 306);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(88, 64);
            this.clearBtn.TabIndex = 18;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(452, 374);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(88, 64);
            this.exitBtn.TabIndex = 19;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // Deposit
            // 
            this.Deposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deposit.Location = new System.Drawing.Point(559, 177);
            this.Deposit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Deposit.Name = "Deposit";
            this.Deposit.Size = new System.Drawing.Size(100, 52);
            this.Deposit.TabIndex = 20;
            this.Deposit.Text = "Deposit";
            this.Deposit.UseVisualStyleBackColor = true;
            this.Deposit.Click += new System.EventHandler(this.deposit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(689, 536);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("MV Boli", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(118, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 41);
            this.label1.TabIndex = 22;
            this.label1.Text = "IainBank";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox2.Location = new System.Drawing.Point(116, 234);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(439, 272);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // ATM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(677, 526);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Deposit);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.insert0);
            this.Controls.Add(this.insert9);
            this.Controls.Add(this.insert8);
            this.Controls.Add(this.insert7);
            this.Controls.Add(this.insert6);
            this.Controls.Add(this.insert5);
            this.Controls.Add(this.insert4);
            this.Controls.Add(this.insert3);
            this.Controls.Add(this.insert2);
            this.Controls.Add(this.insert1);
            this.Controls.Add(this.Withdraw);
            this.Controls.Add(this.Balance);
            this.Controls.Add(this.displayText);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "ATM";
            this.Text = "      ";
            this.Load += new System.EventHandler(this.ATM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox displayText;
        private System.Windows.Forms.Button Balance;
        private System.Windows.Forms.Button Withdraw;
        private System.Windows.Forms.Button insert1;
        private System.Windows.Forms.Button insert2;
        private System.Windows.Forms.Button insert3;
        private System.Windows.Forms.Button insert4;
        private System.Windows.Forms.Button insert5;
        private System.Windows.Forms.Button insert6;
        private System.Windows.Forms.Button insert7;
        private System.Windows.Forms.Button insert8;
        private System.Windows.Forms.Button insert9;
        private System.Windows.Forms.Button insert0;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button Deposit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}


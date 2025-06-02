using System.Drawing;

namespace Projectt
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UsernameText = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.TicketType = new System.Windows.Forms.Label();
            this.TicketText = new System.Windows.Forms.Label();
            this.TicketBalance = new System.Windows.Forms.Label();
            this.BalanceText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(272, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UsernameText
            // 
            this.UsernameText.AutoSize = true;
            this.UsernameText.Font = new System.Drawing.Font("ArcadeClassic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameText.Location = new System.Drawing.Point(12, 298);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(161, 30);
            this.UsernameText.TabIndex = 1;
            this.UsernameText.Text = "Username :";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("ArcadeClassic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(124)))), ((int)(((byte)(78)))));
            this.Username.Location = new System.Drawing.Point(12, 328);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(77, 30);
            this.Username.TabIndex = 2;
            this.Username.Text = "NULL";
            // 
            // TicketType
            // 
            this.TicketType.AutoSize = true;
            this.TicketType.Font = new System.Drawing.Font("ArcadeClassic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TicketType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(124)))), ((int)(((byte)(78)))));
            this.TicketType.Location = new System.Drawing.Point(12, 414);
            this.TicketType.Name = "TicketType";
            this.TicketType.Size = new System.Drawing.Size(77, 30);
            this.TicketType.TabIndex = 4;
            this.TicketType.Text = "NULL";
            // 
            // TicketText
            // 
            this.TicketText.AutoSize = true;
            this.TicketText.Font = new System.Drawing.Font("ArcadeClassic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TicketText.Location = new System.Drawing.Point(12, 384);
            this.TicketText.Name = "TicketText";
            this.TicketText.Size = new System.Drawing.Size(132, 30);
            this.TicketText.TabIndex = 3;
            this.TicketText.Text = "Ticket : ";
            // 
            // TicketBalance
            // 
            this.TicketBalance.AutoSize = true;
            this.TicketBalance.Font = new System.Drawing.Font("ArcadeClassic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TicketBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(124)))), ((int)(((byte)(78)))));
            this.TicketBalance.Location = new System.Drawing.Point(12, 504);
            this.TicketBalance.Name = "TicketBalance";
            this.TicketBalance.Size = new System.Drawing.Size(77, 30);
            this.TicketBalance.TabIndex = 6;
            this.TicketBalance.Text = "NULL";
            // 
            // BalanceText
            // 
            this.BalanceText.AutoSize = true;
            this.BalanceText.Font = new System.Drawing.Font("ArcadeClassic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BalanceText.Location = new System.Drawing.Point(12, 474);
            this.BalanceText.Name = "BalanceText";
            this.BalanceText.Size = new System.Drawing.Size(144, 30);
            this.BalanceText.TabIndex = 5;
            this.BalanceText.Text = "Balance :";
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(50)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(480, 572);
            this.Controls.Add(this.TicketBalance);
            this.Controls.Add(this.BalanceText);
            this.Controls.Add(this.TicketType);
            this.Controls.Add(this.TicketText);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.UsernameText);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Profile";
            this.Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label UsernameText;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label TicketType;
        private System.Windows.Forms.Label TicketText;
        private System.Windows.Forms.Label TicketBalance;
        private System.Windows.Forms.Label BalanceText;
    }
}
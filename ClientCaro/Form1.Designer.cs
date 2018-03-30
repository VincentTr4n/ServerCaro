namespace ClientCaro
{
    partial class Form1
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
            this.pnBoard = new System.Windows.Forms.Panel();
            this.btConnect = new System.Windows.Forms.Button();
            this.lstUser = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btPvsP = new System.Windows.Forms.Button();
            this.btPvsCom = new System.Windows.Forms.Button();
            this.lbRes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnBoard
            // 
            this.pnBoard.BackColor = System.Drawing.Color.Silver;
            this.pnBoard.Location = new System.Drawing.Point(198, 41);
            this.pnBoard.Name = "pnBoard";
            this.pnBoard.Size = new System.Drawing.Size(501, 501);
            this.pnBoard.TabIndex = 0;
            this.pnBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnBoard_Paint);
            this.pnBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnBoard_MouseClick);
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(624, 10);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 23);
            this.btConnect.TabIndex = 1;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // lstUser
            // 
            this.lstUser.FormattingEnabled = true;
            this.lstUser.Location = new System.Drawing.Point(12, 41);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(180, 394);
            this.lstUser.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "List User Online";
            // 
            // txUserName
            // 
            this.txUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txUserName.Location = new System.Drawing.Point(293, 11);
            this.txUserName.Name = "txUserName";
            this.txUserName.Size = new System.Drawing.Size(193, 21);
            this.txUserName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(207, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "User Name";
            // 
            // txPort
            // 
            this.txPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPort.Location = new System.Drawing.Point(537, 11);
            this.txPort.Name = "txPort";
            this.txPort.Size = new System.Drawing.Size(72, 21);
            this.txPort.TabIndex = 5;
            this.txPort.Text = "9090";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(502, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port";
            // 
            // btPvsP
            // 
            this.btPvsP.Location = new System.Drawing.Point(12, 441);
            this.btPvsP.Name = "btPvsP";
            this.btPvsP.Size = new System.Drawing.Size(83, 23);
            this.btPvsP.TabIndex = 7;
            this.btPvsP.Text = "P vs P";
            this.btPvsP.UseVisualStyleBackColor = true;
            this.btPvsP.Click += new System.EventHandler(this.btPvP_Click);
            // 
            // btPvsCom
            // 
            this.btPvsCom.Location = new System.Drawing.Point(101, 441);
            this.btPvsCom.Name = "btPvsCom";
            this.btPvsCom.Size = new System.Drawing.Size(91, 23);
            this.btPvsCom.TabIndex = 8;
            this.btPvsCom.Text = "P vs COM";
            this.btPvsCom.UseVisualStyleBackColor = true;
            this.btPvsCom.Click += new System.EventHandler(this.btPvsCom_Click);
            // 
            // lbRes
            // 
            this.lbRes.AutoSize = true;
            this.lbRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRes.ForeColor = System.Drawing.Color.Red;
            this.lbRes.Location = new System.Drawing.Point(12, 508);
            this.lbRes.Name = "lbRes";
            this.lbRes.Size = new System.Drawing.Size(29, 20);
            this.lbRes.TabIndex = 9;
            this.lbRes.Text = "....";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(12, 477);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Winner :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 553);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbRes);
            this.Controls.Add(this.btPvsCom);
            this.Controls.Add(this.btPvsP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstUser);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.pnBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnBoard;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.ListBox lstUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btPvsP;
        private System.Windows.Forms.Button btPvsCom;
        private System.Windows.Forms.Label lbRes;
        private System.Windows.Forms.Label label4;
    }
}


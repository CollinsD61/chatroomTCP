namespace client
{
    partial class Client
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
            this.txbMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lsvMessage = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txbMessage
            // 
            this.txbMessage.Location = new System.Drawing.Point(12, 367);
            this.txbMessage.Multiline = true;
            this.txbMessage.Name = "txbMessage";
            this.txbMessage.Size = new System.Drawing.Size(631, 58);
            this.txbMessage.TabIndex = 8;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(669, 367);
            this.btnSend.Name = "btnSend";
            this.btnSend.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSend.Size = new System.Drawing.Size(119, 58);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lsvMessage
            // 
            this.lsvMessage.HideSelection = false;
            this.lsvMessage.Location = new System.Drawing.Point(12, 26);
            this.lsvMessage.Name = "lsvMessage";
            this.lsvMessage.Size = new System.Drawing.Size(776, 306);
            this.lsvMessage.TabIndex = 6;
            this.lsvMessage.UseCompatibleStateImageBehavior = false;
            this.lsvMessage.View = System.Windows.Forms.View.List;
            // 
            // Client
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txbMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lsvMessage);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListView lsvMessage;
    }
}


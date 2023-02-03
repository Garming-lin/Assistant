namespace Assistant.Web
{
    partial class Frm_Web
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Web));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cboxReq = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(351, 21);
            this.textBox1.TabIndex = 1;
            // 
            // cboxReq
            // 
            this.cboxReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxReq.FormattingEnabled = true;
            this.cboxReq.Items.AddRange(new object[] {
            "GET",
            "POST",
            "HEAD",
            "PUT",
            "DELETE",
            "OPTIONS",
            "TRACE",
            "CONNECT"});
            this.cboxReq.Location = new System.Drawing.Point(98, 56);
            this.cboxReq.Name = "cboxReq";
            this.cboxReq.Size = new System.Drawing.Size(117, 20);
            this.cboxReq.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "请求方式：";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(467, 29);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(95, 39);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Frm_Web
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 518);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboxReq);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Web";
            this.Text = "Web助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Web_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Web_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cboxReq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
    }
}
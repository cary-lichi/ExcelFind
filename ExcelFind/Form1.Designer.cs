namespace ExcelFind
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
        private void InitializeComponent()
        {
            this.lab_url = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_target = new System.Windows.Forms.TextBox();
            this.textBox_type = new System.Windows.Forms.TextBox();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.btn_selectUrl = new System.Windows.Forms.Button();
            this.btn_find = new System.Windows.Forms.Button();
            this.listBoxMsg = new System.Windows.Forms.ListBox();
            this.btn_replace = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_newChar = new System.Windows.Forms.TextBox();
            this.lab_progress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_url
            // 
            this.lab_url.AutoSize = true;
            this.lab_url.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lab_url.Location = new System.Drawing.Point(53, 45);
            this.lab_url.Name = "lab_url";
            this.lab_url.Size = new System.Drawing.Size(123, 30);
            this.lab_url.TabIndex = 0;
            this.lab_url.Text = "查找目标：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(53, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "文件类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(97, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "目录：";
            // 
            // textBox_target
            // 
            this.textBox_target.Location = new System.Drawing.Point(182, 51);
            this.textBox_target.Name = "textBox_target";
            this.textBox_target.Size = new System.Drawing.Size(222, 23);
            this.textBox_target.TabIndex = 4;
            // 
            // textBox_type
            // 
            this.textBox_type.Location = new System.Drawing.Point(182, 140);
            this.textBox_type.Name = "textBox_type";
            this.textBox_type.Size = new System.Drawing.Size(222, 23);
            this.textBox_type.TabIndex = 5;
            // 
            // textBox_url
            // 
            this.textBox_url.Location = new System.Drawing.Point(182, 189);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(148, 23);
            this.textBox_url.TabIndex = 6;
            // 
            // btn_selectUrl
            // 
            this.btn_selectUrl.Location = new System.Drawing.Point(336, 189);
            this.btn_selectUrl.Name = "btn_selectUrl";
            this.btn_selectUrl.Size = new System.Drawing.Size(68, 23);
            this.btn_selectUrl.TabIndex = 7;
            this.btn_selectUrl.Text = "选择目录";
            this.btn_selectUrl.UseVisualStyleBackColor = true;
            this.btn_selectUrl.Click += new System.EventHandler(this.Btn_selectUrl_Click);
            // 
            // btn_find
            // 
            this.btn_find.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_find.Location = new System.Drawing.Point(446, 45);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(138, 30);
            this.btn_find.TabIndex = 8;
            this.btn_find.Text = "全部查找";
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.Btn_find_Click);
            // 
            // listBoxMsg
            // 
            this.listBoxMsg.FormattingEnabled = true;
            this.listBoxMsg.ItemHeight = 17;
            this.listBoxMsg.Location = new System.Drawing.Point(12, 326);
            this.listBoxMsg.Name = "listBoxMsg";
            this.listBoxMsg.Size = new System.Drawing.Size(856, 242);
            this.listBoxMsg.TabIndex = 9;
            // 
            // btn_replace
            // 
            this.btn_replace.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_replace.Location = new System.Drawing.Point(446, 91);
            this.btn_replace.Name = "btn_replace";
            this.btn_replace.Size = new System.Drawing.Size(138, 30);
            this.btn_replace.TabIndex = 8;
            this.btn_replace.Text = "在文件中替换";
            this.btn_replace.UseVisualStyleBackColor = true;
            this.btn_replace.Click += new System.EventHandler(this.Btn_replace_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(74, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "替换为：";
            // 
            // textBox_newChar
            // 
            this.textBox_newChar.Location = new System.Drawing.Point(183, 97);
            this.textBox_newChar.Name = "textBox_newChar";
            this.textBox_newChar.Size = new System.Drawing.Size(222, 23);
            this.textBox_newChar.TabIndex = 4;
            // 
            // lab_progress
            // 
            this.lab_progress.AutoSize = true;
            this.lab_progress.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lab_progress.Location = new System.Drawing.Point(62, 246);
            this.lab_progress.Name = "lab_progress";
            this.lab_progress.Size = new System.Drawing.Size(121, 20);
            this.lab_progress.TabIndex = 11;
            this.lab_progress.Text = "当前进度：未开始";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 30);
            this.label5.TabIndex = 3;
            this.label5.Text = "日志如下：";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(878, 589);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lab_progress);
            this.Controls.Add(this.textBox_newChar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.btn_replace);
            this.Controls.Add(this.listBoxMsg);
            this.Controls.Add(this.btn_selectUrl);
            this.Controls.Add(this.textBox_url);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_target);
            this.Controls.Add(this.lab_url);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Excel查询工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_target;
        private System.Windows.Forms.TextBox textBox_type;
        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.Button btn_selectUrl;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.ListBox listBoxMsg;
        private System.Windows.Forms.Button btn_replace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_newChar;
        private System.Windows.Forms.Label lab_pro;
        private System.Windows.Forms.Label lab_progress;
        private System.Windows.Forms.Label label5;
    }
}


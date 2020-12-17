namespace WindowsFormsApp3
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Start = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Debug = new System.Windows.Forms.Button();
            this.blackbuttom = new System.Windows.Forms.Button();
            this.WhiteButtom = new System.Windows.Forms.Button();
            this.StoreExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.About = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Update = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(502, 135);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(98, 43);
            this.Start.TabIndex = 0;
            this.Start.Text = "开始游戏";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(502, 318);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(98, 41);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "退出";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(510, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(524, 450);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 4;
            // 
            // Debug
            // 
            this.Debug.Location = new System.Drawing.Point(502, 52);
            this.Debug.Margin = new System.Windows.Forms.Padding(2);
            this.Debug.Name = "Debug";
            this.Debug.Size = new System.Drawing.Size(69, 18);
            this.Debug.TabIndex = 5;
            this.Debug.Text = "DebugMode";
            this.Debug.UseVisualStyleBackColor = true;
            this.Debug.Visible = false;
            this.Debug.Click += new System.EventHandler(this.Debug_Click);
            // 
            // blackbuttom
            // 
            this.blackbuttom.Location = new System.Drawing.Point(502, 72);
            this.blackbuttom.Name = "blackbuttom";
            this.blackbuttom.Size = new System.Drawing.Size(35, 23);
            this.blackbuttom.TabIndex = 6;
            this.blackbuttom.Text = "黑棋";
            this.blackbuttom.UseVisualStyleBackColor = true;
            this.blackbuttom.Visible = false;
            this.blackbuttom.Click += new System.EventHandler(this.blackbuttom_Click);
            // 
            // WhiteButtom
            // 
            this.WhiteButtom.Location = new System.Drawing.Point(544, 72);
            this.WhiteButtom.Name = "WhiteButtom";
            this.WhiteButtom.Size = new System.Drawing.Size(27, 23);
            this.WhiteButtom.TabIndex = 7;
            this.WhiteButtom.Text = "白棋";
            this.WhiteButtom.UseVisualStyleBackColor = true;
            this.WhiteButtom.Visible = false;
            this.WhiteButtom.Click += new System.EventHandler(this.WhiteButtom_Click);
            // 
            // StoreExit
            // 
            this.StoreExit.Location = new System.Drawing.Point(577, 50);
            this.StoreExit.Name = "StoreExit";
            this.StoreExit.Size = new System.Drawing.Size(45, 45);
            this.StoreExit.TabIndex = 8;
            this.StoreExit.Text = "保存后退出";
            this.StoreExit.UseVisualStyleBackColor = true;
            this.StoreExit.Visible = false;
            this.StoreExit.Click += new System.EventHandler(this.StoreExit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(524, 478);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 9;
            // 
            // About
            // 
            this.About.Location = new System.Drawing.Point(502, 198);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(98, 41);
            this.About.TabIndex = 10;
            this.About.Text = "关于游戏";
            this.About.UseVisualStyleBackColor = true;
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("华文琥珀", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(507, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 36);
            this.label5.TabIndex = 11;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Lime;
            this.label6.Location = new System.Drawing.Point(510, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "开发者模式";
            this.label6.Visible = false;
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(502, 262);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(96, 39);
            this.Update.TabIndex = 13;
            this.Update.Text = "更新日志";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.About);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StoreExit);
            this.Controls.Add(this.WhiteButtom);
            this.Controls.Add(this.blackbuttom);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Start);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "黑白棋小游戏";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Debug;
        private System.Windows.Forms.Button blackbuttom;
        private System.Windows.Forms.Button WhiteButtom;
        private System.Windows.Forms.Button StoreExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button About;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Update;
    }
}


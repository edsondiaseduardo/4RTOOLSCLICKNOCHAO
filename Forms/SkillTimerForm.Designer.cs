namespace _4RTools.Forms
{
    partial class SkillTimerForm
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
            this.txtAutoRefreshDelay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSkillTimerKey = new System.Windows.Forms.TextBox();
            this.lblAutoRefreshKey = new System.Windows.Forms.Label();
            this.lblAutoRefreshDelay = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkClickGround1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAutoRefreshDelay2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSkillTimerKey2 = new System.Windows.Forms.TextBox();
            this.chkClickGround2 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAutoRefreshDelay3 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSkillTimerKey3 = new System.Windows.Forms.TextBox();
            this.chkClickGround3 = new System.Windows.Forms.CheckBox();
            this.groupBoxGroundClick = new System.Windows.Forms.GroupBox();
            this.lblOffsetX = new System.Windows.Forms.Label();
            this.numOffsetX = new System.Windows.Forms.NumericUpDown();
            this.lblOffsetY = new System.Windows.Forms.Label();
            this.numOffsetY = new System.Windows.Forms.NumericUpDown();
            this.lblClickDelay = new System.Windows.Forms.Label();
            this.numClickDelay = new System.Windows.Forms.NumericUpDown();
            this.btnTestClick = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoRefreshDelay)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoRefreshDelay2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoRefreshDelay3)).BeginInit();
            this.groupBoxGroundClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClickDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAutoRefreshDelay
            // 
            this.txtAutoRefreshDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAutoRefreshDelay.Location = new System.Drawing.Point(60, 25);
            this.txtAutoRefreshDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtAutoRefreshDelay.Name = "txtAutoRefreshDelay";
            this.txtAutoRefreshDelay.Size = new System.Drawing.Size(61, 23);
            this.txtAutoRefreshDelay.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label2.Location = new System.Drawing.Point(121, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "sec";
            // 
            // txtSkillTimerKey
            // 
            this.txtSkillTimerKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSkillTimerKey.Location = new System.Drawing.Point(60, 53);
            this.txtSkillTimerKey.Name = "txtSkillTimerKey";
            this.txtSkillTimerKey.Size = new System.Drawing.Size(61, 23);
            this.txtSkillTimerKey.TabIndex = 4;
            // 
            // lblAutoRefreshKey
            // 
            this.lblAutoRefreshKey.AutoSize = true;
            this.lblAutoRefreshKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblAutoRefreshKey.Location = new System.Drawing.Point(30, 57);
            this.lblAutoRefreshKey.Name = "lblAutoRefreshKey";
            this.lblAutoRefreshKey.Size = new System.Drawing.Size(27, 15);
            this.lblAutoRefreshKey.TabIndex = 1;
            this.lblAutoRefreshKey.Text = "Key";
            // 
            // lblAutoRefreshDelay
            // 
            this.lblAutoRefreshDelay.AutoSize = true;
            this.lblAutoRefreshDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblAutoRefreshDelay.Location = new System.Drawing.Point(16, 29);
            this.lblAutoRefreshDelay.Name = "lblAutoRefreshDelay";
            this.lblAutoRefreshDelay.Size = new System.Drawing.Size(38, 15);
            this.lblAutoRefreshDelay.TabIndex = 0;
            this.lblAutoRefreshDelay.Text = "Delay";
            this.lblAutoRefreshDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAutoRefreshDelay);
            this.groupBox1.Controls.Add(this.txtAutoRefreshDelay);
            this.groupBox1.Controls.Add(this.lblAutoRefreshKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSkillTimerKey);
            this.groupBox1.Controls.Add(this.chkClickGround1);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 128);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Skill timer 1";
            //
            // chkClickGround1
            //
            this.chkClickGround1.AutoSize = true;
            this.chkClickGround1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.chkClickGround1.Location = new System.Drawing.Point(16, 84);
            this.chkClickGround1.Name = "chkClickGround1";
            this.chkClickGround1.Size = new System.Drawing.Size(120, 19);
            this.chkClickGround1.TabIndex = 6;
            this.chkClickGround1.Text = "Clicar no chão";
            this.chkClickGround1.UseVisualStyleBackColor = true;
            //
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtAutoRefreshDelay2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtSkillTimerKey2);
            this.groupBox2.Controls.Add(this.chkClickGround2);
            this.groupBox2.Location = new System.Drawing.Point(194, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 128);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Skill timer 2";
            //
            // chkClickGround2
            //
            this.chkClickGround2.AutoSize = true;
            this.chkClickGround2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.chkClickGround2.Location = new System.Drawing.Point(16, 84);
            this.chkClickGround2.Name = "chkClickGround2";
            this.chkClickGround2.Size = new System.Drawing.Size(120, 19);
            this.chkClickGround2.TabIndex = 6;
            this.chkClickGround2.Text = "Clicar no chão";
            this.chkClickGround2.UseVisualStyleBackColor = true;
            //
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Delay";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAutoRefreshDelay2
            // 
            this.txtAutoRefreshDelay2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAutoRefreshDelay2.Location = new System.Drawing.Point(60, 25);
            this.txtAutoRefreshDelay2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtAutoRefreshDelay2.Name = "txtAutoRefreshDelay2";
            this.txtAutoRefreshDelay2.Size = new System.Drawing.Size(61, 23);
            this.txtAutoRefreshDelay2.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label3.Location = new System.Drawing.Point(30, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Key";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label4.Location = new System.Drawing.Point(121, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "sec";
            // 
            // txtSkillTimerKey2
            // 
            this.txtSkillTimerKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSkillTimerKey2.Location = new System.Drawing.Point(60, 53);
            this.txtSkillTimerKey2.Name = "txtSkillTimerKey2";
            this.txtSkillTimerKey2.Size = new System.Drawing.Size(61, 23);
            this.txtSkillTimerKey2.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtAutoRefreshDelay3);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtSkillTimerKey3);
            this.groupBox3.Controls.Add(this.chkClickGround3);
            this.groupBox3.Location = new System.Drawing.Point(373, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 128);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Skill timer 3";
            //
            // chkClickGround3
            //
            this.chkClickGround3.AutoSize = true;
            this.chkClickGround3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.chkClickGround3.Location = new System.Drawing.Point(16, 84);
            this.chkClickGround3.Name = "chkClickGround3";
            this.chkClickGround3.Size = new System.Drawing.Size(120, 19);
            this.chkClickGround3.TabIndex = 6;
            this.chkClickGround3.Text = "Clicar no chão";
            this.chkClickGround3.UseVisualStyleBackColor = true;
            //
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label5.Location = new System.Drawing.Point(16, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Delay";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAutoRefreshDelay3
            // 
            this.txtAutoRefreshDelay3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAutoRefreshDelay3.Location = new System.Drawing.Point(60, 25);
            this.txtAutoRefreshDelay3.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtAutoRefreshDelay3.Name = "txtAutoRefreshDelay3";
            this.txtAutoRefreshDelay3.Size = new System.Drawing.Size(61, 23);
            this.txtAutoRefreshDelay3.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label6.Location = new System.Drawing.Point(30, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Key";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label7.Location = new System.Drawing.Point(121, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "sec";
            // 
            // txtSkillTimerKey3
            // 
            this.txtSkillTimerKey3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSkillTimerKey3.Location = new System.Drawing.Point(60, 53);
            this.txtSkillTimerKey3.Name = "txtSkillTimerKey3";
            this.txtSkillTimerKey3.Size = new System.Drawing.Size(61, 23);
            this.txtSkillTimerKey3.TabIndex = 4;
            //
            // groupBoxGroundClick
            //
            this.groupBoxGroundClick.Controls.Add(this.lblOffsetX);
            this.groupBoxGroundClick.Controls.Add(this.numOffsetX);
            this.groupBoxGroundClick.Controls.Add(this.lblOffsetY);
            this.groupBoxGroundClick.Controls.Add(this.numOffsetY);
            this.groupBoxGroundClick.Controls.Add(this.lblClickDelay);
            this.groupBoxGroundClick.Controls.Add(this.numClickDelay);
            this.groupBoxGroundClick.Controls.Add(this.btnTestClick);
            this.groupBoxGroundClick.Location = new System.Drawing.Point(15, 150);
            this.groupBoxGroundClick.Name = "groupBoxGroundClick";
            this.groupBoxGroundClick.Size = new System.Drawing.Size(531, 100);
            this.groupBoxGroundClick.TabIndex = 37;
            this.groupBoxGroundClick.TabStop = false;
            this.groupBoxGroundClick.Text = "Ajuste do clique no chão (vale pra qualquer timer marcado)";
            //
            // lblOffsetX
            //
            this.lblOffsetX.AutoSize = true;
            this.lblOffsetX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblOffsetX.Location = new System.Drawing.Point(16, 30);
            this.lblOffsetX.Name = "lblOffsetX";
            this.lblOffsetX.Size = new System.Drawing.Size(70, 15);
            this.lblOffsetX.TabIndex = 0;
            this.lblOffsetX.Text = "Posição X";
            //
            // numOffsetX
            //
            this.numOffsetX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numOffsetX.Location = new System.Drawing.Point(19, 48);
            this.numOffsetX.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numOffsetX.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.numOffsetX.Name = "numOffsetX";
            this.numOffsetX.Size = new System.Drawing.Size(70, 23);
            this.numOffsetX.TabIndex = 1;
            //
            // lblOffsetY
            //
            this.lblOffsetY.AutoSize = true;
            this.lblOffsetY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblOffsetY.Location = new System.Drawing.Point(120, 30);
            this.lblOffsetY.Name = "lblOffsetY";
            this.lblOffsetY.Size = new System.Drawing.Size(70, 15);
            this.lblOffsetY.TabIndex = 2;
            this.lblOffsetY.Text = "Posição Y";
            //
            // numOffsetY
            //
            this.numOffsetY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numOffsetY.Location = new System.Drawing.Point(123, 48);
            this.numOffsetY.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numOffsetY.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.numOffsetY.Name = "numOffsetY";
            this.numOffsetY.Size = new System.Drawing.Size(70, 23);
            this.numOffsetY.TabIndex = 3;
            //
            // lblClickDelay
            //
            this.lblClickDelay.AutoSize = true;
            this.lblClickDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblClickDelay.Location = new System.Drawing.Point(224, 30);
            this.lblClickDelay.Name = "lblClickDelay";
            this.lblClickDelay.Size = new System.Drawing.Size(100, 15);
            this.lblClickDelay.TabIndex = 4;
            this.lblClickDelay.Text = "Espera antes (ms)";
            //
            // numClickDelay
            //
            this.numClickDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numClickDelay.Location = new System.Drawing.Point(227, 48);
            this.numClickDelay.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numClickDelay.Name = "numClickDelay";
            this.numClickDelay.Size = new System.Drawing.Size(80, 23);
            this.numClickDelay.TabIndex = 5;
            //
            // btnTestClick
            //
            this.btnTestClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnTestClick.Location = new System.Drawing.Point(340, 45);
            this.btnTestClick.Name = "btnTestClick";
            this.btnTestClick.Size = new System.Drawing.Size(175, 28);
            this.btnTestClick.TabIndex = 6;
            this.btnTestClick.Text = "Testar clique agora";
            this.btnTestClick.UseVisualStyleBackColor = true;
            //
            // SkillTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 300);
            this.Controls.Add(this.groupBoxGroundClick);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SkillTimerForm";
            this.Text = "SkillTimerForm";
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoRefreshDelay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoRefreshDelay2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoRefreshDelay3)).EndInit();
            this.groupBoxGroundClick.ResumeLayout(false);
            this.groupBoxGroundClick.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClickDelay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown txtAutoRefreshDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSkillTimerKey;
        private System.Windows.Forms.Label lblAutoRefreshKey;
        private System.Windows.Forms.Label lblAutoRefreshDelay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtAutoRefreshDelay2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSkillTimerKey2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtAutoRefreshDelay3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSkillTimerKey3;
        private System.Windows.Forms.CheckBox chkClickGround1;
        private System.Windows.Forms.CheckBox chkClickGround2;
        private System.Windows.Forms.CheckBox chkClickGround3;
        private System.Windows.Forms.GroupBox groupBoxGroundClick;
        private System.Windows.Forms.Label lblOffsetX;
        private System.Windows.Forms.NumericUpDown numOffsetX;
        private System.Windows.Forms.Label lblOffsetY;
        private System.Windows.Forms.NumericUpDown numOffsetY;
        private System.Windows.Forms.Label lblClickDelay;
        private System.Windows.Forms.NumericUpDown numClickDelay;
        private System.Windows.Forms.Button btnTestClick;
    }
}
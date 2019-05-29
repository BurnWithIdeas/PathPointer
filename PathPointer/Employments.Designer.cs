﻿namespace PathPointer
{
    partial class Employments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridBusiness = new System.Windows.Forms.DataGridView();
            this.BtnGoals = new System.Windows.Forms.Button();
            this.BtnRest = new System.Windows.Forms.Button();
            this.BtnFun = new System.Windows.Forms.Button();
            this.BtnBusiness = new System.Windows.Forms.Button();
            this.BackMain = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.BtnHight = new System.Windows.Forms.Button();
            this.LowButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBusiness)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridBusiness
            // 
            this.dataGridBusiness.AllowUserToAddRows = false;
            this.dataGridBusiness.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridBusiness.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridBusiness.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBusiness.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridBusiness.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridBusiness.EnableHeadersVisualStyles = false;
            this.dataGridBusiness.Location = new System.Drawing.Point(270, 12);
            this.dataGridBusiness.MultiSelect = false;
            this.dataGridBusiness.Name = "dataGridBusiness";
            this.dataGridBusiness.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridBusiness.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridBusiness.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridBusiness.Size = new System.Drawing.Size(273, 389);
            this.dataGridBusiness.TabIndex = 0;
            this.dataGridBusiness.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBusiness_CellValueChanged);
            this.dataGridBusiness.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridBusiness_KeyDown);
            // 
            // BtnGoals
            // 
            this.BtnGoals.Location = new System.Drawing.Point(12, 122);
            this.BtnGoals.Name = "BtnGoals";
            this.BtnGoals.Size = new System.Drawing.Size(234, 60);
            this.BtnGoals.TabIndex = 1;
            this.BtnGoals.Text = "Цели";
            this.BtnGoals.UseVisualStyleBackColor = true;
            this.BtnGoals.Click += new System.EventHandler(this.BtnGoals_Click);
            // 
            // BtnRest
            // 
            this.BtnRest.Location = new System.Drawing.Point(12, 229);
            this.BtnRest.Name = "BtnRest";
            this.BtnRest.Size = new System.Drawing.Size(234, 60);
            this.BtnRest.TabIndex = 2;
            this.BtnRest.Text = "Отдых";
            this.BtnRest.UseVisualStyleBackColor = true;
            this.BtnRest.Click += new System.EventHandler(this.BtnRest_Click);
            // 
            // BtnFun
            // 
            this.BtnFun.Location = new System.Drawing.Point(12, 341);
            this.BtnFun.Name = "BtnFun";
            this.BtnFun.Size = new System.Drawing.Size(234, 60);
            this.BtnFun.TabIndex = 3;
            this.BtnFun.Text = "Развлечения";
            this.BtnFun.UseVisualStyleBackColor = true;
            this.BtnFun.Click += new System.EventHandler(this.BtnFun_Click);
            // 
            // BtnBusiness
            // 
            this.BtnBusiness.Location = new System.Drawing.Point(12, 12);
            this.BtnBusiness.Name = "BtnBusiness";
            this.BtnBusiness.Size = new System.Drawing.Size(234, 60);
            this.BtnBusiness.TabIndex = 4;
            this.BtnBusiness.Text = "Неотложные дела";
            this.BtnBusiness.UseVisualStyleBackColor = true;
            this.BtnBusiness.Click += new System.EventHandler(this.BtnBusiness_Click);
            // 
            // BackMain
            // 
            this.BackMain.Location = new System.Drawing.Point(563, 343);
            this.BackMain.Name = "BackMain";
            this.BackMain.Size = new System.Drawing.Size(234, 60);
            this.BackMain.TabIndex = 5;
            this.BackMain.Text = "Вернуться";
            this.BackMain.UseVisualStyleBackColor = true;
            this.BackMain.Click += new System.EventHandler(this.BackMain_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(563, 12);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(234, 60);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // BtnHight
            // 
            this.BtnHight.Location = new System.Drawing.Point(563, 265);
            this.BtnHight.Name = "BtnHight";
            this.BtnHight.Size = new System.Drawing.Size(116, 60);
            this.BtnHight.TabIndex = 9;
            this.BtnHight.Text = "Понизить";
            this.BtnHight.UseVisualStyleBackColor = true;
            // 
            // LowButton
            // 
            this.LowButton.Location = new System.Drawing.Point(681, 265);
            this.LowButton.Name = "LowButton";
            this.LowButton.Size = new System.Drawing.Size(116, 60);
            this.LowButton.TabIndex = 10;
            this.LowButton.Text = "Повысить";
            this.LowButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(649, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Приоритет";
            // 
            // Employments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LowButton);
            this.Controls.Add(this.BtnHight);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.BackMain);
            this.Controls.Add(this.BtnBusiness);
            this.Controls.Add(this.BtnFun);
            this.Controls.Add(this.BtnRest);
            this.Controls.Add(this.BtnGoals);
            this.Controls.Add(this.dataGridBusiness);
            this.Name = "Employments";
            this.Text = "Занятия";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Employments_FormClosing);
            this.Load += new System.EventHandler(this.Employments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBusiness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridBusiness;
        private System.Windows.Forms.Button BtnGoals;
        private System.Windows.Forms.Button BtnRest;
        private System.Windows.Forms.Button BtnFun;
        private System.Windows.Forms.Button BtnBusiness;
        private System.Windows.Forms.Button BackMain;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button BtnHight;
        private System.Windows.Forms.Button LowButton;
        private System.Windows.Forms.Label label1;
    }
}
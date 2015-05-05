namespace VTScheduler
{
    partial class chooseSemesterForm
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
            this.semesterSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yearSelector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.confirmSemesterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // semesterSelector
            // 
            this.semesterSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semesterSelector.FormattingEnabled = true;
            this.semesterSelector.Items.AddRange(new object[] {
            "Fall",
            "Spring",
            "Winter",
            "Summer1",
            "Summer2"});
            this.semesterSelector.Location = new System.Drawing.Point(99, 9);
            this.semesterSelector.Name = "semesterSelector";
            this.semesterSelector.Size = new System.Drawing.Size(89, 21);
            this.semesterSelector.TabIndex = 0;
            this.semesterSelector.SelectedIndexChanged += new System.EventHandler(this.semesterSelector_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Semester Type:";
            // 
            // yearSelector
            // 
            this.yearSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearSelector.FormattingEnabled = true;
            this.yearSelector.Location = new System.Drawing.Point(99, 36);
            this.yearSelector.Name = "yearSelector";
            this.yearSelector.Size = new System.Drawing.Size(89, 21);
            this.yearSelector.TabIndex = 2;
            this.yearSelector.SelectedIndexChanged += new System.EventHandler(this.yearSelector_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Year:";
            // 
            // confirmSemesterButton
            // 
            this.confirmSemesterButton.Enabled = false;
            this.confirmSemesterButton.Location = new System.Drawing.Point(15, 63);
            this.confirmSemesterButton.Name = "confirmSemesterButton";
            this.confirmSemesterButton.Size = new System.Drawing.Size(173, 32);
            this.confirmSemesterButton.TabIndex = 4;
            this.confirmSemesterButton.Text = "Confirm";
            this.confirmSemesterButton.UseVisualStyleBackColor = true;
            this.confirmSemesterButton.Click += new System.EventHandler(this.confirmSemesterButton_Click);
            // 
            // chooseSemesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 102);
            this.Controls.Add(this.confirmSemesterButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yearSelector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.semesterSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "chooseSemesterForm";
            this.Text = "Choose a Semester";
            this.Load += new System.EventHandler(this.chooseSemesterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox semesterSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox yearSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button confirmSemesterButton;


    }
}


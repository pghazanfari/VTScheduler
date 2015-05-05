namespace VTScheduler
{
    partial class MainForm
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
            this.subjectSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loadClassesButton = new System.Windows.Forms.Button();
            this.classesList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addClassButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addedClassesList = new System.Windows.Forms.ListBox();
            this.removeClassButton = new System.Windows.Forms.Button();
            this.findScheduleButton = new System.Windows.Forms.Button();
            this.preferencesList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // subjectSelector
            // 
            this.subjectSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subjectSelector.FormattingEnabled = true;
            this.subjectSelector.Location = new System.Drawing.Point(63, 18);
            this.subjectSelector.Name = "subjectSelector";
            this.subjectSelector.Size = new System.Drawing.Size(462, 21);
            this.subjectSelector.TabIndex = 0;
            this.subjectSelector.SelectedIndexChanged += new System.EventHandler(this.subjectSelector_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subject:";
            // 
            // loadClassesButton
            // 
            this.loadClassesButton.Enabled = false;
            this.loadClassesButton.Location = new System.Drawing.Point(11, 45);
            this.loadClassesButton.Name = "loadClassesButton";
            this.loadClassesButton.Size = new System.Drawing.Size(514, 31);
            this.loadClassesButton.TabIndex = 2;
            this.loadClassesButton.Text = "Load Classes";
            this.loadClassesButton.UseVisualStyleBackColor = true;
            this.loadClassesButton.Click += new System.EventHandler(this.loadClassesButton_Click);
            // 
            // classesList
            // 
            this.classesList.FormattingEnabled = true;
            this.classesList.Location = new System.Drawing.Point(14, 82);
            this.classesList.Name = "classesList";
            this.classesList.Size = new System.Drawing.Size(511, 251);
            this.classesList.TabIndex = 3;
            this.classesList.SelectedIndexChanged += new System.EventHandler(this.classesList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addClassButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.classesList);
            this.groupBox1.Controls.Add(this.subjectSelector);
            this.groupBox1.Controls.Add(this.loadClassesButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 383);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Browse Classes";
            // 
            // addClassButton
            // 
            this.addClassButton.Enabled = false;
            this.addClassButton.Location = new System.Drawing.Point(11, 340);
            this.addClassButton.Name = "addClassButton";
            this.addClassButton.Size = new System.Drawing.Size(514, 38);
            this.addClassButton.TabIndex = 5;
            this.addClassButton.Text = "Add Class";
            this.addClassButton.UseVisualStyleBackColor = true;
            this.addClassButton.Click += new System.EventHandler(this.addClassButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.removeClassButton);
            this.groupBox2.Controls.Add(this.addedClassesList);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.preferencesList);
            this.groupBox2.Location = new System.Drawing.Point(549, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 383);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Preferences:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Classes:";
            // 
            // addedClassesList
            // 
            this.addedClassesList.FormattingEnabled = true;
            this.addedClassesList.Location = new System.Drawing.Point(12, 196);
            this.addedClassesList.Name = "addedClassesList";
            this.addedClassesList.Size = new System.Drawing.Size(513, 134);
            this.addedClassesList.TabIndex = 3;
            this.addedClassesList.SelectedIndexChanged += new System.EventHandler(this.addedClassesList_SelectedIndexChanged);
            // 
            // removeClassButton
            // 
            this.removeClassButton.Enabled = false;
            this.removeClassButton.Location = new System.Drawing.Point(12, 338);
            this.removeClassButton.Name = "removeClassButton";
            this.removeClassButton.Size = new System.Drawing.Size(513, 38);
            this.removeClassButton.TabIndex = 6;
            this.removeClassButton.Text = "Remove Class";
            this.removeClassButton.UseVisualStyleBackColor = true;
            this.removeClassButton.Click += new System.EventHandler(this.removeClassButton_Click);
            // 
            // findScheduleButton
            // 
            this.findScheduleButton.Location = new System.Drawing.Point(12, 394);
            this.findScheduleButton.Name = "findScheduleButton";
            this.findScheduleButton.Size = new System.Drawing.Size(1068, 65);
            this.findScheduleButton.TabIndex = 6;
            this.findScheduleButton.Text = "Find My Schedule";
            this.findScheduleButton.UseVisualStyleBackColor = true;
            this.findScheduleButton.Click += new System.EventHandler(this.findScheduleButton_Click);
            // 
            // preferencesList
            // 
            this.preferencesList.FormattingEnabled = true;
            this.preferencesList.Items.AddRange(new object[] {
            "Avoid Morning Classes",
            "Avoid Evening Classes",
            "Avoid Friday Classes",
            "Avoid Gaps Between Classes"});
            this.preferencesList.Location = new System.Drawing.Point(12, 35);
            this.preferencesList.Name = "preferencesList";
            this.preferencesList.Size = new System.Drawing.Size(513, 139);
            this.preferencesList.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 471);
            this.Controls.Add(this.findScheduleButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Choose Your Classes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox subjectSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadClassesButton;
        private System.Windows.Forms.ListBox classesList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addClassButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removeClassButton;
        private System.Windows.Forms.ListBox addedClassesList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button findScheduleButton;
        private System.Windows.Forms.CheckedListBox preferencesList;
    }
}
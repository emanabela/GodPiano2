namespace Piano2
{
    partial class PianoForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.DropDown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentNotes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(304, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(417, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 45);
            this.button3.TabIndex = 2;
            this.button3.Text = "Load";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(530, 34);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 45);
            this.button4.TabIndex = 3;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // DropDown
            // 
            this.DropDown.FormattingEnabled = true;
            this.DropDown.Items.AddRange(new object[] {
            "Grave",
            "Largo",
            "Lento",
            "Adagio",
            "Andante",
            "Moderato",
            "Allegro",
            "Presto"});
            this.DropDown.Location = new System.Drawing.Point(655, 62);
            this.DropDown.Name = "DropDown";
            this.DropDown.Size = new System.Drawing.Size(162, 33);
            this.DropDown.TabIndex = 4;
            this.DropDown.Tag = "";
            this.DropDown.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.DropDown.SelectedItem = "Moderato";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(695, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tempo";
            // 
            // CurrentNotes
            // 
            this.CurrentNotes.Enabled = false;
            this.CurrentNotes.FormattingEnabled = true;
            this.CurrentNotes.ItemHeight = 25;
            this.CurrentNotes.Location = new System.Drawing.Point(25, 34);
            this.CurrentNotes.Name = "CurrentNotes";
            this.CurrentNotes.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.CurrentNotes.Size = new System.Drawing.Size(151, 454);
            this.CurrentNotes.TabIndex = 6;
            this.CurrentNotes.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // PianoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.CurrentNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DropDown);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "PianoForm";
            this.Text = "Piano";
            this.Load += new System.EventHandler(this.PianoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox DropDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox CurrentNotes;
    }
}


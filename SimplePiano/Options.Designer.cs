
namespace SimplePiano
{
    partial class Options
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
            this.Instruments = new System.Windows.Forms.ComboBox();
            this.InsSetter = new System.Windows.Forms.Button();
            this.ShowTones = new System.Windows.Forms.CheckBox();
            this.ShowKeys = new System.Windows.Forms.CheckBox();
            this.Volume = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Volume)).BeginInit();
            this.SuspendLayout();
            // 
            // Instruments
            // 
            this.Instruments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Instruments.FormattingEnabled = true;
            this.Instruments.Items.AddRange(new object[] {
            "Piano",
            "Organ",
            "Guitar",
            "Trumpet",
            "Violin"});
            this.Instruments.Location = new System.Drawing.Point(28, 27);
            this.Instruments.Name = "Instruments";
            this.Instruments.Size = new System.Drawing.Size(180, 28);
            this.Instruments.TabIndex = 0;
            this.Instruments.Tag = "";
            this.Instruments.SelectedIndexChanged += new System.EventHandler(this.Instruments_SelectedIndexChanged);
            // 
            // InsSetter
            // 
            this.InsSetter.Enabled = false;
            this.InsSetter.Location = new System.Drawing.Point(28, 76);
            this.InsSetter.Name = "InsSetter";
            this.InsSetter.Size = new System.Drawing.Size(180, 32);
            this.InsSetter.TabIndex = 1;
            this.InsSetter.Text = "Set Instrument";
            this.InsSetter.UseVisualStyleBackColor = true;
            this.InsSetter.Click += new System.EventHandler(this.InsSetter_Click);
            // 
            // ShowTones
            // 
            this.ShowTones.AutoSize = true;
            this.ShowTones.Location = new System.Drawing.Point(28, 170);
            this.ShowTones.Name = "ShowTones";
            this.ShowTones.Size = new System.Drawing.Size(194, 24);
            this.ShowTones.TabIndex = 2;
            this.ShowTones.Text = "Show tones on keyboard";
            this.ShowTones.UseVisualStyleBackColor = true;
            this.ShowTones.CheckedChanged += new System.EventHandler(this.ShowTones_CheckedChanged);
            // 
            // ShowKeys
            // 
            this.ShowKeys.AutoSize = true;
            this.ShowKeys.Location = new System.Drawing.Point(28, 140);
            this.ShowKeys.Name = "ShowKeys";
            this.ShowKeys.Size = new System.Drawing.Size(186, 24);
            this.ShowKeys.TabIndex = 3;
            this.ShowKeys.Text = "Show keys on keyboard";
            this.ShowKeys.UseVisualStyleBackColor = true;
            this.ShowKeys.CheckedChanged += new System.EventHandler(this.ShowKeys_CheckedChanged);
            // 
            // Volume
            // 
            this.Volume.Location = new System.Drawing.Point(305, 27);
            this.Volume.Name = "Volume";
            this.Volume.Size = new System.Drawing.Size(244, 56);
            this.Volume.TabIndex = 4;
            this.Volume.Scroll += new System.EventHandler(this.Volume_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Volume";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 222);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Volume);
            this.Controls.Add(this.ShowKeys);
            this.Controls.Add(this.ShowTones);
            this.Controls.Add(this.InsSetter);
            this.Controls.Add(this.Instruments);
            this.Name = "Options";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.Volume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Instruments;
        private System.Windows.Forms.Button InsSetter;
        private System.Windows.Forms.CheckBox ShowTones;
        private System.Windows.Forms.CheckBox ShowKeys;
        private System.Windows.Forms.TrackBar Volume;
        private System.Windows.Forms.Label label1;
    }
}
namespace PDFTranslatorApp
{
    partial class Form1
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
            this.translateButton = new System.Windows.Forms.Button();
            this.sourceLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.targetLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.selectPdf = new System.Windows.Forms.Button();
            this.sourceLanguageLabel = new System.Windows.Forms.Label();
            this.targetLanguageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // translateButton
            // 
            this.translateButton.Location = new System.Drawing.Point(317, 389);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(144, 49);
            this.translateButton.TabIndex = 0;
            this.translateButton.Text = "Translate";
            this.translateButton.UseVisualStyleBackColor = true;
            this.translateButton.Click += new System.EventHandler(this.translateButton_Click);
            // 
            // sourceLanguageComboBox
            // 
            this.sourceLanguageComboBox.FormattingEnabled = true;
            this.sourceLanguageComboBox.Location = new System.Drawing.Point(142, 240);
            this.sourceLanguageComboBox.Name = "sourceLanguageComboBox";
            this.sourceLanguageComboBox.Size = new System.Drawing.Size(162, 21);
            this.sourceLanguageComboBox.TabIndex = 1;
            // 
            // targetLanguageComboBox
            // 
            this.targetLanguageComboBox.FormattingEnabled = true;
            this.targetLanguageComboBox.Location = new System.Drawing.Point(471, 240);
            this.targetLanguageComboBox.Name = "targetLanguageComboBox";
            this.targetLanguageComboBox.Size = new System.Drawing.Size(175, 21);
            this.targetLanguageComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Source Language";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(466, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output Language";
            // 
            // selectPdf
            // 
            this.selectPdf.Location = new System.Drawing.Point(298, 61);
            this.selectPdf.Name = "selectPdf";
            this.selectPdf.Size = new System.Drawing.Size(183, 68);
            this.selectPdf.TabIndex = 5;
            this.selectPdf.Text = "Select PDF File";
            this.selectPdf.UseVisualStyleBackColor = true;
            this.selectPdf.Click += new System.EventHandler(this.selectPdf_Click);
            // 
            // sourceLanguageLabel
            // 
            this.sourceLanguageLabel.AutoSize = true;
            this.sourceLanguageLabel.Location = new System.Drawing.Point(195, 264);
            this.sourceLanguageLabel.Name = "sourceLanguageLabel";
            this.sourceLanguageLabel.Size = new System.Drawing.Size(41, 13);
            this.sourceLanguageLabel.TabIndex = 6;
            this.sourceLanguageLabel.Text = "Default";
            // 
            // targetLanguageLabel
            // 
            this.targetLanguageLabel.AutoSize = true;
            this.targetLanguageLabel.Location = new System.Drawing.Point(535, 268);
            this.targetLanguageLabel.Name = "targetLanguageLabel";
            this.targetLanguageLabel.Size = new System.Drawing.Size(41, 13);
            this.targetLanguageLabel.TabIndex = 7;
            this.targetLanguageLabel.Text = "Default";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.targetLanguageLabel);
            this.Controls.Add(this.sourceLanguageLabel);
            this.Controls.Add(this.selectPdf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetLanguageComboBox);
            this.Controls.Add(this.sourceLanguageComboBox);
            this.Controls.Add(this.translateButton);
            this.Name = "Form1";
            this.Text = "Form1";            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.ComboBox sourceLanguageComboBox;
        private System.Windows.Forms.ComboBox targetLanguageComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selectPdf;
        private System.Windows.Forms.Label sourceLanguageLabel;
        private System.Windows.Forms.Label targetLanguageLabel;
    }

}


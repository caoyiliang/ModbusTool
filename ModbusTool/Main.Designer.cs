
namespace ModbusTool
{
    partial class Main
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
            this.btnOneR = new System.Windows.Forms.Button();
            this.btnOneW = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // btnOneR
            // 
            this.btnOneR.Location = new System.Drawing.Point(12, 12);
            this.btnOneR.Name = "btnOneR";
            this.btnOneR.Size = new System.Drawing.Size(100, 23);
            this.btnOneR.TabIndex = 2;
            this.btnOneR.Text = "一键读";
            this.btnOneR.UseVisualStyleBackColor = true;
            this.btnOneR.Click += new System.EventHandler(this.btnOneR_Click);
            // 
            // btnOneW
            // 
            this.btnOneW.Location = new System.Drawing.Point(135, 12);
            this.btnOneW.Name = "btnOneW";
            this.btnOneW.Size = new System.Drawing.Size(100, 23);
            this.btnOneW.TabIndex = 3;
            this.btnOneW.Text = "一键写";
            this.btnOneW.UseVisualStyleBackColor = true;
            this.btnOneW.Click += new System.EventHandler(this.btnOneW_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(334, 12);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(103, 23);
            this.btnOutput.TabIndex = 5;
            this.btnOutput.Text = "导出值";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(457, 12);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(103, 23);
            this.btnInput.TabIndex = 5;
            this.btnInput.Text = "导入值";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(12, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(935, 545);
            this.tabControl1.TabIndex = 6;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 606);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.btnOneR);
            this.Controls.Add(this.btnOneW);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_LoadAsync);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOneR;
        private System.Windows.Forms.Button btnOneW;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.TabControl tabControl1;
    }
}
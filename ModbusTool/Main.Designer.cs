
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
            btnOneR = new System.Windows.Forms.Button();
            btnOneW = new System.Windows.Forms.Button();
            btnOutput = new System.Windows.Forms.Button();
            btnInput = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            SuspendLayout();
            // 
            // btnOneR
            // 
            btnOneR.Location = new System.Drawing.Point(12, 12);
            btnOneR.Name = "btnOneR";
            btnOneR.Size = new System.Drawing.Size(100, 23);
            btnOneR.TabIndex = 2;
            btnOneR.Text = "一键读";
            btnOneR.UseVisualStyleBackColor = true;
            btnOneR.Click += btnOneR_Click;
            // 
            // btnOneW
            // 
            btnOneW.Location = new System.Drawing.Point(135, 12);
            btnOneW.Name = "btnOneW";
            btnOneW.Size = new System.Drawing.Size(100, 23);
            btnOneW.TabIndex = 3;
            btnOneW.Text = "一键写";
            btnOneW.UseVisualStyleBackColor = true;
            btnOneW.Click += btnOneW_Click;
            // 
            // btnOutput
            // 
            btnOutput.Location = new System.Drawing.Point(334, 12);
            btnOutput.Name = "btnOutput";
            btnOutput.Size = new System.Drawing.Size(103, 23);
            btnOutput.TabIndex = 5;
            btnOutput.Text = "导出值";
            btnOutput.UseVisualStyleBackColor = true;
            btnOutput.Click += btnOutput_Click;
            // 
            // btnInput
            // 
            btnInput.Location = new System.Drawing.Point(457, 12);
            btnInput.Name = "btnInput";
            btnInput.Size = new System.Drawing.Size(103, 23);
            btnInput.TabIndex = 5;
            btnInput.Text = "导入值";
            btnInput.UseVisualStyleBackColor = true;
            btnInput.Click += btnInput_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl1.Location = new System.Drawing.Point(12, 49);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(935, 545);
            tabControl1.TabIndex = 6;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(959, 606);
            Controls.Add(tabControl1);
            Controls.Add(btnInput);
            Controls.Add(btnOutput);
            Controls.Add(btnOneR);
            Controls.Add(btnOneW);
            Name = "Main";
            Text = "Main";
            Load += Main_LoadAsync;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnOneR;
        private System.Windows.Forms.Button btnOneW;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.TabControl tabControl1;
    }
}
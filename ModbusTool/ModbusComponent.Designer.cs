
namespace ModbusTool
{
    partial class ModbusComponent
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnW = new System.Windows.Forms.Button();
            this.btnR = new System.Windows.Forms.Button();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox.Controls.Add(this.btnW);
            this.groupBox.Controls.Add(this.btnR);
            this.groupBox.Controls.Add(this.tbValue);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox1";
            this.groupBox.Size = new System.Drawing.Size(209, 55);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // btnW
            // 
            this.btnW.Location = new System.Drawing.Point(159, 22);
            this.btnW.Name = "btnW";
            this.btnW.Size = new System.Drawing.Size(41, 23);
            this.btnW.TabIndex = 2;
            this.btnW.Text = "写";
            this.btnW.UseVisualStyleBackColor = true;
            this.btnW.Click += new System.EventHandler(this.btnW_Click);
            // 
            // btnR
            // 
            this.btnR.Location = new System.Drawing.Point(112, 22);
            this.btnR.Name = "btnR";
            this.btnR.Size = new System.Drawing.Size(41, 23);
            this.btnR.TabIndex = 3;
            this.btnR.Text = "读";
            this.btnR.UseVisualStyleBackColor = true;
            this.btnR.Click += new System.EventHandler(this.btnR_Click);
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(6, 22);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(100, 23);
            this.tbValue.TabIndex = 4;
            // 
            // ModbusComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "ModbusComponent";
            this.Size = new System.Drawing.Size(209, 55);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnW;
        private System.Windows.Forms.Button btnR;
        private System.Windows.Forms.TextBox tbValue;
    }
}

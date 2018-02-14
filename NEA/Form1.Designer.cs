namespace NEA
{
    partial class Form_Payment_Keypad
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
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txtBox_Enter = new System.Windows.Forms.TextBox();
            this.lbl_Instruction = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_confirm
            // 
            this.btn_confirm.BackColor = System.Drawing.Color.Lime;
            this.btn_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirm.Location = new System.Drawing.Point(597, 117);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(46, 44);
            this.btn_confirm.TabIndex = 0;
            this.btn_confirm.Text = "O";
            this.btn_confirm.UseVisualStyleBackColor = false;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Red;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(12, 117);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(46, 44);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "X";
            this.btn_cancel.UseVisualStyleBackColor = false;
            // 
            // txtBox_Enter
            // 
            this.txtBox_Enter.BackColor = System.Drawing.Color.YellowGreen;
            this.txtBox_Enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_Enter.Location = new System.Drawing.Point(12, 73);
            this.txtBox_Enter.Name = "txtBox_Enter";
            this.txtBox_Enter.Size = new System.Drawing.Size(631, 38);
            this.txtBox_Enter.TabIndex = 2;
            // 
            // lbl_Instruction
            // 
            this.lbl_Instruction.BackColor = System.Drawing.Color.YellowGreen;
            this.lbl_Instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Instruction.Location = new System.Drawing.Point(12, 50);
            this.lbl_Instruction.Name = "lbl_Instruction";
            this.lbl_Instruction.Size = new System.Drawing.Size(631, 23);
            this.lbl_Instruction.TabIndex = 3;
            this.lbl_Instruction.Text = "Enter Your Registration";
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.Orange;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Location = new System.Drawing.Point(307, 117);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(46, 44);
            this.btn_clear.TabIndex = 4;
            this.btn_clear.Text = "<";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Form_Payment_Keypad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(663, 178);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.lbl_Instruction);
            this.Controls.Add(this.txtBox_Enter);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_confirm);
            this.Name = "Form_Payment_Keypad";
            this.Text = "Payment Keypad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TextBox txtBox_Enter;
        private System.Windows.Forms.Label lbl_Instruction;
        private System.Windows.Forms.Button btn_clear;
    }
}


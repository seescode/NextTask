namespace NextTask
{
    partial class Summary
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
            this.tasksCompleted = new System.Windows.Forms.TextBox();
            this.tasksRemaining = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tasksCompleted
            // 
            this.tasksCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tasksCompleted.Enabled = false;
            this.tasksCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tasksCompleted.Location = new System.Drawing.Point(17, 23);
            this.tasksCompleted.Multiline = true;
            this.tasksCompleted.Name = "tasksCompleted";
            this.tasksCompleted.Size = new System.Drawing.Size(450, 342);
            this.tasksCompleted.TabIndex = 13;
            // 
            // tasksRemaining
            // 
            this.tasksRemaining.BackColor = System.Drawing.SystemColors.Window;
            this.tasksRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tasksRemaining.Enabled = false;
            this.tasksRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tasksRemaining.Location = new System.Drawing.Point(17, 385);
            this.tasksRemaining.Multiline = true;
            this.tasksRemaining.Name = "tasksRemaining";
            this.tasksRemaining.Size = new System.Drawing.Size(450, 342);
            this.tasksRemaining.TabIndex = 14;
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 761);
            this.Controls.Add(this.tasksRemaining);
            this.Controls.Add(this.tasksCompleted);
            this.Name = "Summary";
            this.Text = "Summary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tasksCompleted;
        private System.Windows.Forms.TextBox tasksRemaining;
    }
}
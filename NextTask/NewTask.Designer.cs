namespace NextTask
{
    partial class NewTask
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
            this.description = new System.Windows.Forms.TextBox();
            this.addFront = new System.Windows.Forms.Button();
            this.addNext = new System.Windows.Forms.Button();
            this.addBack = new System.Windows.Forms.Button();
            this.notes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(15, 25);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(450, 68);
            this.description.TabIndex = 0;
            // 
            // addFront
            // 
            this.addFront.Location = new System.Drawing.Point(15, 317);
            this.addFront.Name = "addFront";
            this.addFront.Size = new System.Drawing.Size(75, 23);
            this.addFront.TabIndex = 2;
            this.addFront.Text = "Add Front";
            this.addFront.UseVisualStyleBackColor = true;
            this.addFront.Click += new System.EventHandler(this.addFront_Click);
            // 
            // addNext
            // 
            this.addNext.Location = new System.Drawing.Point(96, 317);
            this.addNext.Name = "addNext";
            this.addNext.Size = new System.Drawing.Size(75, 23);
            this.addNext.TabIndex = 3;
            this.addNext.Text = "Add Next";
            this.addNext.UseVisualStyleBackColor = true;
            this.addNext.Click += new System.EventHandler(this.addNext_Click);
            // 
            // addBack
            // 
            this.addBack.Location = new System.Drawing.Point(177, 317);
            this.addBack.Name = "addBack";
            this.addBack.Size = new System.Drawing.Size(75, 23);
            this.addBack.TabIndex = 4;
            this.addBack.Text = "Add Back";
            this.addBack.UseVisualStyleBackColor = true;
            this.addBack.Click += new System.EventHandler(this.addBack_Click);
            // 
            // notes
            // 
            this.notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notes.Location = new System.Drawing.Point(15, 99);
            this.notes.Multiline = true;
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(450, 212);
            this.notes.TabIndex = 1;
            // 
            // NewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.addBack);
            this.Controls.Add(this.addNext);
            this.Controls.Add(this.addFront);
            this.Controls.Add(this.description);
            this.Name = "NewTask";
            this.Text = "NewTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Button addFront;
        private System.Windows.Forms.Button addNext;
        private System.Windows.Forms.Button addBack;
        private System.Windows.Forms.TextBox notes;
    }
}
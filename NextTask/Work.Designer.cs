namespace NextTask
{
    partial class Work
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
            this.skip = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.done = new System.Windows.Forms.Button();
            this.summary = new System.Windows.Forms.Button();
            this.newTask = new System.Windows.Forms.Button();
            this.notes = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.TextBox();
            this.finished = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // skip
            // 
            this.skip.Location = new System.Drawing.Point(179, 326);
            this.skip.Name = "skip";
            this.skip.Size = new System.Drawing.Size(75, 23);
            this.skip.TabIndex = 7;
            this.skip.Text = "Skip";
            this.skip.UseVisualStyleBackColor = true;
            this.skip.Click += new System.EventHandler(this.skip_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(98, 326);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 6;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // done
            // 
            this.done.Location = new System.Drawing.Point(17, 326);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(75, 23);
            this.done.TabIndex = 5;
            this.done.Text = "Done";
            this.done.UseVisualStyleBackColor = true;
            this.done.Click += new System.EventHandler(this.done_Click);
            // 
            // summary
            // 
            this.summary.Location = new System.Drawing.Point(311, 326);
            this.summary.Name = "summary";
            this.summary.Size = new System.Drawing.Size(75, 23);
            this.summary.TabIndex = 8;
            this.summary.Text = "Summary";
            this.summary.UseVisualStyleBackColor = true;
            this.summary.Click += new System.EventHandler(this.summary_Click);
            // 
            // newTask
            // 
            this.newTask.Location = new System.Drawing.Point(392, 326);
            this.newTask.Name = "newTask";
            this.newTask.Size = new System.Drawing.Size(75, 23);
            this.newTask.TabIndex = 9;
            this.newTask.Text = "New Task";
            this.newTask.UseVisualStyleBackColor = true;
            this.newTask.Click += new System.EventHandler(this.newTask_Click);
            // 
            // notes
            // 
            this.notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notes.Location = new System.Drawing.Point(17, 87);
            this.notes.Multiline = true;
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(450, 212);
            this.notes.TabIndex = 11;
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(17, 13);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(450, 68);
            this.description.TabIndex = 10;
            // 
            // finished
            // 
            this.finished.AutoSize = true;
            this.finished.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finished.Location = new System.Drawing.Point(82, 66);
            this.finished.Name = "finished";
            this.finished.Size = new System.Drawing.Size(320, 37);
            this.finished.TabIndex = 12;
            this.finished.Text = "All Tasks Completed!";
            this.finished.Visible = false;
            // 
            // Work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.finished);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.description);
            this.Controls.Add(this.newTask);
            this.Controls.Add(this.summary);
            this.Controls.Add(this.skip);
            this.Controls.Add(this.update);
            this.Controls.Add(this.done);
            this.Name = "Work";
            this.Text = "Work";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button skip;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button done;
        private System.Windows.Forms.Button summary;
        private System.Windows.Forms.Button newTask;
        private System.Windows.Forms.TextBox notes;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label finished;
    }
}


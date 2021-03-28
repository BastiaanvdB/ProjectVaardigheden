
namespace Magic
{
    partial class MagicConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagicConsole));
            this.magiclist = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // magiclist
            // 
            this.magiclist.BackColor = System.Drawing.SystemColors.HotTrack;
            this.magiclist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.magiclist.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.magiclist.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.magiclist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.magiclist.HideSelection = false;
            this.magiclist.Location = new System.Drawing.Point(-2, -24);
            this.magiclist.MultiSelect = false;
            this.magiclist.Name = "magiclist";
            this.magiclist.Scrollable = false;
            this.magiclist.Size = new System.Drawing.Size(860, 366);
            this.magiclist.TabIndex = 0;
            this.magiclist.UseCompatibleStateImageBehavior = false;
            this.magiclist.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 400;
            // 
            // MagicConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 339);
            this.Controls.Add(this.magiclist);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MagicConsole";
            this.Text = "Someren Security Prompt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView magiclist;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
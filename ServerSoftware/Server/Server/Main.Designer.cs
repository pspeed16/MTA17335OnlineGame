namespace ServerTicTacToe
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
            this.lstClient = new System.Windows.Forms.ListView();
            this.EndPoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastRec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstClient
            // 
            this.lstClient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EndPoint,
            this.ID,
            this.LastMsg,
            this.LastRec});
            this.lstClient.Location = new System.Drawing.Point(12, 12);
            this.lstClient.Name = "lstClient";
            this.lstClient.Size = new System.Drawing.Size(596, 270);
            this.lstClient.TabIndex = 0;
            this.lstClient.UseCompatibleStateImageBehavior = false;
            this.lstClient.View = System.Windows.Forms.View.Details;
            // 
            // EndPoint
            // 
            this.EndPoint.Text = "EndPoint";
            this.EndPoint.Width = 114;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 82;
            // 
            // LastMsg
            // 
            this.LastMsg.Text = "Last Msg";
            this.LastMsg.Width = 255;
            // 
            // LastRec
            // 
            this.LastRec.Text = "Last Rec";
            this.LastRec.Width = 140;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 294);
            this.Controls.Add(this.lstClient);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstClient;
        private System.Windows.Forms.ColumnHeader EndPoint;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader LastMsg;
        private System.Windows.Forms.ColumnHeader LastRec;
    }
}
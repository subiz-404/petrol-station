namespace PetrolStation
{
    partial class FuelPump
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pumpPictureBox = new System.Windows.Forms.PictureBox();
            this.pumpFillingButton = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pumpPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pumpPictureBox
            // 
            this.pumpPictureBox.Image = global::PetrolStation.Properties.Resources.pump;
            this.pumpPictureBox.InitialImage = global::PetrolStation.Properties.Resources.pump;
            this.pumpPictureBox.Location = new System.Drawing.Point(15, 70);
            this.pumpPictureBox.Name = "pumpPictureBox";
            this.pumpPictureBox.Size = new System.Drawing.Size(70, 60);
            this.pumpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pumpPictureBox.TabIndex = 1;
            this.pumpPictureBox.TabStop = false;
            // 
            // pumpFillingButton
            // 
            this.pumpFillingButton.Location = new System.Drawing.Point(10, 135);
            this.pumpFillingButton.Name = "pumpFillingButton";
            this.pumpFillingButton.Size = new System.Drawing.Size(75, 25);
            this.pumpFillingButton.TabIndex = 2;
            this.pumpFillingButton.Text = "Pump";
            this.pumpFillingButton.UseSelectable = true;
            // 
            // FuelPump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pumpFillingButton);
            this.Controls.Add(this.pumpPictureBox);
            this.Name = "FuelPump";
            this.Size = new System.Drawing.Size(100, 160);
            this.Load += new System.EventHandler(this.FuelPump_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pumpPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pumpPictureBox;
        public  MetroFramework.Controls.MetroButton pumpFillingButton;
    }
}

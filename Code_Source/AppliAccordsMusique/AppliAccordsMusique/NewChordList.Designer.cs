
namespace AppliAccordsMusique
{
    partial class NewChordList
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
            this.panContainer = new System.Windows.Forms.Panel();
            this.btnAddChord = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.tbListName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panContainer
            // 
            this.panContainer.AutoScroll = true;
            this.panContainer.Location = new System.Drawing.Point(12, 116);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(255, 285);
            this.panContainer.TabIndex = 0;
            // 
            // btnAddChord
            // 
            this.btnAddChord.Location = new System.Drawing.Point(12, 84);
            this.btnAddChord.Name = "btnAddChord";
            this.btnAddChord.Size = new System.Drawing.Size(245, 26);
            this.btnAddChord.TabIndex = 0;
            this.btnAddChord.Text = "Ajouter un accord";
            this.btnAddChord.UseVisualStyleBackColor = true;
            this.btnAddChord.Click += new System.EventHandler(this.btnAddChord_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(12, 417);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(245, 36);
            this.btnValidate.TabIndex = 1;
            this.btnValidate.Text = "Valider";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // tbListName
            // 
            this.tbListName.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbListName.Location = new System.Drawing.Point(12, 46);
            this.tbListName.MaxLength = 10;
            this.tbListName.Name = "tbListName";
            this.tbListName.Size = new System.Drawing.Size(245, 32);
            this.tbListName.TabIndex = 2;
            this.tbListName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NewChordList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 465);
            this.Controls.Add(this.tbListName);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.btnAddChord);
            this.Controls.Add(this.panContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewChordList";
            this.Text = "Nouveaux accords";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panContainer;
        private System.Windows.Forms.Button btnAddChord;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.TextBox tbListName;
    }
}
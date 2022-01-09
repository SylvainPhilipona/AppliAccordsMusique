
namespace AppliAccordsMusique
{
    partial class ChordsTrain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.cboChords = new System.Windows.Forms.ComboBox();
            this.btnNewList = new System.Windows.Forms.Button();
            this.cboTimer = new System.Windows.Forms.ComboBox();
            this.lblChord = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(140, 40);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cboChords
            // 
            this.cboChords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChords.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChords.FormattingEnabled = true;
            this.cboChords.Location = new System.Drawing.Point(12, 58);
            this.cboChords.Name = "cboChords";
            this.cboChords.Size = new System.Drawing.Size(209, 26);
            this.cboChords.TabIndex = 1;
            this.cboChords.SelectedIndexChanged += new System.EventHandler(this.cboChords_SelectedIndexChanged);
            // 
            // btnNewList
            // 
            this.btnNewList.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewList.Location = new System.Drawing.Point(161, 12);
            this.btnNewList.Name = "btnNewList";
            this.btnNewList.Size = new System.Drawing.Size(140, 40);
            this.btnNewList.TabIndex = 2;
            this.btnNewList.Text = "Créer une nouvelle liste";
            this.btnNewList.UseVisualStyleBackColor = true;
            this.btnNewList.Click += new System.EventHandler(this.btnNewList_Click);
            // 
            // cboTimer
            // 
            this.cboTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimer.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTimer.FormattingEnabled = true;
            this.cboTimer.Location = new System.Drawing.Point(227, 58);
            this.cboTimer.Name = "cboTimer";
            this.cboTimer.Size = new System.Drawing.Size(74, 26);
            this.cboTimer.TabIndex = 3;
            this.cboTimer.SelectedIndexChanged += new System.EventHandler(this.cboTimer_SelectedIndexChanged);
            // 
            // lblChord
            // 
            this.lblChord.Font = new System.Drawing.Font("Consolas", 250.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChord.Location = new System.Drawing.Point(1, 85);
            this.lblChord.Name = "lblChord";
            this.lblChord.Size = new System.Drawing.Size(314, 330);
            this.lblChord.TabIndex = 4;
            this.lblChord.Text = "X";
            this.lblChord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChordsTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 450);
            this.Controls.Add(this.lblChord);
            this.Controls.Add(this.cboTimer);
            this.Controls.Add(this.btnNewList);
            this.Controls.Add(this.cboChords);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChordsTrain";
            this.Text = "Accords entrainement";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cboChords;
        private System.Windows.Forms.Button btnNewList;
        private System.Windows.Forms.ComboBox cboTimer;
        private System.Windows.Forms.Label lblChord;
    }
}


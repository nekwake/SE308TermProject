namespace SE308TermProject
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRunSimulation = new System.Windows.Forms.Button();
            this.numTypeAUsers = new System.Windows.Forms.NumericUpDown();
            this.numTypeBUsers = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numTypeAUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTypeBUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRunSimulation
            // 
            this.btnRunSimulation.Location = new System.Drawing.Point(713, 415);
            this.btnRunSimulation.Name = "btnRunSimulation";
            this.btnRunSimulation.Size = new System.Drawing.Size(75, 23);
            this.btnRunSimulation.TabIndex = 1;
            this.btnRunSimulation.Text = "Run Sim";
            this.btnRunSimulation.UseVisualStyleBackColor = true;
            this.btnRunSimulation.Click += new System.EventHandler(this.btnRunSimulation_Click);
            // 
            // numTypeAUsers
            // 
            this.numTypeAUsers.Location = new System.Drawing.Point(128, 133);
            this.numTypeAUsers.Name = "numTypeAUsers";
            this.numTypeAUsers.Size = new System.Drawing.Size(120, 20);
            this.numTypeAUsers.TabIndex = 2;
            // 
            // numTypeBUsers
            // 
            this.numTypeBUsers.Location = new System.Drawing.Point(444, 133);
            this.numTypeBUsers.Name = "numTypeBUsers";
            this.numTypeBUsers.Size = new System.Drawing.Size(120, 20);
            this.numTypeBUsers.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numTypeBUsers);
            this.Controls.Add(this.numTypeAUsers);
            this.Controls.Add(this.btnRunSimulation);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numTypeAUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTypeBUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRunSimulation;
        private System.Windows.Forms.NumericUpDown numTypeAUsers;
        private System.Windows.Forms.NumericUpDown numTypeBUsers;
    }
}


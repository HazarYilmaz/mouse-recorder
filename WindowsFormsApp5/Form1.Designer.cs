namespace WindowsFormsApp5
{
    partial class mouse_player
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mouse_player));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.ReplayButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.RecordButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(159)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 52);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::WindowsFormsApp5.Properties.Resources.cross;
            this.button1.Location = new System.Drawing.Point(449, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 46);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReplayButton
            // 
            this.ReplayButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ReplayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReplayButton.Font = new System.Drawing.Font("Arial", 15.75F);
            this.ReplayButton.ForeColor = System.Drawing.Color.White;
            this.ReplayButton.Image = global::WindowsFormsApp5.Properties.Resources.play_button_arrowhead;
            this.ReplayButton.Location = new System.Drawing.Point(357, 95);
            this.ReplayButton.Name = "ReplayButton";
            this.ReplayButton.Size = new System.Drawing.Size(117, 100);
            this.ReplayButton.TabIndex = 2;
            this.ReplayButton.Text = "Başlat";
            this.ReplayButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ReplayButton.UseVisualStyleBackColor = false;
            this.ReplayButton.Click += new System.EventHandler(this.ReplayButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopButton.Font = new System.Drawing.Font("Arial", 15.75F);
            this.StopButton.Image = global::WindowsFormsApp5.Properties.Resources.stop_button;
            this.StopButton.Location = new System.Drawing.Point(190, 95);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(117, 100);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Durdur";
            this.StopButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // RecordButton
            // 
            this.RecordButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.RecordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RecordButton.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RecordButton.ForeColor = System.Drawing.Color.White;
            this.RecordButton.Image = global::WindowsFormsApp5.Properties.Resources.button;
            this.RecordButton.Location = new System.Drawing.Point(21, 95);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(117, 100);
            this.RecordButton.TabIndex = 0;
            this.RecordButton.Text = "Kayıt";
            this.RecordButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RecordButton.UseVisualStyleBackColor = false;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(414, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 46);
            this.button2.TabIndex = 5;
            this.button2.Text = "_";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mouse Player";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // mouse_player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 251);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ReplayButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.RecordButton);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mouse_player";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mouse Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ReplayButton;
        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}


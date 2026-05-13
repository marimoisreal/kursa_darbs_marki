namespace kursa_darbs
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.katalogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valstisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tēmasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolekcijasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolekcionariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolekcijuPārvaldībaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolekcijasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.npgsqlConnection1 = new Npgsql.NpgsqlConnection();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.aizvērtAktīvoCilniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.katalogsToolStripMenuItem,
            this.kolekcijasToolStripMenuItem,
            this.logiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.logiToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(702, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // katalogsToolStripMenuItem
            // 
            this.katalogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.valstisToolStripMenuItem,
            this.tēmasToolStripMenuItem});
            this.katalogsToolStripMenuItem.Name = "katalogsToolStripMenuItem";
            this.katalogsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.katalogsToolStripMenuItem.Text = "Katalogs";
            // 
            // valstisToolStripMenuItem
            // 
            this.valstisToolStripMenuItem.Name = "valstisToolStripMenuItem";
            this.valstisToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.valstisToolStripMenuItem.Text = "Valstis";
            this.valstisToolStripMenuItem.Click += new System.EventHandler(this.valstisToolStripMenuItem_Click);
            // 
            // tēmasToolStripMenuItem
            // 
            this.tēmasToolStripMenuItem.Name = "tēmasToolStripMenuItem";
            this.tēmasToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.tēmasToolStripMenuItem.Text = "Tēmas";
            this.tēmasToolStripMenuItem.Click += new System.EventHandler(this.tēmasToolStripMenuItem_Click);
            // 
            // kolekcijasToolStripMenuItem
            // 
            this.kolekcijasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markiToolStripMenuItem,
            this.kolekcionariToolStripMenuItem,
            this.kolekcijuPārvaldībaToolStripMenuItem,
            this.kolekcijasToolStripMenuItem1});
            this.kolekcijasToolStripMenuItem.Name = "kolekcijasToolStripMenuItem";
            this.kolekcijasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.kolekcijasToolStripMenuItem.Text = "Kolekcijas";
            // 
            // markiToolStripMenuItem
            // 
            this.markiToolStripMenuItem.Name = "markiToolStripMenuItem";
            this.markiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.markiToolStripMenuItem.Text = "Markas";
            this.markiToolStripMenuItem.Click += new System.EventHandler(this.markiToolStripMenuItem_Click);
            // 
            // kolekcionariToolStripMenuItem
            // 
            this.kolekcionariToolStripMenuItem.Name = "kolekcionariToolStripMenuItem";
            this.kolekcionariToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kolekcionariToolStripMenuItem.Text = "Kolekcionāri";
            this.kolekcionariToolStripMenuItem.Click += new System.EventHandler(this.kolekcionariToolStripMenuItem_Click);
            // 
            // kolekcijuPārvaldībaToolStripMenuItem
            // 
            this.kolekcijuPārvaldībaToolStripMenuItem.Name = "kolekcijuPārvaldībaToolStripMenuItem";
            this.kolekcijuPārvaldībaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kolekcijuPārvaldībaToolStripMenuItem.Text = "Kolekciju pārvaldība";
            this.kolekcijuPārvaldībaToolStripMenuItem.Click += new System.EventHandler(this.kolekcijuPārvaldībaToolStripMenuItem_Click);
            // 
            // kolekcijasToolStripMenuItem1
            // 
            this.kolekcijasToolStripMenuItem1.Name = "kolekcijasToolStripMenuItem1";
            this.kolekcijasToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.kolekcijasToolStripMenuItem1.Text = "Kolekcijas";
            this.kolekcijasToolStripMenuItem1.Click += new System.EventHandler(this.kolekcijasToolStripMenuItem1_Click);
            // 
            // logiToolStripMenuItem
            // 
            this.logiToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aizvērtAktīvoCilniToolStripMenuItem});
            this.logiToolStripMenuItem.Name = "logiToolStripMenuItem";
            this.logiToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.logiToolStripMenuItem.Text = "Logi";
            this.logiToolStripMenuItem.Click += new System.EventHandler(this.logiToolStripMenuItem_Click);
            // 
            // npgsqlConnection1
            // 
            this.npgsqlConnection1.ProvideClientCertificatesCallback = null;
            this.npgsqlConnection1.ProvidePasswordCallback = null;
            this.npgsqlConnection1.UserCertificateValidationCallback = null;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 574);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // aizvērtAktīvoCilniToolStripMenuItem
            // 
            this.aizvērtAktīvoCilniToolStripMenuItem.Name = "aizvērtAktīvoCilniToolStripMenuItem";
            this.aizvērtAktīvoCilniToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aizvērtAktīvoCilniToolStripMenuItem.Text = "Aizvērt aktīvo cilni";
            this.aizvērtAktīvoCilniToolStripMenuItem.Click += new System.EventHandler(this.aizvērtAktīvoCilniToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SpringGreen;
            this.ClientSize = new System.Drawing.Size(702, 598);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem katalogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valstisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tēmasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolekcijasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolekcionariToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolekcijuPārvaldībaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolekcijasToolStripMenuItem1;
        private Npgsql.NpgsqlConnection npgsqlConnection1;
        private System.Windows.Forms.ToolStripMenuItem aizvērtAktīvoCilniToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
    }
}


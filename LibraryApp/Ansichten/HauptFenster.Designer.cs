#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace LibraryApp.Ansichten;

partial class HauptFenster
{
    /// <inheritdoc />
    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        lblTitel = new Label();
        txtTitel = new TextBox();
        lblAutor = new Label();
        txtAutor = new TextBox();
        lblJahr = new Label();
        txtJahr = new TextBox();
        lblIsbn = new Label();
        txtISBN = new TextBox();
        btnHinzufuegen = new Button();
        btnBildWaehlen = new Button();
        lblSuche = new Label();
        txtSuche = new TextBox();
        btnSuchen = new Button();
        btnAlleAnzeigen = new Button();
        dgvBuecher = new DataGridView();
        picBuchBild = new PictureBox();
        toolTip = new ToolTip(components);
        ((System.ComponentModel.ISupportInitialize)dgvBuecher).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picBuchBild).BeginInit();
        SuspendLayout();
        // 
        // lblTitel
        // 
        lblTitel.AutoSize = true;
        lblTitel.Location = new Point(24, 300);
        lblTitel.Name = "lblTitel";
        lblTitel.Size = new Size(37, 19);
        lblTitel.TabIndex = 5;
        lblTitel.Text = "Titel:";
        // 
        // txtTitel
        // 
        txtTitel.Location = new Point(120, 296);
        txtTitel.Name = "txtTitel";
        txtTitel.PlaceholderText = "z. B. Clean Code";
        txtTitel.Size = new Size(200, 25);
        txtTitel.TabIndex = 6;
        // 
        // lblAutor
        // 
        lblAutor.AutoSize = true;
        lblAutor.Location = new Point(24, 336);
        lblAutor.Name = "lblAutor";
        lblAutor.Size = new Size(44, 19);
        lblAutor.TabIndex = 7;
        lblAutor.Text = "Autor:";
        // 
        // txtAutor
        // 
        txtAutor.Location = new Point(120, 332);
        txtAutor.Name = "txtAutor";
        txtAutor.PlaceholderText = "z. B. Robert C. Martin";
        txtAutor.Size = new Size(200, 25);
        txtAutor.TabIndex = 8;
        // 
        // lblJahr
        // 
        lblJahr.AutoSize = true;
        lblJahr.Location = new Point(24, 372);
        lblJahr.Name = "lblJahr";
        lblJahr.Size = new Size(117, 19);
        lblJahr.TabIndex = 9;
        lblJahr.Text = "Erscheinungsjahr:";
        // 
        // txtJahr
        // 
        txtJahr.Location = new Point(120, 368);
        txtJahr.Name = "txtJahr";
        txtJahr.PlaceholderText = "z. B. 2008";
        txtJahr.Size = new Size(200, 25);
        txtJahr.TabIndex = 10;
        toolTip.SetToolTip(txtJahr, "Nur ganze Zahlen erlauben.");
        // 
        // lblIsbn
        // 
        lblIsbn.AutoSize = true;
        lblIsbn.Location = new Point(24, 408);
        lblIsbn.Name = "lblIsbn";
        lblIsbn.Size = new Size(39, 19);
        lblIsbn.TabIndex = 11;
        lblIsbn.Text = "ISBN:";
        // 
        // txtISBN
        // 
        txtISBN.Location = new Point(120, 404);
        txtISBN.Name = "txtISBN";
        txtISBN.PlaceholderText = "z. B. 9780132350884";
        txtISBN.Size = new Size(200, 25);
        txtISBN.TabIndex = 12;
        // 
        // btnHinzufuegen
        // 
        btnHinzufuegen.BackColor = Color.LightSteelBlue;
        btnHinzufuegen.FlatAppearance.BorderSize = 0;
        btnHinzufuegen.FlatStyle = FlatStyle.Flat;
        btnHinzufuegen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnHinzufuegen.ForeColor = Color.White;
        btnHinzufuegen.Location = new Point(24, 448);
        btnHinzufuegen.Name = "btnHinzufuegen";
        btnHinzufuegen.Size = new Size(200, 36);
        btnHinzufuegen.TabIndex = 13;
        btnHinzufuegen.Text = "+ Buch hinzufügen";
        btnHinzufuegen.UseVisualStyleBackColor = false;
        btnHinzufuegen.Click += btnHinzufuegen_Click;
        // 
        // btnBildWaehlen
        // 
        btnBildWaehlen.BackColor = Color.LightSteelBlue;
        btnBildWaehlen.FlatAppearance.BorderSize = 0;
        btnBildWaehlen.FlatStyle = FlatStyle.Flat;
        btnBildWaehlen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnBildWaehlen.ForeColor = Color.White;
        btnBildWaehlen.Location = new Point(240, 448);
        btnBildWaehlen.Name = "btnBildWaehlen";
        btnBildWaehlen.Size = new Size(150, 36);
        btnBildWaehlen.TabIndex = 14;
        btnBildWaehlen.Text = "Bild auswählen...";
        btnBildWaehlen.UseVisualStyleBackColor = false;
        btnBildWaehlen.Click += btnBildWaehlen_Click;
        // 
        // lblSuche
        // 
        lblSuche.AutoSize = true;
        lblSuche.Location = new Point(24, 502);
        lblSuche.Name = "lblSuche";
        lblSuche.Size = new Size(49, 19);
        lblSuche.TabIndex = 16;
        lblSuche.Text = "Suche:";
        // 
        // txtSuche
        // 
        txtSuche.Location = new Point(120, 498);
        txtSuche.Name = "txtSuche";
        txtSuche.PlaceholderText = "Titel oder Autor...";
        txtSuche.Size = new Size(200, 25);
        txtSuche.TabIndex = 17;
        // 
        // btnSuchen
        // 
        btnSuchen.BackColor = Color.LightSteelBlue;
        btnSuchen.FlatAppearance.BorderSize = 0;
        btnSuchen.FlatStyle = FlatStyle.Flat;
        btnSuchen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSuchen.ForeColor = Color.White;
        btnSuchen.Location = new Point(340, 496);
        btnSuchen.Name = "btnSuchen";
        btnSuchen.Size = new Size(120, 32);
        btnSuchen.TabIndex = 18;
        btnSuchen.Text = "Suchen";
        btnSuchen.UseVisualStyleBackColor = false;
        btnSuchen.Click += btnSuchen_Click;
        // 
        // btnAlleAnzeigen
        // 
        btnAlleAnzeigen.BackColor = Color.LightSteelBlue;
        btnAlleAnzeigen.FlatAppearance.BorderSize = 0;
        btnAlleAnzeigen.FlatStyle = FlatStyle.Flat;
        btnAlleAnzeigen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnAlleAnzeigen.ForeColor = Color.White;
        btnAlleAnzeigen.Location = new Point(410, 448);
        btnAlleAnzeigen.Name = "btnAlleAnzeigen";
        btnAlleAnzeigen.Size = new Size(150, 36);
        btnAlleAnzeigen.TabIndex = 15;
        btnAlleAnzeigen.Text = "Alle anzeigen";
        btnAlleAnzeigen.UseVisualStyleBackColor = false;
        btnAlleAnzeigen.Click += btnAlleAnzeigen_Click;
        // 
        // dgvBuecher
        // 
        dgvBuecher.AllowUserToAddRows = false;
        dgvBuecher.AllowUserToDeleteRows = false;
        dgvBuecher.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        dgvBuecher.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBuecher.BackgroundColor = Color.White;
        dgvBuecher.BorderStyle = BorderStyle.None;
        dgvBuecher.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvBuecher.Location = new Point(24, 24);
        dgvBuecher.MultiSelect = false;
        dgvBuecher.Name = "dgvBuecher";
        dgvBuecher.ReadOnly = true;
        dgvBuecher.RowHeadersVisible = false;
        dgvBuecher.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBuecher.Size = new Size(520, 252);
        dgvBuecher.TabIndex = 0;
        dgvBuecher.CellClick += dgvBuecher_CellClick;
        // 
        // picBuchBild
        // 
        picBuchBild.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        picBuchBild.BorderStyle = BorderStyle.None;
        picBuchBild.Location = new Point(560, 24);
        picBuchBild.Name = "picBuchBild";
        picBuchBild.Size = new Size(280, 252);
        picBuchBild.SizeMode = PictureBoxSizeMode.Zoom;
        picBuchBild.TabIndex = 1;
        picBuchBild.TabStop = false;
        // 
        // HauptFenster
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        ClientSize = new Size(864, 560);
        Controls.Add(picBuchBild);
        Controls.Add(dgvBuecher);
        Controls.Add(btnAlleAnzeigen);
        Controls.Add(btnSuchen);
        Controls.Add(lblSuche);
        Controls.Add(txtSuche);
        Controls.Add(btnBildWaehlen);
        Controls.Add(btnHinzufuegen);
        Controls.Add(txtISBN);
        Controls.Add(lblIsbn);
        Controls.Add(txtJahr);
        Controls.Add(lblJahr);
        Controls.Add(txtAutor);
        Controls.Add(lblAutor);
        Controls.Add(txtTitel);
        Controls.Add(lblTitel);
        Font = new Font("Segoe UI", 10F);
        MinimumSize = new Size(880, 600);
        Name = "HauptFenster";
        Text = "LibraryApp";
        Load += HauptFenster_Load;
        ((System.ComponentModel.ISupportInitialize)dgvBuecher).EndInit();
        ((System.ComponentModel.ISupportInitialize)picBuchBild).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.ComponentModel.IContainer? components;
    private Label lblTitel = null!;
    private TextBox txtTitel = null!;
    private Label lblAutor = null!;
    private TextBox txtAutor = null!;
    private Label lblJahr = null!;
    private TextBox txtJahr = null!;
    private Label lblIsbn = null!;
    private TextBox txtISBN = null!;
    private Button btnHinzufuegen = null!;
    private Button btnBildWaehlen = null!;
    private Label lblSuche = null!;
    private TextBox txtSuche = null!;
    private Button btnSuchen = null!;
    private Button btnAlleAnzeigen = null!;
    private DataGridView dgvBuecher = null!;
    private PictureBox picBuchBild = null!;
    private ToolTip toolTip = null!;
}

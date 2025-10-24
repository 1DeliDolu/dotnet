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
        lblTitel.Location = new Point(24, 24);
        lblTitel.Name = "lblTitel";
        lblTitel.Size = new Size(32, 15);
        lblTitel.TabIndex = 0;
        lblTitel.Text = "Titel:";
        // 
        // txtTitel
        // 
        txtTitel.Location = new Point(120, 21);
        txtTitel.Name = "txtTitel";
        txtTitel.PlaceholderText = "z. B. Clean Code";
        txtTitel.Size = new Size(220, 23);
        txtTitel.TabIndex = 1;
        // 
        // lblAutor
        // 
        lblAutor.AutoSize = true;
        lblAutor.Location = new Point(24, 63);
        lblAutor.Name = "lblAutor";
        lblAutor.Size = new Size(38, 15);
        lblAutor.TabIndex = 2;
        lblAutor.Text = "Autor:";
        // 
        // txtAutor
        // 
        txtAutor.Location = new Point(120, 60);
        txtAutor.Name = "txtAutor";
        txtAutor.PlaceholderText = "z. B. Robert C. Martin";
        txtAutor.Size = new Size(220, 23);
        txtAutor.TabIndex = 3;
        // 
        // lblJahr
        // 
        lblJahr.AutoSize = true;
        lblJahr.Location = new Point(24, 102);
        lblJahr.Name = "lblJahr";
        lblJahr.Size = new Size(92, 15);
        lblJahr.TabIndex = 4;
        lblJahr.Text = "Erscheinungsjahr:";
        // 
        // txtJahr
        // 
        txtJahr.Location = new Point(120, 99);
        txtJahr.Name = "txtJahr";
        txtJahr.PlaceholderText = "z. B. 2008";
        txtJahr.Size = new Size(220, 23);
        txtJahr.TabIndex = 5;
        toolTip.SetToolTip(txtJahr, "Nur ganze Zahlen erlauben.");
        // 
        // lblIsbn
        // 
        lblIsbn.AutoSize = true;
        lblIsbn.Location = new Point(24, 141);
        lblIsbn.Name = "lblIsbn";
        lblIsbn.Size = new Size(33, 15);
        lblIsbn.TabIndex = 6;
        lblIsbn.Text = "ISBN:";
        // 
        // txtISBN
        // 
        txtISBN.Location = new Point(120, 138);
        txtISBN.Name = "txtISBN";
        txtISBN.PlaceholderText = "z. B. 9780132350884";
        txtISBN.Size = new Size(220, 23);
        txtISBN.TabIndex = 7;
        // 
        // btnHinzufuegen
        // 
        btnHinzufuegen.Location = new Point(120, 177);
        btnHinzufuegen.Name = "btnHinzufuegen";
        btnHinzufuegen.Size = new Size(220, 32);
        btnHinzufuegen.TabIndex = 8;
        btnHinzufuegen.Text = "+ Buch hinzufügen";
        btnHinzufuegen.UseVisualStyleBackColor = true;
        btnHinzufuegen.Click += btnHinzufuegen_Click;
        // 
        // btnBildWaehlen
        // 
        btnBildWaehlen.Location = new Point(360, 177);
        btnBildWaehlen.Name = "btnBildWaehlen";
        btnBildWaehlen.Size = new Size(140, 32);
        btnBildWaehlen.TabIndex = 9;
        btnBildWaehlen.Text = "Bild auswählen...";
        btnBildWaehlen.UseVisualStyleBackColor = true;
        btnBildWaehlen.Click += btnBildWaehlen_Click;
        // 
        // txtSuche
        // 
        txtSuche.Location = new Point(24, 230);
        txtSuche.Name = "txtSuche";
        txtSuche.PlaceholderText = "Titel oder Autor...";
        txtSuche.Size = new Size(220, 23);
        txtSuche.TabIndex = 10;
        // 
        // btnSuchen
        // 
        btnSuchen.Location = new Point(260, 229);
        btnSuchen.Name = "btnSuchen";
        btnSuchen.Size = new Size(100, 25);
        btnSuchen.TabIndex = 11;
        btnSuchen.Text = "Suchen";
        btnSuchen.UseVisualStyleBackColor = true;
        btnSuchen.Click += btnSuchen_Click;
        // 
        // btnAlleAnzeigen
        // 
        btnAlleAnzeigen.Location = new Point(376, 229);
        btnAlleAnzeigen.Name = "btnAlleAnzeigen";
        btnAlleAnzeigen.Size = new Size(120, 25);
        btnAlleAnzeigen.TabIndex = 12;
        btnAlleAnzeigen.Text = "Alle anzeigen";
        btnAlleAnzeigen.UseVisualStyleBackColor = true;
        btnAlleAnzeigen.Click += btnAlleAnzeigen_Click;
        // 
        // dgvBuecher
        // 
        dgvBuecher.AllowUserToAddRows = false;
        dgvBuecher.AllowUserToDeleteRows = false;
        dgvBuecher.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvBuecher.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBuecher.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvBuecher.Location = new Point(24, 272);
        dgvBuecher.MultiSelect = false;
        dgvBuecher.Name = "dgvBuecher";
        dgvBuecher.ReadOnly = true;
        dgvBuecher.RowHeadersVisible = false;
        dgvBuecher.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBuecher.Size = new Size(540, 220);
        dgvBuecher.TabIndex = 13;
        dgvBuecher.CellClick += dgvBuecher_CellClick;
        // 
        // picBuchBild
        // 
        picBuchBild.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        picBuchBild.BorderStyle = BorderStyle.FixedSingle;
        picBuchBild.Location = new Point(580, 24);
        picBuchBild.Name = "picBuchBild";
        picBuchBild.Size = new Size(260, 468);
        picBuchBild.SizeMode = PictureBoxSizeMode.Zoom;
        picBuchBild.TabIndex = 14;
        picBuchBild.TabStop = false;
        // 
        // HauptFenster
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(864, 521);
        Controls.Add(picBuchBild);
        Controls.Add(dgvBuecher);
        Controls.Add(btnAlleAnzeigen);
        Controls.Add(btnSuchen);
        Controls.Add(txtSuche);
        Controls.Add(btnBildWaehlen);
        Controls.Add(btnHinzufuegen);
        Controls.Add(txtJahr);
        Controls.Add(lblJahr);
        Controls.Add(txtISBN);
        Controls.Add(lblIsbn);
        Controls.Add(txtAutor);
        Controls.Add(lblAutor);
        Controls.Add(txtTitel);
        Controls.Add(lblTitel);
        MinimumSize = new Size(880, 560);
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
    private TextBox txtSuche = null!;
    private Button btnSuchen = null!;
    private Button btnAlleAnzeigen = null!;
    private DataGridView dgvBuecher = null!;
    private PictureBox picBuchBild = null!;
    private ToolTip toolTip = null!;
}

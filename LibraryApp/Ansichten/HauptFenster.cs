using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LibraryApp.Modelle;
using LibraryApp.Steuerung;

namespace LibraryApp.Ansichten;

public partial class HauptFenster : Form
{
    private readonly BuchSteuerung steuerung = new();
    private string ausgewaehltesBildPfad = string.Empty;

    public HauptFenster()
    {
        InitializeComponent();
    }

    private void HauptFenster_Load(object? sender, EventArgs e)
    {
        ZeigeBuecher(steuerung.BuecherListe());
        StyleDataGrid();
    }

    private void btnHinzufuegen_Click(object? sender, EventArgs e)
    {
        string titel = txtTitel.Text;
        string autor = txtAutor.Text;
        string isbn = txtISBN.Text;

        if (!int.TryParse(txtJahr.Text, out int jahr))
        {
            MessageBox.Show("Bitte ein gültiges Erscheinungsjahr eingeben.", "Eingabefehler",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtJahr.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(titel) || string.IsNullOrWhiteSpace(autor) || string.IsNullOrWhiteSpace(isbn))
        {
            MessageBox.Show("Titel, Autor und ISBN dürfen nicht leer sein.", "Eingabefehler",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        steuerung.BuchHinzufuegen(titel, autor, jahr, isbn, ausgewaehltesBildPfad);
        AktualisiereTabelle();
        BereinigeEingaben();
    }

    private void AktualisiereTabelle()
    {
        ZeigeBuecher(steuerung.BuecherListe());
    }

    private void BereinigeEingaben()
    {
        txtTitel.Clear();
        txtAutor.Clear();
        txtJahr.Clear();
        txtISBN.Clear();
        ausgewaehltesBildPfad = string.Empty;
        picBuchBild.Image = null;
        txtTitel.Focus();
    }

    private void btnSuchen_Click(object? sender, EventArgs e)
    {
        List<Buch> treffer = steuerung.Suche(txtSuche.Text);
        ZeigeBuecher(treffer);
    }

    private void btnAlleAnzeigen_Click(object? sender, EventArgs e)
    {
        txtSuche.Clear();
        AktualisiereTabelle();
    }

    private void ZeigeBuecher(List<Buch> daten)
    {
        dgvBuecher.DataSource = null;
        dgvBuecher.DataSource = daten;
    }

    private void StyleDataGrid()
    {
        dgvBuecher.EnableHeadersVisualStyles = false;
        dgvBuecher.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
        dgvBuecher.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvBuecher.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvBuecher.DefaultCellStyle.SelectionBackColor = Color.FromArgb(176, 196, 222);
        dgvBuecher.DefaultCellStyle.SelectionForeColor = Color.Black;
    }

    private void btnBildWaehlen_Click(object? sender, EventArgs e)
    {
        using OpenFileDialog dialog = new()
        {
            Filter = "Bilddateien|*.jpg;*.jpeg;*.png;*.bmp",
            Title = "Buchbild auswählen"
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            ausgewaehltesBildPfad = dialog.FileName;
            picBuchBild.ImageLocation = ausgewaehltesBildPfad;
        }
    }

    private void dgvBuecher_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (dgvBuecher.SelectedRows.Count == 0)
        {
            return;
        }

        if (dgvBuecher.SelectedRows[0].DataBoundItem is Buch buch)
        {
            if (!string.IsNullOrWhiteSpace(buch.BildPfad) && File.Exists(buch.BildPfad))
            {
                picBuchBild.ImageLocation = buch.BildPfad;
            }
            else
            {
                picBuchBild.Image = null;
            }
        }
    }
}

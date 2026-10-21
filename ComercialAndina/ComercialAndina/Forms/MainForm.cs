using ComercialAndina.ComercialAndina.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ComercialAndina.ComercialAndina.Forms
{
    public sealed class MainForm : Form
    {
        private readonly GestorComercial gestor = new GestorComercial();

        public MainForm()
        {
            Text = "Comercial Andina S.A.C.";
            Width = 1000;
            Height = 650;
            StartPosition = FormStartPosition.CenterScreen;

            var titulo = new Label
            {
                Text = "Sistema de Gestión de Ventas",
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16, FontStyle.Bold)
            };

            var descripcion = new Label
            {
                Text = "Prototipo académico de Estructuras de Datos",
                Dock = DockStyle.Top,
                Height = 35,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(descripcion);
            Controls.Add(titulo);
        }
    }
}

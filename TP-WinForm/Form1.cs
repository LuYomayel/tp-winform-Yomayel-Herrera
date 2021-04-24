﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_WinForm
{
    public partial class Form1 : Form
    {
        private List<Producto> listaProductos;

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            
            try
            {
                listaProductos = productoNegocio.listar();
                dgw.DataSource = listaProductos;

                //Oculto Columnas de la grilla.
                //Puedo poner el indice de la columna o el nombre de la propiedad.
                //dgw.Columns["Ficha"].Visible = false;
                ////dgw.Columns["Descripcion"].Visible = false;
                dgw.Columns["UrlImagen"].Visible = false;
                //dgw.Columns["Evolucion"].Visible = false;

                RecargarImg(listaProductos[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RecargarImg(string img)
        {
            
            try
            {
                pBox.Load(img);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgw_MouseClick(object sender, MouseEventArgs e)
        {
            Producto seleccionado = (Producto)dgw.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.UrlImagen);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar agregar = new Agregar();
            agregar.ShowDialog();
        }
    }
}

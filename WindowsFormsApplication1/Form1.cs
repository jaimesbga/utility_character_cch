using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Controles;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        private cuadricula cPanel;

        public Form1()
        {        

            InitializeComponent();
            cargarMalla();
    
        }

        private void cargarMalla()
        {

            cPanel= new cuadricula(8,16);
            //=================================================================================
            for (int i = 0; i < cPanel.get_Y(); i++)
            {
                for (int j = 0; j < cPanel.get_X(); j++)
                {

                    this.Controls.Add(cPanel.get_button(i, j));
                    this.Update();
                }
            }
            //=================================================================================
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = cPanel.procesarCuadriculas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cPanel.limpiarPanel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cPanel.setCaracter(textBox1.Text);
        }

    }
}

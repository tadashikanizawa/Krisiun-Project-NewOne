﻿using Krisiun_Project.G_Code;
using Krisiun_Project.Janelas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Krisiun_Project.UserControils
{
    public partial class Lado_UserControl : UserControl
    {
        public delegate void AlterarPropriedadesEventHandler(bool visible);

        public delegate void AlterarPropriedadesEventHandler1(bool visible);

        // Declarando um evento usando o delegado
        public event AlterarPropriedadesEventHandler OnAlterarPropriedades;
        public event AlterarPropriedadesEventHandler1 OnAlterarPropriedades1;
     
        public Lado_UserControl()
        {
            InitializeComponent();
            
        }

        private void frente_checkBox_CheckedChanged(object sender, EventArgs e)
        {
        Mudarvisibilidade(frente_checkBox.Checked);
        }
        private void tras_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Mudarvisibilidade1(tras_checkBox.Checked);

        }
        private void Mudarvisibilidade(bool visible)
        {
                OnAlterarPropriedades?.Invoke(visible);
            
        }
        private void Mudarvisibilidade1(bool isibile2)
        {

            OnAlterarPropriedades1?.Invoke(isibile2);
        }

        private void Lado_UserControl_Load(object sender, EventArgs e)
        {

        }
        public bool Bool_Frente
        {
            get { return frente_checkBox.Checked; }
            set { frente_checkBox.Checked = value; }
        }
        public bool Bool_Tras
        {
            get { return tras_checkBox.Checked; }
            set { tras_checkBox.Checked = value; }
        }
        public void LoadLado(Ferramentas ferramenta)
        {
            Bool_Frente = ferramenta.Frente;
            Bool_Tras = ferramenta.Tras;
        }
   
    }
}

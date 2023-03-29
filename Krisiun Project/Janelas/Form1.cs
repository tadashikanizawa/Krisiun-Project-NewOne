﻿using Krisiun_Project.Dados_aleatorios;
using Krisiun_Project.Dados_Aleatorios1;
using Krisiun_Project.Desenhos;
using Krisiun_Project.G_Code;
using Krisiun_Project.janela_principal;
using Krisiun_Project.Janelas;
using Krisiun_Project.Numeros;
using Krisiun_Project.UserControils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;
using WindowsFormsApp1;
using static Krisiun_Project.Pitch_principal;

namespace Krisiun_Project
{
    public partial class Form1 : Form
    {
        #region Iniciação
        // private Listas listas;
        private Peca peca;
        private Tap taps;
        private Bugs.Bugs_Txb bugs;
        private Shindashi shin;
        private Pitch meio;
        private ToolNumber toolnum;
        private Addtextbox addtb;
        private Tests t;
        private DrillMaterialKey drillMaterialKey;
        private Bools bools;
        private Drills Mydrills;
        private TiposdeMentori TiposdeMentori;
        private Coordenadas coordenadas;
        private CoordenadasGrupo xygrupo;
        private Ferramentas ferramentas;
        private TipoDeDrills tipoDeDrills;
        private TiposdeMentori tiposdeMentori;
        private DGV_Codes datagridcodes;
        private Form2 form2;
        private Form3 form3;
        private Form5 form5;
        private GCodeGenerator gCodeGenerator;

        private Zairyo.Desenho d;
        private NSB nsb;
        private ColorItem coloritem;
        private Pastas pastas;
        private Mentori_Frente mentorifrente;
        //private  NSBLoader nSB;
        // private NSBLoader nsbs;
        public BindingSource bindingSource = new BindingSource();
        public BindingSource bindingSource1 = new BindingSource();
        public BindingSource bindingSource2 = new BindingSource();
        public BindingSource bindingSource3 = new BindingSource();
        public BindingSource bindingSource4 = new BindingSource();
        public List<Kougu> ListadeKougu;

        public Form1()
        {
            InitializeComponent();
            this.bools = new Bools();

            this.drillMaterialKey = new DrillMaterialKey(null, null);
            this.coordenadas = new Coordenadas();
            this.meio = new Pitch(bools);
            this.d = new Zairyo.Desenho(bools);
            this.toolnum = new ToolNumber();
            this.peca = new Peca();
            this.ferramentas = new Ferramentas(peca);


            this.Mydrills = new Drills(peca);
            this.bugs = new Bugs.Bugs_Txb();
            this.shin = new Shindashi(meio);
            this.t = new Tests();
            this.addtb = new Addtextbox(t, coordenadas);
            this.pastas = new Pastas();
            this.taps = new Tap(peca);
            this.form2 = new Form2(this, ferramentas, bools);

            this.gCodeGenerator = new GCodeGenerator(ferramentas, pastas, peca);
            this.datagridcodes = new DGV_Codes(this, peca);
            this.form3 = new Form3(peca, this, meio, shin, bugs, bools);
            this.form5 = new Form5(ferramentas, peca, this, pastas, gCodeGenerator);
            this.nsb = new NSB();
        

            bindingSource4.DataSource = null;

            dgvCoordenadas.DataSource = bindingSource4;

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            //addtb.CriarTextBoxesIniciais(panel_XY);
            //tamanhopainel(panel_XY);
            bindingSource.DataSource = ferramentas.ListFrente;
            dataGridView1.DataSource = bindingSource;

            bindingSource1.DataSource = ferramentas.ListTras;
            dataGridView2.DataSource = bindingSource1;

            bindingSource2.DataSource = ferramentas.ListTotal;
            dataGridView3.DataSource = bindingSource2;


            gruposCoordenadasBindingSource.DataSource = gruposCoordenadas;

            // Atribui o BindingSource como DataSource da ListBox


            // Atribui o BindingSource como DataSource da DataGridView
            dgvCoordenadas.DataSource = gruposCoordenadasBindingSource;
            dgvCoordenadas.DataMember = "Coordenadas";


            add_tb_naLista();
            //addtb.CriarTextBoxesIniciais(panelXY);

            form3.ShowDialog();
            panel_update();
            atualizarComboBoxCores();
            addcore();
            TipoDeDrills.LoadListdeDrills();
            TiposdeMentori.TipoMentoriLoad();
            TiposdeTap.CriarListas();
            Kougu.CarregarListadeKougu();
            NSB.NSBLoad();
            Mydrills.LoadKaitenValuesFromCsv();
            comboBoxCores.SelectedIndex = 8;

        }
        public Color[] cores = new Color[] { Color.Black, Color.Cyan, Color.Red, Color.Blue, Color.Green, Color.Gray, Color.Pink, Color.Purple, Color.LightGray };
        public void addcore()
        {
            foreach (Color cor in cores)
            {
                ColorItem itemCor = new ColorItem(cor, cor.Name);
                comboBoxCores.Items.Add(itemCor);
            }

        }
        Color corAtual = Color.Black;
        private void selecionarCor(object sender, EventArgs e)
        {
            ColorItem itemCor = (ColorItem)comboBoxCores.SelectedItem;
            corAtual = itemCor.Color; // Definindo a cor atual para a cor selecionada
        }
        private void atualizarComboBoxCores()
        {
            foreach (ColorItem itemCor in comboBoxCores.Items)
            {
                if (itemCor.Color.Equals(corAtual))
                {
                    comboBoxCores.SelectedItem = itemCor;
                    break;
                }
            }
        }
        public BindingList<CoordenadasGrupo> gruposCoordenadas = new BindingList<CoordenadasGrupo>();
        public BindingSource coordenadasBindingSource = new BindingSource();
        public List<TextBox> TextBoxes = new List<TextBox>();
        public List<CheckBox> CheckBoxes = new List<CheckBox>();
        public List<Panel> PanelList = new List<Panel>();
        public List<TextBox> xyboxs = new List<TextBox>();
        public List<ComboBox> ComboBoxList = new List<ComboBox>();
        private BindingSource gruposCoordenadasBindingSource = new BindingSource();
        #endregion

        // Atribui o BindingSource à lista de grupos de coordenadas
        #region Load_as_coisas.

    
  
        private void add_tb_naLista()
        {
            //TextBoxes.Add(Num_pro_textbox); //[0]
            //TextBoxes.Add(drill_kei_tb);    //[1]
            //TextBoxes.Add(drill_z_tb); //[2]
            //TextBoxes.Add(men_frente_tam_tb); //[3]
            //TextBoxes.Add(men_frente_kei_tb); //[4]
            //TextBoxes.Add(men_frente_z_tb);//[5]
            //TextBoxes.Add(men_frente_dan_tb);//[6]

            //TextBoxes.Add(tool_tb); //7


            //TextBoxes.Add(men_tras_tam); //8
            //TextBoxes.Add(men_tras_kei); //9
            //TextBoxes.Add(men_tras_z); //10
            //TextBoxes.Add(men_tras_dan);//11



            //CheckBoxes.Add(frente_checkBox); //[0]
            //CheckBoxes.Add(tras_checkBox); //[1]
            //CheckBoxes.Add(sentan_cb); //[2]
            //CheckBoxes.Add(men_frente_checkbox); //[3]
            //CheckBoxes.Add(men_tras_checkbox); //[4]


            //PanelList.Add(panel_boringana); //[0]

            //ComboBoxList.Add(drill_combobox); //0
            ComboBoxList.Add(comboBoxCores);//1
       
        }
        #region Tamanho_Escala_Base



        private void button1_Click(object sender, EventArgs e)
        {
            NSBForm formnsb = new NSBForm();
            formnsb.Show();
        }
        public void SavePictureBoxAsJPG(Panel pb, String strg)
        {
            Bitmap bitmap = new Bitmap(pb.Width, pb.Height);

            // Copiar o conteúdo do panel para o bitmap
            pb.DrawToBitmap(bitmap, pb.ClientRectangle);

            // Salvar o bitmap em jpg
            string dir = pastas.CaminhoRaiz;
            string ar = strg;
            bitmap.Save(Path.Combine(dir, ar), System.Drawing.Imaging.ImageFormat.Jpeg);
        }

     


        private void button2_Click(object sender, EventArgs e)
        {
            float escala = (float)Convert.ToDouble(scale_tb.Text);
            escala = escala + 0.5f;
            scale_tb.Text = escala.ToString();
            panel_update();
        }

        private void scale_tb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(scale_tb.Text)) { return; }
            bugs.sohnums(scale_tb, e);
            peca.scale = (float)Convert.ToDouble(scale_tb.Text);
            float scala;
            if (float.TryParse(scale_tb.Text, out scala))
            {
                peca.scale = scala;
                peca.UpdateSize(peca.sizex, peca.sizey, peca.sizez);
            }
            meio.calculo_de_base(shin, peca, peca.basex, peca.basey);
            paneld_f.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float escala = (float)Convert.ToDouble(scale_tb.Text);
            escala = escala - 0.5f;
            if (escala <= 0) { escala = 0.1f; }
            scale_tb.Text = escala.ToString();
            panel_update();
        }

        #endregion
        #region Sobre_Paineis_de_Desenho
        private void y_inv_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            peca.yinv = y_inv_checkbox.Checked;
            panel_update();
        }
        private void paneld_f_Paint(object sender, PaintEventArgs e)
        {
            if (bools.Maru == true) { d.zaryoelipse(e, peca); d.linhabase_circulo(e, shin, peca, meio, t, false, false); }
            if (bools.Shikaku == true)
            {
                d.zaryoretangulo(e, peca);
                d.linhabase(e, shin, peca, meio, t, false, false);

                d.linhaslaterias(e, shin, peca, meio, t, false, false);
            }
            Font font = new Font("Arial", 10);
            Font font1 = new Font("Arial", 7);
            Brush brush = new SolidBrush(Color.Black);
            Graphics g = e.Graphics;
            g.DrawString("FRONT", font, brush, 10, 10);
            d.DesenharFerramentas(e, ferramentas.ListTotal, false, false, paneld_f, panel_b);
            //  d.linha(e);
        }

        private void panel_b_Paint(object sender, PaintEventArgs e) //painel da traseira.
        {
            bool boolx = false;
            bool booly = false;
            if (x_inv_checkbok.Checked) { boolx = true; }
            if (y_inv_checkbox.Checked) { booly = true; }
            if (bools.Maru == true) { d.zaryoelipse(e, peca); d.linhabase_circulo(e, shin, peca, meio, t, boolx, booly); }
            if (bools.Shikaku == true)
            {
                d.zaryoretangulo(e, peca);
                d.linhabase(e, shin, peca, meio, t, boolx, booly);
                d.linhaslaterias(e, shin, peca, meio, t, boolx, booly);
            }
            Font font = new Font("Arial", 10);
            Brush brush = new SolidBrush(Color.Black);
            Graphics g = e.Graphics;
            d.DesenharFerramentas(e, ferramentas.ListTotal, boolx, booly, panel_b, paneld_f);
            g.DrawString("BACK", font, brush, 10, 10);
            // d.linha(e);
        }
        private void panel_yoko_Paint(object sender, PaintEventArgs e)
        {

            d.lado(e, peca);
            //d.desenholado(e, ferramentas.ListTotal);
            //d.DesenharFerramentas(e, ferramentas.ListTotal, false, false, panel_yoko, panel_yoko);
            d.desenholadonew(e, ferramentas.ListTotal);
        }
        private void frente_rd_CheckedChanged(object sender, EventArgs e)
        {
            if (frente_rd.Checked)
            {
                paneld_f.Refresh();
                paneld_f.BringToFront();
                if (lado_checkbox.Checked) { panel_yoko.BringToFront(); }

            }
        }

        private void tras_rd_CheckedChanged(object sender, EventArgs e)
        {
            if (tras_rd.Checked)
            {
                panel_b.Refresh();
                panel_b.BringToFront();
                if (lado_checkbox.Checked) { panel_yoko.BringToFront(); }

            }
        }

        private void code_rd_CheckedChanged(object sender, EventArgs e)
        {

            panel_Code.BringToFront();
        }
        public void panel_update()
        {
            paneld_f.Invalidate();
            panel_b.Invalidate();
            panel_yoko.Invalidate();
        }
        private void lado_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (lado_checkbox.Checked) { bools.bool_lado = true; panel_yoko.Visible = true; }
            else { bools.bool_lado = false; panel_yoko.Visible = false; }
            panel_yoko.BringToFront();
            panel_update();
        }
        #endregion
        #region Em relação aos Panels de config de Iteração

        private DataGridViewCell selectedCell;
        private void Form1_Load(object sender, EventArgs e)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;


            this.Size = new Size(2000, 1500);

        }


        #endregion

        #endregion
        #region Métodos de atualizar as budegas
        private void AtualizarNome<T>(TextBox textBox, T objeto, string nomePropriedade) where T : class
        {
            if (lastSelectedDgv != null)
            {
                T objetoSelecionado = lastSelectedDgv.CurrentRow.DataBoundItem as T;
                if (objetoSelecionado != null)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(nomePropriedade);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(objetoSelecionado, Convert.ChangeType(textBox.Text, propertyInfo.PropertyType));
                        lastSelectedDgv.Refresh();
                        dataGridView1.Refresh();
                        dataGridView2.Refresh();
                        dataGridView3.Refresh();
                    }
                }
            }
        }
        private void Load_Textbox<T>(TextBox textBox, T objeto, string nomePropriedade) where T : class
        {
            if (lastSelectedDgv != null)
            {
                float valor;
                if (float.TryParse(textBox.Text, out valor))
                {
                    T objetoSelecionado = lastSelectedDgv.CurrentRow.DataBoundItem as T;
                    if (objetoSelecionado != null)
                    {
                        PropertyInfo propertyInfo = typeof(T).GetProperty(nomePropriedade);
                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(objetoSelecionado, Convert.ChangeType(valor, propertyInfo.PropertyType));
                            lastSelectedDgv.Refresh();
                            dataGridView1.Refresh();
                            dataGridView2.Refresh();
                            dataGridView3.Refresh();
                        }
                    }

                }
            }
        }
        private void Load_TextboxString<T>(TextBox textBox1, T objeto, string nomePropriedade) where T : class
        {
            if (lastSelectedDgv != null)
            {
                string valor1 = textBox1.Text;
                string valor2 = valor1;
                T objetoSelecionado = lastSelectedDgv.CurrentRow.DataBoundItem as T;
                if (objetoSelecionado != null)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(nomePropriedade);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(objetoSelecionado, Convert.ChangeType(valor2, propertyInfo.PropertyType));
                        lastSelectedDgv.Refresh();
                        dataGridView1.Refresh();
                        dataGridView2.Refresh();
                        dataGridView3.Refresh();
                    }
                }


            }
        }
        public int index = 0;
        private void Load_TextboxString2<T>(ComboBox textBox, TextBox textBox1, T objeto, string nomePropriedade) where T : class
        {
            if (lastSelectedDgv != null)
            {
                string valor = textBox.Text;
                string valor1 = textBox1.Text;
                string valor2 = index.ToString() + "-" + valor + "φ" + valor1;
                T objetoSelecionado = lastSelectedDgv.CurrentRow.DataBoundItem as T;
                if (objetoSelecionado != null)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(nomePropriedade);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(objetoSelecionado, Convert.ChangeType(valor2, propertyInfo.PropertyType));
                        lastSelectedDgv.Refresh();
                        dataGridView1.Refresh();
                        dataGridView2.Refresh();
                        dataGridView3.Refresh();
                    }
                }

                index++;
            }
        }
        private void Load_Combobox<T>(ComboBox comboBox, T objeto, string nomePropriedade) where T : class
        {
            if (lastSelectedDgv != null)
            {
                T objetoSelecionado = lastSelectedDgv.CurrentRow.DataBoundItem as T;
                if (objetoSelecionado != null)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(nomePropriedade);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(objetoSelecionado, Convert.ChangeType(comboBox.Text, propertyInfo.PropertyType));
                        lastSelectedDgv.Refresh();
                        dataGridView1.Refresh();
                        dataGridView2.Refresh();
                        dataGridView3.Refresh();
                    }
                }
            }
        }
        private void Load_ComboboxColor<T>(ComboBox comboBox, T objeto, string nomePropriedade) where T : class
        {
            if (lastSelectedDgv != null)
            {
                T objetoSelecionado = lastSelectedDgv.CurrentRow.DataBoundItem as T;
                if (objetoSelecionado != null)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(nomePropriedade);
                    if (propertyInfo != null && propertyInfo.PropertyType == typeof(Color))
                    {
                        ColorItem itemCor = (ColorItem)comboBox.SelectedItem;
                        Color corSelecionada = itemCor.Color;
                        propertyInfo.SetValue(objetoSelecionado, corSelecionada);
                        lastSelectedDgv.Refresh();
                        dataGridView1.Refresh();
                        dataGridView2.Refresh();
                        dataGridView3.Refresh();
                    }
                }
            }
        }
        private void Load_ComboboxDrillType<T>(ComboBox comboBox, T objeto) where T : class
        {
            if (lastSelectedDgv != null)
            {
                T objetoSelecionado = lastSelectedDgv.CurrentRow.DataBoundItem as T;
                if (objetoSelecionado != null)
                {
                    Drills selectedDrill = objetoSelecionado as Drills;
                    if (selectedDrill != null)
                    {
                        TipoDeDrills drillType = comboBox.SelectedItem as TipoDeDrills;
                        if (drillType != null)
                        {
                            selectedDrill.TipoDrill = drillType;
                            lastSelectedDgv.Refresh();
                            dataGridView1.Refresh();
                            dataGridView2.Refresh();
                            dataGridView3.Refresh();
                        }
                    }
                }
            }
        }

        private void Load_Checkbox<T>(CheckBox checkBox, T objeto, string nomePropriedade) where T : class
        {
            if (lastSelectedDgv != null)
            {
                bool valor;
                if (checkBox.CheckState == CheckState.Checked)
                {
                    valor = true;
                }
                else if (checkBox.CheckState == CheckState.Unchecked)
                {
                    valor = false;
                }
                else
                {
                    return; // Valor indeterminado, não atualiza nada
                }

                T objetoSelecionado = lastSelectedDgv.CurrentRow.DataBoundItem as T;
                if (objetoSelecionado != null)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(nomePropriedade);
                    if (propertyInfo != null && propertyInfo.PropertyType == typeof(bool))
                    {
                        propertyInfo.SetValue(objetoSelecionado, valor);
                        lastSelectedDgv.Refresh();
                        dataGridView1.Refresh();
                        dataGridView2.Refresh();
                        dataGridView3.Refresh();
                    }
                }
            }
        }

        #endregion
        #region Sobre as DataGridView
        //o bagulho pra identificar qual datagrid ta seleciona
        private DataGridView lastSelectedDgv = null;
        private Ferramentas GetSelectedObject()
        {
            if (dataGridView3.CurrentRow != null)
            {
                return (Ferramentas)dataGridView3.CurrentRow.DataBoundItem;
            }
            return null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            datagridcodes.RemoverFerramenta(dataGridView1, ferramentas.ListFrente, e);
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            datagridcodes.RemoverFerramenta(dataGridView2, ferramentas.ListTras, e);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            datagridcodes.SelecionarFerramenta4(dataGridView1, e, ComboBoxList, TextBoxes, CheckBoxes, PanelList, dgvCoordenadas);

        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            datagridcodes.SelecionarFerramenta4(dataGridView2, e, ComboBoxList, TextBoxes, CheckBoxes, PanelList, dgvCoordenadas);
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
    //        datagridcodes.SelecionarFerramenta4(dataGridView3, e, ComboBoxList, TextBoxes, CheckBoxes, PanelList, dgvCoordenadas);
            //datagridcodes.AtualizarTextBoxEPainel()
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // datagridcodes.RemoverFerramenta(dataGridView3, ferramentas.ListFrente, e);
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)

        {
            lastSelectedDgv = dataGridView1;
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

            lastSelectedDgv = dataGridView2;
            dataGridView1.ClearSelection();
            dataGridView3.ClearSelection();

        }
        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {

            lastSelectedDgv = dataGridView3;
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();

            Ferramentas ferramentaSelecionada = ObterFerramentaSelecionada();
            AbrirFormEdicao(ferramentaSelecionada);

        }
        #endregion
        #region Sobre as Checkboxs frente/tras
   
        private void x_inv_checkbok_CheckedChanged(object sender, EventArgs e)
        {
            peca.xinv = x_inv_checkbok.Checked;
            panel_update();
        }
        #endregion
        #region Botões e Textboxs do Solid Drill
  
    
        private void comboBoxCores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ComboboxColor<Drills>(comboBoxCores, null, "Color");
            panel_update();
        }
      


     
        #endregion
        #region Resto
     
        public  void DGV_Update()
        {
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            dataGridView3.Refresh();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            //  frente_checkBox.Checked = false;
            // tras_checkBox.Checked = false;
            //sentan_cb.Checked = false;
            //men_tras_checkbox.Checked = false;
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.Select();
            //form2.ShowDialog();
            dataGridView3.Refresh();
            AdicionarForm adicionarForm = new AdicionarForm();
            adicionarForm.ShowDialog();


            if (dataGridView3.Rows.Count == 0) { return; }
            dataGridView3.CurrentCell = dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[0];
            datagridcodes.AtualizarTextBoxEPainel(dataGridView3.CurrentRow.DataBoundItem as Ferramentas, TextBoxes, CheckBoxes, PanelList);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KouguForm kouguForm = new KouguForm();
            kouguForm.ShowDialog();
        }




        int counter = 0;

        #endregion
        #region Coordenadas
        private void button7_Click(object sender, EventArgs e)
        {
            MentoriForm mentoriForm = new MentoriForm();
            mentoriForm.ShowDialog();
        }


        private void ExibirCoordenadas(Drills drills)
        {
            // cria uma string para armazenar as coordenadas
            string coordenadasStr = "";

            // percorre a lista de coordenadas do objeto de perfuração e adiciona as coordenadas à string
            foreach (PointF coordenadas in drills.CoordenadasList)
            {
                coordenadasStr += "(" + coordenadas.X + ", " + coordenadas.Y + ")\n";
            }

            // exibe as coordenadas em uma MessageBox
            MessageBox.Show(coordenadasStr, "Coordenadas de Perfuração");
        }

        private void btnSalvarCoordenadas_Click(object sender, EventArgs e)
        {
            // Verifica se a célula selecionada é válida
            if (selectedCell != null && selectedCell.RowIndex >= 0 && selectedCell.ColumnIndex >= 0)
            {
                // Obtém o índice da linha selecionada na DataGridView separada
                int rowIndex = selectedCell.RowIndex;

                // Obtém a BindingList<PointF> atual da DataGridView
                var pointsList = dgvCoordenadas.DataSource as BindingList<PointF>;

                // Obtém o objeto selecionado na DataGridView principal
                var selectedObject = dataGridView3.CurrentRow.DataBoundItem as Ferramentas;

                // Verifica se o objeto selecionado é uma instância de Drills ou Taps
                if (selectedObject is Drills drills)
                {
                    // Remove o ponto selecionado da lista de pontos do objeto Drills
                    drills.CoordenadasList.RemoveAt(rowIndex);

                    // Atualiza a BindingList<PointF> e a DataGridView separada com a lista atualizada
                    pointsList.ResetBindings();
                    dgvCoordenadas.Refresh();
                }
                else if (selectedObject is Tap taps)
                {
                    // Remove o ponto selecionado da lista de pontos do objeto Taps
                    taps.CoordenadasList.RemoveAt(rowIndex);

                    // Atualiza a BindingList<PointF> e a DataGridView separada com a lista atualizada
                    pointsList.ResetBindings();
                    dgvCoordenadas.Refresh();
                }
            }

        }

        private void AtualizaDrills(Drills drill)
        {
            int index = ferramentas.ListTotal.IndexOf(drill);
            ferramentas.ListTotal.RemoveAt(index);
            ferramentas.ListTotal.Insert(index, drill);
            ferramentas.ListDrills.RemoveAt(index);
            ferramentas.ListDrills.Insert(index, drill);
        }

        private void dgvCoordenadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel_Code_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button8_Click(object sender, EventArgs e)
        {
            // Obtém as coordenadas inseridas pelo usuário
            if (float.TryParse(txtX.Text, out float x) && float.TryParse(txtY.Text, out float y))
            {
                // Obtém o objeto selecionado na DataGridView principal
                var selectedObject = dataGridView3.CurrentRow.DataBoundItem as Ferramentas;

                // Verifica se o objeto selecionado é uma instância de Drills ou Taps
                if (selectedObject is Drills drills)
                {
                    // Adiciona o novo ponto à lista de pontos do objeto Drills
                    drills.CoordenadasList.Add(new PointF(x, y));

                    // Obtém a BindingList<PointF> atual da DataGridView separada
                    var pointsList = dgvCoordenadas.DataSource as BindingList<PointF>;

                    // Atualiza a BindingList<PointF> e a DataGridView separada com a lista atualizada
                    pointsList.ResetBindings();
                    dgvCoordenadas.Refresh();
                }
                else if (selectedObject is Tap taps)
                {
                    // Adiciona o novo ponto à lista de pontos do objeto Taps
                    taps.CoordenadasList.Add(new PointF(x, y));

                    // Obtém a BindingList<PointF> atual da DataGridView separada
                    var pointsList = dataGridView2.DataSource as BindingList<PointF>;

                    // Atualiza a BindingList<PointF> e a DataGridView separada com a lista atualizada
                    pointsList.ResetBindings();
                    dataGridView2.Refresh();
                }
            }
            panel_update();
        }


        private void dgvCoordenadas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtém a BindingList<PointF> atual da DataGridView
                var pointsList = dgvCoordenadas.DataSource as BindingList<PointF>;

                // Obtém o objeto selecionado na DataGridView principal
                var selectedObject = dataGridView3.CurrentRow.DataBoundItem as Ferramentas;

                // Verifica se o objeto selecionado é uma instância de Drills ou Taps
                if (selectedObject is Drills drills)
                {
                    // Atualiza a lista de pontos do objeto Drills com a lista atualizada na BindingList
                    drills.CoordenadasList = pointsList.ToList();
                }
                else if (selectedObject is Tap taps)
                {
                    // Atualiza a lista de pontos do objeto Taps com a lista atualizada na BindingList
                    taps.CoordenadasList = pointsList.ToList();
                }
            }
        }

        private void dgvCoordenadas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

            // Obtém o índice da linha selecionada na DataGridView separada
            int rowIndex = e.Row.Index;

            // Obtém a BindingList<PointF> atual da DataGridView
            var pointsList = dataGridView2.DataSource as BindingList<PointF>;

            // Obtém o objeto selecionado na DataGridView principal
            var selectedObject = dataGridView1.CurrentRow.DataBoundItem as Ferramentas;

            // Verifica se o objeto selecionado é uma instância de Drills ou Taps
            if (selectedObject is Drills drills)
            {
                // Remove o ponto selecionado da lista de pontos do objeto Drills
                drills.CoordenadasList.RemoveAt(rowIndex);
            }
            else if (selectedObject is Tap taps)
            {
                // Remove o ponto selecionado da lista de pontos do objeto Taps
                taps.CoordenadasList.RemoveAt(rowIndex);
            }

        }

        private void dgvCoordenadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedCell = dgvCoordenadas.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private void button10_Click(object sender, EventArgs e)
        {
            form3.ShowDialog();
        }
        #endregion
        #region Sobre Mentori
        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow != null)
            {
                int index = dataGridView3.CurrentRow.Index;
                Ferramentas ferramentaSelecionada = ferramentas.ListTotal[index];

                if (ferramentaSelecionada is Drills drill)
                    if (drill.CoordenadasList.Count == drill.numlado + 1)
                    {
                        drill.numlado = 0;
                    }
                    else
                    {
                        drill.numlado += 1;
                    }

                dataGridView3.Refresh();
                panel_update();
            }
        }

   
        public float tamcutter2;
    



       
        #endregion

        private void button12_Click(object sender, EventArgs e)
        {
            form5.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MaterialForm materialForm = new MaterialForm();
            materialForm.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            TapMMForm tapMMForm = new TapMMForm();
            tapMMForm.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
        
        }

        private void button17_Click(object sender, EventArgs e)
        {
            DrillsForm drillsFOrm = new DrillsForm(this, ferramentas, peca);
            drillsFOrm.ShowDialog();
        }

        private void AbrirFormEdicao(Ferramentas ferramenta)
        {
            if (ferramenta != null)
            {
                if (ferramenta is Drills)
                {
                    DrillsForm drillsFOrm = new DrillsForm(this, ferramentas, peca);
                    drillsFOrm.ShowDialog();
                }
                // Adicione condições para outras classes derivadas de Ferramenta, se houver.
            }
        }
        private Ferramentas ObterFerramentaSelecionada()
        {
            if (dataGridView3.CurrentRow != null)
            {
                return dataGridView3.CurrentRow.DataBoundItem as Ferramentas;
            }
            return null;
        }


    }



}


using Krisiun_Project.Dados_aleatorios;
using Krisiun_Project.Desenhos;
using Krisiun_Project.G_Code;
using Krisiun_Project.janela_principal;
using Krisiun_Project.Janelas;
using Krisiun_Project.Numeros;
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
        private Bools bools;
        private Drills brocas;
        private Coordenadas coordenadas;
        private CoordenadasGrupo xygrupo;
        private Ferramentas ferramentas;
        private DGV_Codes datagridcodes;
        private Form2 form2;
        private Form3 form3;
        private Grupos grupos;
        private Zairyo.Desenho d;
        private NSB nsb;
        private ColorItem coloritem;
        //private  NSBLoader nSB;
        // private NSBLoader nsbs;
        public BindingSource bindingSource = new BindingSource();
        public BindingSource bindingSource1 = new BindingSource();
        public BindingSource bindingSource2 = new BindingSource();
        public BindingSource bindingSource3 = new BindingSource();
        public BindingSource bindingSource4 = new BindingSource();

     
        public Form1()
        {
            InitializeComponent();
            this.bools = new Bools();
            this.coordenadas = new Coordenadas();
            this.meio = new Pitch(bools);
            this.d = new Zairyo.Desenho(bools);
            this.toolnum = new ToolNumber();
            this.peca = new Peca();
            this.bugs = new Bugs.Bugs_Txb();
            this.shin = new Shindashi(meio);
            this.t = new Tests();
            this.addtb = new Addtextbox(t, coordenadas);
            this.ferramentas = new Ferramentas();
            this.taps = new Tap();
            this.brocas = new Drills();
            this.form2 = new Form2(this, ferramentas, bools);
            this.grupos = new Grupos();
            this.datagridcodes = new DGV_Codes(this, peca);
            this.form3 = new Form3(peca, this, meio, shin, bugs, bools);
            this.nsb = new NSB();
            var nSB = NSBLoader.Load();

            bindingSource4.DataSource = null;
            drill_combobox.DataSource = Enum.GetValues(typeof(TipoDrill));
            drill_combobox.DisplayMember = "ToString";
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
            bindingSource3.DataSource = ferramentas.ListDrills;
            dataGridView4.DataSource = bindingSource3;
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
            comboBoxCores.SelectedIndex = 5;

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
        public List<TextBox>xyboxs = new List<TextBox>();
        public List<ComboBox> ComboBoxList = new List<ComboBox>();
        private BindingSource gruposCoordenadasBindingSource = new BindingSource();
        #endregion
        
        // Atribui o BindingSource à lista de grupos de coordenadas
   
        private void add_tb_naLista()
        {
            TextBoxes.Add(Num_pro_textbox); //[0]
            TextBoxes.Add(drill_kei_tb);    //[1]
            TextBoxes.Add(drill_z_tb); //[2]
            TextBoxes.Add(men_frente_tam_tb); //[3]
            TextBoxes.Add(men_frente_kei_tb); //[4]
            TextBoxes.Add(men_frente_z_tb);//[5]
            TextBoxes.Add(men_frente_dan_tb);//[6]
            TextBoxes.Add(tool_tb); //7

            TextBoxes.Add(men_tras_tam); //8
            TextBoxes.Add(men_tras_kei); //9
            TextBoxes.Add(men_tras_z); //10
            TextBoxes.Add(men_tras_dan);//11



            CheckBoxes.Add(frente_checkBox); //[0]
            CheckBoxes.Add(tras_checkBox); //[1]
            CheckBoxes.Add(sentan_cb); //[2]
            CheckBoxes.Add(men_frente_checkbox); //[3]
            CheckBoxes.Add(men_tras_checkbox); //[4]


            PanelList.Add(panel_boringana); //[0]

            ComboBoxList.Add(drill_combobox); //0
            ComboBoxList.Add(comboBoxCores);//1

        }
        #region Tamanho_Escala_Base

        //private void shikaku_rd_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (shikaku_rd.Checked) { sizey.Enabled = true; }
        //}

        //private void maru_rb_CheckedChanged(object sender, EventArgs e)
        //{
        //    sizey.Enabled = false;
        //    panel_update();
        //}


        private void button1_Click(object sender, EventArgs e)
        {
            SavePictureBoxAsJPG(paneld_f, "frente.jpg");

            SavePictureBoxAsJPG(panel_b, "tras.jpg");
        }
        private void SavePictureBoxAsJPG(Panel pb, String strg)
        {
            Bitmap bitmap = new Bitmap(pb.Width, pb.Height);

            // Copiar o conteúdo do panel para o bitmap
            pb.DrawToBitmap(bitmap, pb.ClientRectangle);

            // Salvar o bitmap em jpg
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string ar = strg;
            bitmap.Save(Path.Combine(dir, ar), System.Drawing.Imaging.ImageFormat.Jpeg);
        }


        //private void textBox3_TextChanged(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(sizex.Text)) { return; }
        //    bugs.sohnums(sizex, e);
        //    //    t.teste(sizex.Text);


        //    if (float.TryParse(sizex.Text, out float x) &&
        //        float.TryParse(sizey.Text, out float y) &&
        //        float.TryParse(sizez.Text, out float z))
        //    {
        //        if (maru_rb.Checked)
        //        { peca.width = x; peca.height = x; peca.z = z; sizey.Enabled = false; basex_tb.Enabled = false; basex_tb.Text = (x / 2).ToString(); basey_tb.Enabled = false; basey_tb.Text = (x / 2).ToString(); sizey.Text = sizex.Text; }

        //        if (shikaku_rd.Checked)
        //        {
        //            peca.width = x; peca.height = y; peca.z = z; basex_tb.Enabled = true; basey_tb.Enabled = true; sizey.Enabled = true;
        //            float p = peca.width / 2;
        //            basex_tb.Text = p.ToString();

        //        }
        //        panel_update();
        //    }

        //}
        //private void sizey_TextChanged(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(sizey.Text)) { return; }
        //    bugs.sohnums(sizey, e);

        //    if (float.TryParse(sizex.Text, out float x) &&
        //        float.TryParse(sizey.Text, out float y) &&
        //        float.TryParse(sizez.Text, out float z))
        //    {
        //        peca.width = x; peca.height = y; peca.z = z;
        //        panel_update();
        //    }
        //    float p = peca.height / 2;
        //    basey_tb.Text = p.ToString();

        //}
        //private void sizez_TextChanged(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(sizez.Text)) { return; }
        //    bugs.sohnums(sizey, e);

        //    if (float.TryParse(sizex.Text, out float x) &&
        //        float.TryParse(sizey.Text, out float y) &&
        //        float.TryParse(sizez.Text, out float z))
        //    {
        //        peca.width = x; peca.height = y; peca.z = z;
        //        panel_update();
        //    }


        //}

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
        //private void basex_tb_TextChanged(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(basex_tb.Text)) { return; };
        //    bugs.sohnums(basex_tb, e);
        //    bugs.sohnums(basey_tb, e);
        //    if (float.TryParse(basex_tb.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float x) &&
        //        float.TryParse(basey_tb.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float y))
        //    {
        //        meio.calculo_de_base(shin, peca, basex_tb, basey_tb);

        //        himen_tb.Text = shin.x.ToString();
        //        zuban_tb.Text = shin.y.ToString();
        //        panel_update();
        //    }
        //    else
        //    {
        //        // o valor não é um número válido
        //    }
        //}

        //private void basey_tb_TextChanged(object sender, EventArgs e)
        //{

        //    if (string.IsNullOrEmpty(basey_tb.Text)) { return; };
        //    bugs.sohnums(basey_tb, e);
        //    meio.calculo_de_base(shin, peca, basex_tb, basey_tb);
        //    himen_tb.Text = shin.x.ToString();
        //    zuban_tb.Text = shin.y.ToString();
        //    panel_update();
        //}
        #endregion
        #region Sobre_Paineis_de_Desenho
        private void y_inv_checkbox_CheckedChanged(object sender, EventArgs e)
        {
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
            d.DesenharFerramentas(e, ferramentas.ListTotal, false, false, panel_yoko, panel_yoko);
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
            datagridcodes.SelecionarFerramenta4(dataGridView3, e, ComboBoxList, TextBoxes, CheckBoxes, PanelList, dgvCoordenadas);
            //datagridcodes.AtualizarTextBoxEPainel()
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            datagridcodes.RemoverFerramenta(dataGridView3, ferramentas.ListFrente, e);
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

        }
        #endregion
        #region Sobre as Checkboxs frente/tras
        private void frente_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (frente_checkBox.Checked) { panel_men_frente.Visible = true; }
            if (!frente_checkBox.Checked) { panel_men_frente.Visible = false; }

            if (lastSelectedDgv != null && lastSelectedDgv.CurrentRow != null)
            {
                Ferramentas ferramentaSelecionada = lastSelectedDgv.CurrentRow.DataBoundItem as Ferramentas;
                if (ferramentaSelecionada != null)
                {

                    //
                    //                   if (tras_checkBox.Checked != bools.Form3_Tras) { return; }
                    if (!ferramentas.ListFrente.Contains(ferramentaSelecionada))
                    {
                        if (frente_checkBox.Checked)
                        {
                            ferramentas.ListFrente.Add(ferramentaSelecionada);
                            ferramentaSelecionada.Frente = frente_checkBox.Checked;
                        }
                    }
                    if (frente_checkBox.Checked == false)
                    {

                        // Remova o objeto da lista
                        ferramentas.ListFrente.Remove(ferramentaSelecionada);
                        ferramentaSelecionada.Frente = false;
                        // Atualize a exibição da DGV
                        dataGridView2.Refresh();



                    }
                    if (ferramentas.ListTras.Contains(ferramentaSelecionada))
                    {
                        return;
                    }

                    dataGridView2.Refresh();
                    dataGridView3.Refresh();
                    dataGridView1.Refresh();
                    lastSelectedDgv.Refresh();
                }
            }
            dataGridView2.Refresh();
            dataGridView3.Refresh();
            dataGridView1.Refresh();

        }
        private void tras_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (tras_checkBox.Checked) { panel_men_tras.Visible = true; }
            if (!tras_checkBox.Checked) { panel_men_tras.Visible=false; }

            if (lastSelectedDgv != null && lastSelectedDgv.CurrentRow != null)
            {
                Ferramentas ferramentaSelecionada = lastSelectedDgv.CurrentRow.DataBoundItem as Ferramentas;
                if (ferramentaSelecionada != null)
                {


                    // Remova o objeto da lista
                    ferramentas.ListTras.Remove(ferramentaSelecionada);
                    ferramentaSelecionada.Tras = false;
                    // Atualize a exibição da DGV
                    dataGridView2.Refresh();
                    dataGridView3.Refresh();
                    dataGridView1.Refresh();



                    if (!ferramentas.ListTras.Contains(ferramentaSelecionada))
                    {
                        if (tras_checkBox.Checked) { ferramentas.ListTras.Add(ferramentaSelecionada); }

                        ferramentaSelecionada.Tras = tras_checkBox.Checked;
                    }
                    lastSelectedDgv.Refresh();

                    dataGridView2.Refresh();
                    dataGridView3.Refresh();
                }
            }
            dataGridView2.Refresh();
            dataGridView3.Refresh();
            dataGridView1.Refresh();

        }
        private void x_inv_checkbok_CheckedChanged(object sender, EventArgs e)
        {
            panel_update();
        }
        #endregion
        #region Botões e Textboxs do Solid Drill

        private void drill_kei_tb_TextChanged(object sender, EventArgs e)
        {
            men_frente_kei_tb.Text = drill_kei_tb.Text;
            string filePath = "";
            string file = "kougu.csv";
            filePath = AppDomain.CurrentDomain.BaseDirectory;
            bool valueFound = false;


            // obtém o valor selecionado na ComboBox
            string selectedValue = drill_kei_tb.Text;

            // abre o arquivo CSV novamente
            using (StreamReader reader = new StreamReader(Path.Combine(filePath, file)))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    // verifica se o valor da primeira coluna é igual ao valor selecionado na ComboBox
                    if (values[0] == selectedValue)
                    {
                        tool_tb.Text = values[2];

                        drill_combobox.Text = values[1];
                        valueFound = true;
                        // atribui o valor da segunda coluna à TextBox
                        break; // para o loop
                    }
                }
                if (!valueFound)
                {
                    tool_tb.Text = toolnum.contador();
                }


                // Aqui você pode acessar o objeto drills e suas propriedades

            }

        }




        private void sentan_cb_CheckedChanged(object sender, EventArgs e)
        {
            Load_Checkbox<Drills>(sentan_cb, null, "Sentan");
        }

        public void drill_z_tb_Leave(object sender, EventArgs e)
        {
              
        }
        private void drill_z_tb_TextChanged(object sender, EventArgs e)
        {
            float atsumi = peca.z;
            string valor = drill_z_tb.Text.ToString().Replace("-", "");
            float z;
            float kei;

            var nsb = NSBLoader.Load();
            if (float.TryParse(drill_kei_tb.Text, out kei))
            {
                if (float.TryParse(valor, out z))
                {
                    if ((TipoDrill)drill_combobox.SelectedItem == TipoDrill.ソリッドドリル)
                    {
                        NSB x = nsb.Find(n => n.Dia == kei);
                        if (x != null)
                        {
                            if (x.Hachou < z)
                            {
                                DialogResult result = MessageBox.Show("Moldinoソリッドドリル5Dの刃長は" + x.Hachou.ToString() + "mm.\n\nもっと長いドリルを追加するか？", "確認", MessageBoxButtons.YesNo);

                                if (result == DialogResult.Yes)
                                {
                                    MessageBox.Show("teste-Drill");
                                }
                            }
                        }
                    }
                    if ((TipoDrill)drill_combobox.SelectedItem == TipoDrill.カムドリル)
                    {
                        kei *= 5.15f;
                        if (kei < z)
                        {
                            DialogResult result = MessageBox.Show("イスカルドリル5Dの長さは" + kei.ToString() + "mm.\n\nもっと長いドリルを追加するか？", "確認", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                MessageBox.Show("teste-Cam");
                            }
                        }
                    }


                }
            }

        }
        #endregion
        #region Resto
        private void Num_pro_textbox_Leave(object sender, EventArgs e)
        {
            if (lastSelectedDgv != null)
            {
                Ferramentas ferramentaSelecionada = lastSelectedDgv.CurrentRow.DataBoundItem as Ferramentas;
                if (ferramentaSelecionada != null)
                {
                    //ferramentaSelecionada.Nome = Num_pro_textbox.Text;
                    lastSelectedDgv.Refresh();
                }
            }
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            dataGridView3.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //  frente_checkBox.Checked = false;
            // tras_checkBox.Checked = false;
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
              dataGridView3.Select();
            form2.ShowDialog();
            dataGridView3.Refresh();

         
         
         if (dataGridView3.Rows.Count == 0) { return; }
            dataGridView3.CurrentCell = dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[0];
            datagridcodes.AtualizarTextBoxEPainel(dataGridView3.CurrentRow.DataBoundItem as Ferramentas, TextBoxes, CheckBoxes, PanelList);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            taps.addtap();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Load_Textbox<Drills>(drill_kei_tb, null, "Kei");
            Load_Combobox<Drills>(drill_combobox, null, "DrillTipo");
            Load_Textbox<Drills>(drill_z_tb, null, "Fukasa");
            Load_Textbox<Drills>(tool_tb, null, "ToolNumber");
            Load_Combobox<Drills>(drill_combobox, null, "ToolName");
            Load_ComboboxColor<Drills>(comboBoxCores, null, "Color");
            panel_update();

        }
        int counter = 0;

        #endregion
        #region Coordenadas
        private void button7_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView3.SelectedCells[0].RowIndex;
            Drills drills = dataGridView3.Rows[rowIndex].DataBoundItem as Drills;

            ExibirCoordenadas(drills);
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
        private void comboBoxCores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ComboboxColor<Drills>(comboBoxCores, null, "Color");
            panel_update();
        }
    }

}

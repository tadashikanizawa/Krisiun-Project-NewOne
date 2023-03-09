using Krisiun_Project.G_Code;
using Krisiun_Project.janela_principal;
using Krisiun_Project.Janelas;
using Krisiun_Project.Numeros;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WindowsFormsApp1;
using static Krisiun_Project.Pitch_principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Krisiun_Project
{
    public partial class Form1 : Form
    {
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
        private Ferramentas ferramentas;
        private DGV_Codes datagridcodes;
        private Form2 form2;
        private Form3 form3;
        private Grupos grupos;
        private Zairyo.Desenho d;
        public BindingSource bindingSource = new BindingSource();
        public BindingSource bindingSource1 = new BindingSource();
        public BindingSource bindingSource2 = new BindingSource();
        public BindingSource teste = new BindingSource();
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
            this.brocas = new Drills(ferramentas);
            this.form2 = new Form2(this, ferramentas, bools);
            this.grupos = new Grupos();
            this.datagridcodes = new DGV_Codes(this, peca);
            this.form3 = new Form3(peca, this, meio, shin, bugs, bools);


            drill_combobox.DataSource = Enum.GetValues(typeof(TipoDrill));
            drill_combobox.DisplayMember = "ToString";

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            addtb.CriarTextBoxesIniciais(panel_XY);
            tamanhopainel(panel_XY);
            bindingSource.DataSource = ferramentas.ListFrente;
            dataGridView1.DataSource = bindingSource;
            bindingSource1.DataSource = ferramentas.ListTras;
            dataGridView2.DataSource = bindingSource1;
            bindingSource2.DataSource = ferramentas.ListTotal;
            dataGridView3.DataSource = bindingSource2;

            add_tb_naLista();
            form3.ShowDialog();
            panel_update();
        }

        public List<TextBox> TextBoxes = new List<TextBox>();
        public List<CheckBox> CheckBoxes = new List<CheckBox>();
        public List<Panel> PanelList = new List<Panel>();
        public List<ComboBox> ComboBoxList = new List<ComboBox>();
        private void add_tb_naLista()
        {
            TextBoxes.Add(Num_pro_textbox); //[0]
            TextBoxes.Add(drill_kei_tb);    //[1]
            TextBoxes.Add(drill_z_tb); //[2]
            TextBoxes.Add(men_frente_tam_tb); //[3]
            TextBoxes.Add(men_frente_kei_tb); //[4]
            TextBoxes.Add(men_frente_z_tb);//[5]
            TextBoxes.Add(men_frente_dan_tb);//[6]

            TextBoxes.Add(men_tras_tam); //7
            TextBoxes.Add(men_tras_kei); //8
            TextBoxes.Add(men_tras_z); //9
            TextBoxes.Add(men_tras_dan);//10



            CheckBoxes.Add(frente_checkBox); //[0]
            CheckBoxes.Add(tras_checkBox); //[1]
            CheckBoxes.Add(sentan_cb); //[2]
            CheckBoxes.Add(men_frente_checkbox); //[3]
            CheckBoxes.Add(men_tras_checkbox); //[4]


            PanelList.Add(panel_boringana); //[0]
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
            if(float.TryParse(scale_tb.Text, out scala)) {
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

            g.DrawString("BACK", font, brush, 10, 10);
            // d.linha(e);
        }
        private void panel_yoko_Paint(object sender, PaintEventArgs e)
        {

            d.lado(e, peca);

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
            if(lado_checkbox.Checked){ bools.bool_lado = true; panel_yoko.Visible = true; }
            else { bools.bool_lado= false; panel_yoko.Visible = false; }
            panel_yoko.BringToFront();
            panel_update(); 
        }
        #endregion
        #region Em relação aos Panels de config de Iteração
        private void tamanhopainel(Panel panel)
        {
            panel.MaximumSize = new Size(150, 500);
            // Definir a altura do painel para acomodar todos os objetos
            int panelHeight = panel.Controls.Cast<Control>().Sum(c => c.Height + c.Margin.Vertical);
            panel.Height = panelHeight;

            // Verificar se o conteúdo do painel está saindo da área visível
            if (panel.DisplayRectangle.Height < panel.Height)
            {
                // Exibir barra de rolagem
                panel.AutoScroll = true;
            }
            else
            {
                // Ocultar barra de rolagem
                panel.AutoScroll = false;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            
           
            this.Size = new Size(2000, 1500);
            //panel_principal.BringToFront();
        }


        //private void menu_radioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (menu_radioButton.Checked) { panel_principal.BringToFront(); }
        //}

    

        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            //  frente_checkBox.Checked = false;
            // tras_checkBox.Checked = false;
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            //   dataGridView3.Select();

            form2.ShowDialog();
            dataGridView3.Refresh();

            if (dataGridView3.Rows.Count == 1) { return; }
            dataGridView3.CurrentCell = dataGridView3.Rows[dataGridView3.Rows.Count - 2].Cells[0];
            datagridcodes.AtualizarTextBoxEPainel(dataGridView3.CurrentRow.DataBoundItem as Ferramentas, TextBoxes, CheckBoxes, PanelList);
        }



        private void Num_pro_textbox_TextChanged(object sender, EventArgs e)
        {
        }
        //o bagulho pra identificar qual datagrid ta seleciona
        private DataGridView lastSelectedDgv = null;

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
        private void AtualizarNome1<T>(TextBox textBox, T objeto, string nomePropriedade) where T : class
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
        private void AtualizarNome2<T>(ComboBox comboBox, T objeto, string nomePropriedade) where T : class
        {
            if (lastSelectedDgv != null)
            {
                T objetoSelecionado = lastSelectedDgv.CurrentRow.DataBoundItem as T;
                if (objetoSelecionado != null)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(nomePropriedade);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(objetoSelecionado, Convert.ChangeType(comboBox.Text.ToString(), propertyInfo.PropertyType));
                        lastSelectedDgv.Refresh();
                        dataGridView1.Refresh();
                        dataGridView2.Refresh();
                        dataGridView3.Refresh();
                    }
                }
            }
        }
        private void AtualizarNome3<T>(CheckBox checkBox, T objeto, string nomePropriedade) where T : class
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
                //  Drills drillSelecionado = lastSelectedDgv.CurrentRow.DataBoundItem as Drills;
                    AtualizarNome1<Ferramentas>(drill_kei_tb, null, "kei");

                    // Aqui você pode acessar o objeto drills e suas propriedades
              
            }

        }
        private void drill_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarNome2<Ferramentas>(drill_combobox, null, "ToolName");
        }
        #region Sobre as DataGridView
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
            datagridcodes.SelecionarFerramenta(dataGridView1, e, TextBoxes, CheckBoxes, PanelList);

        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            datagridcodes.SelecionarFerramenta(dataGridView2, e, TextBoxes, CheckBoxes, PanelList);
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            datagridcodes.SelecionarFerramenta(dataGridView3, e, TextBoxes, CheckBoxes, PanelList);
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

        private void drill_tool_tb_TextChanged(object sender, EventArgs e)
        {
            AtualizarNome1<Ferramentas>(tool_tb, null, "ToolNumber");
        }

        private void drill_z_tb_TextChanged(object sender, EventArgs e)
        {
            float atsumi = peca.z;
            string valor = drill_z_tb.Text.ToString().Replace("-","");
            float z;
            float z1;
            float kei;
            if (float.TryParse(drill_kei_tb.Text, out kei))
            {
                if (float.TryParse(valor, out z))
                {
                    z1 = z;
                    kei *= 5.15f;
                    if (kei < z && z > atsumi)
                    {
                        DialogResult result = MessageBox.Show("刃長が足りない可能性があります。/n/ 貫通する予定なら反対側に追加するか？", "Confirmação", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            // Remova o objeto da lista
                            if (!tras_checkBox.Checked) { tras_checkBox.Checked = true; }
                            if (!frente_checkBox.Checked) { frente_checkBox.Checked = true; }
                            // Atualize a exibição da DGV
                            z1 = peca.z / 2;
                            z1 += 2;
                            if (float.TryParse(drill_z_tb.Text, out z))
                            {
                                if (kei <= z)
                                {
                                    drill_z_tb.Text = z1.ToString();
                                }
                                else
                                {
                                    drill_z_tb.Text = z.ToString();
                                    MessageBox.Show("まだ足りないです。他の孔開けツールを追加した方がいいです。");
                                }
                            }


                        }
                     

                    }
                    else { 
                    if (kei < z)
                    {
                        MessageBox.Show("刃長が足りない可能性が有り、気を付けましょう。");
                    }
                    }
                }
            }

            AtualizarNome1<Ferramentas>(drill_z_tb, null, "fukasa");
        }
        

        private void sentan_cb_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarNome3<Ferramentas>(sentan_cb, null, "Sentan");
        }

        private void drill_z_tb_Leave(object sender, EventArgs e)
        {
            float atsumi = peca.z;
            float z;
            float z1;
            float kei;
            if (float.TryParse(drill_kei_tb.Text, out kei))
            {
                if (float.TryParse(drill_z_tb.Text, out z))
                {
                    z1 = z;
                    kei *= 5.15f;
                    if (kei < z && z > atsumi)
                    {
                        DialogResult result = MessageBox.Show("刃長が足りない可能性があります。/n/ 貫通する予定なら反対側に追加するか？", "Confirmação", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            // Remova o objeto da lista
                            if (!tras_checkBox.Checked) { tras_checkBox.Checked = true; }
                            if (!frente_checkBox.Checked) { frente_checkBox.Checked = true; }
                            // Atualize a exibição da DGV
                            z1 = peca.z / 2;
                            z1 += 2;
                            if (float.TryParse(drill_z_tb.Text, out z))
                            {
                                if (kei <= z)
                                {
                                    drill_z_tb.Text = z1.ToString();
                                }
                                else {
                                    drill_z_tb.Text = z.ToString();
                                        MessageBox.Show("まだ足りないです。他の孔開けツールを追加した方がいいです。"); }
                            }
                            
                            
                        }
                        if (result == DialogResult.No)
                        {

                        }
                    }
                }
            }

            AtualizarNome1<Ferramentas>(drill_z_tb, null, "fukasa");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            brocas.adddrill();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            taps.addtap();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            panel_update();
        }


    }

}

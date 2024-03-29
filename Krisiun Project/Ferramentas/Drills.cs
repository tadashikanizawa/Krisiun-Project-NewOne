﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System;
using Krisiun_Project.Dados_Aleatorios1;
using System.Globalization;
using System.IO;
using static Krisiun_Project.Pitch_principal;
using Krisiun_Project.UserControils;

namespace Krisiun_Project.G_Code
{
    public class Drills : Ferramentas
    {
        public float Z { get; set; }
     
        public string DrillTipo { get; set; }
        public float TamSentan { get; set; }
        public TipoDeDrills TipoDrill {get;set;}
        public Dictionary<DrillMaterialKey, float> KaitenValues{get; set;}
    
        public bool Sentan { get; set; } 

        public Drills(Peca peca):base (peca)
        {
            CoordenadasList = new List<PointF>();
            KaitenValues = LoadKaitenValuesFromCsv();
        
  
        }
        
        public  void CriarDrills(Ferramentas ferramentas, Drill_UserControl drill, Lado_UserControl lado, Mentori_Frente MentoriF, Mentori_Frente MentoriT, Colors_UserControl color, DataGridView xy_dgv, DataGridView pcd_dgv, RadioButton xyradiobutton, RadioButton pcdradiobutton, TextBox PCDRaio, TextBox pontoinicialX, TextBox pontoinicialY)
        {
            float kei;
            float fukasa;
            int tool;
            Drills drills = new Drills(peca);
            drills.Index = Programas.Index();
            drills.Nome = drills.Index.ToString() + "-"+ drill.drill_combobox.Text;
            drills.ToolName = drill.drill_combobox.Text;
            drills.TipoDrill = (TipoDeDrills)drill.drill_combobox.SelectedItem;
            if (float.TryParse(drill.drill_kei_tb.Text, out kei))
            {
                drills.Kei = kei;
            }
            if (float.TryParse(drill.drill_z_tb.Text, out fukasa))
            {
                drills.Fukasa = fukasa;
            }
            drills.Sentan = drill.sentan_check.Checked;
            drills.Description = drill.Kakou_Annai_tb.Text;
            drills.Resfriamento = drill.Resfri_Combobox.Text;
            if (int.TryParse(drill.tool_tb.Text, out tool)) { drills.ToolNumber = tool; }

            drills.Frente = lado.Bool_Frente;
            drills.Tras = lado.Bool_Tras;
            Color colorselecionada = (Color)color.comboBox1.SelectedItem;
            drills.Color = colorselecionada;
            drills.numlado = 0;

            Ferramentas.DGVtoCoordenadasList(drills, xy_dgv, pcd_dgv, xyradiobutton, pcdradiobutton, PCDRaio, pontoinicialX, pontoinicialY);
            Mentori.CriarMentori(ferramentas.ListTotal,ferramentas.ListFrente,ferramentas.ListTras, drills, peca, MentoriF, MentoriT);

            ferramentas.ListTotal.Add(drills);
            if(drills.Frente){ ferramentas.ListFrente.Add(drills); }
            if(drills.Tras) { ferramentas.ListTras.Add(drills);}
            if (drills.Mentori_F_Bool) { ferramentas.MentoriFrente.Add(drills); }
            if(drills.Mentori_B_Bool) { ferramentas.MentoriTras.Add(drills); }

        }
        public void EditarDrills(Ferramentas ferramentas, Drills drills, Drill_UserControl drill, Lado_UserControl lado, Mentori_Frente MentoriF, Mentori_Frente MentoriT, Colors_UserControl color, DataGridView xy_dgv, DataGridView pcd_dgv, RadioButton xyradiobutton, RadioButton pcdradiobutton, TextBox PCDRaio, TextBox pontoinicialX, TextBox pontoinicialY)
        {
            float kei;
            float fukasa;
            int tool;
        
            drills.Nome = drills.Index.ToString() + "-" + drill.drill_combobox.Text;
            drills.ToolName = drill.drill_combobox.Text;
            drills.TipoDrill = (TipoDeDrills)drill.drill_combobox.SelectedItem;
            if (float.TryParse(drill.drill_kei_tb.Text, out kei))
            {
                drills.Kei = kei;
            }
            if (float.TryParse(drill.drill_z_tb.Text, out fukasa))
            {
                drills.Fukasa = fukasa;
            }
            drills.Sentan = drill.sentan_check.Checked;
            drills.Description = drill.Kakou_Annai_tb.Text;
            drills.Resfriamento = drill.Resfri_Combobox.Text;
            if (int.TryParse(drill.tool_tb.Text, out tool)) { drills.ToolNumber = tool; }

            drills.Frente = lado.Bool_Frente;
            drills.Tras = lado.Bool_Tras;
            Color colorselecionada = (Color)color.comboBox1.SelectedItem;
            drills.Color = colorselecionada;
            drills.numlado = 0;

            Ferramentas.DGVtoCoordenadasList(drills, xy_dgv, pcd_dgv, xyradiobutton, pcdradiobutton, PCDRaio, pontoinicialX, pontoinicialY);
            Mentori.CriarMentori(ferramentas.ListTotal, ferramentas.ListFrente, ferramentas.ListTras, drills, peca, MentoriF, MentoriT);

            //if (drills.Frente) { ferramentas.ListFrente.Add(drills); } else { ferramentas.ListFrente.Remove(drills); }
            //if (drills.Tras) { ferramentas.ListTras.Add(drills); } else { ferramentas.ListTras.Remove(drills); }
            //if (drills.Mentori_F_Bool) { ferramentas.MentoriFrente.Add(drills); } else { ferramentas.MentoriFrente.Remove(drills); }
            //if (drills.Mentori_B_Bool) { ferramentas.MentoriTras.Add(drills); }
            //else
            //{
            //    ferramentas.MentoriTras.Remove(drills);
            //}

        }

        protected override void UpdateKaitenAndOkuri()
        {
         
            if (!string.IsNullOrEmpty(_toolName) && _kei > 0)
            {// Busque o dicionário de valores de Kaiten para o TipoDrill selecionado

                TipoDeDrills.UpdateKaitenValueBasedOnMaterial(TipoDrill, peca, KaitenValues);
          
                float valorkaiten = TipoDrill.KaitenValue / _kei;
                Kaiten = Convert.ToInt32(valorkaiten);

                float valorokuri = valorkaiten * 0.1f;
                if(valorokuri > 300) { valorokuri = 300; }

                Okuri = Convert.ToInt32(valorokuri);

            }
        }
        public Dictionary<DrillMaterialKey, float> LoadKaitenValuesFromCsv()
        {
            Dictionary<DrillMaterialKey, float> kaitenValues = new Dictionary<DrillMaterialKey, float>();
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string ar = "Drill_Kaiten_Value.csv";
            string filePath = Path.Combine(dir, ar);
            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine(); // Pula o cabeçalho

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    string materialName = parts[0];
                    string drillTypeName = parts[1];
                    float kaitenValue = float.Parse(parts[2]);

                    DrillMaterialKey key = new DrillMaterialKey(drillTypeName, materialName);
                    kaitenValues[key] = kaitenValue;
                }
            }
            return kaitenValues;
        }

    }
 

    }
    public class DrillMaterialKey
    {
        public string DrillTypeName { get; set; }
        public string MaterialName { get; set; }
        public Dictionary<DrillMaterialKey, float> KaitenValues { get; private set; }

        public DrillMaterialKey(string drillTypeName, string materialName)
        {
            DrillTypeName = drillTypeName;
            MaterialName = materialName;
         //   KaitenValues = LoadKaitenValuesFromCsv();
        }

        public override bool Equals(object obj)
        {
            if (obj is DrillMaterialKey other)
            {
                return DrillTypeName == other.DrillTypeName && MaterialName == other.MaterialName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (DrillTypeName, MaterialName).GetHashCode();
        }



     

    }




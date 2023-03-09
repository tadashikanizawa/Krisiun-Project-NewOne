using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Krisiun_Project.Dados_aleatorios
{
    internal class NSB
    {
        //    [Name("Code")]
        public string Code { get; set; }

        //  [Name("Dia")]
        public float Dia { get; set; }

        //[Name("Hachou")]
        public float Hachou { get; set; }

        //[Name("Zenchou")]
        public int Zenchou { get; set; }

    }
    internal static class NSBLoader
    {
        public static List<NSB> Load()
        {
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string ar = "NSB.csv";
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                IgnoreBlankLines = true,
                MissingFieldFound = null
            };

            using (var reader = new StreamReader((Path.Combine(dir, ar))))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<NSB>().ToList();
            }
        }
    }
}

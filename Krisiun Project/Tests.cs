using System.ComponentModel;

namespace Krisiun_Project.janela_principal
{
    public class Tests
    {
        public string x;
        public BindingList<dynamic> bindings;
        // public string y;
        // public string z;
        public Tests()
        {
            this.x = "wololo";
            this.bindings = new BindingList<dynamic>();
        }
        public void teste(string s) { this.x = s; }
    }
}

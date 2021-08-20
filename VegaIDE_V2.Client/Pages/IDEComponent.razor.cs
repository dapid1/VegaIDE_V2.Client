using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VegaIDE_V2.Shared;

namespace VegaIDE_V2.Client.Pages
{
    public partial class IDEComponent
    {
        public string sourceCode;
        public string language;
        public Output Output { get; set; }
        public Compiler Compiler { get; set; }
        public EventCallback<string> ValueChanged
        {
            get;
            set;
        }

        public void RunCode()
        {

            //initialse the Code Property
            Compiler.RunCode();
        }

        private Task OnValueChanged(ChangeEventArgs e)
        {
            language = e.Value.ToString();
            return ValueChanged.InvokeAsync(language);
        }
    }
}
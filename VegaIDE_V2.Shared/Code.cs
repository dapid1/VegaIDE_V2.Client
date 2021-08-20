using System;

namespace VegaIDE_V2.Shared
{
    public class Code
    {
        public Code(Language language, string CodeString, string Location)
        {
            Language = language;
            this.CodeString = CodeString;
            this.Location = Location;
        }

        public string Location { get; set; }
        public string CodeString { get; set; }
        public Language Language { get; set; }
        public Language Python { get; }

        public void SetLanguage(string language)
        {
            throw new NotImplementedException();
        }
    }
}

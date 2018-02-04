using System;

namespace Discord.Commands
{ 
    public class OptionalAttribute : Attribute
    {
        public OptionalAttribute(string text)
        {
            this.Text = text;
        }

        public string Text { get; }
    }
}
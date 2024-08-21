
using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace WPM.Commands
{
    public abstract class CommonParameterSettings : CommandSettings
    {
        [CommandOption("--language|-l")]
        [Description("Specifies the language to type in.")]
        [DefaultValue("en")]
        public string Language { get; set; } = "en";

        [CommandOption("--symbols|-s")]
        [Description("Specifies whether to include symbols. Does not apply to easy mode. Defaults to false")]
        [DefaultValue(false)]
        public bool Symbols { get; set; }

        [CommandOption("--time|-t")]
        [Description("How much time should be used at max in seconds.")]
        [DefaultValue(60)]
        public int Time { get; set; } // Use int for time

        public override ValidationResult Validate()
        {
            var languages = new List<string> { "en", "de" };

            // Validate language
            if (!languages.Contains(Language))
            {
                return ValidationResult.Error($"Invalid language specified. Allowed values are: {string.Join(", ", languages)}");
            }

            // Validate time
            if (Time <= 0)
            {
                return ValidationResult.Error("Time must be a positive integer.");
            }

            return ValidationResult.Success();
        }
    }
}
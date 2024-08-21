using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;
using WPM.TextGenerator;

namespace WPM.Commands;

public sealed class ClassicCommand : Command<ClassicCommand.Settings>
{
    public sealed class Settings : CommonParameterSettings
    {
        [CommandOption("--mode|-m")]
        [Description("Specifies the difficulty")]
        [DefaultValue("easy")]
        public string Mode { get; set; } = "easy";

        public override ValidationResult Validate()
        {
            var baseValidation = base.Validate();
            if (!baseValidation.Successful)
            {
                return ValidationResult.Error(baseValidation.Message);
            }

            var validModes = new List<string>() { "easy", "hard" };
            if (!validModes.Contains(Mode))
            {
                return ValidationResult.Error(
                    $"Invalid mode specified. Allowed values are: {string.Join(", ", validModes)}");
            }

            return ValidationResult.Success();
        }
    }

    private readonly ITextGeneratorService _textGeneratorService; 
    public ClassicCommand(ITextGeneratorService textGeneratorService)
    {
        _textGeneratorService = textGeneratorService;
    }
    
    
    public override int Execute(CommandContext context, Settings settings)
    {
        try
        {
            var path = "/Users/michaelkvasin/csharp/WPM/WPM/Words/English/words_1000.txt";
            var text = _textGeneratorService.GenerateRandomTextFromFile(path);
            AnsiConsole.Write(text);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return 0;
    }
}
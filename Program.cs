using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils;

namespace DotNetGuid {
    [Command(
        Name = "guid",
        Description = "A console tool that generates Globally Unique Identifiers (GUIDs).",
        ExtendedHelpText = @"
Formats:
  The following table shows the accepted format specifiers for the format parameter. 
  ""0"" represents a digit; hyphens (""-""), braces (""{"", ""}""), and parentheses (""("", "")"") appear as shown.

  N, n  32 digits:

        00000000000000000000000000000000

  D, d  32 digits separated by hyphens:

        00000000-0000-0000-0000-000000000000

  B, b  32 digits separated by hyphens, enclosed in braces:

        {00000000-0000-0000-0000-000000000000}

  P, p  32 digits separated by hyphens, enclosed in parentheses:

        (00000000-0000-0000-0000-000000000000)

  X, x  Four hexadecimal values enclosed in braces, where the fourth value 
        is a subset of eight hexadecimal values that is also enclosed in braces:

        {0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}
"
    )]
    public class Program {
        public static int Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);

        [Option(Description = "The format specifier. See formats section.")]
        public string Format { get; }

        [Option(Description = "The number of guids to generate.")]
        public int Number { get; } = 1;

        private void OnExecute() {
            if (Number <= 0) {
                Console.WriteLine("The number must be an integer greater than 0.");
                return;
            }

            try {
                IEnumerable<string> guids = Enumerable.Range(0, Number).Select(_ => {
                    Guid guid = Guid.NewGuid();
                    string formatted = guid.ToString(Format);
                    return formatted;
                });
                string output = string.Join(Environment.NewLine, guids);
                Console.Write(output);
            } catch (Exception exception) {
                Console.WriteLine(exception.Message);
                return;
            }
        }
    }
}

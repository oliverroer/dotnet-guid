# dotnet-guid
A console tool that generates Globally Unique Identifiers (GUIDs).

## Usage

```
guid [options]
```

### Options

| Option                 | Description                                  |
| ---------------------- | -------------------------------------------- |
| `-f|--format <FORMAT>` | The format specifier. See formats section.   |
| `-n|--number <NUMBER>` | The number of guids to generate.             |
| `-?|-h|--help`         | Show help information                        |

### Formats

The following table shows the accepted format specifiers for the format parameter.
  
"0" represents a digit; hyphens ("-"), braces ("{", "}"), and parentheses ("(", ")") appear as shown.

| Format   | Description                                                                                                                                | Example                                                                   |
| -------- | ------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------- |
| `N`, `n` | 32 digits                                                                                                                                  | `00000000000000000000000000000000`                                        |
| `D`, `d` | 32 digits separated by hyphens                                                                                                             | `00000000-0000-0000-0000-000000000000`                                    |
| `B`, `b` | 32 digits separated by hyphens, enclosed in braces                                                                                         | `{00000000-0000-0000-0000-000000000000}`                                  |
| `P`, `p` | 32 digits separated by hyphens, enclosed in parentheses                                                                                    | `(00000000-0000-0000-0000-000000000000)`                                  |
| `X`, `x` | Four hexadecimal values enclosed in braces, where the fourth value is a subset of eight hexadecimal values that is also enclosed in braces | `{0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}`    |
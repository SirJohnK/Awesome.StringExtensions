# Awesome.StringExtensions
A collection of awesome string extension methods.

## ToTitleCase
Converts string to title case with culture specific handling of articles, conjunctions and prepositions.

```csharp
/// <summary>
/// Converts string to title case with culture specific handling of articles, conjunctions and prepositions.
/// </summary>
public static string ToTitleCase(this string text, CultureInfo culture)
```
```csharp
/// <summary>
/// Converts string to title case with current culture specific handling of articles, conjunctions and prepositions.
/// </summary>
public static string ToTitleCase(this string text)
```
### Supported languages
|Language|Culture Data|
| -------------------  | :------------------: |
|English|[en-US](Awesome.StringExtensions/CultureData/en-US.json)|
|French|[fr-FR](Awesome.StringExtensions/CultureData/fr-FR.json)|
|German|[de-DE](Awesome.StringExtensions/CultureData/de-DE.json)|
|Spanish|[es-ES](Awesome.StringExtensions/CultureData/es-ES.json)|
|Swedish|[sv-SE](Awesome.StringExtensions/CultureData/sv-SE.json)|

## License
The MIT License (MIT), see [LICENSE](LICENSE) file.

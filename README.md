# Awesome.StringExtensions
A collection of awesome string extension methods.

### ToTitleCase
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
#### Supported languages
|Language|Culture Data|
| -------------------  | :------------------: |
|English|[en-US](Awesome.StringExtensions/CultureData/en-US.json)|

### License
The MIT License (MIT), see [LICENSE](LICENSE) file.

# Awesome.StringExtensions

A collection of awesome string extension methods.

## What's included?

The following string extensions are available in Awesome.StringExtensions:

* [CleanWhitespace](#CleanWhitespace)
* [RemoveWhitespace](#RemoveWhitespace)
* [ReplaceWhitespace](#ReplaceWhitespace)
* [ToAcronym](#ToAcronym)
* [ToAlphabetic](#ToAlphabetic)
* [ToAlphanumeric](#ToAlphanumeric)
* [ToCamelCase](#ToCamelCase)
* [ToSentenceCase](#ToSentenceCase)
* [ToSnakeCase](#ToSnakeCase)
* [ToTitleCase](#ToTitleCase)

## CleanWhitespace

Cleans text whitespace and returns the result.
* Replaces contiguous sequences of whitespace with a single space.
* Also Removes all leading and trailing whitespaces.

```csharp
/// <summary>
/// Replaces contiguous sequences of whitespace with a single space.
/// Also Removes all leading and trailing whitespaces.
/// </summary>
/// <param name="text">Input text.</param>
/// <returns>Input text with no leading, trailing or contiguous sequences of whitespace.</returns>
public static string CleanWhitespace(this string text)
```

## RemoveWhitespace

Removes all whitespaces and returns result.

```csharp
/// <summary>
/// Removes all whitespaces and returns result.
/// </summary>
/// <param name="text">Input text.</param>
/// <returns>Input text with no whitespaces.</returns>
public static string RemoveWhitespace(this string text)
```

## ReplaceWhitespace

Replaces all whitespaces with specified replacement string and returns result.

```csharp
/// <summary>
/// Replaces all whitespaces with specified replacement string and returns result.
/// </summary>
/// <param name="text">Input text.</param>
/// <param name="replacement">Replacement string, default empty string.</param>
/// <param name="groupreplace">Replace contiguous sequences of whitespace with single replacement string boolean, default true.</param>
/// <returns>Input text with all whitespaces replaced with the replacement string.</returns>
public static string ReplaceWhitespace(this string text, string replacement = "", bool groupreplace = true)
```
        
## ToAcronym

Create a acronym for the specified text and returns result.
* Remove all non alphabetical characters and forms an acronym from the remaining words.
* *Definition of acronym - an abbreviation formed from the initial letters of other words and pronounced as a word (e.g. ASCII, NASA).*

```csharp
/// <summary>
/// Create a acronym for the specified text and returns result.
/// Remove all non alphabetical characters and forms an acronym from the remaining words.
/// </summary>
/// <param name="text">Input text.</param>
/// <returns>An acronym for the input text.</returns>
/// <remarks>Definition of acronym - an abbreviation formed from the initial letters of other words and pronounced as a word (e.g. ASCII, NASA).</remarks>
public static string ToAcronym(this string text)
```

## ToAlphabetic

Remove all non alphabetical characters and returns result.

```csharp
/// <summary>
/// Remove all non alphabetical characters and returns result.
/// </summary>
/// <param name="text">Input text.</param>
/// <param name="preserveWhitespace">Preserve whitespaces boolean, default true. Otherwise removes all whitespaces.</param>
/// <returns>Input text without any non alphabetical characters.</returns>
public static string ToAlphabetic(this string text, bool preserveWhitespace = true)
```

## ToAlphanumeric

## ToCamelCase

## ToSentenceCase

## ToSnakeCase

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

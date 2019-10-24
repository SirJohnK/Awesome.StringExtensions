# Awesome.StringExtensions

A collection of awesome string extension methods.

## What's included?

The following string extensions are available in Awesome.StringExtensions:

* [CleanWhitespace](#CleanWhitespace)

* [CountSentences](#CountSentences)
* [CountUniqueWords](#CountUniqueWords)
* [CountWordLengths](#CountWordLengths)
* [CountWords](#CountWords)
* [RemoveWhitespace](#RemoveWhitespace)
* [ReplaceWhitespace](#ReplaceWhitespace)
* [Sentences](#Sentences)
* [ToAcronym](#ToAcronym)
* [ToAlphabetic](#ToAlphabetic)
* [ToAlphanumeric](#ToAlphanumeric)
* [ToCamelCase](#ToCamelCase)
* [ToSentenceCase](#ToSentenceCase)
* [ToSnakeCase](#ToSnakeCase)
* [ToTitleCase](#ToTitleCase)
* [UniqueWords](#UniqueWords)
* [Words](#Words)

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

Creates a acronym for the specified text and returns result.
* Removes all non alphabetical characters and forms an acronym from the remaining words.
* *Definition of acronym - an abbreviation formed from the initial letters of other words and pronounced as a word (e.g. ASCII, NASA).*

```csharp
/// <summary>
/// Creates a acronym for the specified text and returns result.
/// Removes all non alphabetical characters and forms an acronym from the remaining words.
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

Removes all non alphanumerical characters and returns result.

```csharp
/// <summary>
/// Removes all non alphanumerical characters and returns result.
/// </summary>
/// <param name="text">Input text.</param>
/// <param name="preserveWhitespace">Preserve whitespaces boolean, default true. Otherwise removes all whitespaces.</param>
/// <returns>Input text without any non alphanumerical characters.</returns>
public static string ToAlphanumeric(this string text, bool preserveWhitespace = true)
```

## ToCamelCase

Capitalizes the first letter of each word and removes all whitespaces.

```csharp
/// <summary>
/// Capitalizes the first letter of each word and removes all whitespaces.
/// Also removes all non alphabetical characters.
/// </summary>
/// <param name="text">Input text.</param>
/// <returns>Input text with first letter of each word capitalized and without whitespaces.</returns>
public static string ToCamelCase(this string text)
```

## ToSentenceCase

Capitalizes the first letter of the first word and all other words are lowercase in each sentence.

```csharp
/// <summary>
/// Capitalizes the first letter of the first word and all other words are lowercase in each sentence.
/// </summary>
/// <param name="text">Input text.</param>
/// <param name="cleanWhitespace">Clean whitespaces boolean, default true. (<see cref="CleanWhitespace(string)"/>)</param>
/// <returns>Input text with first letter of the first word capitalized and all other words in lowercase in each sentence.</returns>
public static string ToSentenceCase(this string text, bool cleanWhitespace = true)
```

## ToSnakeCase

All whitespaces are replaced with underscore character.
* Replaces all contiguous sequences of whitespace with a single underscore.

```csharp
/// <summary>
/// All whitespaces are replaced with underscore character.
/// Replaces all contiguous sequences of whitespace with a single underscore.
/// </summary>
/// <param name="text">Input text.</param>
/// <returns>Input text with all whitespaces replaced with underscore character.</returns>
public static string ToSnakeCase(this string text)
```

## ToTitleCase

Converts string to title case with culture specific handling of articles, conjunctions and prepositions.

Rules:
* Capitalize the first word and the last word of the title.
* Capitalize the principal words.
* Capitalize all words of four letters or more.
* Do not capitalize articles, conjunctions, and prepositions of three letters or fewer.

```csharp
/// <summary>
/// Converts string to title case with culture specific handling of articles, conjunctions and prepositions.
/// </summary>
/// <param name="text">Input text.</param>
/// <param name="culture">Language culture to retrive and identify words.</param>
/// <returns>Input text with word casing based on title case rules.</returns>
/// <remarks>
/// Rules:
/// - Capitalize the first word and the last word of the title.
/// - Capitalize the principal words.
/// - Capitalize all words of four letters or more.
/// - Do not capitalize articles, conjunctions, and prepositions of three letters or fewer.
/// </remarks>
public static string ToTitleCase(this string text, CultureInfo culture)
```
```csharp
/// <summary>
/// Converts string to title case with current culture specific handling of articles, conjunctions and prepositions.
/// </summary>
/// <param name="text">Input text.</param>
/// <returns>Input text with word casing based on title case rules. (<see cref="ToTitleCase(string, CultureInfo)"/>)</returns>
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

If culture data is not found for specified culture, attempt is made to find another support data with same base language.
e.g. If culture en-GB is not found, a search is made based on culture TwoLetterISOLanguageName (en).
Any culture with same base language will be used as a replacement. (en-US could replace en-GB)

## License

The MIT License (MIT), see [LICENSE](LICENSE) file.

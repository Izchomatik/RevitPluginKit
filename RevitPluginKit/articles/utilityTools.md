
# Utility tools

## Description

A set of various tools designed to simplify the work with Revit API.

At the moment, the following categories of utility tools are distinguished:

* Converters

* Validators

## Converter tools

A set of tools designed for simple value conversions.

* [Converters Api documentation](https://izchomatik.github.io/RevitPluginKit/api/RevitPluginKit.Converters.html)

* Namespace: `RevitPluginKit.Converters`

	* Supports conversions between metric and imperial units.

	* Supports string conversions

> [!NOTE]
>
> The most convenient way to use converters - is with a using declaration:
>
> ```csharp
> using RevitPluginKit.Converters;
> ```

Example code snippet for converting 10 Square Feet to Square Meters:

```csharp
double squareMeters = MetricConverter.SquareFeetToSquareMeters(squareFeet: 10);
```

Example code snippet for converting 1000 millimeters to feet:

```csharp
double feet = MetricConverter.MMToFeet(millimeters: 1000);
```

## Validator tools

A set of tools designed to validate values.

* [ Validators Api documentation](https://izchomatik.github.io/RevitPluginKit/api/RevitPluginKit.Validators.html)

* Namespace: `RevitPluginKit.Validators`

	* WPF validation of an input value as being a number is supported.

> [!NOTE]
>
> The most convenient way to use validators - is with a using declaration:
>
> ```csharp
> using RevitPluginKit.Validators;
> ```

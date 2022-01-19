
# Collectors

## Description

A set of utilities and functions designed for quick and easy collection of various elements located in one of the instances of the "Revit" model or document.

* [Api documentation](https://izchomatik.github.io/RevitPluginKit/api/RevitPluginKit.Collectors.html)

* Namespace: `RevitPluginKit.Collectors`

> **NOTE**
>
> The most convenient way to use collectors - is with a using declaration:
>
> ```c#
>using RevitPluginKit.Collectors;
> ```

***

## Feature usage scenarios

* Collection of generic entities such as documents, link instances etc.

* Collection of basic entities such as levels, grids, styles etc.

* Collection of internal entities - such as views, sheets, schedules etc.

* Collection of element types based on user parameters - for subsequent specific processing

* Collection of element instances based on user parameters - for subsequent specific processing

***

## Instance collector

Use the element instance collector by "Revit" Category (`ElementsCollector.InstancesByCategory`) to collect specific element instances.

Example code snippet for collecting all door elements in the current model:

```csharp
List<Element> doors = ElementsCollector.InstancesByCategory<Element>(
    document: document,
    category: BuiltInCategory.OST_Doors);
```

Work in progress.

***

## Type collector

Work in progress.

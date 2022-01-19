
# Collectors

## Description

A set of utilities and functions designed for quick and easy collection of various elements located in one of the instances of the "Revit" model or document.

* [Collectors Api documentation](https://izchomatik.github.io/RevitPluginKit/api/RevitPluginKit.Collectors.html)

* Namespace: `RevitPluginKit.Collectors`

> [!NOTE]
>
> The most convenient way to use collectors - is with a using declaration:
>
> ```csharp
> using RevitPluginKit.Collectors;
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

Use the element instance collector by "Revit" Category (`ElementsCollector.InstancesByCategory<T>`) to collect specific element instances.

Example code snippet for collecting all door elements in the current model:

```csharp
List<Element> doors = ElementsCollector.InstancesByCategory<Element>(
    document: document,
    category: BuiltInCategory.OST_Doors);
```

Example code snippet for collecting floor elements in the current model, in defined option, with the given family name, with the given type name, on required level:

```csharp
List<Floor> testFloors = ElementsCollector.InstancesByCategory<Floor>(
    document: document,
    category: BuiltInCategory.OST_Floors,
    optionFilter: optionFilter,
    familyName: "floorFamilyName",
    typeName: "floorTypeName",
    levelIdsToFilterBy: new List<ElementId>() { levelId });
```

***

## Type collector

Use the element type collector by "Revit" Category (`ElementsCollector.TypesByCategory<T>`) to collect specific element types.

Example code snippet for collecting all door types in the current model:

```csharp
List<Element> testTypes = ElementsCollector.TypesByCategory<Element>(
    document: document,
    category: BuiltInCategory.OST_Doors);
```

Example code snippet for collecting floor types in the current model, with the given family name:

```csharp
List<Floor> testFloors = ElementsCollector.InstancesByCategory<Floor>(
    document: document,
    category: BuiltInCategory.OST_Floors,
    familyName: "floorFamilyName";
```

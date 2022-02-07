# The basics of creating new plugins

## Description

This article describes the process of organizing a custom plug-in for the Revit program based on .NET technologies (C#) and Visual Studio IDE software from Microsoft.

## Solution creation

In the new session visual studio:

* Create a new project

* Select the project type: `Class Library (.NET Framework)`

* Enter the required information (Project name, Location, Framework (`.NET Framework 4.7.2`)) and click `Create`

* Rename the main class (for example rename `Class1.cs` to `myPluginMain.cs`) if needed

## Add addin manifest

* Add Revit addin manifest:

	In your custom plugin project, create a .addin manifest file (for example: myPlugin.addin) that Revit will use to include your plugin on startup.

	Add the following lines to this file:

	```
	<?xml version="1.0" encoding="utf-8"?>
	<RevitAddIns>
		<AddIn Type="Application">
			<Name>myPluginName</Name>
			<Assembly>myPlugin.dll</Assembly>
			<AddInId>GUID</AddInId>
			<FullClassName>myPluginNamespace.myPluginMain</FullClassName>
			<Text>myPlugin text.</Text>
			<Description>myPlugin description.</Description>
			<VisibilityMode>AlwaysVisible</VisibilityMode>
			<VendorId>myPlugin vendor</VendorId>
			<VendorDescription>myPlugin vendor description</VendorDescription>
		</AddIn>
	</RevitAddIns>
	```

* Adjust field values (marked using `myPlugin`)

* Replace the GUID field with your unique GUID-token (you can generate it in any free online GUID-generator service)

## Add required references

* Add references to the two main libraries of the Revit program to your custom plugin project:

* In Solution Explorer, right-click the `References` section of your custom plug-in project and select "Add Reference..."
	
	Add `RevitAPI.dll` (for Revit 2019, this library is usually located at: C:\Program Files\Autodesk\Revit 2019\RevitAPI.dll)

	Add `RevitAPIUI.dll` (for Revit 2019, this library is usually located at: C:\Program Files\Autodesk\Revit 2019\RevitAPIUI.dll)

* For each of the Revit libraries (`RevitAPI.dll` and `RevitAPIUI.dll`), set the value of the "Copy Local" property as false

* [Install RevitPluginKit (for example using NuGet packages)](https://izchomatik.github.io/RevitPluginKit/articles/installation.html)

## Implement `IExternalApplication` interface

In order for Revit to correctly connect your plugin as external applications, you need to implement `IExternalApplication` interface

* In your main entry class (for example `myPluginMain.cs`) implement `IExternalApplication` interface

## Add Custom functions and test your new plug-in

* Add custom UI elements to the new plug-in. You can use the information from the page: [Quick start guide](https://izchomatik.github.io/RevitPluginKit/articles/quickStartGuide.html)

* Build your project (`Build` tab => `Build Solution` or `Ctrl+Shift+B`)

* Copy the custom plug-in library (myPlugin.dll), RevitPluginKit.dll and custom plug-in manifest (myPlugin.addin) to the Revit addins folder

	Usually the folder with addins on the example of Revit 2019 is located at: `C:\ProgramData\Autodesk\Revit\Addins\2019`

	After building the project, your custom plug-in library (myPlugin.dll) and RevitPluginKit.dll are in the bin folder located at the root of the project

* Open Revit and check that your plug-in has appeared in Revit the tabs

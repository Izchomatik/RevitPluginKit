# Quick start guide on RevitPluginKit test project

## Customize debug settings

* Open `RevitPluginKitTests` project properties

* Add settings in `Debug` tab:

	* In `Start action` section set flag `Start external program:` and add your `Revit.exe` destination (Revit 2019 or later version) - for example: `C:\Program Files\Autodesk\Revit 2019\Revit.exe`

	* In `Start options` section add Revit test file destination - for example: `D:\GitHub\RevitPluginKitTests\assets\revit\RevitPluginKitTests.rvt`

* Start `F5`, and check that the correct test model is launched

## Running tests

* After launching the test model - go to the tab `RPK Tests` (located in Revit ribbon)

* Each button represents a test of the `RevitPluginKit` library - select and run the required test

## Tests description

* `General test` - runs all the tests listed below at the same time - generates a general report on all tests

* `Collectors test` - runs tests related to checking the functionality of item collectors

	* namespace `RevitPluginKit.Collectors`

* `Converters test` - runs tests related to checking the functionality of value converters

	* namespace `RevitPluginKit.Converters`

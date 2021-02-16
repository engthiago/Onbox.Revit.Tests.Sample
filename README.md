![01 - Build Test Project](https://github.com/engthiago/Onbox.Revit.Tests.Sample/workflows/01%20-%20Build%20Test%20Project/badge.svg)
![02 - Test Results Report](https://github.com/engthiago/Onbox.Revit.Tests.Sample/workflows/02%20-%20Test%20Results%20Report/badge.svg)
## Continous Integration Sample for Revit based on Design Automation on Autodesk Forge

### Tech used
- [Forge's Design Automation](https://forge.autodesk.com/en/docs/design-automation/v3/developers_guide/overview/)
- [Forge's Data Management API](https://forge.autodesk.com/en/docs/data/v2/overview/)
- [Onbox Framework](https://github.com/engthiago/Onboxframework)
- [NUnit](https://nunit.org/)
- [Postman](https://www.postman.com/)
- [Github Actions](https://github.com/features/actions)

### How it works?
It uses a predefined AppBundle and Activity to plug-in Test Assemblies via parameters specified by Workitems. A Forge app needs to be setup and the AppBundle and Activity needs to be defined, but only once.

### Automation
A build trigger can be fired by a commit, [the build artifacts will packaged](https://github.com/engthiago/Onbox.Revit.Tests.Sample/runs/1908490497?check_suite_focus=true) and sent automatically to Forge to run the tests. After completing execution, a [NUnit test result will be produced and interpreted by Github actions](https://github.com/engthiago/Onbox.Revit.Tests.Sample/runs/1908534974?check_suite_focus=true) in form of a test Report. 

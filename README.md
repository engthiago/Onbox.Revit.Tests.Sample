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
- [Powershell](https://docs.microsoft.com/en-us/powershell)

### How it works?
It uses a predefined AppBundle and Activity to plug-in Test Assemblies via parameters specified by Workitems. A Forge app needs to be setup and the AppBundle/Activity needs to be defined, but only once. Every commit to the repository will trigger a github action that will build and package the tests and its dependencies and send them as a workitem to Forge.

![CI Process](https://raw.githubusercontent.com/engthiago/Onbox.Revit.Tests.Sample/master/CI_process.png)


### Automation
A build trigger can be fired by a commit, [the build artifacts will packaged](https://github.com/engthiago/Onbox.Revit.Tests.Sample/runs/1908490497?check_suite_focus=true) and sent automatically to Forge to run the tests. After completing execution, a [NUnit test result will be produced and interpreted by Github actions](https://github.com/engthiago/Onbox.Revit.Tests.Sample/runs/1908534974?check_suite_focus=true) in form of a test Report. 
![Test Report](https://raw.githubusercontent.com/engthiago/Onbox.Revit.Tests.Sample/master/test-report.png)

## Getting Started
This repository already contains a sample project to get you started. It contains a Design Automation Bundle zip and a Postman collection to make it easier to create the infrastructure on Forge like image above. There's a bit of setup the first time but after that the CI process will automatically run everytime a commit is done.
  - Clone this repository
  - Create your own Forge Application, make sure to enable Design Automation and Data Management API
  - On your repo on Github, go to Settings -> Secrets and add client_id and client_secret as enviroment secrets from the Forge app 
  - Use Postman to import Postman collection located at ./remote_tests/revit_tests.postman_collection.json
  - Setup Postman environment variables (see next topic)
  - On Postman, open Request: 03 - Upload App Bundle, to to Body and locate the specify the location of your revit_tests_bundle at .remote_tests/revit_tests.bundle.zip
  - Run Postman App Bundle folder: 00 - Authenticate -> 01 - Register App Bundle -> 02 - Upload App Bundle -> 03 - Create App Bundle Alias
  - Run Postman Activity folder: 01 - Create Activity -> 02 - Create Activity Alias
  - Run Postman: Cloud Storage folder: 01 - Create Bucket
  - On Github repository, go to Actions, it should have two Actions already created, first one should trigger automatically when you commit any changes
  - Open ./tests/Onbox.Revit.Tests.csproj in Visual Studio and edit the project, add new tests, etc
  - Commit the changes to see the Action 01 - Build Test Project be triggered
  - After action completed, open it up and go to the Post step and copy results download URL and Workitem Id
  - After Workitem completed, go to Actions 02 - Test Results Report and fire up the workflow using the results download URL

## Postman Variables
![Postman Variables](https://raw.githubusercontent.com/engthiago/Onbox.Revit.Tests.Sample/master/postman-variables.jpg)

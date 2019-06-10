# GWW

A BCIT Student project for a small wholesale buisness to generate sales Invoices.

This codebase contains the source C# code for a Windows 10 application utilizing C# WinForms. This program allows users to Create, Update, Read and Delete (CRUD) invoices in a MySQL database. A employee would use the program for the following activities:

* Process and save customer orders
* Checking an order before shipment
* Calculate taxes and shipping fees per order
* Store client contact info and product info

This program utilized Visual Studio and 

## Getting Started

This guide will only cover set up in a Windows OS Development environment.

The following dependencies and instructions will be required to compile and run the code:

### Prerequisites

A computer with the following software installed:
```
* Windows
* MySQL
* Visual Studio
```
This guide will not go into the details of installing these softwares.

### Installing

Utilizing Microsoft Visual Studio, You must download and configure the following:

#### Extensions and Update
```
1. Tools > Extensions and Updates
2. Search Online for
    a. Microsoft Rdlc Report Designer for Visual Studio
    b. Microsoft Reporting Services Projects
```

#### Nuget
```
1. Tools > NuGet Package Manager > Manage for solution...
2. Check if the following is installed
    a. Dapper
    b. Microsoft.Report.Viewer
    c. Microsoft.ReportingServices.ReportViewerControl.WinForms
    d. Microsoft.SqlServer.Types
```

## Deployment

Utilizing Microsoft Visual Studio:

### Compile the Code:
```
1. Build > Configuration Manager
2. Select Release Option
3. Hit Start
```

## Authors
* **Jeffrey Chou** - *Release 1.0* - [Jeffrey-Chou](https://github.com/Jeffrey-Chou)
* **Matthew Shew** - *Release 1.0* - [shewmj](https://github.com/shewmj)
* **John Tee** - *Release 1.0* - [jctee](https://github.com/jctee)
* **Li Yan Tong** - *Release 1.0* - [Tliyen](https://github.com/Tliyen)

## Acknowlegements

We would like to thank Great West Wholesale for the opportunity to work with them.

BCIT Contacts: 
* Farnaz Dargahi for input and feedback on project implementation

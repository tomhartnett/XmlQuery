# XmlQuery

A utility for querying XML data from an existing XML file using XPath queries.  I wrote this utility primarily because I wanted a quick way to test XPath queries before using them in code I am working on.

### Install

This is a simple .NET WinForms application written in C#.  You can just download the source and build it with Visual Studio.  I initially created this solution in Visual Studio 2010, but I last built it in Visual Studio 2013.  I was able to download and build the solution with Visual Studio Express 2013 for Windows Desktop (the free version).  I'm pretty sure you could build it with msbuild and not use Visual Studio at all, but I have not tested this.

### Usage

* Click the Load button to browse to an existing XML file.
* Type a valid XPath query into the query textbox.
* Hit Enter or click Query to run the XPath query.
* You will see the results in the right pane.
* Use the Copy button to copy to clipboard or Save button to save to file.

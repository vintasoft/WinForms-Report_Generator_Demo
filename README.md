# VintaSoft WinForms Report Generator Demo

This C# project uses <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html">VintaSoft Imaging .NET SDK</a> and demonstrates how to generate reports:
* Generate reports based on DOCX/XLSX template.
* Save generated report to PDF, DOCX, XLSX or TIFF file.
* View generated repors in PDF reader or Office default application.
* See code examples, which illustate how to work with DOCX and XLSX editor.


## Screenshot
<img src="vintasoft-report-generator-demo.png" title="VintaSoft Report Generator Demo">


## Usage
1. Get the 30 day free evaluation license for <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html" target="_blank">VintaSoft Imaging .NET SDK</a> as described here: <a href="https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html" target="_blank">https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html</a>

2. Update the evaluation license in "CSharp\MainForm.cs" file:
   ```
   Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");
   ```

3. Build the project ("ReportGeneratorDemo.Net8.csproj" file) in Visual Studio or using .NET CLI:
   ```
   dotnet build ReportGeneratorDemo.Net8.csproj
   ```

4. Run compiled application and try to generate reports.


## Documentation
VintaSoft Imaging .NET SDK on-line User Guide and API Reference for .NET developer is available here: https://www.vintasoft.com/docs/vsimaging-dotnet/


## Support
Please visit our <a href="https://myaccount.vintasoft.com/">online support center</a> if you have any question or problem.

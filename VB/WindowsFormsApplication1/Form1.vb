Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
Imports DevExpress.Spreadsheet
Imports System.Diagnostics

Namespace WindowsFormsApplication1

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim report As XtraReport1 = New XtraReport1()
            Dim report2 As XtraReport2 = New XtraReport2()
            report.CreateDocument(False)
            report2.CreateDocument(False)
            report.Pages.AddRange(report2.Pages)
            Dim tool As ReportPrintTool = New ReportPrintTool(report)
            tool.ShowPreviewDialog()
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim report As XtraReport1 = New XtraReport1()
            Dim report2 As XtraReport2 = New XtraReport2()
            report.CreateDocument(False)
            report2.CreateDocument(False)
            report.ExportToXlsx("test1.xlsx", New DevExpress.XtraPrinting.XlsxExportOptions() With {.SheetName = "report1"})
            report2.ExportToXlsx("test2.xlsx", New DevExpress.XtraPrinting.XlsxExportOptions() With {.SheetName = "report2"})
            Dim workbook As Workbook = New Workbook()
            workbook.LoadDocument("test1.xlsx")
            Dim workbook2 As Workbook = New Workbook()
            workbook2.LoadDocument("test2.xlsx")
            workbook.Worksheets.Insert(1, "report2")
            workbook.Worksheets(1).CopyFrom(workbook2.Worksheets(0))
            workbook.SaveDocument("test3.xlsx")
            Call Process.Start("test3.xlsx")
        End Sub
    End Class
End Namespace

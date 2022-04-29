Imports CustomDatesPivot
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Windows
Imports System.Windows.Controls

Namespace WpfApplication1

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Private Table As DataTable

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.dateEdit1.DateTime = Date.Now
            Me.dateEdit2.DateTime = Date.Now.AddMonths(12)
            Table = CreatePivotTable(100)
            Me.pivot.DataSource = Table
        End Sub

        Private Shared Function CreatePivotTable(ByVal RowCount As Integer) As DataTable
            Dim rnd As Random = New Random()
            Dim tbl As DataTable = New DataTable()
            tbl.Columns.Add("ID", GetType(Integer))
            tbl.Columns.Add("Name", GetType(String))
            tbl.Columns.Add("Checked", GetType(Boolean))
            tbl.Columns.Add("Number", GetType(Integer))
            tbl.Columns.Add("Value", GetType(Decimal))
            tbl.Columns.Add("AltValue", GetType(Decimal))
            tbl.Columns.Add("Date", GetType(Date))
            For i As Integer = 0 To RowCount - 1
                Dim row As DataRow = tbl.Rows.Add(New Object() {i, String.Format("Name{0}", i Mod 9), i Mod 2 = 0, rnd.Next(10), rnd.Next(100, 1000), rnd.Next(100, 1000), Date.Now.AddDays(rnd.Next(300))})
            Next

            Return tbl
        End Function

        Private Sub pivot_CustomFieldValueCells(ByVal sender As Object, ByVal e As DevExpress.Xpf.PivotGrid.PivotCustomFieldValueCellsEventArgs)
            Dim index As Integer = Me.pivot.GetRowIndex(New Object() {Nothing})
            If index <> -1 Then e.Remove(e.GetCell(False, index))
        End Sub

        Private Sub button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim DateFields As List(Of String) = New List(Of String)()
            DateFields.Add("Date")
            Dim CustomDates As List(Of Date) = New List(Of Date)()
            Dim [date] As Date = Me.dateEdit1.DateTime
            While [date] < Me.dateEdit2.DateTime
                CustomDates.Add([date])
                Select Case Me.comboBox.Text
                    Case "Year"
                        [date] = [date].AddYears(1)
                    Case "Quarter"
                        [date] = [date].AddMonths(3)
                    Case "Month"
                        [date] = [date].AddMonths(1)
                    Case Else
                        [date] = [date].AddDays(1)
                End Select
            End While

            Me.pivot.DataSource = New DateDataSourceWrapper(Table.DefaultView, DateFields, CustomDates)
        End Sub
    End Class
End Namespace

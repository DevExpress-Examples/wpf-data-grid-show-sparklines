Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace SparklineInGrid

    Public Partial Class MainWindow
        Inherits Window

        Public Property SalesData As List(Of SalesDataRow)

        Public Sub New()
            Me.InitializeComponent()
            Me.grid.DataContext = Me
            SalesData = New List(Of SalesDataRow)()
            Dim rowsCount As Integer = 20
            For i As Integer = 0 To rowsCount - 1
                SalesData.Add(New SalesDataRow() With {.Title = String.Format("Index: {0}", i + 1), .SparklineData = GenerateSparklineData()})
            Next
        End Sub

        Private random As Random = New Random()

        Private Function GenerateSparklineData() As IList
            Dim sparklineData As ObservableCollection(Of SalesItem) = New ObservableCollection(Of SalesItem)()
            Dim dateTime As Date = New DateTime(2013, 07, 17)
            For i As Integer = 0 To 30 - 1
                sparklineData.Add(New SalesItem() With {.ValueColumn = random.Next(-20, 20), .ArgumentColumn = dateTime.AddDays(i)})
            Next

            Return sparklineData
        End Function
    End Class

    Public Class SalesDataRow

        Public Property Title As Object

        Public Property SparklineData As IList
    End Class

    Public Class SalesItem

        Public Property ArgumentColumn As Object

        Public Property ValueColumn As Integer
    End Class
End Namespace

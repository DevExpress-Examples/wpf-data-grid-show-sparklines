Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Threading
Imports System.Windows
Imports DevExpress.Xpf.Utils

Namespace SparklineInGrid

	Partial Public Class MainWindow
		Inherits Window

		Private privateSalesData As List(Of SalesDataRow)
		Public Property SalesData() As List(Of SalesDataRow)
			Get
				Return privateSalesData
			End Get
			Set(ByVal value As List(Of SalesDataRow))
				privateSalesData = value
			End Set
		End Property

		Public Sub New()
			InitializeComponent()

			grid.DataContext = Me

			SalesData = New List(Of SalesDataRow)()

			Dim rowsCount As Integer = 20

			For i As Integer = 0 To rowsCount - 1
				SalesData.Add(New SalesDataRow() With {.Title = String.Format("Index: {0}", i+1), .SparklineData = GenerateSparklineData()})
			Next i

		End Sub

		Private random As New Random()

		Private Function GenerateSparklineData() As IList
			Dim sparklineData As New ObservableCollection(Of SalesItem)()

			Dim dateTime As New DateTime(2013, 07, 17)

			For i As Integer = 0 To 29
				sparklineData.Add(New SalesItem() With {.ValueColumn = random.Next(-20, 20), .ArgumentColumn = dateTime.AddDays(i)})
			Next i

			Return sparklineData
		End Function

	End Class

	Public Class SalesDataRow
		Private privateTitle As Object
		Public Property Title() As Object
			Get
				Return privateTitle
			End Get
			Set(ByVal value As Object)
				privateTitle = value
			End Set
		End Property
		Private privateSparklineData As IList
		Public Property SparklineData() As IList
			Get
				Return privateSparklineData
			End Get
			Set(ByVal value As IList)
				privateSparklineData = value
			End Set
		End Property
	End Class

	Public Class SalesItem
		Private privateArgumentColumn As Object
		Public Property ArgumentColumn() As Object
			Get
				Return privateArgumentColumn
			End Get
			Set(ByVal value As Object)
				privateArgumentColumn = value
			End Set
		End Property
		Private privateValueColumn As Integer
		Public Property ValueColumn() As Integer
			Get
				Return privateValueColumn
			End Get
			Set(ByVal value As Integer)
				privateValueColumn = value
			End Set
		End Property
	End Class
End Namespace

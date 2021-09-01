<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T615806)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DateDataSourceWrapper.cs](./CS/WpfApplication1/DateDataSourceWrapper.cs) (VB: [DateDataSourceWrapper.vb](./VB/WpfApplication1/DateDataSourceWrapper.vb))
* [MainWindow.xaml](./CS/WpfApplication1/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/WpfApplication1/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/WpfApplication1/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApplication1/MainWindow.xaml.vb))
<!-- default file list end -->
# How to add custom Field Values (Rows/Columns) that are not present in a DataSource


<em>This is a WPF version of the <a href="https://www.devexpress.com/Support/Center/p/E4493">How to add custom Field Values (Rows/Columns) that are not present in a DataSource</a> example.</em><br><br>PivotGridControl does not display field values in row and column areas if these values are not represented in the underlying datasource. As a workaround, add all required values to the original datasource or create a datasource wrapper that contains all required values on its level, and there is no need to modify original datasource. <br>This example illustrates how to create such a datasource wrapper. It is based on the <a href="https://www.devexpress.com/Support/Center/p/E1180">How to create a data source wrapper that adds an empty item to the lookup list</a> example.<br><br>In this example, the CustomDates collection is filled with DateTime values based on the actual Start/End DateTime range and the specified interval (e.g., Month). This collection is passed to the DateDataSourceWrapper class instance along with the original data source collection (<em>Table.DefaultView</em>). The main idea of creating a custom wrapper class is to merge the CustomDates collection with the original data table without modifying the latter one. So, when PivotGridControl requests data using the common <a href="https://msdn.microsoft.com/en-us/library/system.collections.ilist(v=vs.110).aspx">IList</a> and <a href="https://msdn.microsoft.com/en-us/library/system.componentmodel.itypedlist(v=vs.110).aspx">ITypedList</a> interface methods, wrapper returns data from the original collection or generates <em>EmptyObjectPropertyDescriptor</em> objects to return rows with null "Date" field values. For instance, check the DateDataSourceWrapper.this[int index] and DateDataSourceWrapper.GetItemProperties method implementations.<br><br>You can also check the following example that illustrates the ITypedList interface concept: <a href="https://docs.microsoft.com/en-us/dotnet/framework/winforms/how-to-implement-the-itypedlist-interface">How to: Implement the ITypedList Interface</a>.

<br/>



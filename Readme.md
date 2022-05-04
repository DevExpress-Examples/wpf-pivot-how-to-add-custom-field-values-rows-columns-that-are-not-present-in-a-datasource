<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T615806)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# How to Add Custom Field Values (Rows/Columns) that are not Present in a Data Source

Pivot Grid does not display field values in row and column areas if these values are not represented in the underlying data source. This example demonstrates how to create a data source wrapper that contains all required values on its level, and there is no need to modify original data source. In the example, the `CustomDates` collection is filled with DateTime values based on the actual Start/End DateTime range and the specified interval (for example, `Month`). This collection is passed to the `DateDataSourceWrapper` class instance along with the original data source collection (`Table.DefaultView`). `CustomDates` collection is merged with the original data table and you do not need to modify the data source. When Pivot Grid requests data with the common [IList](https://msdn.microsoft.com/en-us/library/system.collections.ilist(v=vs.110).aspx) and [ITypedList](https://msdn.microsoft.com/en-us/library/system.componentmodel.itypedlist(v=vs.110).aspx) interfaces methods, the `DateDataSourceWrapper` object returns data from the original collection or generates `EmptyObjectPropertyDescriptor` objects to return rows with null "Date" field values.

The following image illustrates Pivot Grid that displays the custom `March` field value from the `CustomDates` collection along with field values from the data source:
 
![Pivot Grid - Custom Field Values](./images/custom-field-values.png)

<!-- default file list -->
## Files to Look at

* [DateDataSourceWrapper.cs](./CS/WpfApplication1/DateDataSourceWrapper.cs) (VB: [DateDataSourceWrapper.vb](./VB/WpfApplication1/DateDataSourceWrapper.vb))
* [MainWindow.xaml](./CS/WpfApplication1/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/WpfApplication1/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/WpfApplication1/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApplication1/MainWindow.xaml.vb))
<!-- default file list end -->
## Documentation

[Fields](https://docs.devexpress.com/WPF/8024/controls-and-libraries/pivot-grid/fundamentals/fields)
## More Examples 

- [Pivot Grid for WinForms - How to Add Custom Field Values (Rows/Columns) that Are Not Present in a Data Source](https://github.com/DevExpress-Examples/how-to-add-custom-field-values-rows-columns-that-are-not-present-in-a-datasource-e4493)

- [How to create a data source wrapper that adds an empty item to the lookup list](https://github.com/DevExpress-Examples/how-to-create-a-data-source-wrapper-that-adds-an-empty-item-to-the-lookup-list-e1180)



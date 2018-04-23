using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using DevExpress.Xpf.Utils;

namespace SparklineInGrid {

    public partial class MainWindow : Window {

        public List<SalesDataRow> SalesData { get; set; }

        public MainWindow() {
            InitializeComponent();

            grid.DataContext = this;

            SalesData = new List<SalesDataRow>();

            int rowsCount = 20;

            for (int i = 0; i < rowsCount; i++)
                SalesData.Add(new SalesDataRow() { Title = String.Format("Index: {0}", i+1), 
                    SparklineData = GenerateSparklineData() });

        }

        Random random = new Random();

        IList GenerateSparklineData() {
            ObservableCollection<SalesItem> sparklineData = new ObservableCollection<SalesItem>();
            
            DateTime dateTime = new DateTime(2013, 07, 17);

            for (int i=0; i < 30; i++)
                sparklineData.Add(new SalesItem() { ValueColumn = random.Next(-20, 20), ArgumentColumn = dateTime.AddDays(i) });

            return sparklineData;
        }

    }

    public class SalesDataRow {
        public object Title { get; set; }
        public IList SparklineData { get; set; }
    }

    public class SalesItem {
        public object ArgumentColumn { get; set; }
        public int ValueColumn { get; set; }
    }
}

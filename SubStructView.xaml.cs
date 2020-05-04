﻿using System.Collections.ObjectModel;
using System.Windows.Controls;
using MHW_Editor.Controls;

namespace MHW_Editor {
    public partial class SubStructView {
        public SubStructView() {
            InitializeComponent();
        }
    }

    public sealed class SubStructViewDynamic<T> : SubStructView where T : class {
        public SubStructViewDynamic(MainWindow mainWindow, string name, ObservableCollection<T> items) {
            Title = name;
            Owner = mainWindow;

            var dataGrid = new MhwDataGridGeneric<T> {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility   = ScrollBarVisibility.Auto
            };
            dataGrid.SetItems(mainWindow, items);

            AddChild(dataGrid);
        }
    }
}
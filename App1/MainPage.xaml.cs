using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int countX;
        int countY;
        int countDeep;
        int strtCount = 10;

        public MainPage()
        {
            this.InitializeComponent();
            initStartValue(strtCount);
            initView();
        }

        private void initStartValue(int strtCount)
        {
            countX = countY = countDeep = strtCount;
            slideX.Value = strtCount;
            slideY.Value = strtCount;
        }

        private void initView()
        {
            updateGridColAndRow();
            initPage();
        }

        private void updateGridColAndRow()
        {
            //clearGrid();
            for (int i = 0; i < countX; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < countY; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void clearGrid()
        {
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
            grid.Children.Clear();
        }

        public void initPage()
        {
            for(int col = 0; col < countX; col++)
            {
                for (int row = 0; row < countY; row++)
                {
                    addButton(row, col);
                }
            }
        }

        private void addButton(int col, int row)
        {
            Rectangle rect = new Rectangle();
            rect.Fill = new SolidColorBrush(
                Color.FromArgb(255, 
                (byte)(255 - col* countDeep), 
                (byte)(255 - row* countDeep), 
                255));
            grid.Children.Add(rect);
            Grid.SetColumn(rect, col);
            Grid.SetRow(rect, row);
            rect.PointerEntered += Btn_PointerEntered;
        }

        private void Btn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ((Rectangle)sender).Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }

        private void slideX_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            countX = (int)slideX.Value;
            clearGrid();
            initView();
        }

        private void slideY_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            countY = (int)slideY.Value;
            clearGrid();
            initView();
        }

        private void deep_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            countDeep = (int)deep.Value;
            clearGrid();
            initView();
        }
    }
}

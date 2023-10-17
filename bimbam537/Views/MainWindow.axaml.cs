using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;
using bimbam537.ViewModels;
using Brush = Avalonia.Media.Brush;
using Brushes = Avalonia.Media.Brushes;
using Color = Avalonia.Media.Color;


namespace bimbam537.Views;

public partial class MainWindow : Window
{
    private bool isBlackTheme = false;
    

public MainWindow()
    {
        InitializeComponent();
        isBlackTheme = false;
        ChangeTheme(new WhiteTheme());
        table1Button.Click += delegate { ChangeTable(0); };
        table2Button.Click += delegate { ChangeTable(1); };
        table3Button.Click += delegate { ChangeTable(2); };
        table4Button.Click += delegate { ChangeTable(3); };
        
        ChangeTable(0);
    }

public void ThemeChanger(object? sender, RoutedEventArgs e)
{
    if (!isBlackTheme)
    {
        isBlackTheme = true;
        ChangeTheme(new BlackTheme());
    }
    else
    {
        isBlackTheme = false;
        ChangeTheme(new WhiteTheme());
    }
}

public void UpdateTables(object? sender, RoutedEventArgs e)
{
    MainWindowViewModel.UpdateCollections();
}

    public void ChangeTheme(Theme theme)
    {
            TabsGrid.Background = new SolidColorBrush(theme.mainColor);
            FunctionsGrid.Background = new SolidColorBrush(theme.mainColor);
            DataGridPanel.Background = new SolidColorBrush(theme.mainColor);
            dataGrid.Background = new SolidColorBrush(theme.secondaryColor);
            dataGrid.Foreground = new SolidColorBrush(theme.textColor);
            dataGrid.RowBackground = new SolidColorBrush(theme.secondaryColor);
            
            table1Button.Background = new SolidColorBrush(theme.elementsColor1);
            table1Button.Foreground = new SolidColorBrush(theme.textColor);
            table2Button.Background = new SolidColorBrush(theme.elementsColor1);
            table2Button.Foreground = new SolidColorBrush(theme.textColor);
            table3Button.Background = new SolidColorBrush(theme.elementsColor1);
            table3Button.Foreground = new SolidColorBrush(theme.textColor);
            table4Button.Background = new SolidColorBrush(theme.elementsColor1);
            table4Button.Foreground = new SolidColorBrush(theme.textColor);
            
            addButton.Background = new SolidColorBrush(theme.elementsColor2);
            addButton.Foreground = new SolidColorBrush(theme.textColor);
            changeButton.Background = new SolidColorBrush(theme.elementsColor2);
            changeButton.Foreground = new SolidColorBrush(theme.textColor);
            deleteButton.Background = new SolidColorBrush(theme.elementsColor2);
            deleteButton.Foreground = new SolidColorBrush(theme.textColor);
            updateButton.Background = new SolidColorBrush(theme.elementsColor2);
            updateButton.Foreground = new SolidColorBrush(theme.textColor);
            themeButton.Background = new SolidColorBrush(theme.elementsColor2);
            themeButton.Foreground = new SolidColorBrush(theme.textColor);
    }

    public void ChangeTable(int id)
    {
        switch (id)
        {
            case 0:
                table1Button.BorderBrush = Brushes.Blue;
                table2Button.BorderBrush = Brushes.Transparent;
                table3Button.BorderBrush = Brushes.Transparent;
                table4Button.BorderBrush = Brushes.Transparent;

                dataGrid.ItemsSource = MainWindowViewModel.requests;
                var col = new DataGridTemplateColumn();
                col.Header = "Ответственные";
                col.CellTemplate = new FuncDataTemplate<Object>((itemModel, nameScope) =>
                {
                    return new Avalonia.Controls.ComboBox
                    {
                        SelectedIndex = 0
                    };
                });
                
                dataGrid.Columns.Add(col);
                break;
            case 1:
                table1Button.BorderBrush = Brushes.Transparent;
                table2Button.BorderBrush = Brushes.Blue;
                table3Button.BorderBrush = Brushes.Transparent;
                table4Button.BorderBrush = Brushes.Transparent;

                dataGrid.ItemsSource = MainWindowViewModel.statuses;
                break;
            case 2:
                table1Button.BorderBrush = Brushes.Transparent;
                table2Button.BorderBrush = Brushes.Transparent;
                table3Button.BorderBrush = Brushes.Blue;
                table4Button.BorderBrush = Brushes.Transparent;

                dataGrid.ItemsSource = MainWindowViewModel.defects;
                break;
            case 3:
                table1Button.BorderBrush = Brushes.Transparent;
                table2Button.BorderBrush = Brushes.Transparent;
                table3Button.BorderBrush = Brushes.Transparent;
                table4Button.BorderBrush = Brushes.Blue;

                dataGrid.ItemsSource = MainWindowViewModel.responsibles;
                break;
        }
    }
    
}

public interface Theme
{
    public Color mainColor { get; set; }
    public Color secondaryColor { get; set; }
    public Color elementsColor1 { get; set; }
    public Color elementsColor2 { get; set; }
    
    public Color textColor { get; set; }
}

public class BlackTheme : Theme
{
    public Color mainColor { get; set; } = new(255, 26, 26, 29);
    public Color secondaryColor { get; set; } = new(255, 78, 78, 80);
    public Color elementsColor1 { get; set; } = new(255, 114, 34, 50);
    public Color elementsColor2 { get; set; } = new(255, 195, 7, 63);

    public Color textColor { get; set; } = Colors.White;
}

public class WhiteTheme : Theme
{
    public Color mainColor { get; set; } = new Color(255, 247, 249, 251);
    public Color secondaryColor { get; set; } = new Color(255, 143, 193, 227);
    public Color elementsColor1 { get; set; } = new Color(255, 104, 120, 100);
    public Color elementsColor2 { get; set; } = new Color(255, 49, 112, 142);

    public Color textColor { get; set; } = Colors.Black;
}
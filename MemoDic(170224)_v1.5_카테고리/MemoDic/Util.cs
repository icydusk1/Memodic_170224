using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

public class Util
{
    public static void PasswordTextVisibility(string password, TextBlock textBlock)
    {
        if (password == null || password == "")
        {
            textBlock.Visibility = Visibility.Visible;
        }
        else
        {
            textBlock.Visibility = Visibility.Collapsed;
        }
    }
}

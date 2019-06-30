// Author:      Li Leo Wang
// Start Date:  2019-06-29
// Description: Demo WPF: 
//      - Binding between ListBox and TextBox
//      - Animation on mouse over
//      - Link to array
//      - Alternate style with item container style selector
// Notes:
//      - (none)
//          
// Change history:
//      - Refer to GitHub comments related to each source file.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnDemo_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("demo");
            string[] a = { "BLUE", "YELLOW" };
            IEnumerable<string> q =
                from n in a
                where n.StartsWith("b", StringComparison.OrdinalIgnoreCase)
                    || n.StartsWith("y", StringComparison.OrdinalIgnoreCase)
                select n;
            foreach (var s in q)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = s;
                lbxColors.Items.Add(item);
            }
        }
    }

    public class RowStyle : StyleSelector
    {
        public Style DefaultStyle { get; set; }
        public Style AlternateStyle { get; set; }

        private bool m_bIsAlternate = false;

        public override Style SelectStyle(object item, DependencyObject container)
        {
            Style style = m_bIsAlternate ? AlternateStyle : DefaultStyle;
            m_bIsAlternate = !m_bIsAlternate;

            return style;
        }
    }
}

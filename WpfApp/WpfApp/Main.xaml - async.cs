// Author:      Li Leo Wang
// Start Date:  2019-06-29
// Description: Demo WPF: 
//      - Use async coordinate UI thread and long running background thread
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
using System.Threading;
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
            Longrunning_async("andrew");
            txtMsg.Content = "waiit...";
        }

        async void Longrunning_async(string name)
        {
            var r = await Longrunning_task(name);
            txtMsg.Content = r;
        }

        Task<string> Longrunning_task(string name)
        {
            return Task.Factory.StartNew(() => Longrunning(name));
        }

        string Longrunning(string name)
        {
            Thread.Sleep(3000);

            return "hello: " + name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfProject.Enum;
using System.Linq;

namespace WpfProject.Pages
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : UserControl
    {

        public Add()
        {
            InitializeComponent();

            foreach (var item in Country.GetValues(typeof(Country)))
            {
                Country_box.Items.Add(item);
            }
        }

        private void Add_btn(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(this.Country_box.Text);
        }

        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            


            string[] split = Phone.Text.Split(new char[] { '-', '(', ')' });
            StringBuilder sb = new StringBuilder();
            if (Country_box.Text == "Poland")
            {
                Phone.MaxLength = 14;
                if (Phone.Text.ToString().Length == 9)
                {
                    foreach (var item in split)
                    {
                        if (item.Trim() != "")
                        {
                            sb.Append(item);
                        }
                    }
                    this.Phone.Text = String.Format("+48 {0:000-000-000}", double.Parse(sb.ToString()));
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            

        }
    }
}

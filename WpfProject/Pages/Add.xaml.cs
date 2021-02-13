﻿using System;
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
using System.Text.RegularExpressions;

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
        /// <summary>
        /// Dodanie danych do bazy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(this.Phone.Text);
            try
            {
                var eMailValidator = new System.Net.Mail.MailAddress(Mail.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("xD");
            }
        }
        /// <summary>
        /// Kod ograniczający ilość cyfr i format numeru w zaleźności od wybranego kraju
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            #region Formatowanie numeru ze względu na kraj
            string[] split = Phone.Text.Split(new char[] { '-', '(', ')' });
            StringBuilder sb = new StringBuilder();

            if (Country_box.Text == "Poland")
            {
                Phone.MaxLength = 15;
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

            if (Country_box.Text == "Germany")
            {
                Phone.MaxLength = 17;
                if (Phone.Text.ToString().Length == 11)
                {
                    foreach (var item in split)
                    {
                        if (item.Trim() != "")
                        {
                            sb.Append(item);
                        }
                    }
                    this.Phone.Text = String.Format("+49 {0:000-000-00000}", double.Parse(sb.ToString()));
                }
            }

            if (Country_box.Text == "Norway")
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
                    this.Phone.Text = String.Format("+47 {0:00-00-00}", double.Parse(sb.ToString()));
                }
            }

            if (Country_box.Text == "Czech")
            {
                Phone.MaxLength = 16;
                if (Phone.Text.ToString().Length == 9)
                {
                    foreach (var item in split)
                    {
                        if (item.Trim() != "")
                        {
                            sb.Append(item);
                        }
                    }
                    this.Phone.Text = String.Format("+420 {0:000-000-000}", double.Parse(sb.ToString()));
                }
            }
            #endregion
        }
        /// <summary>
        /// Czyszczenie pola na numer telefonu, po wybraniu innego kraju.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Phone.Text = "";
        }
        /// <summary>
        /// Przyjmowanie tylko liczb w TextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Mail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
using EntityExample.Entities;

namespace EntityExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            

            _renewControlls();
        }

        private void _renewControlls()
        {
            using (PeopleModelContainer db = new PeopleModelContainer())
            {
                dataGridPeoples.ItemsSource = db.PeopleSet;
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            using (PeopleModelContainer db = new PeopleModelContainer())
            {
                db.PeopleSet.AddObject(new People()
                {
                    Id = Guid.NewGuid(),
                    Familyname = textBoxFamilyname.Text,
                    Firstname = textBoxFirstname.Text,
                    Secondname = textBoxSecondname.Text
                });

                db.SaveChanges();
            }

            _renewControlls();
        }
    }
}

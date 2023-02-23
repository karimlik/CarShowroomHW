using CarShowroom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CarShowroom
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            CarsDbContext context = new();
            using (context)
            {
                var showList = context.Showrooms
                    .ToList();

                ShowroomGrid.ItemsSource = showList;
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            CarsDbContext context = new();
            using (context)
            {
                var showList = context.Showrooms
                    .ToList();

                ShowroomGrid.ItemsSource = showList;
            }
        }

        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            CarsDbContext context = new CarsDbContext();

            string inputId, inputName, inputAddress, inputPhone;
            Title = "Data";

            inputId = Interaction.InputBox("Input Id", Title, "Id", 500, 300);
            inputName = Interaction.InputBox("Input Name", Title, "Name", 500, 300);
            inputAddress = Interaction.InputBox("Input Address", Title, "Address", 500, 300);
            inputPhone = Interaction.InputBox("Input Phone", Title, "Phone", 500, 300);

            int phone = 0, id = 0;
            bool isIdInt = int.TryParse(inputId, out id);
            bool isPhoneInt = int.TryParse(inputPhone, out phone);

            using (context)
            {
                var entity = context.Showrooms.FirstOrDefault(item => item.ShowroomId == id);

                entity.Name = inputName;
                entity.Address = inputAddress;   
                entity.Phone = phone;

                context.SaveChanges();
                updateBtn_Click(sender, e);

            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            CarsDbContext context = new CarsDbContext();

            string inputName, inputAddress, inputPhone;
            Title = "Data";

            inputName = Interaction.InputBox("Input Name", Title, "Name", 500, 300);
            inputAddress = Interaction.InputBox("Input Address", Title, "Address", 500, 300);
            inputPhone = Interaction.InputBox("Input Phone", Title, "Phone", 500, 300);

            int phone = 0;
            bool isPhoneInt = int.TryParse(inputPhone, out phone);

            using (context)
            {

                var showroom = new Showroom { Name = inputName, Address = inputAddress, Phone = phone };

                context.Add(showroom);
                context.SaveChanges();

                updateBtn_Click(sender, e);

            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            CarsDbContext context = new CarsDbContext();

            string Title, Default;
            Title = "Data";
            Default = "0";

            var idInput = Interaction.InputBox("Input Id", Title, Default, 500, 300);
            int id = 0;
            bool isInt = int.TryParse(idInput, out id);

            if (isInt)
            {
                Showroom showroom = new Showroom() { ShowroomId = id };
                using (context)
                {
                    context.Entry(showroom).State = EntityState.Deleted;
                    context.SaveChanges();

                    updateBtn_Click(sender, e);
                }
            }

            else
            {
                MessageBox.Show("Input true id value!");
            }
        }
    }
}

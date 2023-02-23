using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using CarShowroom.Models;

namespace CarShowroom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            CarsDbContext context = new();
            using (context)
            {
                var carsList = context.Cars
                    .Include(x => x.ShowroomInfo)
                    .ToList();

                CarsGrid.ItemsSource = carsList;
            }
        }

        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            CarsDbContext context = new CarsDbContext();

            string Title;
            Title = "Data";

            var idInput = Interaction.InputBox("Input Id", Title, "0", 500, 300);
            int id = 0;
            bool isInt = int.TryParse(idInput, out id); //У меня не получилось взять ID с SelectedItem

            using (context)
            {
                var entity = context.Cars.FirstOrDefault(item => item.Id == id);


                if (isInt == true && entity != null)
                {
                    string inputMake, inputModel, inputMY, inputEC, inputPrice;

                    inputMake = Interaction.InputBox("Input Make", Title, "Make", 500, 300);
                    inputModel = Interaction.InputBox("Input Model", Title, "Model", 500, 300);
                    inputMY = Interaction.InputBox("Input Model Year", Title, "Model Year", 500, 300);
                    inputEC = Interaction.InputBox("Input Engine Capacity", Title, "Engine Capacity", 500, 300);
                    inputPrice = Interaction.InputBox("Input Price", Title, "Price", 500, 300);
                    var ShowInput = Interaction.InputBox("Input Showroom ID", Title, "0", 500, 300);

                    int showId = 0, price = 0, modelyear = 0, engineCapacity = 0;
                    bool isMyInt = int.TryParse(inputMY, out modelyear);
                    bool isEcInt = int.TryParse(inputEC, out engineCapacity);
                    bool isPriceInt = int.TryParse(inputPrice, out price);
                    bool isShowInt = int.TryParse(ShowInput, out showId);

                    var showEntity = context.Showrooms.FirstOrDefault(item => item.ShowroomId == showId);

                    if (inputMake == "" || inputModel == "" || isShowInt == false || isMyInt == false || isEcInt == false || isPriceInt == false || showEntity == null)
                    {
                        string message = "You are supposed to input true data!";
                        string title = "Error!";
                        MessageBox.Show(message, title);
                        return;
                    }

                    entity.Make = inputMake;
                    entity.Model = inputModel;
                    entity.ModelYear = modelyear;
                    entity.EngineCapacity = engineCapacity;
                    entity.Price = price;
                    entity.ShowId = showId;

                    context.SaveChanges();
                    updateBtn_Click(sender, e);
                }

                else
                {
                    MessageBox.Show("Input true id value!");
                }
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
                Car cars = new Car() { Id = id };
                using (context)
                {
                    context.Entry(cars).State = EntityState.Deleted;
                    context.SaveChanges();

                    updateBtn_Click(sender, e);
                }
            }

            else
            {
                MessageBox.Show("Input true id value!");
            }
        }

        private void addCarBtn_Click(object sender, RoutedEventArgs e)
        {
            CarsDbContext context = new CarsDbContext();

            string inputMake, inputModel, inputMY, inputEC, inputPrice;
            Title = "Data";

            inputMake = Interaction.InputBox("Input Make", Title, "Make", 500, 300);
            inputModel = Interaction.InputBox("Input Model", Title, "Model", 500, 300);
            inputMY = Interaction.InputBox("Input Model Year", Title, "Model Year", 500, 300);
            inputEC = Interaction.InputBox("Input Engine Capacity", Title, "Engine Capacity", 500, 300);
            inputPrice = Interaction.InputBox("Input Price", Title, "Price", 500, 300);
            var ShowInput = Interaction.InputBox("Input Showroom ID", Title, "0", 500, 300);

            int showId = 0, price = 0, modelyear = 0, engineCapacity = 0;
            bool isMyInt = int.TryParse(inputMY, out modelyear);
            bool isEcInt = int.TryParse(inputEC, out engineCapacity);
            bool isPriceInt = int.TryParse(inputPrice, out price);
            bool isShowInt = int.TryParse(ShowInput, out showId);

            using (context)
            {
                var entity = context.Showrooms.FirstOrDefault(item => item.ShowroomId == showId);

                if (isShowInt && isEcInt && isMyInt && isPriceInt && entity != null)
                {
                    var car = new Car { Make = inputMake, Model = inputModel, ModelYear = modelyear, EngineCapacity = engineCapacity, Price = price, ShowId = showId };

                    context.Add(car);
                    context.SaveChanges();

                    updateBtn_Click(sender, e);
                }

                else
                {
                    MessageBox.Show("Input true id value!");
                }
            }
        }

        private void showroomListBtn_Click(object sender, RoutedEventArgs e)
        {
            var showroomWin = new Window1();
            showroomWin.Show();
        }
    }
}

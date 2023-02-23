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
                    inputModel = Interaction.InputBox("Input Description", Title, "Model", 500, 300);
                    var DepartmentInput = Interaction.InputBox("Input Department ID", Title, "0", 500, 300);

                    int showId = 0;
                    bool isShowInt = int.TryParse(DepartmentInput, out showId);

                    var departEntity = context.Showrooms.FirstOrDefault(item => item.ShowroomId == showId);

                    if (inputName == "" || inputDesc == "" || departEntity == null)
                    {
                        string message = "You are supposed to input true data!";
                        string title = "Error!";
                        MessageBox.Show(message, title);
                        return;
                    }

                    entity.Name = inputName;
                    entity.Description = inputDesc;
                    entity.DepartmentId = departId;

                    context.SaveChanges();
                    Button_Click(sender, e);
                }

                else
                {
                    MessageBox.Show("Input true id value!");
                }
            }
        }
    }
}

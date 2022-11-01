using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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


namespace weatherProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<WeatherOfTheDay> WeatherOfTheDayList = new List<WeatherOfTheDay>();
        public MainWindow()
        {
            InitializeComponent();
            VindStatus.Items.Add("Blåsigt");
            VindStatus.Items.Add("Vindstilla");
            VindStatus.Items.Add("Stillsam bris");
            VäderStatus.Items.Add("Soligt");
            VäderStatus.Items.Add("Molnigt");
            VäderStatus.Items.Add("Regn");

        }

        private void VindStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Utskrift.Items.Clear();
            WeatherOfTheDayList.Add(new WeatherOfTheDay(VäderStatus.SelectedItem.ToString(), VindStatus.SelectedItem.ToString(), Int32.Parse(temperatur.Text)));

           
                Utskrift.Items.Add($"{WeatherOfTheDayList[WeatherOfTheDayList.Count-1].Sun}\n{WeatherOfTheDayList[WeatherOfTheDayList.Count - 1].Temp} grader\n{WeatherOfTheDayList[WeatherOfTheDayList.Count - 1].Windy}");
                
          
            VäderStatus.SelectedItem = null;
            temperatur.Text = "";
            VindStatus.SelectedItem = null;
            

        }

        private void Spara_Click(object sender, RoutedEventArgs e)
        {
            Utskrift.Items.Clear();
            string fileName = "Weather.json";
            string jsonString = JsonSerializer.Serialize(WeatherOfTheDayList);
            File.WriteAllText(fileName, jsonString);

            MessageBox.Show($"Sparad!");
            
        }

        private void hämtaData_Click(object sender, RoutedEventArgs e)
        {
            ListOfData.Items.Clear();
            string fileName = "Weather.json";
            string jsonString = File.ReadAllText(fileName);
            List<WeatherOfTheDay> temporary = JsonSerializer.Deserialize<List<WeatherOfTheDay>>(jsonString)!;

            WeatherOfTheDayList = temporary;

            foreach (WeatherOfTheDay väder in WeatherOfTheDayList)
            {
                ListOfData.Items.Add($"{väder.Sun}\n{väder.Temp} grader\n{väder.Windy}");

            }
        }
    }
}

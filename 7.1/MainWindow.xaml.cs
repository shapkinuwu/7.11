using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _7._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer timer; // Объявление таймера

       
        /// <summary>
        /// Метод  btnAdd_Click() для занесения рецепта в книгу.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Add.Text) && !lstElem.Items.Contains(Add.Text))
            {
                if (MessageBox.Show("Вы действительно хотите добавить рецепт? ", "Добавление в список", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    lstElem.Items.Add(Add.Text);
                    Add.Clear();
                   
                }
                timer = new Timer();
                timer.Interval = 6000; // Устанавливаем интервал срабатывания таймера (в миллисекундах)
                timer.Elapsed += Timer_Elapsed; // Добавляем обработчик события срабатывания таймера
                timer.Start(); // Запускаем таймер
                

            }
            else MessageBox.Show("Строка не может быть пустой", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }


        /// <summary>
        /// Метод  Timer_Elapsed() для обозначения срабатывания таймера.
        /// </summary>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show("Рецепт оказался опасным для жизни", "Сообщение"); // Выводим сообщение при срабатывании таймера
                Uri uri = new Uri(@".\Sound\jutkii-smeh-odinochnyii-mujskoi-zalivnoi-rezkii.wav");
                var player = new MediaPlayer();
                player.Open(uri);
                player.Play();
            });
        }


        /// <summary>
        /// Метод  Выход_Click() для закрытия приложения.
        /// </summary>
        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lstElem.Items.Clear();
        }
    }
}

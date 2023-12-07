using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PhoneBook_Galkin
{
     /// <summary>
     /// Логика взаимодействия для MainWindow.xaml
     /// </summary>
     public partial class MainWindow : Window
	{
          public static Connection connect;
          public static Pages.Main.main;
        public MainWindow()
          {
               InitializeComponent();
               connect = new Connection();
               connect.LoadData(Connections.tabels.users);
               connect.LoadData(Connection.tabels.calls);
               main = new Pages.Main();
               OpenPageMain();
          }

          public void OpenPageMain()
          {
               DoubleAnimation opgridAnimation = new DoubleAnimation();
               opgridAnimation.From = 1;
               opgridAnimation.To = 0;
               opgridAnimation.Duration = TimeSpan.FromSeconds(0.6);
               opgridAnimation.Completed += delegate
               {
                    frame.Navigate(main);
                    opgridAnimation.From = 0;
                    opgridAnimation.To = 1;
                    opgridAnimation.Duration = TimeSpan.FromSeconds(1.2);

                    frame.BeginAnimation(Frame.OpacityMaskProperty, opgridAnimation);
               };
               frame.BeginAnimation(Frame.OpacityMaskProperty, opgridAnimation);
          }
     }
}

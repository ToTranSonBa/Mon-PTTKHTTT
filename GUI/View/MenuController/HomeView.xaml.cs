using System;
using System.Collections.Generic;
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
using System.IO;
using System.Reflection;
using DTO;

namespace GUI.View.MenuController
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private string baseDir;
        private int index = 0;
        
        public HomeView()
        {
           
            InitializeComponent();
            //lấy ra đường dẫn tương đối


            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string guiPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(baseDir))));

            string finalImagePath = System.IO.Path.Combine(guiPath, "Res", "Home0.png");

            ImageBrush enabledBackground = new ImageBrush(new BitmapImage(new Uri(finalImagePath)));

            this.Background = enabledBackground;

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }
        #region method
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                index++;
                if (index > 3)
                    index = 0;

                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string guiPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(baseDir))));

                string finalImagePath = System.IO.Path.Combine(guiPath, "Res", "Home" + index.ToString() + ".png");

                ImageBrush enabledBackground = new ImageBrush(new BitmapImage(new Uri(finalImagePath)));

                this.Background = enabledBackground;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail!");
            }

        }
        #endregion

        #region event
        private void right_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                index++;
                if (index > 3)
                    index = 0;
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string guiPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(baseDir))));

                string finalImagePath = System.IO.Path.Combine(guiPath, "Res", "Home" + index.ToString() + ".png");

                ImageBrush enabledBackground = new ImageBrush(new BitmapImage(new Uri(finalImagePath)));

                this.Background = enabledBackground;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail!");
            }

        }

        private void left_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                index--;
                if (index < 0)
                    index = 3;
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string guiPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(baseDir))));

                string finalImagePath = System.IO.Path.Combine(guiPath, "Res", "Home" + index.ToString() + ".png");

                ImageBrush enabledBackground = new ImageBrush(new BitmapImage(new Uri(finalImagePath)));

                this.Background = enabledBackground;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail!");
            }

        }

        
        #endregion
    }
}

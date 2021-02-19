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
using System.Threading;
using System.Windows.Threading;

namespace Terningekast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public byte score = 0;
        public int placeholder = 0;
        public int terning = 0;
        public byte liv = 3;
        public int caseSwitch = 0;
        public char point = '۞';

        public byte runterILive = 0;

        public double starttid = 0;
        
        public DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            //terningside.Source = new BitmapImage(new Uri(@"C:\Users\jona444j\Documents\Code\Projecter\Terningekast\test\reddice.jpg"));
            over_button.Background = Brushes.Green;
            under_button.Background = Brushes.Red;
            Random rand = new Random();
            terning = rand.Next(1, 7);
            MessageBox.Show(
            "Du har 3 sekunder til at gætte hvad terningen lander på.\n"+
            "Hvis du ikke når det, mister du et liv.\n"+
            "Hvis du gætter forkert, mister du et liv.\n"+
            "Hvis du gætter rigtigt får du et point.\n"+
            "Få flest point.");
            skift();
        }
        /*
        public void start_enter(object sender, EventArgs e){
            while(ButtonMouseOver){
                starttid-=0.001;
                start.Content=starttid;
                if (starttid==0) {
                    skift();
                    break;
                }
                delay(1);
            }
            
        }
        public void start_leave(object sender, MouseEventArgs e) {
            starttid=1;
            start.Content="Hold musen her i et sekund.";
        }*/

        public void skift(){
            
            placeholder = terning;
            // terningview.Text = placeholder.ToString();

            switch(placeholder){
                case 1:
                    terningside.Source = new BitmapImage(new Uri(@"C:\Users\jona444j\Documents\Code\Projecter\Terningekast\images\6 sides\Alea_1.png"));
                    break;
                case 2:
                    terningside.Source = new BitmapImage(new Uri(@"C:\Users\jona444j\Documents\Code\Projecter\Terningekast\images\6 sides\Alea_2.png"));
                    break;
                case 3:
                    terningside.Source = new BitmapImage(new Uri(@"C:\Users\jona444j\Documents\Code\Projecter\Terningekast\images\6 sides\Alea_3.png"));
                    break;
                case 4:
                    terningside.Source = new BitmapImage(new Uri(@"C:\Users\jona444j\Documents\Code\Projecter\Terningekast\images\6 sides\Alea_4.png"));
                    break;
                case 5:
                    terningside.Source = new BitmapImage(new Uri(@"C:\Users\jona444j\Documents\Code\Projecter\Terningekast\images\6 sides\Alea_5.png"));
                    break;
                case 6:
                    terningside.Source = new BitmapImage(new Uri(@"C:\Users\jona444j\Documents\Code\Projecter\Terningekast\images\6 sides\Alea_6.png"));
                    break;
                }
            timer.Stop();
            timer.Tick -= TimerTick;
            StartDeathTimer();
            
            
            //delay(3000);
            //stop_spillet();
        }

        public void over_button_click(object sender, RoutedEventArgs e){

            Random rand = new Random();
            terning = rand.Next(1, 7);

            if (placeholder <= terning){
                score += 1;
                runterILive+=1;
                if(score<=10) {
                    scoreview.Text += point;
                }
                else if(score>10){
                    scoreview.Text = score.ToString();
                }
                //if(3%runterILive==0){
                //Fire();
                //}

                hele.Background=Brushes.Gold;
                //delay(500);
                skift();
            }
            else {
                skift();
                stop_spillet();
            }
            
        }

        public void under_button_click(object sender, RoutedEventArgs e){

            Random rand = new Random();
            terning = rand.Next(1, 7);

            if (placeholder >= terning){
                score += 1;
                runterILive+=1;
                
                if(score<=10) {
                    scoreview.Text += point;
                }
                else if(score>10){
                    scoreview.Text = score.ToString();
                }
                //if(3%runterILive==0){
                
                //}
                hele.Background=Brushes.Gold;
                //delay(500);
                //scoreview.Text = score.ToString();
                
                skift();
            }
            else {
                skift();
                stop_spillet();
            }
            
        }

        public void stop_spillet(){
            runterILive = 0;
            if (liv==1){
                timer.Stop();
                timer.Tick -= TimerTick;
                // livview.Text = "0";
                liv1.Source=null;
                hele.Background=Brushes.DarkGray;
                MessageBox.Show($"Desværre - du mistede alle dine liv. Din score blev: "+score);
                under_button.IsEnabled = false;
                over_button.IsEnabled = false;
                System.Environment.Exit(1);
            }
            else {
                liv -= 1;
                // hele.Background=Brushes.Cornsilk;
                if (liv == 2) {
                    //livview.Foreground=Brushes.OrangeRed;
                    hele.Background=Brushes.Tomato;
                    liv3.Source=null;
                }
                else if (liv == 1){
                    hele.Background=Brushes.DarkRed;
                    liv2.Source=null;
                    //livview.Foreground=Brushes.Red;
                }
                /*
                hele.Background=Brushes.Red;

                System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();  
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Start();  

                System.Threading.Thread.Sleep(1000);
                hele.Background=Brushes.Cornsilk;
                */
                
                //livview.Text = liv.ToString();
                
                
                
            }
            
        }

        /*private void delay(double ms)
        {
            DateTime dt = DateTime.Now.AddMilliseconds(ms);
            while (DateTime.Now <= dt)
            {
                ;
            }
        }*/
         

        public void StartDeathTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(3d);
            timer.Tick += TimerTick;
            timer.Start();
        }

        /*
        public void Fire()
        {

            fire.Visibility = Visibility.Visible;
            fire.Foreground=Brushes.Purple;
            Thread.Sleep(250);
            fire.Foreground=Brushes.LightYellow;
            Thread.Sleep(250);
            fire.Foreground=Brushes.Blue;
            Thread.Sleep(250);
            fire.Foreground=Brushes.Brown;
            Thread.Sleep(250);
            fire.Visibility = Visibility.Hidden;
        }
        */
        public void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            stop_spillet();
        }

        /*
        private void tid(double ms)
        {
            DateTime dt = DateTime.Now.AddMilliseconds(ms);
            while ()
            {
                if (over_button_click()){
                    break;
                }
                else{
                    
                }
            }

            stop_spillet();

        }  */
        
        //private void pointanimation(){}
        
        




        //public void billeder(EventArgs e) {
            //string billede= "";
            //var terningnummer = combo.SelectedIndex;
            //byte terningnummer1 = Convert.ToByte(terningnummer.ToString());
            //byte terningnummer = Convert.ToByte(combo.SelectedValue.ToString());
            
            
            //string boyo = "";
            //boyo = Convert.ToString(terningnummer);
            //File.WriteAllText(@"test\text.txt", "boyo"); 
            // test.Text= $"{boyo}";
            
            /*
            switch(terningnummer1){
                case 0:
                    billede.Source = new BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/commons/2/25/Tetrahedron.png"));
                    break;

                case 1:
                    billede.Source = new BitmapImage(new Uri("https://www.creativefabrica.com/wp-content/uploads/2019/07/Pair-of-dice-580x386.jpg"));
                    break;
            }
            */
        //}

    }
}

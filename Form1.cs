using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace Spel_3_Whack_A_Mole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            





        }
        public class JsonScore
        {
            public string Date { get; set; }
            public int score { get; set; }
            public int miss { get; set; }
        }

        public int iCorrectMole;
        public int iScore;
        public int iAttempts;
        public int iIntervalTimer = 5000;
        public int iMisKlik;
        public Boolean isProgramRunning;

        public void RandomMole()
        {
            Random rand = new Random();
            PictureBox[] pb_Array = new PictureBox[7];
            pb_Array[0] = pb_Mole1;
            pb_Array[1] = pb_Mole2;
            pb_Array[2] = pb_Mole3;
            pb_Array[3] = pb_Mole4;
            pb_Array[4] = pb_Mole5;
            pb_Array[5] = pb_Mole6;
            pb_Array[6] = pb_Mole7;

            foreach(var Element in pb_Array)
            {
                //Element.Enabled = false; Niet nodig aangezien als we dit aanzetten, we niet meer de miskliks kunnen toetsen
                Element.Visible = false;
                Element.Image = Properties.Resources.alive;
            }

            int iRandomNum = rand.Next(0, 7);
            iCorrectMole = iRandomNum;
            pb_Array[iRandomNum].Enabled = true;
            pb_Array[iRandomNum].Visible = true;
            txt_HitScore.Text = iScore.ToString();
            txt_MisKlik.Text = iMisKlik.ToString();
            Console.WriteLine(iCorrectMole);


        }

        

        private async void pb_Mole2_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Correct num: {iCorrectMole}, clicked num: 2, correct? {iCorrectMole == 1}");
            if (iCorrectMole == 1)
            {
                iScore++;




                pb_Mole2.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                iIntervalTimer -= 50;
                timer1.Interval = iIntervalTimer;
            } else
            {
                iMisKlik++;
            }
           
        }

        private async void pb_Mole1_Click(object sender, EventArgs e)
        {
            if (iCorrectMole == 0)
            {
                iScore++;




                pb_Mole1.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                iIntervalTimer -= 50;
                timer1.Interval = iIntervalTimer;
            }
            else
            {
                iMisKlik++;
            }
        }

        private async void pb_Mole7_Click(object sender, EventArgs e)
        {
            if (iCorrectMole == 6)
            {
                iScore++;




                pb_Mole7.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                iIntervalTimer -= 50;
                timer1.Interval = iIntervalTimer;
            }
            else
            {
                iMisKlik++;
            }
        }

        private async void pb_Mole3_Click(object sender, EventArgs e)
        {
            if (iCorrectMole == 2)
            {
                iScore++;




                pb_Mole3.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                iIntervalTimer -= 50;
                timer1.Interval = iIntervalTimer;
            }
            else
            {
                iMisKlik++;
            }
        }

        private async void pb_Mole4_Click(object sender, EventArgs e)
        {
            if (iCorrectMole == 3)
            {
                iScore++;




                pb_Mole4.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                iIntervalTimer -= 50;
                timer1.Interval = iIntervalTimer;
            }
            else
            {
                iMisKlik++;
            }
        }

        private async void pb_Mole6_Click(object sender, EventArgs e)
        {
            if (iCorrectMole == 5)
            {
                iScore++;




                pb_Mole6.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                iIntervalTimer -= 50;
                timer1.Interval = iIntervalTimer;
            }
            else
            {
                iMisKlik++;
            }
        }

        private async void pb_Mole5_Click(object sender, EventArgs e)
        {
            if (iCorrectMole == 4)
            {
                iScore++;




                pb_Mole5.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                iIntervalTimer -= 50;
                timer1.Interval = iIntervalTimer;
            }
            else
            {
                iMisKlik++;
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor cur = new Cursor(Properties.Resources.cursor.Handle);
            this.Cursor = cur;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RandomMole();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            isProgramRunning = true;

        }
        

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (isProgramRunning)
            {
                iMisKlik++;
                txt_MisKlik.Text = iMisKlik.ToString();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var JsonScore = new JsonScore
            {
                Date = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss"),
                score = iScore,
                miss = iMisKlik
            };

            string fileName = @"C:\\Users\\Nawid\\AppData\\Local\\WeatherForecast.json";
            string jsonString = JsonSerializer.Serialize(JsonScore);
            System.IO.File.WriteAllText(fileName, jsonString);
            Console.WriteLine(File.ReadAllText(fileName));


        }
    }
}
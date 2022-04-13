using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Media;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows;


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
        PictureBox[] pb_Array = new PictureBox[7];
        SoundPlayer HitSound = new SoundPlayer(Properties.Resources.hit_sound);
        SoundPlayer MissSound = new SoundPlayer(Properties.Resources.miss_sound);
        System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.background_music);
        



        public void RandomMole()
        {
            
            Random rand = new Random();
            
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

        public void DisableMoles()
        {

            foreach (var Element in pb_Array)
            {
                //Element.Enabled = false; Niet nodig aangezien als we dit aanzetten, we niet meer de miskliks kunnen toetsen
                Element.Visible = false;
                Element.Image = Properties.Resources.alive;
            }
        }

        

        private async void pb_Mole2_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Correct num: {iCorrectMole}, clicked num: 2, correct? {iCorrectMole == 1}");
            if (iCorrectMole == 1)
            {
                iScore++;
                HitSound.Play();




                pb_Mole2.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                UpdateGameTimer();
                await Task.Delay(200);
                sp.Play();
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
                HitSound.Play();




                pb_Mole1.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                UpdateGameTimer();
                await Task.Delay(200);
                sp.Play();
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
                HitSound.Play();



                
                pb_Mole7.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                UpdateGameTimer();
                await Task.Delay(200);
                sp.Play();
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
                HitSound.Play();



               
                pb_Mole3.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                UpdateGameTimer();
                await Task.Delay(200);
                sp.Play();
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
                HitSound.Play();


                
                pb_Mole4.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                UpdateGameTimer();
                await Task.Delay(200);
                sp.Play();
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
                HitSound.Play();


                
                pb_Mole6.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                UpdateGameTimer();
                await Task.Delay(200);
                sp.Play();
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
                HitSound.Play();


                
                pb_Mole5.Image = Properties.Resources.dead;
                Console.WriteLine("Suspending thread");
                await Task.Delay(500);
                Console.WriteLine("Continuing thread");

                RandomMole();
                UpdateGameTimer();
                await Task.Delay(200);
                sp.Play();
            }
            else
            {
                iMisKlik++;
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welkom bij onze versie van Whack-A-Mole, in deze game is nauwkeurigheid en snelheid belangrijk. Het werkt alsvolgt: Als jij op de start knop klinkt dan gaan er om de 5 seconden mollen verschijnen, het is aan jou de taak om deze te slaan met je hamer. Om de 5 punten gaat het 1 seconde sneller. Raak je mis? dan gaat er een punt af, 3 miskliks = game over");

            Cursor cur = new Cursor(Properties.Resources.cursor.Handle);
            this.Cursor = cur;
            
        }

        public void UpdateGameTimer()
        {
            if(iScore == 5 || iScore == 10 || iScore == 15 || iScore == 20 || iScore == 25)
            {
                iIntervalTimer -= 1000;
                timer1.Interval = iIntervalTimer;
            } else if (iScore == 30)
            {
                timer1.Stop();
                MessageBox.Show("Gefeliciteerd, je hebt de maximale haalbare score gehaald!");
                Environment.Exit(0);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if(iMisKlik >= 3)
            {
                DisableMoles();
                this.BackgroundImage = Properties.Resources.Game_over;
                timer1.Enabled = false;
                timer1.Stop();
                isProgramRunning = false;
                sp.Stop();
            } else
            {
                RandomMole();
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            isProgramRunning = true;








        }
        

        private async void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (isProgramRunning)
            {
                MissSound.Play();
                iMisKlik++;
                txt_MisKlik.Text = iMisKlik.ToString();
                await Task.Delay(700);
                sp.Play();
            }
        }

        public class highScore

        {

            public string Date { get; set; }

            public int Score { get; set; }

            public int Misklik { get; set; }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = Path.Combine(appdata, "scores-game.json");
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            
            var saveScore = JsonConvert.DeserializeObject<List<highScore>>(jsonData)
                                  ?? new List<highScore>();

            
            saveScore.Add(new highScore()
            {
                Date = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss"),
                Score = iScore,
                Misklik = iMisKlik


            });


            
            jsonData = JsonConvert.SerializeObject(saveScore);
            System.IO.File.WriteAllText(filePath, jsonData);




        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
/*  (above line) enables to play different sound(s)*/
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piano2
{
    /*  note, this is the Form1*/
    public partial class PianoForm : Form
    {

        #region Variables & Arrays

        /*variables & arrays*/
        string beforeWave;
        string soundSpath = @"C:\Users\emana\GodPiano\Piano2\Piano2\bin\Debug\Notes-Sound files\mapped\";
        double count = 0;
        private SoundPlayer sp;
        private Timer timer1;
        private Stopwatch stopWatch;
        List<MusicNote> MusicNoteObejectsCollection = new List<MusicNote>();//to store music notes
        int xLoc = 100;
        int yLoc = 200;

        int iXloc = 40, iYloc = 10;



        int[] whitePitch = {1,3,5,6,8,10,12,13,15,17,18,20,22,24,25};
        //int[] whitePitch = {10,30,50,60,80,100,120,130,150,170,180,200,220,240};
        int[] blackPitch = {2,4,7,9,11,14,16,19,21,23};
        //int[] xPos= {100,300,700,900,1100,1500,1700,2100,2300,2500};
        int[] xPos= {10,30,70,90,110,150,170,210,230,250};
        private Panel panel1= new Panel();
        public Panel panel2= new Panel();


        #endregion  

        /*  this is the constructor of the "Form1"/PianoForm*/
        public PianoForm()
        {
            InitializeComponent();    
        }

        #region DrawPianoButtons() (we dont use it)
        private void DrawPianoButtons()
        {
            Muskey mk;
            BlackMuskey bmk;
            /*  draw the white buttons*/
            for (int k = 0; k < 7; k++)
            {
                int pitch = whitePitch[k];
                int xPos = k * 20;
                mk = new Muskey(pitch,xPos,50);
                mk.MouseDown += new MouseEventHandler(this.button1_MouseDown);
                mk.MouseDown += new MouseEventHandler(this.button1_MouseUp);
                this.panel1.Controls.Add(mk);
            }
            int Offs = 20;
            for (int k = 0; k < 5; k++)
            {
                int pitch = blackPitch[k];
                /*  note here we are using xPoss unlike in notes (xPos)*/
                int xPoss = xPos[k];
                bmk = new BlackMuskey(pitch,xPoss,50);
                /*  note here we use bmk unlike in the notes*/
                bmk.MouseDown += new MouseEventHandler(this.button1_MouseDown);
                bmk.MouseDown += new MouseEventHandler(this.button1_MouseUp);
                this.panel1.Controls.Add(bmk);
                //this.panel1.Controls[this.panel1.Controls.Count-1].BringToFront();
                this.Controls[this.panel1.Controls.Count-1].BringToFront();
            }
        }
        #endregion  



        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
           
            stopWatch.Stop();
            count = stopWatch.ElapsedMilliseconds;
            foreach (Muskey mk in this.panel1.Controls)
            {
                if (sender==mk)
                {
                    if (e.Button==MouseButtons.Left)
                    {
                        //timer1.Stop();
                        //timer1.Enabled = false;
                        string bNoteShape = null;//note this is the name of the file.
                        int duration = 0;
                        //sp.Stop();
                        bool flip = false;
                        bool isBlack = false;
                        
                        //work on this and create the noteshape.

                        if (returnTicker(count) <= 1) {
                            bNoteShape = "SemiQuaver";
                            duration = 1;
                            
                        }                            
                        else if (returnTicker(count) == 2) {
                            bNoteShape = "Quaver";
                            duration = 2;
                        }
                        else if (returnTicker(count)>=3 && returnTicker(count)<=5)
                        {
                            bNoteShape = "Crotchet";
                            duration = 4;
                        }
                        else if (returnTicker(count) >= 6 && returnTicker(count) <= 10)
                        {
                            bNoteShape = "minim";
                            duration = 10;
                        }
                        else if (returnTicker(count) >= 11 && returnTicker(count) <= 15)
                        {
                            bNoteShape = "DotMinim";
                            duration = 14;
                        }
                        else
                        {
                            bNoteShape = "SemiBreve";
                            duration = 18;
                        }

                        #region Assigning note
                        int z = mk.notePitch;

                        //to check black: 2,4,7,9,11,14,16,19,21,23
                        if (z == 2 || z == 4 || z == 7 || z == 9 || z == 11 || z == 14 || z == 16 || z == 19 || z == 21 || z == 23)
                            isBlack = true;

                        
                        //assigning location
                        if (z == 1)
                        { iYloc = 120; flip = false; }
                        if (z == 2)
                        { iYloc = 115; flip = false; }
                        if (z == 3)
                        { iYloc = 110; flip = false; }
                        if (z == 4)
                        { iYloc = 105; flip = false; }
                        if (z == 5)
                        { iYloc = 100; flip = false; }
                        if (z == 6)
                        { iYloc = 95; flip = false; }
                        if (z == 7)
                        { iYloc = 90; flip = false; }
                        if (z == 8)
                        { iYloc = 85; flip = false; }
                        if (z == 9)
                        { iYloc = 80; flip = false; }
                        if (z == 10)
                        { iYloc = 75; flip = false; }
                        if (z == 11)
                        { iYloc = 70; flip = false; }
                        if (z == 12)
                        { iYloc = 65; flip = false; }
                        if (z == 13)
                        { iYloc = 60; flip = true; }
                        if (z == 14)
                        { iYloc = 55; flip = true; }
                        if (z == 15)
                        { iYloc = 50; flip = true; }
                        if (z == 16)
                        { iYloc = 45; flip = true; }
                        if (z == 17)
                        { iYloc = 40; flip = true; }
                        if (z == 18)
                        { iYloc = 35; flip = true; }
                        if (z == 19)
                        { iYloc = 30; flip = true; }
                        if (z == 20)
                        { iYloc = 25; flip = true; }
                        if (z == 21)
                        { iYloc = 20; flip = true; }
                        if (z == 22)
                        { iYloc = 15; flip = true; }
                        if (z == 23)
                        { iYloc = 10; flip = true; }
                        if (z == 24)
                        { iYloc = 5; flip = true; }
                        if (z == 25)
                        { iYloc = 0; flip = true; }
                        #endregion

                        MusicNote mn = new MusicNote(mk.notePitch, duration, bNoteShape, flip, isBlack);
                        MusicNoteObejectsCollection.Add(mn);
                        mn.Location = new Point(iXloc, iYloc);
                        this.panel2.Controls.Add(mn);
                        iXloc += 25;
                    }
                }
            }
            //throw new NotImplementedException();
        }

        private int returnTicker(double counter)
        {
            int tickCount = 0;
            if (counter%63!=0)
                return  tickCount = Convert.ToInt32(Math.Floor(counter / 63));
            else
                return tickCount = Convert.ToInt32(counter / 63);

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
            //timer1 = new Timer();
            //((sender as Button).Tag as Stopwatch).Start();
            sp = new SoundPlayer();

            foreach (Muskey mk in this.panel1.Controls)
            {
                if (sender == mk) // if this is true for a specific key that is pressed on the musik keyboard
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        //timer1.Enabled = true;
                        //count = 0.0;
                        //timer1.Tick += new EventHandler(this.timer1_Tick);
                        //timer1.Start();

                        sp.SoundLocation =soundSpath + mk.notePitch.ToString() + ".wav";
                        //i think we need to specify the duration 
                        sp.Play();
                   
                    }
                }
            }
            
        }

        private void PianoForm_Load(object sender, EventArgs e)
        {
            //adding panel1 ~ the buttons
            this.panel1.Location = new Point(xLoc,yLoc+50);
            //this.panel1.BackColor = Color.Azure;
            this.panel1.Size = new Size(600,200);
            this.Controls.Add(panel1);
            //adding the panel2 ~ the music lines.
            this.panel2.Location = new Point(xLoc, 60);
            
            this.panel2.BackgroundImage = Image.FromFile(@"C:\Users\emana\GodPiano\GodPiano2\Piano2\Piano2\bin\Debug\Notes-Images\MusicLines.png");
            this.panel2.BackColor = Color.Transparent;
            this.panel2.Size = new Size(669, 192);
            this.Controls.Add(panel2);
            


            Muskey mk;
            BlackMuskey bmk;
            
            /*  draw the white buttons*/

            for (int k = 0; k < whitePitch.Length; k++)
            {
                int pitch = whitePitch[k];
                int xPos = k * 40;//xPosition?
                mk = new Muskey(pitch, xPos, 10);
                mk.Tag = new Stopwatch();
                mk.MouseDown += new MouseEventHandler(this.button1_MouseDown);                
                mk.MouseUp += new MouseEventHandler(this.button1_MouseUp);
                this.panel1.Controls.Add(mk);
                
            }
            int Offs = 20;
            for (int k = 0; k < blackPitch.Length; k++)
            {
                int pitch = blackPitch[k];
                /*  note here we are using xPoss unlike in notes (xPos)*/
                int xP = xPos[k]*2;
                bmk = new BlackMuskey(pitch, xP, 10);
                bmk.Tag = new Stopwatch();
                bmk.MouseDown += new MouseEventHandler(this.button1_MouseDown);
                bmk.MouseUp += new MouseEventHandler(this.button1_MouseUp);
                this.panel1.Controls.Add(bmk);
                this.panel1.Controls[this.panel1.Controls.Count-1].BringToFront();
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
        }

        public void MusicNote_Click(object sender, MouseEventArgs e)
        {
            /*note panel2 is the holder of the music stuff.*/
            foreach (MusicNote mn in this.panel2.Controls)
            {
                /*  if this condition is true for a specific note checked on  music stuff*/
                if (sender == mn)
                {
                    timer1.Enabled = true; /*   this is the variable of timpe component*/
                    count = 0;
                    SoundPlayer sp = new SoundPlayer();
                   // sp.SoundLocation( mk.notePitch.toString()+".wav");
                    while (count <= mn.noteDuration)
                    {
                        sp.Play();
                    }
                    timer1.Enabled = false;
                    sp.Stop();
                }
            }
        }
    }
}
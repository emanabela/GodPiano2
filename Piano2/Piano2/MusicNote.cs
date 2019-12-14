using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piano2
{
    class MusicNote : PictureBox
    {
        string soundSpath = @"C:\Users\emana\GodPiano\Piano2\Piano2\bin\Debug\Notes-Sound files\mapped\";
        public string path = @"C:\Users\emana\GodPiano\Piano2\Piano2\bin\Debug\Notes-Images\";
        public int pitch;
        private Stopwatch stopWatch;
        public string noteShape;
        public int noteDuration;
        public bool flip, isBlack;
        public double count = 0;
        public enum accidental
        {
            flat,
            sharp,
            sole
        }


        public bool isDragging = false; // this field show the begining & ending of dragging.
        /*  Constructor of the MusicNote*/
        public MusicNote(int iPitch, int iDuration, string iNoteShape, bool iFlip, bool iIsBlack) : base()
        {
            pitch = iPitch;
            noteShape = iNoteShape;
            noteDuration = iDuration;
            flip = iFlip;
            isBlack = iIsBlack;

            Location = new Point(100, 50);
            Size = new Size(25, 40);
            /*  geting the img of music note*/
            //Bitmap bmp = new Bitmap(@"C:\Users\emana\GodPiano\Piano2\Piano2\bin\Debug\Notes-Images\Quaver.png",true);
            if (iIsBlack == true)
            {
                Bitmap bmp = new Bitmap(path + "Black" + noteShape + ".bmp", true);
                //if (iFlip == true)
                //    bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Image = bmp;
            }
            else
            {
                Bitmap bmp = new Bitmap(path + noteShape + ".bmp", true);
                //if (iFlip == true)
                //    bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Image = bmp;
            }



            //BackColor = Color.Transparent;

            /*  Event registrations, the functions passed as parameters are defined bellow. */
            this.MouseDown += new MouseEventHandler(StartDrag);
            this.MouseUp += new MouseEventHandler(StopDrag);
            this.MouseMove += new MouseEventHandler(NoteDrag);
            this.MouseClick += new MouseEventHandler(NoteClick);
        }

        //i am not sure i couldl explain what this function does. is from notes.
        private void InitilaizeComponent()
        {
            this.BackColor = SystemColors.Control;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        #region Even Start,Stop and Note
        private void StartDrag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                //pitch = e.Y; //this is the current Y coordinate of mouse
                this.Location = new Point(this.Location.X, e.Y);
            }
            if(e.Button == MouseButtons.Right)
            {
                stopWatch = new Stopwatch();
                stopWatch.Start();
            }
        }
        private void StopDrag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                #region declare change of pitch

                if (this.Top >= 117)
                    pitch = 1;
                else if (this.Top >= 112)
                    pitch = 2;
                else if (this.Top >= 107)
                    pitch = 3;
                else if (this.Top >= 102)
                    pitch = 4;
                else if (this.Top >= 97)
                    pitch = 5;
                else if (this.Top >= 92)
                    pitch = 6;
                else if (this.Top >= 87)
                    pitch = 7;
                else if (this.Top >= 82)
                    pitch = 8;
                else if (this.Top >= 77)
                    pitch = 9;
                else if (this.Top >= 72)
                    pitch = 10;
                else if (this.Top >= 67)
                    pitch = 11;
                else if (this.Top >= 62)
                    pitch = 12;
                else if (this.Top >= 57)
                    pitch = 13;
                else if (this.Top >= 52)
                    pitch = 14;
                else if (this.Top >= 47)
                    pitch = 15;
                else if (this.Top >= 42)
                    pitch = 16;
                else if (this.Top >= 37)
                    pitch = 17;
                else if (this.Top >= 32)
                    pitch = 18;
                else if (this.Top >= 27)
                    pitch = 19;
                else if (this.Top >= 22)
                    pitch = 20;
                else if (this.Top >= 17)
                    pitch = 21;
                else if (this.Top >= 12)
                    pitch = 22;
                else if (this.Top >= 7)
                    pitch = 23;
                else if (this.Top >= 2)
                    pitch = 24;
                else if (this.Top >= -10)
                    pitch = 25;
                #endregion

                isDragging = false;

                int z = pitch;
                //to check black: 2,4,7,9,11,14,16,19,21,23
                if (z == 2 || z == 4 || z == 7 || z == 9 || z == 11 || z == 14 || z == 16 || z == 19 || z == 21 || z == 23)
                    isBlack = true;
                else
                    isBlack = false;

                if (isBlack == true)
                {
                    Bitmap bmp = new Bitmap(path + "Black" + noteShape + ".bmp", true);
                    //if (iFlip == true)
                    //    bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    Image = bmp;
                }
                else
                {
                    Bitmap bmp = new Bitmap(path + noteShape + ".bmp", true);
                    //if (iFlip == true)
                    //    bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    Image = bmp;
                }
            }
            if(e.Button == MouseButtons.Right)
            {
                stopWatch.Stop();

                //timer1.Stop();
                //timer1.Enabled = false;
                string bNoteShape = null;//note this is the name of the file.
                int duration = 0;
                //sp.Stop();
                bool flip = false;
                bool isBlack = false;
                count = stopWatch.ElapsedMilliseconds;
                //work on this and create the noteshape.

                if (returnTicker(count) <= 1)
                {
                    bNoteShape = "SemiQuaver";
                    duration = 1;
                }
                else if (returnTicker(count) == 2)
                {
                    bNoteShape = "Quaver";
                    duration = 2;
                }
                else if (returnTicker(count) >= 3 && returnTicker(count) <= 5)
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

                if (this.isBlack == true)
                {
                    Bitmap bmp = new Bitmap(path + "Black" + bNoteShape + ".bmp", true);
                    Image = bmp;
                }
                else
                {
                    Bitmap newbmp = new Bitmap(path + bNoteShape + ".bmp", true);
                    this.Image = newbmp;
                }
                this.noteDuration = duration;
            }
        }
        private void NoteDrag(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                /*  Top property is the distance in pixels between the top edge of the component
                    and the top endge of its container.*/
                this.Top = this.Top + (e.Y - this.pitch); //this to move in vertical direction
            }
        }

        private void NoteClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle) // play the note
            {
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = soundSpath + this.pitch.ToString() + ".wav";
                sp.Play();
                Task.Delay(this.noteDuration*1000).ContinueWith(t => sp.Stop());
            }
        }
        #endregion

        /*this method is used to redrwaw automatically.*/
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        private int returnTicker(double counter)
        {
            int tickCount = 0;
            if (counter % 63 != 0)
                return tickCount = Convert.ToInt32(Math.Floor(counter / 63));
            else
                return tickCount = Convert.ToInt32(counter / 63);

        }

    }

}

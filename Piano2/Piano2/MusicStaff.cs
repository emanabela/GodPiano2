using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piano2
{
    public partial class MusicStaff : Panel
    {
        /*  ...when constructed in the main window it display itself as a rectangle of a fixed
            size with 5 lines of music staff. The lines are fixed-relative to the upper left corner
            of the panel*/

        #region Operations
        void PlayLB(List<MusicNote> MusicNoteObejectsCollection, int tempo)
        {


        }

        private void PlayAll()
        {
            ///playing all the music notes continuously when clicking on the Play button.
            ///i.e. plays the whole melody by traversing the collection of music notes
        }
        private void AdjustTempo()
        {
            ///adjust the overal tempo field (grave,largo,lento,adagio,andante,moderato,allegro,presto)
        }

        #endregion

    }
}

using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication2
{
    public partial class Renamer : Form
    {
        public Renamer()
        {
            InitializeComponent();
            CenterToScreen();
            Text = "üRenamer";
        }

        //________METODOS DE CLASE___________

        static void start(string carp, string nom, int numdig, int numini, string[] fich)
        {
            uRenamerCod uren = new uRenamerCod(carp, nom, numdig, numini);
            uren.RenombrarArchivos(fich);
        }

        static string[] ListaArchivos(string carp, string nom, int numdig, int numini)
        {
            uRenamerCod uren = new uRenamerCod(carp, nom, numdig, numini);
            return uren.MostrarArchivos();
        }

        static string[] vistaPrevia(string carp, string nom, int numdig, int numini, string[] fich)
        {
            uRenamerCod uren = new uRenamerCod(carp, nom, numdig, numini);
            return uren.MostrarPrevia(fich);
        }

        public void actualizarVP()
        {
            listBox2.Items.Clear();
            string carp = textBox1.Text;
            string nom = textBox2.Text;

            if (nom.Length == 0)
                nom = carp.Substring(carp.LastIndexOf("\\") + 1);

            string[] arch = new string[listBox1.Items.Count];
            listBox1.Items.CopyTo(arch, 0);

            string[] files = vistaPrevia(carp, nom, int.Parse(numericUpDown1.Value + ""), int.Parse(numericUpDown2.Value + ""), arch);

            foreach (string f in files)
                listBox2.Items.Add(f + "\r\n");
        }

        //________EVENTOS DE BOTONES___________

        private void Inicio_Click(object sender, EventArgs e) {
            if (!Directory.Exists(textBox1.Text))
                MessageBox.Show("El directorio especificado no existe");

            else {
                string carp = textBox1.Text;
                string nom = textBox2.Text.Length == 0 ? carp.Substring(carp.LastIndexOf("\\") + 1) : textBox2.Text;

                string[] arch = new string[listBox1.Items.Count];
                listBox1.Items.CopyTo(arch, 0);

                start(carp, nom, int.Parse(numericUpDown1.Value + ""), int.Parse(numericUpDown2.Value + ""), arch);

                string[] files = ListaArchivos(carp, nom, int.Parse(numericUpDown1.Value + ""), int.Parse(numericUpDown2.Value + ""));
                listBox1.Items.Clear();

                foreach (string f in files){
                    listBox1.Text += f;
                    listBox1.Items.Add(f);
                }

                actualizarVP();
            }
        }

        private void VistaPrevia_Click(object sender, EventArgs e){
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button2.Enabled = true;
            listBox2.Items.Clear();
            if (!Directory.Exists(textBox1.Text))
                MessageBox.Show("El directorio especificado no existe");
            
            else {
                string carp = textBox1.Text;
                string nom = textBox2.Text.Length == 0 ? carp.Substring(carp.LastIndexOf("\\") + 1) : textBox2.Text;

                string[] files = ListaArchivos(carp, nom, int.Parse(numericUpDown1.Value + ""), int.Parse(numericUpDown2.Value + ""));
                listBox1.Items.Clear();

                foreach (string f in files){
                    listBox1.Text += f;
                    listBox1.Items.Add(f);
                }
                actualizarVP();
            }
        }

        private void DirExplorer_Click(object sender, EventArgs e){
            folderBrowserDialog1.SelectedPath = textBox1.Text;
            FolderBrowserLauncher.ShowFolderBrowser(folderBrowserDialog1);
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }


        //________DESPLAZAMIENTO DE ITEMS___________

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e){
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            listBox2.ClearSelected();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e){
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            listBox1.ClearSelected();
        }

        private void Subir_Click(object sender, EventArgs e){
            List<object> itemsToMove = (from object item in listBox1.SelectedItems select item).ToList();
            int numItems = listBox1.Items.Count;

            for (int i = 0; i < itemsToMove.Count; i++){
                var selectedItem = itemsToMove[i];
                int oldIndex = listBox1.Items.IndexOf(selectedItem);
                int newIndex = oldIndex == 0 ? numItems - 1 : oldIndex - 1;

                listBox1.Items.Remove(selectedItem);
                listBox1.Items.Insert(newIndex, selectedItem);
                listBox1.SetSelected(newIndex, true);
            }
            actualizarVP();
        }

        private void Bajar_Click(object sender, EventArgs e){
            List<object> itemsToMove = (from object item in listBox1.SelectedItems select item).ToList();
            int numItems = listBox1.Items.Count;

            for (int i = itemsToMove.Count - 1; i >= 0; i--){
                var selectedItem = itemsToMove[i];
                int oldIndex = listBox1.Items.IndexOf(selectedItem);
                int newIndex = oldIndex == numItems - 1 ? 0 : oldIndex + 1;
                Console.Write("hola");

                listBox1.Items.Remove(selectedItem);
                listBox1.Items.Insert(newIndex, selectedItem);
                listBox1.SetSelected(newIndex, true);
            }
            actualizarVP();
        }


        private void Borrar_Click(object sender, EventArgs e){
            List<object> itemsToMove = (from object item in listBox1.SelectedItems select item).ToList();

            foreach (var i in itemsToMove)
                listBox1.Items.Remove(i);

            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

            actualizarVP();
        }

        //_________________________________________________

        private void Renamer_Load(object sender, EventArgs e) { }
    }
}


// Gracias, stackoverflow
public static class FolderBrowserLauncher
{
    /// <summary>
    /// Using title text to look for the top level dialog window is fragile.
    /// In particular, this will fail in non-English applications.
    /// </summary>
    const string _topLevelSearchString = "Browse For Folder";

    /// <summary>
    /// These should be more robust.  We find the correct child controls in the dialog
    /// by using the GetDlgItem method, rather than the FindWindow(Ex) method,
    /// because the dialog item IDs should be constant.
    /// </summary>
    const int _dlgItemBrowseControl = 0;
    const int _dlgItemTreeView = 100;

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Some of the messages that the Tree View control will respond to
    /// </summary>
    private const int TV_FIRST = 0x1100;
    private const int TVM_SELECTITEM = (TV_FIRST + 11);
    private const int TVM_GETNEXTITEM = (TV_FIRST + 10);
    private const int TVM_GETITEM = (TV_FIRST + 12);
    private const int TVM_ENSUREVISIBLE = (TV_FIRST + 20);

    /// <summary>
    /// Constants used to identity specific items in the Tree View control
    /// </summary>
    private const int TVGN_ROOT = 0x0;
    private const int TVGN_NEXT = 0x1;
    private const int TVGN_CHILD = 0x4;
    private const int TVGN_FIRSTVISIBLE = 0x5;
    private const int TVGN_NEXTVISIBLE = 0x6;
    private const int TVGN_CARET = 0x9;


    /// <summary>
    /// Calling this method is identical to calling the ShowDialog method of the provided
    /// FolderBrowserDialog, except that an attempt will be made to scroll the Tree View
    /// to make the currently selected folder visible in the dialog window.
    /// </summary>
    /// <param name="dlg"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static DialogResult ShowFolderBrowser(FolderBrowserDialog dlg, IWin32Window parent = null)
    {
        DialogResult result = DialogResult.Cancel;
        int retries = 10;

        using (Timer t = new Timer())
        {
            t.Tick += (s, a) =>
            {
                if (retries > 0)
                {
                    --retries;
                    IntPtr hwndDlg = FindWindow((string)null, _topLevelSearchString);
                    if (hwndDlg != IntPtr.Zero)
                    {
                        IntPtr hwndFolderCtrl = GetDlgItem(hwndDlg, _dlgItemBrowseControl);
                        if (hwndFolderCtrl != IntPtr.Zero)
                        {
                            IntPtr hwndTV = GetDlgItem(hwndFolderCtrl, _dlgItemTreeView);

                            if (hwndTV != IntPtr.Zero)
                            {
                                IntPtr item = SendMessage(hwndTV, (uint)TVM_GETNEXTITEM, new IntPtr(TVGN_CARET), IntPtr.Zero);
                                if (item != IntPtr.Zero)
                                {
                                    SendMessage(hwndTV, TVM_ENSUREVISIBLE, IntPtr.Zero, item);
                                    retries = 0;
                                    t.Stop();
                                }
                            }
                        }
                    }
                }

                else
                {
                    //
                    //  We failed to find the Tree View control.
                    //
                    //  As a fall back (and this is an UberUgly hack), we will send
                    //  some fake keystrokes to the application in an attempt to force
                    //  the Tree View to scroll to the selected item.
                    //
                    t.Stop();
                    SendKeys.Send("{TAB}{TAB}{DOWN}{DOWN}{UP}{UP}");
                }
            };

            t.Interval = 10;
            t.Start();

            result = dlg.ShowDialog(parent);
        }

        return result;
    }
}

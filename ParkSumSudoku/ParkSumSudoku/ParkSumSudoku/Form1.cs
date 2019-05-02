// Jordan Park and Jose Ortiz
// Z1816715  z1792042       
// Assignment 5
// 4/11/2019

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrtizParkAssignment5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setUP();
            
            readFiles();
            getTimes();
        }

        List<Options> be = new List<Options>();
        string[,] puzzleFiles = new string[3, 3];
        Pen bPen = new Pen(Color.Black, 5);
        Brush bBrush = new SolidBrush(Color.Turquoise);
        int choice = -1, dev = -1, levelChoice;
        int pauseCtrl = 0,gdim=3;
        Stopwatch timer = new Stopwatch();
        string difficultyChoice = "";
        List<Puzzle> puzzles = new List<Puzzle>();
        List<int> currentSumList = new List<int>();
        List<int> currentSumResults = new List<int>();
        List<int> SumResults = new List<int>();
        List<string> currentIDS = new List<string>();
        List<Speed> currentSpeeds = new List<Speed>();
        string tbs;
        
        bool gameStart = false;

        class Speed
        {
            char diff;
            int level, speed;
            public Speed()
            {
                diff = 'e';
                level = 1;
                speed = 123;
            }

            public Speed(char diff, int level, int speed)
            {
                this.diff = diff;
                this.level = level;
                this.speed = speed;
            }

            public char pDiff
            {
                get { return diff; }
                set { diff = value; }
            }
            public int plevel
            {
                get { return level; }
                set { level = value; }
            }
            public int pSpeed
            {
                get { return speed; }
                set { speed = value; }
            }
        }

        class Puzzle
        {
            private string id;
            private string difficulty;
            private int level;
            private List<int> unsolved = new List<int>();
            private List<int> solved = new List<int>();
            private List<int> sums = new List<int>();

            public Puzzle()
            {
                this.difficulty = "Easy";
                this.level = 1;
                unsolved = new List<int> { 0, 2, 0, 4, 0, 6, 0, 8, 9 };
                solved = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            }

            public Puzzle(string id, string difficulty, int level, List<int> unsolved, List<int> solved, List<int> sums)
            {
                this.id = id;
                this.difficulty = difficulty;
                this.level = level;
                this.unsolved = unsolved;
                this.solved = solved;
                this.sums = sums;
            }


            public string pID    
            {
                get { return id; }
                set { id = value; }
            }
            public string pDifficulty
            {
                get { return difficulty; }
                set { difficulty = value; }
            }
            public int pLevel
            {
                get { return level; }
                set { level = value; }
            }
            public List<int> pUnsolved
            {
                get { return unsolved; }
                set { unsolved = value; }
            }
            public List<int> pSolved
            {
                get { return solved; }
                set { solved = value; }
            }
            public List<int> pSums
            {
                get { return sums; }
                set {sums = value; }
            }
        }

      

        class Options
        {
            public string name { get; set; }
            public int val { get; set; }
        }

        private void setUP()
        {
            string directoryCon;
            using (StreamReader inFile = new StreamReader("directory.txt"))
            {
                while (!inFile.EndOfStream)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            directoryCon = inFile.ReadLine();
                            puzzleFiles[i, j] = directoryCon;
                        }
                    }

                }
            }
            this.be.Add(new Options() { name = "Easy", val = 0 });
            this.be.Add(new Options() { name = "Medium", val = 1 });
            this.be.Add(new Options() { name = "Hard", val = 2 });
            this.diffselectCombo.DataSource = be;
            this.diffselectCombo.DisplayMember = "name";
            this.diffselectCombo.SelectedIndex = 0;

            string[] levelOP = { "1", "2", "3" };
            levelselectCombo.DataSource = levelOP;

        }

        
        private void readFiles()
        {
            scanFiles("e1", "Easy", 1, 3, "Easy/e1.txt");
            scanFiles("e2", "Easy", 2, 3, "Easy/e2.txt");
            scanFiles("e3", "Easy", 3, 3,"Easy/e3.txt");

            scanFiles("m1", "Medium", 1, 5, "Medium/m1.txt");
            scanFiles("m2", "Medium", 2, 5, "Medium/m2.txt");
            scanFiles("m3", "Medium", 3, 5, "Medium/m3.txt");

            scanFiles("h1", "Hard", 1, 7, "Hard/h1.txt");
            scanFiles("h2", "Hard", 2, 7, "Hard/h2.txt");
            scanFiles("h3", "Hard", 3, 7, "Hard/h3.txt");
            
        }

        private void scanFiles(string id, string diffi, int level, int dim, string file)
        {
            string stuff = "";
            string stuff2 = "";
            //string ss = "";
            int counter = 0;
            using (StreamReader inFile = new StreamReader(file))
            {
                while (!inFile.EndOfStream)
                {
                    if (counter <= dim)
                    {
                        stuff += inFile.ReadLine();counter++;
                    }
                    else  //if (counter < dim * 2)
                    {
                        stuff2 += inFile.ReadLine();
                    }
                 
                    
                }
            }

            //richtest.AppendText(stuff + "\n");
            //richtest.AppendText(stuff2 + "\n");

            List<int> uSolved = getList(stuff);
            List<int> Solved = getList(stuff2);
            //List<int> saved = getList(ss);       
            List<int> sumList = getListofSums(Solved);
            //List<int> sumList = new List<int>();

            //(string id, string difficulty, uint level, List<int> unsolved, List<int> solved)
            Puzzle myPuzzle = new Puzzle(id, diffi, level, uSolved, Solved, sumList);
            //LoadPuzzle temp = new LoadPuzzle(id,diffi,level,uSolved,saved,file);
            puzzles.Add(myPuzzle);

        }

        
        List<int> getList(string str)
        {
          
            List<int> myList = new List<int>();
            foreach (char c in str)
            {
                myList.Add(charToInt(c));
            }
            return myList;
        }

        List<int> getListofSums(List<int> solved)
        {
            //get columns 
            int lSize = solved.Count;
     
            int dim = solved.Count;
            if ((lSize / 3) == 3)
            {
                dim = 3;
            }
            else if ((lSize / 5) == 5)
            {
                dim = 5;
            }
            else if ((lSize / 7) == 7)
            {
                dim = 7;
            }

            int sizeOfList = (dim * 2) + 2;
            List<int> myList = new List<int>();
            for (int i = 0; i < sizeOfList; i++)
            { myList.Add(0); };
            //column sums, row sums, bottom right, top right
            int indexCount = 0;


           
            //Get column sums
            int columnHold = 0;
            for (int i = 0; i < dim; i++)
            {
                switch (dim)
                {
                    case 3: columnHold = solved[i] + (solved[i + dim]) + (solved[i + (dim*2)]);
                        myList[indexCount] = columnHold;
                        indexCount++;
                        break;
                    case 5: columnHold = solved[i] + (solved[i + dim]) + (solved[i + (dim * 2)])
                            + (solved[i + (dim * 3)]) + (solved[i + (dim * 4)]);
                        myList[indexCount] = columnHold;
                        indexCount++;
                        break;
                    case 7:
                        columnHold = solved[i] + (solved[i + dim]) + (solved[i + (dim * 2)])
                            + (solved[i + (dim * 3)]) + (solved[i + (dim * 4)]) + (solved[i + (dim * 5)])
                            + (solved[i + (dim * 6)]);
                        myList[indexCount] = columnHold;
                        indexCount++;
                        break;
                }   
            }

            //Get row sums
            int rowHold = 0;
            int nextRow = 0;

            for (int i = 0; i < lSize; i++)
            {
                rowHold += solved[i];
                if (nextRow == (dim-1))
                {
                    myList[indexCount] = rowHold;
                    indexCount++;
                    rowHold = 0;
                    nextRow = -1;
                }
                nextRow++;
            }

            //bottom right
            int bDiagonal = 0;
            int bDiagInd = (dim+1);
            for (int i = 0; i < dim; i++)
            {
                if (i == 0)
                {
                    bDiagonal += solved[i];
                }
                else
                {
                    bDiagonal += solved[bDiagInd];
                    bDiagInd += (dim + 1);
                }
            }
            myList[indexCount] = bDiagonal;
            indexCount++;

            //top right
            int tDiagonal = 0;
            int tDiagInd = (dim - 1);

            for (int i = 0; i < dim; i++)
            {

                tDiagonal += solved[tDiagInd];
                tDiagInd += (dim - 1);
            }
            myList[indexCount] = tDiagonal;
            indexCount++;


            foreach (int i in myList)
            {
                //richtest.AppendText(i + " ");
            }
           // richtest.AppendText("\n");
            return myList;
        }

        public static int charToInt(char c)
        {
            return (int)(c - '0');
        }

        private void create_Board(int dim)
        {
            boardPanel.Refresh();
            boardPanel.Controls.Clear();
            horizontalSolved.Controls.Clear();
            verticalSolved.Controls.Clear();
            BRSolved.Controls.Clear();
            TRSolved.Controls.Clear();
            currentVerticals.Controls.Clear();
            currentHorizontals.Controls.Clear();
            BRcurrent.Controls.Clear();
            TRcurrent.Controls.Clear();

            List<int> uSolved = new List<int>();
            List<int> sumsList = new List<int>();
            foreach (Puzzle p in puzzles)
            {
                if (p.pDifficulty == difficultyChoice && p.pLevel == levelChoice)
                {
                    uSolved = p.pUnsolved;
                    sumsList = p.pSums;
                    SumResults = p.pSums;
                }
            }

            for (int i = 0; i < uSolved.Capacity; i++)
            { currentIDS.Add(""); };

            currentSumList = uSolved;
            currentSumResults = getListofSums(currentSumList);
            

            int x, y, cX, cY, xMess = 1, yMess = 1, TRmess = 1;
            int count = 0;
            //height       //width
            int boxSize = 1, boxSize2 = 1, fSize = 1;

            switch (dim)
            {
                case 3:
                    boxSize = 90;
                    boxSize2 = 120;
                    fSize = 40;
                    break;
                case 5:
                    boxSize = 50;
                    boxSize2 = 80;
                    fSize = 26;
                    break;
                case 7:
                    boxSize = 35;
                    boxSize2 = 60;
                    fSize = 20;
                    break;
            }

            x = 600 / (dim) * 1;
            y = 600 / (dim) * 1;
            cX = (x / 2);
            cY = y + (cX);
            x -= cX + boxSize;
            y -= cX + boxSize;

            if (dim == 3)
            {
                cX -= 30;
                yMess += 45;
                TRmess = 10;
                xMess = 0;
            }
            else if (dim == 5)
            {
                cX -= 10;
                yMess += 0;
                TRmess = 50;
                xMess = 40;
            }
            else if (dim == 7)
            {
                cX -= 5;
                yMess += -5;
                TRmess = 60;
                xMess = 45;
            }

            int maxSolved = sumsList.Capacity;
            int currentHorizontalIndex = 0;
            // int columnsSolved = dim;
            int columnsSolved = (dim);
            int br = (dim * 2);
            int tr = (dim * 2) + 1;
            bool drewSolvedHorizontal = false;

            for (int i = 0; i < dim; i++)
            {
                y = 600 / dim * (1 + i);
                //y -= cX+boxSize;
                y -= cX + (boxSize2 - boxSize + yMess);
                //draw Vertical Solved Boxes
                TextBox TV = new TextBox();
                TV.Multiline = true;
                TV.MaxLength = 2;
                TV.Font = new Font("Arial", fSize, FontStyle.Bold);
                TV.MinimumSize = new Size(boxSize2, boxSize);
                TV.Size = new Size(boxSize2, boxSize);
                //TV.Name = ("TVText" +columnsSolved);
                verticalSolved.Controls.Add(TV);
                TV.Location = new Point(10, y);
                TV.Text = (sumsList[columnsSolved]).ToString();
                TV.BackColor = Color.Tan;
                TV.ForeColor = Color.Green;
                TV.ReadOnly = true;
                TV.BringToFront();
                
                //draw Vertical UNSOLVED boxes
                TextBox TUV = new TextBox();
                TUV.MaxLength = 2;
                TUV.Font = new Font("Arial", fSize, FontStyle.Bold);
                TUV.MinimumSize = new Size(boxSize2, boxSize);
                TUV.Size = new Size(boxSize2, boxSize);
                TUV.Name = ("TUVText" + columnsSolved);
                currentIDS[columnsSolved] = TUV.Name;
                currentVerticals.Controls.Add(TUV);
                TUV.Location = new Point(12, y);
                TUV.Text = (currentSumResults[columnsSolved]).ToString();
                TUV.BackColor = Color.Tan;
                TUV.ForeColor = Color.Blue;
                TUV.ReadOnly = true;
                TUV.BringToFront();

                columnsSolved++;



                //draw Corner solved Boxes
                //bottom right
                TextBox TBR = new TextBox();
                TBR.Multiline = true;
                TBR.Font = new Font("Arial", fSize, FontStyle.Bold);
                TBR.MinimumSize = new Size(boxSize2, boxSize);
                TBR.Size = new Size(boxSize2, boxSize);
                //TBR.Name = ("TBRText" + br);
                BRSolved.Controls.Add(TBR);
                TBR.Location = new Point(10, 30);
                TBR.Text = (sumsList[br]).ToString();
                TBR.BackColor = Color.Tan;
                TBR.ForeColor = Color.Green;
                TBR.ReadOnly = true;
                TBR.BringToFront();

                //bottom right (top left) unsolved
                TextBox TBRU = new TextBox();
                TBRU.Multiline = true;
                TBRU.Font = new Font("Arial", fSize, FontStyle.Bold);
                TBRU.MinimumSize = new Size(boxSize2, boxSize);
                TBRU.Size = new Size(boxSize2, boxSize);
                TBRU.Name = ("TBRUText" + br);
                currentIDS[br] = TBRU.Name;
                BRcurrent.Controls.Add(TBRU);
                TBRU.Location = new Point(10, TRmess);
                TBRU.Text = (currentSumResults[br]).ToString();
                TBRU.BackColor = Color.Tan;
                TBRU.ForeColor = Color.Blue;
                TBRU.ReadOnly = true;
                TBRU.BringToFront();

                //top right
                TextBox TTR = new TextBox();
                TTR.Multiline = true;
                TTR.Font = new Font("Arial", fSize, FontStyle.Bold);
                TTR.MinimumSize = new Size(boxSize2, boxSize);
                TTR.Size = new Size(boxSize2, boxSize);
                //TTR.Name = ("TTRText" + tr);
                TRSolved.Controls.Add(TTR);
                TTR.Location = new Point(10, TRmess);
                TTR.Text = (sumsList[tr]).ToString();
                TTR.BackColor = Color.Tan;
                TTR.ForeColor = Color.Green;
                TTR.ReadOnly = true;
                TTR.BringToFront();

                //top right (bottom left) unsolved
                TextBox TTRU = new TextBox();
                TTRU.Multiline = true;
                TTRU.Font = new Font("Arial", fSize, FontStyle.Bold);
                TTRU.MinimumSize = new Size(boxSize2, boxSize);
                TTRU.Size = new Size(boxSize2, boxSize);
                TTRU.Name = ("TTRUText" + tr);
                currentIDS[tr] = TTRU.Name;
                TRcurrent.Controls.Add(TTRU);
                TTRU.Location = new Point(10, 30);
                TTRU.Text = (currentSumResults[tr]).ToString();
                TTRU.BackColor = Color.Tan;
                TTRU.ForeColor = Color.Blue;
                TTRU.ReadOnly = true;
                TTRU.BringToFront();



                for (int j = 0; j < dim; j++)
                {
                    x = 600 / dim * (1 + j);
                    x -= cX + boxSize;

                    TextBox T = new TextBox();
                    T.Multiline = true;
                    //makes the makes number length 1 space
                    T.MaxLength = 1;
                    T.Font = new Font("Arial", fSize, FontStyle.Bold);
                    T.MinimumSize = new Size(boxSize2, boxSize);
                    T.Size = new Size(boxSize2, boxSize);
                    T.Name = (count.ToString());
                    T.KeyPress += T_KeyPress;
                    T.TextChanged += T_TextChanged;
                    T.Cursor = Cursors.Default;
                    boardPanel.Controls.Add(T);
                    T.Location = new Point(x, y);
                    if (uSolved[count] != 0)
                    {
                        //this is where we put preexisting "known" values
                        T.Text = (uSolved[count]).ToString();
                        T.Font = new Font("Arial", fSize, FontStyle.Italic);
                        T.BackColor = Color.White;
                        T.ForeColor = Color.Purple;
                        T.ReadOnly = true;
                    }
                    count++;
                    // T.Size = new Size(boxSize + boxSize2, 1);

                    if (!drewSolvedHorizontal)
                    //draw Horizontal solved textboxes
                    {
                        TextBox TH = new TextBox();
                        TH.Multiline = true;
                        TH.MaxLength = 1;
                        TH.Font = new Font("Arial", fSize, FontStyle.Bold);
                        TH.MinimumSize = new Size(boxSize2, boxSize);
                        TH.Size = new Size(boxSize2, boxSize);
                        //TH.Name = ("THText" + currentHorizontalIndex);
                        horizontalSolved.Controls.Add(TH);
                        TH.Location = new Point(x, 20);
                        TH.Text = (sumsList[currentHorizontalIndex]).ToString();
                        TH.BackColor = Color.Tan;
                        TH.ForeColor = Color.Green;
                        TH.ReadOnly = true;
                        TH.BringToFront();

                        //horizontal current Sum unsolved 
                        TextBox THU = new TextBox();
                        THU.MaxLength = 2;
                        THU.Font = new Font("Arial", fSize, FontStyle.Bold);
                        THU.MinimumSize = new Size(boxSize2, boxSize);
                        THU.Size = new Size(boxSize2, boxSize);
                        THU.Name = ("THUText" + currentHorizontalIndex);
                        currentIDS[currentHorizontalIndex] = THU.Name;
                        currentHorizontals.Controls.Add(THU);
                        THU.Location = new Point(x, xMess);
                        THU.Text = (currentSumResults[currentHorizontalIndex]).ToString();
                        THU.BackColor = Color.Tan;
                        THU.ForeColor = Color.Blue;
                        THU.ReadOnly = true;
                        THU.BringToFront();
                        currentHorizontalIndex++;
                    }


                }
                drewSolvedHorizontal = true;
            }
            gameStart = true;
            /*
            foreach (string s in currentIDS)
            {
                richtest.AppendText(s + "\n");
            }
            */
        }


        private void Update_Current_Sums(int index, int value)
        {
            currentSumList[index] = value;

            //richtest.AppendText("index = " + index + "\n");
            
          
            currentSumResults = getListofSums(currentSumList);

            int verticalCount = dev;
            int brCount = dev * 2;
            int trCount = (dev * 2) + 1;



            for (int i = 0; i < dev; i++)
            {
                currentHorizontals.Controls[currentIDS[i]].Text = currentSumResults[i].ToString();
            }

            for (int i = verticalCount; i < brCount; i++)
            {
               currentVerticals.Controls[currentIDS[i]].Text = currentSumResults[i].ToString();
            }

            //br
            BRcurrent.Controls[currentIDS[brCount]].Text = currentSumResults[brCount].ToString();

            //tr
            TRcurrent.Controls[currentIDS[trCount]].Text = currentSumResults[trCount].ToString();


           
            bool didIWin = SumResults.SequenceEqual(currentSumResults);
            if (didIWin)
            {
                char pick = ' ';
                switch (choice)
                {
                    case 0:
                        pick = 'e';
                        break;
                    case 1:
                        pick = 'm';
                        break;
                    case 2:
                        pick = 'h';
                        break;
                    default:
                        pick = 'e';
                        break;
                }
                IWon(pick);
            }
            
        }

        //makes sure only numbers can be put in except 0
        private void T_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '0')
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }    
            e.Handled = false;
            return;
        }

        private void T_TextChanged(object sender, EventArgs e)
        {

            TextBox T = sender as TextBox;
            // richtest.Clear();
            //richtest.AppendText("You changed " + T.Name + " to value of " + T.Text + "\n");
            int boxIndex = 1;
            int value = 1;

            boxIndex = Int32.Parse(T.Name);

            if (string.IsNullOrWhiteSpace(T.Text))
            {
                value = 0;
            }
            else
            {
                value = Int32.Parse(T.Text);
            }

            if (gameStart == true)
            {
                Update_Current_Sums(boxIndex, value);
            }
            
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {          
            
            if (pauseCtrl % 2 == 0)
            {
                timer.Stop();
                pauseCtrl++;

                pauseButton.Text = "Resume";
                blockerPanel.Visible = true;
            }
            else
            {
                timer.Start();
                pauseCtrl--;
                pauseButton.Text = "Pause";
                blockerPanel.Visible = false;
            }
        }

        private void blockerPanel_Paint(object sender, PaintEventArgs e)
        {
            int adjust = 2;
            Pen myPen = new Pen(Color.DodgerBlue, 15);
            e.Graphics.DrawLine(myPen, 0, 0, blockerPanel.Width, 0);
            e.Graphics.DrawLine(myPen, 0, blockerPanel.Height - adjust, blockerPanel.Width, blockerPanel.Height - adjust);
            e.Graphics.DrawLine(myPen, 0, 0, 0, blockerPanel.Height);
            e.Graphics.DrawLine(myPen, blockerPanel.Width - adjust, 0, blockerPanel.Width - adjust, blockerPanel.Height);

        }

        private void create_Solved_Board(int dim)
        {
            boardPanel.Refresh();
            boardPanel.Controls.Clear();
            horizontalSolved.Controls.Clear();
            verticalSolved.Controls.Clear();
            BRSolved.Controls.Clear();
            TRSolved.Controls.Clear();
            currentVerticals.Controls.Clear();
            currentHorizontals.Controls.Clear();
            BRcurrent.Controls.Clear();
            TRcurrent.Controls.Clear();

            List<int> uSolved = new List<int>();
            List<int> sumsList = new List<int>();
            foreach (Puzzle p in puzzles)
            {
                if (p.pDifficulty == difficultyChoice && p.pLevel == levelChoice)
                {
                    uSolved = p.pSolved;
                    sumsList = p.pSums;
                    SumResults = p.pSums;
              
                }
            }

           
            for (int i = 0; i < uSolved.Capacity; i++)
            { currentIDS.Add(""); };

            currentSumList = uSolved;
            currentSumResults = getListofSums(currentSumList);


            int x, y, cX, cY, xMess = 1, yMess = 1, TRmess = 1;
            int count = 0;
            //height       //width
            int boxSize = 1, boxSize2 = 1, fSize = 1;

            switch (dim)
            {
                #region
                case 3:
                    boxSize = 90;
                    boxSize2 = 120;
                    fSize = 40;
                    break;
                case 5:
                    boxSize = 50;
                    boxSize2 = 80;
                    fSize = 26;
                    break;
                case 7:
                    boxSize = 35;
                    boxSize2 = 60;
                    fSize = 20;
                    break;
                    #endregion
            }

            x = 600 / (dim) * 1;
            y = 600 / (dim) * 1;
            cX = (x / 2);
            cY = y + (cX);
            x -= cX + boxSize;
            y -= cX + boxSize;

            if (dim == 3)
            {
                cX -= 30;
                yMess += 45;
                TRmess = 10;
                xMess = 0;
            }
            else if (dim == 5)
            {
                cX -= 10;
                yMess += 0;
                TRmess = 50;
                xMess = 40;
            }
            else if (dim == 7)
            {
                cX -= 5;
                yMess += -5;
                TRmess = 60;
                xMess = 45;
            }

            int maxSolved = sumsList.Capacity;
            int currentHorizontalIndex = 0;
            // int columnsSolved = dim;
            int columnsSolved = (dim);
            int br = (dim * 2);
            int tr = (dim * 2) + 1;
            bool drewSolvedHorizontal = false;

            for (int i = 0; i < dim; i++)
            {
                #region
                y = 600 / dim * (1 + i);
                //y -= cX+boxSize;
                y -= cX + (boxSize2 - boxSize + yMess);

                //draw Vertical Solved Boxes
                TextBox TV = new TextBox();
                TV.Multiline = true;
                TV.MaxLength = 2;
                TV.Font = new Font("Arial", fSize, FontStyle.Bold);
                TV.MinimumSize = new Size(boxSize2, boxSize);
                TV.Size = new Size(boxSize2, boxSize);
                //TV.Name = ("TVText" +columnsSolved);
                verticalSolved.Controls.Add(TV);
                TV.Location = new Point(10, y);
                TV.Text = (sumsList[columnsSolved]).ToString();
                TV.BackColor = Color.Tan;
                TV.ForeColor = Color.Green;
                TV.ReadOnly = true;
                TV.BringToFront();

                //draw Vertical UNSOLVED boxes
                TextBox TUV = new TextBox();
                TUV.MaxLength = 2;
                TUV.Font = new Font("Arial", fSize, FontStyle.Bold);
                TUV.MinimumSize = new Size(boxSize2, boxSize);
                TUV.Size = new Size(boxSize2, boxSize);
                TUV.Name = ("TUVText" + columnsSolved);
                currentIDS[columnsSolved] = TUV.Name;
                currentVerticals.Controls.Add(TUV);
                TUV.Location = new Point(12, y);
                TUV.Text = (currentSumResults[columnsSolved]).ToString();
                TUV.BackColor = Color.Tan;
                TUV.ForeColor = Color.Blue;
                TUV.ReadOnly = true;
                TUV.BringToFront();

                columnsSolved++;

                //draw Corner solved Boxes
                //bottom right
                TextBox TBR = new TextBox();
                TBR.Multiline = true;
                TBR.Font = new Font("Arial", fSize, FontStyle.Bold);
                TBR.MinimumSize = new Size(boxSize2, boxSize);
                TBR.Size = new Size(boxSize2, boxSize);
                //TBR.Name = ("TBRText" + br);
                BRSolved.Controls.Add(TBR);
                TBR.Location = new Point(10, 30);
                TBR.Text = (sumsList[br]).ToString();
                TBR.BackColor = Color.Tan;
                TBR.ForeColor = Color.Green;
                TBR.ReadOnly = true;
                TBR.BringToFront();

                //bottom right (top left) unsolved
                TextBox TBRU = new TextBox();
                TBRU.Multiline = true;
                TBRU.Font = new Font("Arial", fSize, FontStyle.Bold);
                TBRU.MinimumSize = new Size(boxSize2, boxSize);
                TBRU.Size = new Size(boxSize2, boxSize);
                TBRU.Name = ("TBRUText" + br);
                currentIDS[br] = TBRU.Name;
                BRcurrent.Controls.Add(TBRU);
                TBRU.Location = new Point(10, TRmess);
                TBRU.Text = (currentSumResults[br]).ToString();
                TBRU.BackColor = Color.Tan;
                TBRU.ForeColor = Color.Blue;
                TBRU.ReadOnly = true;
                TBRU.BringToFront();

                //top right
                TextBox TTR = new TextBox();
                TTR.Multiline = true;
                TTR.Font = new Font("Arial", fSize, FontStyle.Bold);
                TTR.MinimumSize = new Size(boxSize2, boxSize);
                TTR.Size = new Size(boxSize2, boxSize);
                //TTR.Name = ("TTRText" + tr);
                TRSolved.Controls.Add(TTR);
                TTR.Location = new Point(10, TRmess);
                TTR.Text = (sumsList[tr]).ToString();
                TTR.BackColor = Color.Tan;
                TTR.ForeColor = Color.Green;
                TTR.ReadOnly = true;
                TTR.BringToFront();

                //top right (bottom left) unsolved
                TextBox TTRU = new TextBox();
                TTRU.Multiline = true;
                TTRU.Font = new Font("Arial", fSize, FontStyle.Bold);
                TTRU.MinimumSize = new Size(boxSize2, boxSize);
                TTRU.Size = new Size(boxSize2, boxSize);
                TTRU.Name = ("TTRUText" + tr);
                currentIDS[tr] = TTRU.Name;
                TRcurrent.Controls.Add(TTRU);
                TTRU.Location = new Point(10, 30);
                TTRU.Text = (currentSumResults[tr]).ToString();
                TTRU.BackColor = Color.Tan;
                TTRU.ForeColor = Color.Blue;
                TTRU.ReadOnly = true;
                TTRU.BringToFront();

                //
                //The code to actually make the grid starts here
                //
                for (int j = 0; j < dim; j++)
                {
                    #region
                    x = 600 / dim * (1 + j);
                    x -= cX + boxSize;

                    TextBox T = new TextBox();
                    T.Multiline = true;
                    //makes the makes number length 1 space
                    T.MaxLength = 1;
                    T.Font = new Font("Arial", fSize, FontStyle.Bold);
                    T.MinimumSize = new Size(boxSize2, boxSize);
                    T.Size = new Size(boxSize2, boxSize);
                    T.Name = (count.ToString());
                    T.KeyPress += T_KeyPress;
                    //T.TextChanged += T_TextChanged;
                    boardPanel.Controls.Add(T);
                    T.Location = new Point(x, y);
                    if (uSolved[count] != 0)
                    {
                        //this is where we put preexisting "known" values
                        T.Text = (uSolved[count]).ToString();
                        T.Font = new Font("Arial", fSize, FontStyle.Italic);
                        T.BackColor = Color.White;
                        T.ForeColor = Color.Purple;
                        T.ReadOnly = true;
                    }
                    count++;
                    //
                    //the code to actually make the grid stops here
                    //



                    // T.Size = new Size(boxSize + boxSize2, 1);

                    if (!drewSolvedHorizontal)
                    //draw Horizontal solved textboxes
                    {
                        TextBox TH = new TextBox();
                        TH.Multiline = true;
                        TH.MaxLength = 1;
                        TH.Font = new Font("Arial", fSize, FontStyle.Bold);
                        TH.MinimumSize = new Size(boxSize2, boxSize);
                        TH.Size = new Size(boxSize2, boxSize);
                        //TH.Name = ("THText" + currentHorizontalIndex);
                        horizontalSolved.Controls.Add(TH);
                        TH.Location = new Point(x, 20);
                        TH.Text = (sumsList[currentHorizontalIndex]).ToString();
                        TH.BackColor = Color.Tan;
                        TH.ForeColor = Color.Green;
                        TH.ReadOnly = true;
                        TH.BringToFront();

                        //horizontal current Sum unsolved 
                        TextBox THU = new TextBox();
                        THU.MaxLength = 2;
                        THU.Font = new Font("Arial", fSize, FontStyle.Bold);
                        THU.MinimumSize = new Size(boxSize2, boxSize);
                        THU.Size = new Size(boxSize2, boxSize);
                        THU.Name = ("THUText" + currentHorizontalIndex);
                        currentIDS[currentHorizontalIndex] = THU.Name;
                        currentHorizontals.Controls.Add(THU);
                        THU.Location = new Point(x, xMess);
                        THU.Text = (currentSumResults[currentHorizontalIndex]).ToString();
                        THU.BackColor = Color.Tan;
                        THU.ForeColor = Color.Blue;
                        THU.ReadOnly = true;
                        THU.BringToFront();
                        currentHorizontalIndex++;
                    }

#endregion
                }
                drewSolvedHorizontal = true;
#endregion
            }
            gameStart = true;

        }


        private void cheatButton_Click(object sender, EventArgs e)
        {
            create_Solved_Board(gdim);
            timer.Reset();
            //timer.Start();
            //visTimer.Start();
            if (!(pauseCtrl % 2 == 0))
            {
                //timer.Start();
                pauseCtrl--;
                pauseButton.Text = "Pause";
                blockerPanel.Visible = false;
            }
        }
        private bool checkReadOnly(Control Ctrl)
        {
            bool isReadOnly = false;
            if (((TextBox)Ctrl).ReadOnly == true)
            {
                isReadOnly = true;
            }
            else
            {
                isReadOnly = false;
            }
            return isReadOnly;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            gameStart = false;
         

            foreach (Control ct in boardPanel.Controls.OfType<TextBox>())
            {
                if (checkReadOnly(ct) == true)
                {
                    
                }
                else
                {
                    ct.Text = String.Empty;

                    Update_Current_Sums(Int32.Parse(ct.Name), 0);

                }
            }
            currentSumList = new List<int>();
            currentSumResults = new List<int>();
            currentIDS = new List<string>();
            SumResults = new List<int>();

            create_Board(gdim);
            timer.Reset();
            timer.Start();
            visTimer.Start();

            if (!(pauseCtrl % 2 == 0))
            {
                timer.Start();
                pauseCtrl--;
                pauseButton.Text = "Pause";
                blockerPanel.Visible = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //boardPanel.[i.ToString()].Text;
            tbs = "";
            for (int i = 0; i < (dev * dev); i++)
                tbs += boardPanel.Controls[i.ToString()].Text;

            System.IO.File.WriteAllText("Saved/" + difficultyChoice + levelChoice + ".txt", tbs);
        }

        private void visTimer_Tick(object sender, EventArgs e)
        {

            TimeSpan ts = timer.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}.{1:00}",
                ts.Seconds,
                ts.Milliseconds / 10);

            timerLabel.Text = elapsedTime.ToString();
            /*
            double outtb = timer.ElapsedMilliseconds / 1000;
            timerLabel.Text = outtb.ToString() + " Seconds";
            */
        }
        private void IWon(char pick)
        {
   
            foreach (Speed a in currentSpeeds)
            {
                if (a.pDiff == pick && a.plevel == ((choice+1)) && a.pSpeed > timer.ElapsedMilliseconds / 1000)
                {
                    a.pSpeed = (int)timer.ElapsedMilliseconds / 1000;
                }
            }
            timer.Stop();
            richtest.Clear();
            curBoard();
            TimeSpan ts = timer.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:0}.{1:00}",
                ts.Seconds,
                ts.Milliseconds / 10);
            richtest.AppendText("\nTime! Your time was " + elapsedTime.ToString() + " seconds!");
            MessageBox.Show("YOU WIN.");

        }
        private void checkButton_Click(object sender, EventArgs e)
        {
            char pick = ' ';
            switch (choice)
            {
                case 0:
                    pick = 'e';
                    break;
                case 1:
                    pick = 'm';
                    break;
                case 2:
                    pick = 'h';
                    break;
                default:
                    pick = 'e';
                    break;
            }
            tbs = "";
            string solvedString = "";
            for (int i = 0; i < (dev * dev); i++)
                tbs += boardPanel.Controls[i.ToString()].Text;
            foreach (Puzzle p in puzzles)
            {
                if (p.pDifficulty == difficultyChoice && p.pLevel == levelChoice)
                {
                    foreach (int i in p.pSolved)
                    {
                        solvedString += i.ToString();
                    }
                    if (tbs.Equals(solvedString))
                    {
                        System.Windows.Forms.MessageBox.Show("You have completed the puzzle");

                        IWon(pick);
                    }
                    else
                    {
                        MessageBox.Show("Not quite correct, keep trying!");
                    }
                }
            }

        }


        private void boardPanel_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(bBrush, 0, 0, boardPanel.Width, boardPanel.Height);

            Brush nBrush = new SolidBrush(Color.Turquoise);
            int adjust = 2;

            Pen myPen = new Pen(Color.Magenta, 15);
            e.Graphics.DrawLine(myPen, 0, 0, boardPanel.Width, 0);
            e.Graphics.DrawLine(myPen, 0, boardPanel.Height - adjust, boardPanel.Width, boardPanel.Height - adjust);
            e.Graphics.DrawLine(myPen, 0, 0, 0, boardPanel.Height);
            e.Graphics.DrawLine(myPen, boardPanel.Width - adjust, 0, boardPanel.Width - adjust, boardPanel.Height);

            int x =1, y=1, cX=1, cY=1;
            int boxSize = 1;

            switch (dev)
            {
                case 3:
                    nBrush = new SolidBrush(Color.LimeGreen);
                    e.Graphics.FillRectangle(nBrush, 0, 0, boardPanel.Width, boardPanel.Height);
                    //e.Graphics.DrawLine(bPen, 166, 0, 166, boardPanel.Height);
                    break;
                case 5:
                    nBrush = new SolidBrush(Color.Yellow);
                    e.Graphics.FillRectangle(nBrush, 0, 0, boardPanel.Width, boardPanel.Height);
                    break;
                case 7:
                    nBrush = new SolidBrush(Color.Red);
                    e.Graphics.FillRectangle(nBrush, 0, 0, boardPanel.Width, boardPanel.Height);
                    break;
                default: break;
              }
            if (dev != -1)
            {
                x = 600 / (dev) * 1;
                y = 600 / (dev) * 1;
                cX = (x / 2);
                cY = y + (cX);
                x -= cX + boxSize;
                y -= cX + boxSize;

                e.Graphics.DrawLine(myPen, 0, 0, boardPanel.Width, 0);
                e.Graphics.DrawLine(myPen, 0, boardPanel.Height-adjust, boardPanel.Width, boardPanel.Height-adjust);
                e.Graphics.DrawLine(myPen, 0, 0, 0, boardPanel.Height);
                e.Graphics.DrawLine(myPen, boardPanel.Width-adjust, 0, boardPanel.Width-adjust, boardPanel.Height);


                for (int i = 0; i < dev; i++)
                {
                    y = 600 / dev * (1 + i);
                    e.Graphics.DrawLine(bPen, 0, y, boardPanel.Width, y);
                    y -= cX + boxSize;

                    for (int j = 0; j < dev; j++)
                    {
                        x = 600 / dev * (1 + j);
                        e.Graphics.DrawLine(bPen, x, 0, x, boardPanel.Height);
                        x -= cX + boxSize;

                    }
                }
            }
        }

        private void curBoard()
        {
            char pick = 'e';
            int avg = 0;
            switch (choice)
            {
                case 0:
                    pick = 'e';
                    break;
                case 1:
                    pick = 'm';
                    break;
                case 2:
                    pick = 'h';
                    break;
                default:
                    pick = 'e';
                    break;
            }
            richtest.Clear();
            richtest.AppendText("LEADERBOARD \n");
            foreach (Speed a in currentSpeeds)
            {

                if (pick == a.pDiff)
                {
                    richtest.AppendText("Level: " + a.plevel + " = " + a.pSpeed + " seconds\n");
                    avg += a.pSpeed;
                }
            }

            richtest.AppendText("The average speed for the " + difficultyChoice + " difficulty is " + (avg / 3) + " seconds.");
        }

        private void diffButton_Click(object sender, EventArgs e)
        {

            gameStart = false;
            choice = diffselectCombo.SelectedIndex;
            levelChoice = levelselectCombo.SelectedIndex + 1;
       
            foreach (Control ct in boardPanel.Controls.OfType<TextBox>())
            {
                if (!checkReadOnly(ct))
                {        
                    ct.Text = String.Empty;

                    Update_Current_Sums(Int32.Parse(ct.Name), 0);

                }
            }

            currentSumList = new List<int>();
            currentSumResults = new List<int>();
            currentIDS = new List<string>();
            SumResults = new List<int>();


            if (!(pauseCtrl % 2 == 0))
            {
                timer.Start();
                pauseCtrl--;
                pauseButton.Text = "Pause";
                blockerPanel.Visible = false;
            }

            switch (choice)
            {
                case 0:
                    difficultyChoice = "Easy";
                    curBoard();
                    dev = 3;
                    gdim = 3;
                    timer.Reset();
                    timer.Start();
                    visTimer.Start();
                    create_Board(dev);
                    break;
                case 1:
                    difficultyChoice = "Medium";
                    curBoard();
                    dev = 5;
                    gdim = 5;
                    timer.Reset();
                    timer.Start();
                    visTimer.Start();
                    create_Board(dev);
                    break;
                case 2:
                    difficultyChoice = "Hard";
                    curBoard();
                    dev = 7;
                    gdim = 7;
                    timer.Reset();
                    timer.Start();
                    visTimer.Start();
                    create_Board(dev);
                    break;
                case -1: //start up or no difficulty selected
                    break;
                default:
                    MessageBox.Show("Error with difficulty selection.");
                    break;
            }

            //this.Refresh();
        }

        private void getTimes()
        {
            string fileContents;
            string[] results = new string[3];
            using (StreamReader inFile = new StreamReader("Speed/speed.txt"))
            {

                while (!inFile.EndOfStream)
                {
                    fileContents = inFile.ReadLine();
                    results = fileContents.Split('-');
                    Speed s = new Speed(char.Parse(results[0]), int.Parse(results[1]), int.Parse(results[2]));
                    currentSpeeds.Add(s);

                }
            }
        }
    }
}

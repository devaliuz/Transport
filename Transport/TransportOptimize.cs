using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using Newtonsoft.Json;


namespace Transport
{
    [Serializable]
    public partial class TransportOptimize : Form
    {
        int Columns;
        int Rows;

        List<List<string>> Matrix = new List<List<string>>();                                   //Calling List For Datagrid
        List<List<int>> Solution = new List<List<int>>();
        public TransportOptimize()
        {
            InitializeComponent();
            Startup();
        }

        private void BTNaddCol_Click(object sender, EventArgs e)
        {
            AddCol();
        }

        private void BTNdelCol_Click(object sender, EventArgs e)
        {
            DelCol();
        }

        private void BTNoptimize_Click(object sender, EventArgs e)
        {
            Optimize();
        }

        private void InputGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.ColumnIndex != 0 && e.RowIndex < InputGrid.RowCount - 1)                      //Calling Rows/Column in which int is needed
            {
                int i;
                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))                   //Check if content is parsable to int   
                {
                    e.Cancel = true;
                    StatusLabel.Text = "Bitte nur Zahlen eingeben!";                                 //Throws Usernotification
                }
                else
                {
                    StatusLabel.Text = "Status Ok";                                                  //Throws Usernotification                                         
                }
            }
        }

        private void InputGrid_CellLeave(object sender, DataGridViewCellEventArgs e)            //Throws Eventhandler when Leaving Cell
        {
            WriteList();                                                                        // writes all Changes into Matrix-List                                   
            SafeToJson();                                                                       // saves all Changes into Save.json
        }

        private void Startup()
        {
            if (!File.Exists("Save.json"))                                                       //Checks if NOT File exists
            {
                InputGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fabriken" }); //Creates first two essential Columns
                InputGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Vorrat" });  //

                Matrix.Add(new List<string>() { "Fabriken", "Vorrat" });
                SafeToJson();                                                                    // and saves them into Save.json
            }
            else
            {
                OnStartReadFromJson();                                                           //reads from Json, to fill Grids
            }
        }

        private void AddCol()                                                                    //Adds new Column
        {
            Columns = Matrix[0].Count;                                                            //Counts all saved Collumns
            string Headname;                                                                      //Creates Var for Headname
            if (TBColl.Text == "" || TBColl.Text == "Spaltenname")                                //prevents from Columnhead beeing empty
            {
                Headname = Convert.ToString(Columns - 1);                                         //Gives Columnhead name of current Column
            }
            else
            {
                Headname = TBColl.Text;                                                           //Gives Columnhead user-chosen name
            }
            InputGrid.Columns.Insert(Columns - 1, new DataGridViewTextBoxColumn { HeaderText = Headname }); //Adds Column into Grid, at penultimate index 
            TBColl.Text = "";                                                                     //Resets the userinput for Columnhead

            WriteList();                                                                          //Writes all Changes to List
            SafeToJson();                                                                         //Saves all Changes into Json
        }

        private void DelCol()                                                                    //Deletes penultimate Collumn
        {
            Columns = Matrix[0].Count;                                                           //Counts all Collumns
            if (Columns > 2)                                                                     //prevents from exidently deleting last 2 Columns
            {
                InputGrid.Columns.RemoveAt(Columns - 2);                                         //Locates penultimate Column and deletes it
                WriteList();                                                                     //Writes all changes to List
                SafeToJson();                                                                    //Saves all Changes in Save.json
            }
        }
        private void SafeToJson()                                                                //Saves List to save.json
        {
            try
            {
                string jsonString = System.Text.Json.JsonSerializer.Serialize(Matrix);           //converts List into json-like type-string
                File.WriteAllText("Save.json", jsonString);                                      //Writes the converted string into the File
            }
            catch (IOException ioex)                                                              //Throws message if saving went wrong through IO services
            {
                MessageBox.Show(ioex.Message);
            }
            catch (Exception ex)                                                                  //throws message if saving went wrong at all
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OnStartReadFromJson()                                                       //reads from file and Loads into List and Grid
        {
            string jsonString = File.ReadAllText("Save.json");
            Matrix = JsonConvert.DeserializeObject<List<List<string>>>(jsonString);                //encrypts json into readable string, throws content into List

            if (Matrix != null)                                                                    //prevents from working with empty List
            {
                Columns = Matrix[0].Count;                                                         //sets Colums to number of items in List
                Rows = Matrix.Count;                                                               //sets Rows to number lists in Matrix
                for (int r = 0; r < Rows; r++)                                                     //starts reading row by row
                {
                    if (r != 0)                                                                    //Checks if row == header
                    {
                        InputGrid.Rows.Add(Matrix[r].ToArray());                                   //writes all cell-values of each row (as array) into grid
                    }
                    else
                    {
                        for (int c = 0; c < Columns; c++)                                          //repeats for each column                 
                        {

                            string Headname = Matrix[r][c];                                         //gets name of Columnhead by position
                            InputGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = Headname }); // Writes Columnhead into Grid


                        }
                    }
                }
            }
        }

        private void WriteList()                                                                 //Writes all Grid-Content into Matrix-List
        {
            List<string> head = new List<string>();
            Matrix.Clear();                                                                         //Clears List before refilling
            for (int h = 0; h < InputGrid.ColumnCount; h++)                                           //Writes all headers into Head
            {
                head.Add(InputGrid.Columns[h].HeaderText);                                          //Places Headername into "Headposition" in List
            }
            Matrix.Add(head);                                                                       //Adds all Headers into the List
            for (int r = 0; r < InputGrid.RowCount - 1; r++)                                          //Reads row by row (except last one)
            {
                List<string> row = new List<string>();

                for (int c = 0; c < InputGrid.ColumnCount; c++)                                     //Reads every column in row
                {
                    if (InputGrid[c, r].Value != null)                                              //Checks if Cell isnt empty
                    {
                        row.Add(InputGrid[c, r].Value.ToString());                                  //Adds Cell-Value into List
                    }
                    else
                    {
                        row.Add("");                                                                //Adds empty string into row
                    }
                }
                Matrix.Add(row);                                                                    //Writes all Rows into List
            }
        }

        private void Optimize() 
        {
            Solution.Clear();
            
            List<List<int>> Shops = new List<List<int>>();
            List<List<int>> Fabrics = new List<List<int>>();
            List<int> ShopDem = new List<int>();
            List<int> FabSup = new List<int>();
            List<List<int>> lowestlist = new List<List<int>>();

            for(int i = 0; i < InputGrid.RowCount-2; i++) 
            {
                int index = Convert.ToInt32(InputGrid[InputGrid.ColumnCount-1,i].Value);
                FabSup.Add(index);
            }
            for (int i = 1; i < InputGrid.ColumnCount - 1; i++)
            {
                int index = Convert.ToInt32(InputGrid[i,InputGrid.RowCount-2].Value);
                ShopDem.Add(index);
            }
               
            for(int c =1; c < InputGrid.ColumnCount-1; c++)
            {
                List<int> Shopcol = new List<int>();
                for (int r = 0; r < InputGrid.RowCount - 2; r++)
                {
                    Shopcol.Add(Convert.ToInt32(InputGrid[c, r].Value.ToString()));
                }
                    Shops.Add(Shopcol);
            }
            
            for (int r = 0; r < InputGrid.RowCount-2; r++)
            {
                List<int> Fabricrow = new List<int>();
                for (int c = 1; c < InputGrid.ColumnCount-1; c++)
                {
                    Fabricrow.Add(Convert.ToInt32(InputGrid[c, r].Value.ToString()));
                }
                Fabrics.Add(Fabricrow);
            }
                        
                for (int c = 1; c < InputGrid.ColumnCount - 1; c++)
                {
                    int[] shoparray = new int[Fabrics.Count];
                    List<int> list = new List<int>();
                    for (int sa = 0; sa < Fabrics.Count; sa++)
                    {
                        shoparray[sa] = Shops[c - 1][sa];
                    }
                    Array.Sort(shoparray);
                    list.AddRange(shoparray);
                    lowestlist.Add(list);
                }

            for (int i = 0; i < (Shops.Count); i++)
                {
                    List<int> Solutionpart = new List<int>();
                    Solutionpart.AddRange(new int[Shops[i].Count]);
                    for (int j = 0; j < lowestlist[i].Count; j++)
                    {
                        int index = Shops[i].IndexOf(lowestlist[i][j]);
                        if(ShopDem[i] != 0 && FabSup[index] != 0)
                        {
                            if (FabSup[index] >= ShopDem[i])
                            {
                                FabSup[index] = FabSup[index] - ShopDem[i];
                                Solutionpart[index] = ShopDem[i];
                                ShopDem[i] = 0;
                            }
                            else
                            {
                                ShopDem[i] = ShopDem[i] - FabSup[index];
                                Solutionpart[index] = FabSup[index];
                                FabSup[index] = 0;
                            }                            
                        }
                        
                    }
                    Solution.Add(Solutionpart);
                }
            
            
            ShowSolution();

        }
        private void ShowSolution()
        {
            Outputgrid.Rows.Clear();
            Outputgrid.Columns.Clear();

            Columns = Solution[0].Count;                                                                //sets Colums to number of items in List
            Rows = Solution.Count;                                                                      //Set Rows to number of items in List
            string[,] array = new string[Columns+1, Rows+1];


            

            for (int c = 1; c < InputGrid.ColumnCount - 1; c++)                                         //repeats for each column                 
            {
                string Headname = InputGrid.Columns[c].HeaderText;                                      //gets name of Columnhead by position
                Outputgrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = Headname });        // Writes Columnhead into Grid
            }
                                                                                                        
            for (int r = 0; r < Rows; r++)                                                              //starts reading row by row
            {                                                                                                        
                for (int c = 0; c < Solution[r].Count; c++)
                {                    
                    array[c,r] = Solution[r][c].ToString();                    
                }
            }

            for (int c = 0; c < Columns; c++)                                                              
            {
                List<string> rebuild = new List<string>();
                for (int r = 0; r < Rows; r++)
                {
                    rebuild.Add(array[c,r]);
                }
                Outputgrid.Rows.Add(rebuild.ToArray());
            }
            ThrowCost();
        }
        private void ThrowCost() 
        {
            int Ergebnis = 0;
            for (int r = 0; r < Solution[0].Count; r++)
            {
                for (int c = 0; c < Solution.Count; c++)
                {
                    Ergebnis += (Solution[c][r] * Convert.ToInt32(Matrix[r + 1][c + 1]));       //Multiply all non 0 Values withe the effortunits in Inputgrid
                }
            }
            LabelSolution.Text = "Die ermittelten Transportkosten betragen: " + Ergebnis.ToString(); //Show User Whole Costs for Transportation
        }
        
    }
}
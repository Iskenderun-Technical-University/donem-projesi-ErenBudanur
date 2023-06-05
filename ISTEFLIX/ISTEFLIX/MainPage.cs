using Dizi_Film_Uyfulamasý;
namespace ISTEFLIX
{
    public partial class MainPage : Form
    {
        List<Prod> PRODS = new List<Prod>();
        public int pagevalue = 0;
        private int datasize = 18;
        public MainPage()
        {
            InitializeComponent();
            Mysql.command("CREATE TABLE IF NOT EXISTS ISTEFLIX (FILM_NAME VARCHAR(64),PHOTOURL VARCHAR(256),URL VARCHAR(256))");
            foreach (Prod temp in Mysql.ReadDataFromTable("ISTEFLIX"))
                PRODS.Add(new Prod(temp.name, temp.PHOTOURL, temp.URL));
        }
        private void draw()
        {
            int formWidth = 200;
            int formHeight = 200;
            int spacing = 40;
            int maxPerRow = datasize / 3;

            int rowCount = 0;
            int columnCount = 0;

            for (int i = 0 + pagevalue * datasize; i < datasize + pagevalue * datasize && i < PRODS.Count; i++)
            {
                Products temp = new Products();
                temp.set_prod(PRODS[i]);
                int xPos = columnCount * (formWidth + spacing);
                int yPos = rowCount * (formHeight + spacing * 2);
                temp.Location = new Point(xPos, yPos);
                temp.TopLevel = false;
                panel1.Controls.Add(temp);
                temp.Show();

                columnCount++;

                if (columnCount >= maxPerRow)
                {
                    columnCount = 0;
                    rowCount++;
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            draw();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (pagevalue > 0)
            {
                panel1.Controls.Clear();
                panel1.BackColor = Color.FromArgb(65, 65, 65);
                pagevalue--;
                draw();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (PRODS.Count / datasize > pagevalue)
            {
                panel1.Controls.Clear();
                panel1.BackColor = Color.FromArgb(65, 65, 65);
                pagevalue++;
                draw();
            }
        }
    }
}
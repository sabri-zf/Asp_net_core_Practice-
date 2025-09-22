using System.Text;

namespace build_Project_Using_ASP_NetCore
{

    sealed public class Player
    { 
        public int Id { get; set; }
        public string Full_Name { get; set; } = null!;
        public string Team { get; set; } = null!;
        public byte Age  {get;set; }


        public override string ToString()
        {
            var str = new StringBuilder();
            str.AppendLine("---------   Player Card  ------------");
            str.AppendLine($"Full-Name : {this.Full_Name}");
            str.AppendLine($"Team      : {this.Team}");
            str.AppendLine($"Age       : {Age} years old");
            str.AppendLine("-------------------------------------");

            return str.ToString();
        }

    }

    public class Players
    {
        public static List<Player> ListPlayer => new List<Player>()
        {
            new Player(){Id = 1 , Full_Name = "Ryad Mahraz",Team ="Hilale sauid FC",Age = 35},
            new Player(){Id = 2 , Full_Name = "Mohammed Salah",Team ="Liverpool FC",Age=32},
            new Player(){Id = 3 , Full_Name = "Pakio Saka",Team ="Arsinal FC",Age = 23},
        };
    }
}

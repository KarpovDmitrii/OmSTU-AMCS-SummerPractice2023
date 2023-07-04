using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpaceCadets;
public class Program
{
    public class Student
    {
        public string Name = "";
        public string Group = "";
        public string Discipline = "";
        public double Mark = 0;
    }

    public static void Main(string[] way)
    {
        string path_to_input_file = way[0];
        string path_to_output_file = way[1];

        string file = File.ReadAllText(path_to_input_file);

        dynamic json_file = JsonConvert.DeserializeObject(file) ?? new JObject();
        List<Student> students = json_file.data.ToObject<List<Student>>();
        string scenario = json_file.taskName;
        List<dynamic> total;

        switch (scenario)
        {
            case "GetStudentsWithHighestGPA":
                {
                    total = GetStudentsWithHighestGPA(students);
                    break;
                }
            case "CalculateGPAByDiscipline":
                {
                    total = CalculateGPAByDiscipline(students);
                    break;
                }
            case "GetBestGroupsByDiscipline":
                {
                    total = GetBestGroupsByDiscipline(students);
                    break;
                }
            default:
                throw new Exception();
        }
        string output_file = JsonConvert.SerializeObject(new { Response = total },
         Formatting.Indented);

        File.WriteAllText(path_to_output_file, output_file);
    }

    public static List<dynamic> GetStudentsWithHighestGPA(List<Student> students)
    {

    }

    public static List<dynamic> CalculateGPAByDiscipline(List<Student> students)
    {

    }

    public static List<dynamic> GetBestGroupsByDiscipline(List<Student> students)
    {

    }
}
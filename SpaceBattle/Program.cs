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
        var students_with_all_marks = students.GroupBy(p => p.Name).Select(g => new
        {
            Name = g.Key,
            Marks = g.Select(p => p.Mark).ToArray()
        });

        double HighestGpa = students_with_all_marks.Max(student => (student.Marks.Sum()) /
         student.Marks.Length);
        var total = students_with_all_marks.Where(student => (student.Marks.Sum()) /
         student.Marks.Length == HighestGpa).Select(student => new
        {
            Name = student.Name,
            Mark = Math.Round((student.Marks.Sum()/ student.Marks.Length),2)
        });
        List<dynamic> exit_list = total.ToList<dynamic>();
        return exit_list;
    }

    public static List<dynamic> CalculateGPAByDiscipline(List<Student> students)
    {

    }

    public static List<dynamic> GetBestGroupsByDiscipline(List<Student> students)
    {

    }
}
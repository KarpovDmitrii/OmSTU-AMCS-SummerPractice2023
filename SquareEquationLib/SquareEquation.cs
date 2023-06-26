namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double[] answer;
        double eps = 1e-9;
        if ((-eps < a && a < eps)||
            double.IsInfinity(a) || double.IsInfinity(b) ||
            double.IsInfinity(c) || double.IsNaN(a) ||
            double.IsNaN(b) || double.IsNaN(c))                                                 
        {
            throw new System.ArgumentException();
        }
        b = b/a;
        c = c/a;
        double discriminant = Math.Pow(b, 2) - 4 * c;
        if (discriminant <= -eps)
        {
            answer =new double[0];
            return answer;
        }
        else if (-eps < discriminant && discriminant < eps)
        {
            answer = new double[1];
            answer[0] = -(b) / 2;
            return answer;
        }
        else
        
        {
            answer = new double[2];
            answer[0] = -(b + Math.Sign(b) * Math.Sqrt(discriminant)) / 2;
            answer[1] = c / answer[0];
            return answer;
        }
    }
}
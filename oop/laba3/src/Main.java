import java.util.Stack;

class Main
{
    public static void main (String[] args) throws java.lang.Exception
    {
        double x[]={100,100.2,100.4,99.95,100.153,99.81,100.03,100.25,100.32,100.27};
        double y[]={4.93,4.935,4.941,4.956,4.964,4.985,4.993,5.007,5.018,5.114};
        int n = 10;
        Stack<Double> I = new Stack<>();
        Stack<Double> U = new Stack<>();
        for (int i=0;i<n;i++){
            U.push(x[i]);
            I.push(y[i]);
        }

        double Syx = 0;
        double Sxx = 0;
        for (int i=0; i<n; i++)
        {
            Syx = Syx + (U.peek()*I.pop());
            Sxx = Sxx + (U.peek()*U.pop());
        }
        double r = Syx/Sxx;
        System.out.println("R="+1.0/r);
    }
}
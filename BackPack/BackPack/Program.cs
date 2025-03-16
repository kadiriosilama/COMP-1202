namespace week06_Fri10am;
class BackPack
{
    //variables
    //id, color, numStains, numStraps

    //public means: I can read/write the variable or method form outside the class

    public int idNum;

    public string mainColor;

    public int numStains;

    public int numStraps;

    //default constructor - method by nature

    public BackPack()
    {

    }
}
    
    public class Proram
{
    public static void Main(string[] args)
    {
        //create an 'instance' or an 'object' from my class (BackPack)
        //approach 1
       BackPack bp_0 = new BackPack {
            idNum = 0;
            mainColor = "black",
            numStains = 0,
            numStraps = 2
        }; 

        bp_0.print();
        bp_0.mainColor = "red";
        bp_0.print();


        //Approach 2: using a constructor to create an object / instance
        BackPack bp_1 = new BackPack();
        bp_1.idNum =namespace ;
        bp_1.mainColor = "blue";
        bp_1.numStains = 5;
        bp_1.numStraps = 1;






    }

public class Proram;

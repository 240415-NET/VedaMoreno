using System;
					
namespace StringArray;

    class Program
    {
        static void Main(string[] args)
        {              
            int student_one_grade = 97;
            int student_two_grade = 93;
            int student_three_grade = 100;
            int student_four_grade = 85;    
           
            Console.WriteLine(student_one_grade);
            Console.WriteLine(student_two_grade);
            Console.WriteLine(student_three_grade);
            Console.WriteLine(student_four_grade);
			
			//arrays use []			
			//arrays count from zero
			
			int[] student_grades = new int[4];
			
			student_grades[0] = 97;
			student_grades[1] = 93;
			student_grades[2] = 100;
			student_grades[3] = 85;
			
			int[] student_grades2 = {97,93,100,85};
			
			//Console.WriteLine(student_grades);
			
			for(int i = 0; i < 4; i++)
			{
				Console.WriteLine(student_grades[i]);	
				
			}
					

        }


    }


/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
class ATM {
  static void Main() {
    
    string uname = "CC3Laboratory", userString = "";
    int password = 12345, balance = 10000, piin = 123456, userInt = 0;
    
    do{
        Console.Write("Enter Username: ");
        userString = Console.ReadLine();
        
        Console.Write("Enter Password: ");
        userInt = Convert.ToInt32(Console.ReadLine());
        
        if(userString != uname && userInt != password)
            Console.WriteLine("Incorrect Login Credentials!");
            
    }while(userString != uname && userInt != password);
    
    Console.WriteLine("\nLogin Success!\n");
    
        while(true){
        balik:
            Console.WriteLine( 
                        "\n================================================================== " +
                        "\n [1] Check Balance" + 
                        "\n [2] Withdraw Money" + 
                        "\n [3] Deposit Money" + 
                        "\n [4] Exit Application" + 
                        "\n================================================================== \n");

            int choice = Convert.ToInt32(Console.ReadLine());
            
            switch(choice){
                case 1:
                    Console.WriteLine("You balance is " + balance);
                    goto balik;
                    
                case 2:
                    blah:
                        Console.WriteLine("Enter your PIN: ");
                        userInt = Convert.ToInt32(Console.ReadLine());
                        
                        if(userInt != piin)
                            Console.WriteLine("Incorrect Login Credentials!");
                            goto blah;
                            
                    withdraw:        
                        Console.Write("Enter the amount to Withdraw: ");
                        userInt = Convert.ToInt32(Console.ReadLine());
                        switch(userInt > 0 && userInt <= balance){
                            case true:
                                balance = balance - userInt;
                                Console.WriteLine(
                                    "Successfully Withdrawn!" + 
                                    "Your balance is now: " + balance);
                                    goto balik;
                            
                            case false:
                                Console.WriteLine(
                                    "\nYour Balance is not enough!\n");
                                goto withdraw;
                        }
                
                case 3:
                    Console.Write("Enter the amount to Deposit: ");
                    userInt = Convert.ToInt32(Console.ReadLine());
                    balance = balance + userInt;
                    Console.WriteLine(
                        "\nDeposit Successfull! \n" +
                        "Your balance is now: " + balance);
                        goto balik;
                
                case 4:
                    Console.WriteLine ("Babye");
                    return;
            
            }
        }
    }
}
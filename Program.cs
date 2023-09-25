

public class cardHolder{

    int pin;
    String cardNumber;
    String firstName;
    String lastName;
    double accountBalance;

    public cardHolder(string cardNumber, int pin, string firstName, string lastName, double accountBalance){
        
        this.pin = pin;
        this.cardNumber = cardNumber;
        this.firstName = firstName;
        this.lastName = lastName;
        this.accountBalance = accountBalance;
    }

    public String getNum(){
        return cardNumber;
    }

    public int getPin(){
        return pin;
    }

    public String getFristName(){
        return firstName;
    }

    public String getLastName(){
        return lastName;
    }

    public double getAccBal(){
        return accountBalance;
    }


    public void setNum(String newCardNumber){
        cardNumber = newCardNumber;
    }

    public void setPin(int newPin){
        pin = newPin;
    }

    public void setFristname(String newFristName){
        firstName = newFristName;
    }

    public void setLastName(String newLastName){
        lastName = newLastName;
    }

    public void setAccBal(double newAccountBalance){
        accountBalance = newAccountBalance;
    }


    public static void Main(String[] args){
        void printOptions(){

            System.Console.WriteLine("Please choose an option...");
            System.Console.WriteLine("1. Deposite");
            System.Console.WriteLine("2. Withdraw");
            System.Console.WriteLine("3. Check balance");
            System.Console.WriteLine("4. Exit");
        }

        void deposite(cardHolder currentUser){

            System.Console.WriteLine("How much would you like to deposite: ");
            double deposite = Double.Parse(Console.ReadLine());
            currentUser.setAccBal(deposite);
            System.Console.WriteLine("Deposite was successful. Your current balance is:" + currentUser.getAccBal() + "Thank You");

        }

        void withdraw(cardHolder currentUser){

            System.Console.WriteLine("How much would you like to withdraw: ");
            double withdraw = Double.Parse(Console.ReadLine());

            //check account balance for money
            if(currentUser.getAccBal()> withdraw){

                System.Console.WriteLine("Your balance is insufficient: ");
            }
            else{
                currentUser.setAccBal(currentUser.getAccBal() - withdraw);
                System.Console.WriteLine("Enjoy your day! Bye..");
            }
        }

        void accountbalance(cardHolder currentUser){
            System.Console.WriteLine("Your current balance is : " + currentUser.getAccBal());
        }



        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("76264859365", 0123, "Naa","Dsane", 6592.56));
        cardHolders.Add(new cardHolder("76264859366", 4567, "Jesse","Jones", 4592.16));
        cardHolders.Add(new cardHolder("76264859367", 0987, "Kotey","Amarh", 1572.56));
        cardHolders.Add(new cardHolder("76264859368", 2345, "Nii","Smith", 9592.59));
        cardHolders.Add(new cardHolder("76264859369", 7654, "Dan","Osei", 6192.21));
        cardHolders.Add(new cardHolder("76264859370", 1029, "Joe","Mensah", 8592.58));


        //User Prompt
        Console.WriteLine("Hello, Welcome to Naa's ATM");
        System.Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true){
            try{
                debitCardNum = System.Console.ReadLine();

                //checking against db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNumber == debitCardNum);
                if (currentUser != null) {break; }
                else{ System.Console.WriteLine("Your Card is not recognized. Please try again");}
            }
            catch {System.Console.WriteLine("Your Card is not recognized. Please try again"); }
        }

        System.Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while(true){
            try{
                userPin= int.Parse(Console.ReadLine());

                //checking against db
                if (currentUser.getPin() == userPin) {break; }
                else{ System.Console.WriteLine("Your pin is incorrect. Please try again");}
            }
            catch {System.Console.WriteLine("Your pin is incorrect. Please try again"); }
        }

        System.Console.WriteLine("Welcome" + currentUser.getFristName() + ": )");
        int option = 0;
        do {
            printOptions();
            try{
                option = int.Parse(Console.ReadLine());
            }
            catch {}
            if (option == 1) { deposite(currentUser);}
            else if(option == 2) {withdraw(currentUser);}
            else if (option == 3) {accountbalance(currentUser);}
            else if(option == 4) {break; }
            else {option = 0;}

        }
        while(option !=4);
        System.Console.WriteLine("Thank You! Have a great day..");



    }
}
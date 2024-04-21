using System;
using System.Data.Common;


class ToDoMain { 
  
    // Main Method 
    static public void Main(String[] args) 
    { 
        var tasks = new List<Task>();
        var id = 0;
        var toStop = true;
        int Done = 0, ToDo = 0, InProgress = 0;

        void addNewTask() 
        {
            Console.WriteLine("Enter task title:");
            string? taskTitle = Console.ReadLine();
            if(taskTitle == ""){
                Console.WriteLine("Error, please enter non empty name");
                mainMethod();
            }
            else{
                Console.WriteLine("Enter task description:");
                string? taskDisc = Console.ReadLine();            
                string taskStatus = "To Do";
                int id = generateId();
                Task newTask = new Task(id, taskTitle, taskDisc, taskStatus);
                ToDo++;
                tasks.Add(newTask);
            }
        } 
        string chooseStatus()
        {
            Console.WriteLine("Enter a status number:");
            Console.WriteLine("1. In Progress");
            Console.WriteLine("2. To Do");
            Console.WriteLine("3. Done");
            int statusChoice = 0;
            try{
                statusChoice = Convert.ToInt32(Console.ReadLine());
            }
            catch{
                Console.WriteLine("Please Enter one of the avaliable numbers");

            }
            string status = "";
            switch(statusChoice)
            {
                case 1:
                status = "In Progress";
                InProgress++;
                break;

                case 2:
                status = "To Do";
                ToDo++;
                break;

                case 3:
                status = "Done";
                Done++;
                break;

                default:
                Console.WriteLine("Please choose one of the three status");
                status = chooseStatus();
                break;
            }
            return status;
        }
        int generateId(){
            id++;
            return id;
        }
        void changeStatus()
        {
            Console.WriteLine("All Tasks");
            foreach (var task in tasks)
            {
                Console.WriteLine("{0} : {1} : {2}",task.getSetTaskId, task.getSetTaskName, task.getSetTaskStatus );
            }
            Console.WriteLine("Enter Task number to change status:");
            int taskIdToChangeStatus = 0;
            try{
                taskIdToChangeStatus = Convert.ToInt32(Console.ReadLine());
            }
            catch{
                Console.WriteLine("Please Enter one of the avaliable numbers");

            }
            var found = false;
            var index = 0;
            foreach(var task in tasks){
                if(taskIdToChangeStatus == task.getSetTaskId){
                    found = true;
                    index = task.getSetTaskId - 1;
                    string oldStatus = task.getSetTaskStatus;
                    switch(oldStatus){
                        case "To Do":
                        ToDo--;
                        break;
                        case "In Progress":
                        InProgress--;
                        break;
                        case "Done":
                        Done--;
                        break;
                    }
                }
            }
            if(found == true){
                string newStatus = chooseStatus();
                tasks[index].getSetTaskStatus = newStatus;
            }
            else{
                Console.WriteLine("Enter valid number");
            }
        }
        void printTasks(string status, int count){
            if(status == ""){
                if(tasks.Count() > 0){
                    foreach(var task in tasks) 
                    {
                        Console.WriteLine("Task: {0} \nDiscreption: {1} \nStatus: {2} ", task.getSetTaskName, task.getSetTaskDisc, task.getSetTaskStatus);
                    }
                }
                else{
                    Console.WriteLine("No tasks added!");
                }
            }
            else{
                if(count > 0){
                foreach(var task in tasks){
                    if(task.getSetTaskStatus == status){
                        Console.WriteLine("Task: {0} \nDiscreption: {1} \nStatus: {2} ", task.getSetTaskName, task.getSetTaskDisc, task.getSetTaskStatus);
                    }
                }
                }
                else{
                    Console.WriteLine("No {0} status found", status); 
                }
            }
            
        }

        void showAllTasks()
        {    
            Console.WriteLine("Enter the number of tasks category:");
            Console.WriteLine("1. All Tasks");
            Console.WriteLine("2. To Do Tasks");
            Console.WriteLine("3. In Progress Tasks");
            Console.WriteLine("4. Done Tasks");
            var catChoice = 0;
            try{
                catChoice = Convert.ToInt32(Console.ReadLine());
            }
            catch{
                Console.WriteLine("Please Enter one of the avaliable numbers");
            }
            var count = 0;
            switch(catChoice){
                case 1:
                count = tasks.Count();
                printTasks("", count);

                break;
                case 2:
                count = ToDo;
                printTasks("To Do", count);
                
                break;
                case 3:
                count = InProgress;
                printTasks("In Progress", count);
                
                break;
                case 4:
                count = Done;
                printTasks("Done", count);
                
                break;
                default: 
                Console.WriteLine(""); // do this
                break;  
            }
        }

        void mainMethod(){
            while(toStop){
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Add new task");
                Console.WriteLine("2. Show tasks");
                Console.WriteLine("3. Change status");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice:");
                
                int choice = 0;
                try {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch{
                    Console.WriteLine("Please Enter one of the avaliable numbers");
                }   
                switch(choice){
                    case 1:
                    addNewTask();
                    break;

                    case 2:
                    showAllTasks();
                    break;

                    case 3:
                    changeStatus();
                    break;

                    case 4:
                    toStop = false;
                    break;
                }
            }
        }
        mainMethod();
    } 
} 
enum Status{
    toDo,
    done,
    inprogress
}
class Task{
    private int taskId;
    private string taskName;
    private string taskDisc;
    private string taskStatus;
    public Task(){
    }
    public Task(int id, string name, string disc, string status){
        taskId = id;
        taskName = name;
        taskDisc = disc;
        taskStatus = status;
    }
    public int getSetTaskId{
        get{return taskId;}
    }
    public string getSetTaskName{
        get{return taskName;}
        set{taskName = value;}
    }
    public string getSetTaskDisc{
        get{return taskDisc;}
        set{taskDisc = value;}
    }
    public string getSetTaskStatus{
        get{return taskStatus;}
        set{taskStatus = value;}
    }
}
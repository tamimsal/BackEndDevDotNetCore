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
            Console.WriteLine("Enter task description:");
            string? taskDisc = Console.ReadLine();            
            string taskStatus = "To Do";
            int id = generateId();
            Task newTask = new Task(id, taskTitle, taskDisc, taskStatus);
            tasks.Add(newTask);
        } 
        string chooseStatus()
        {
            Console.WriteLine("Enter a status number:");
            Console.WriteLine("1. In Progress");
            Console.WriteLine("2. To Do");
            Console.WriteLine("3. Done");
            int statusChoice = Convert.ToInt32(Console.ReadLine());
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

        void showAllTasks()
        {    
            Console.WriteLine("Enter the number of tasks category:");
            Console.WriteLine("1. All Tasks");
            Console.WriteLine("2. To Do Tasks");
            Console.WriteLine("3. In Progress Tasks");
            Console.WriteLine("4. Done Tasks");
            int.TryParse(Console.ReadLine(),out int catChoice);
            switch(catChoice){
                case 1:
                if(tasks.Count() > 0){
                    foreach(var task in tasks) //do this as a function
                    {
                        Console.WriteLine("Task: {0} \nDiscreption: {1} \nStatus: {2} ", task.getSetTaskName, task.getSetTaskDisc, task.getSetTaskStatus);
                    }
                }
                else{
                    Console.WriteLine("No tasks added!");
                }
                break;
                case 2:
                if(ToDo > 0){
                    foreach(var task in tasks)
                    {
                        if(task.getSetTaskStatus == "To Do"){
                            Console.WriteLine("Task: {0} \nDiscreption: {1} \nStatus: {2} ", task.getSetTaskName, task.getSetTaskDisc, task.getSetTaskStatus);
                        }
                    }
                }
                else{
                    Console.WriteLine("No To Do tasks");
                }
                break;
                case 3:
                if(ToDo > 0){
                    foreach(var task in tasks)
                    {
                        if(task.getSetTaskStatus == "In Progress"){
                            Console.WriteLine("Task: {0} \nDiscreption: {1} \nStatus: {2} ", task.getSetTaskName, task.getSetTaskDisc, task.getSetTaskStatus);
                        }
                    }
                }
                else{
                    Console.WriteLine("No In Progress tasks");
                }
                break;
                case 4:
                if(ToDo > 0){
                    foreach(var task in tasks)
                    {
                        if(task.getSetTaskStatus == "Done"){
                            Console.WriteLine("Task: {0} \nDiscreption: {1} \nStatus: {2} ", task.getSetTaskName, task.getSetTaskDisc, task.getSetTaskStatus);
                        }
                    }
                }
                else{
                    Console.WriteLine("No Done tasks");
                }
                break;
                default: 
                Console.WriteLine(""); // do this
                break;  
            }
        }

        void mainMethod(){
            while(toStop){
                Console.WriteLine("1. Add new task");
                Console.WriteLine("2. Show tasks");
                Console.WriteLine("3. Change Status");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice){
                    case 1:
                    addNewTask();
                    break;

                    case 2:
                    showAllTasks();
                    break;

                    case 3:
                    //changeStatus();
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
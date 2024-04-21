//To Do List v1.1
//Done By: Tamim Salhab

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
        void AddNewTask() 
        {
            Console.WriteLine("Enter task title:");
            string? taskTitle = Console.ReadLine();
            if(taskTitle == ""){
                Console.WriteLine("Error, please enter non empty name");
                MainMethod();
            }
            else{
                Console.WriteLine("Enter task description:");
                string? taskDisc = Console.ReadLine();            
                Status taskStatus = Status.toDo;
                int id = GenerateId();
                Task newTask = new Task(id, taskTitle, taskDisc, taskStatus);
                ToDo++;
                tasks.Add(newTask);
            }
        } 
        Status ChooseStatus()
        {
            Console.WriteLine("--------------------------------");
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
            Status status;
            switch(statusChoice)
            {
                case 1:
                status = Status.inProgress;
                InProgress++;
                break;

                case 2:
                status = Status.toDo;
                ToDo++;
                break;

                case 3:
                status = Status.done;
                Done++;
                break;

                default:
                Console.WriteLine("Please choose one of the three status");
                status = ChooseStatus();
                break;
            }
            return status;
        }
        int GenerateId(){
            id++;
            return id;
        }
        void ChangeStatus()
        {
            Console.WriteLine("All Tasks");
            foreach (var task in tasks){
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
                    Status oldStatus = task.getSetTaskStatus;
                    switch(oldStatus){
                        case Status.toDo:
                        ToDo--;
                        break;
                        case Status.inProgress:
                        InProgress--;
                        break;
                        case Status.done:
                        Done--;
                        break;
                    }
                }
            }
            if(found == true){
                Status newStatus = ChooseStatus();
                tasks[index].getSetTaskStatus = newStatus;
            }
            else{
                Console.WriteLine("Enter valid number");
            }
        }
        string GetToPrintStatus(Status status){
            string toPrintStatus = "";
            switch(status){
                case Status.done:
                toPrintStatus = "Done";
                break;
                case Status.toDo:
                toPrintStatus = "To Do";
                break;
                case Status.inProgress:
                toPrintStatus = "In Progress";
                break;
                case Status.emptyStatus:
                toPrintStatus = "";
                break;
            }
            return toPrintStatus;
        }
        void PrintTasks(Status status, int count){
            if(Status.emptyStatus == status){
                if(count > 0){
                    foreach(var task in tasks){
                        Console.WriteLine("Task: {0} \nDiscreption: {1} \nStatus: {2} ", task.getSetTaskName, task.getSetTaskDisc, GetToPrintStatus(task.getSetTaskStatus));
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
                            Console.WriteLine("Task: {0} \nDiscreption: {1} \nStatus: {2} ", task.getSetTaskName, task.getSetTaskDisc, GetToPrintStatus(task.getSetTaskStatus));
                        }
                    }
                }
                else{
                    Console.WriteLine("No tasks added!");
                }
            }
        }
        void ShowAllTasks()
        {    
            Console.WriteLine("--------------------------------");
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
                PrintTasks(Status.emptyStatus, count);

                break;
                case 2:
                count = ToDo;
                PrintTasks(Status.toDo, count);
                
                break;
                case 3:
                count = InProgress;
                PrintTasks(Status.inProgress, count);
                
                break;
                case 4:
                count = Done;
                PrintTasks(Status.done, count);
                
                break;
                default: 
                Console.WriteLine("Please Enter one of the avaliable choices");
                MainMethod();
                break;  
            }
        }
        void MainMethod(){
            while(toStop){
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Add new task");
                Console.WriteLine("2. Show tasks");
                Console.WriteLine("3. Change status");
                Console.WriteLine("4. Exit");
                int choice = 0;
                try {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch{
                    Console.WriteLine("Please Enter one of the avaliable numbers");
                }   
                switch(choice){
                    case 1:
                    AddNewTask();
                    break;

                    case 2:
                        if(tasks.Count() > 0){
                            ShowAllTasks();
                        }
                        else{
                            Console.WriteLine("No tasks were added yet");
                        }
                    break;

                    case 3:
                        if(tasks.Count() > 0){
                            ChangeStatus();
                        }
                        else{
                            Console.WriteLine("No tasks were added yet");
                        }
                    break;

                    case 4:
                    toStop = false;
                    break;
                }
            }
        }
        MainMethod();
    } 
} 
enum Status{
    toDo,
    done,
    inProgress,
    emptyStatus
}
class Task{
    private int taskId;
    private string taskName;
    private string taskDisc;
    private Status taskStatus;

    Guid guidId = Guid.NewGuid();

    public Task(){
    }
    public Task(int id, string name, string disc, Status status){
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
    public Status getSetTaskStatus{
        get{return taskStatus;}
        set{taskStatus = value;}
    }
}
//To Do app
//Done By: Tamim Salhab

//declaring variables





var taskTitleAndDisc = new Dictionary<string, string>();
Dictionary<string, string> taskTitleAndStatus = new();
var ToDo = 0;
int InProgress = 0, Done = 0;
bool toStop = true;
// enum statuses{
//     todo = 0, inprogress = 0, done =0
// }






//adding new task method 
void addNewTask() 
{
    Console.WriteLine("Enter task title:");
    string? taskTitle = Console.ReadLine();
    Console.WriteLine("Enter task description:");
    string? taskDisc = Console.ReadLine();
    taskTitleAndDisc.Add(taskTitle,taskDisc);
    string taskStatus = chooseStatus();
    taskTitleAndStatus.Add(taskTitle, taskStatus); 
}

//showing all tasks method
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
        if(taskTitleAndDisc.Count() > 0){
            foreach (KeyValuePair<string, string> items in taskTitleAndDisc)
            {
                Console.WriteLine("{0} : {1} : {2}", items.Key, items.Value, taskTitleAndStatus[items.Key]);
            }
        }
        break;
        case 2:
        if(ToDo > 0){
            foreach (KeyValuePair<string, string> items in taskTitleAndDisc)
            {
                if(taskTitleAndStatus[items.Key] == "To Do")
                {
                    Console.WriteLine("{0} : {1} : {2}", items.Key, items.Value, taskTitleAndStatus[items.Key]);
                }
            }
        }
        break;
        case 3:
        if(InProgress > 0){
            foreach (KeyValuePair<string, string> items in taskTitleAndDisc)
            {
                if(taskTitleAndStatus[items.Key] == "In Progress")
                {
                    Console.WriteLine("{0} : {1} : {2}", items.Key, items.Value, taskTitleAndStatus[items.Key]);
                }
            }
        }
        break;
        case 4:
        if(Done > 0){
            foreach (KeyValuePair<string, string> items in taskTitleAndDisc)
            {
                if(taskTitleAndStatus[items.Key] == "Done")
                {
                    Console.WriteLine("{0} : {1} : {2}", items.Key, items.Value, taskTitleAndStatus[items.Key]);
                }
            }
        }
        break;

    }
}

string chooseStatus()
{
    Console.WriteLine("Enter a status number:");
    Console.WriteLine("1. In Progress");
    Console.WriteLine("2. To DO");
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

void changeStatus()
{
    Console.WriteLine("All Tasks");
    foreach (KeyValuePair<string, string> items in taskTitleAndDisc)
    {
        Console.WriteLine("{0} : {1}", items.Key, taskTitleAndStatus[items.Key]);
    }
    Console.WriteLine("Enter Task title to change status:");
    string? titleStatusToChange = "";
    titleStatusToChange = Console.ReadLine();
    if(!taskTitleAndStatus.ContainsKey(titleStatusToChange))
    {
        Console.WriteLine("Please enter valid name");
        mainMethod();
    }
    else{
        Console.WriteLine("Current Status: " + taskTitleAndStatus[titleStatusToChange]);
        string currentStatus = taskTitleAndStatus[titleStatusToChange];
        switch(currentStatus)
        {
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
        string status = chooseStatus();
        taskTitleAndStatus[titleStatusToChange] = status;
        switch(status)
        {
            case "To Do":
            ToDo++;
            break;

            case "In Progress":
            InProgress++;
            break;

            case "Done":
            Done++;
            break;
        }
        Console.WriteLine("Status Changed Successefully");
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
            changeStatus();
            break;

            case 4:
            toStop = false;
            break;
        }
    }
}

mainMethod();
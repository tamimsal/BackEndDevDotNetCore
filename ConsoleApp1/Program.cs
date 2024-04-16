Dictionary<string, string> taskTitleAndDisc = new Dictionary<string, string>();
Dictionary<string, string> taskTitleAndStatus = new Dictionary<string, string>();

void addNewTask() 
{
    Console.WriteLine("Enter task title:");
    string taskTitle = Console.ReadLine();
    Console.WriteLine("Enter task Discreption:");
    string taskDisc = Console.ReadLine();
    taskTitleAndDisc.Add(taskTitle,taskDisc);

    string taskStatus = chooseStatus();
    taskTitleAndStatus.Add(taskTitle, taskStatus);

}

void showAllTasks()
{    
    Console.WriteLine("Enter the number of tasks category:");
    Console.WriteLine("1. All Tasks");
    Console.WriteLine("2. To Do Tasks");
    Console.WriteLine("3. In Progress Tasks");
    Console.WriteLine("4. Done Tasks");
    int catChoice = Convert.ToInt32(Console.ReadLine());

    switch(catChoice){
        case 1:
            foreach (KeyValuePair<string, string> items in taskTitleAndDisc)
            {
                Console.WriteLine("{0} : {1} : {2}", items.Key, items.Value, taskTitleAndStatus[items.Key]);
            }
            break;
        case 2:
            foreach (KeyValuePair<string, string> items in taskTitleAndDisc)
            {
                if(taskTitleAndStatus[items.Key] == "To Do")
                    Console.WriteLine("{0} : {1} : {2}", items.Key, items.Value, taskTitleAndStatus[items.Key]);
            }
            break;
        case 3:
            foreach (KeyValuePair<string, string> items in taskTitleAndDisc)
            {
                if(taskTitleAndStatus[items.Key] == "In Progress")
                    Console.WriteLine("{0} : {1} : {2}", items.Key, items.Value, taskTitleAndStatus[items.Key]);
            }
            break;
        case 4:
            foreach (KeyValuePair<string, string> items in taskTitleAndDisc)
            {
                if(taskTitleAndStatus[items.Key] == "Done")
                    Console.WriteLine("{0} : {1} : {2}", items.Key, items.Value, taskTitleAndStatus[items.Key]);
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
            break;
        case 2:
            status = "To Do";
            break;
        case 3:
            status = "Done";
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
    string titleStatusToChange = Console.ReadLine();
    Console.WriteLine("Current Status: " + taskTitleAndStatus[titleStatusToChange]);

    string status = chooseStatus();
    taskTitleAndStatus[titleStatusToChange] = status;
    Console.WriteLine("Status Changed Successefully");
}
    

    
bool f = true;
while(f){
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
            f = false;
        break;
    }
}
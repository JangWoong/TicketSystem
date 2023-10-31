using NLog;

string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.Setup().LoadConfigurationFromFile(path).GetCurrentClassLogger();
logger.Info("Program started");

string ticketFile = "Tickets.csv", enhancementsFile = "Enhancements.csv", taskFile = "Task.csv";
TicketsFile tf = new TicketsFile(ticketFile, enhancementsFile, taskFile);
string choice;

do
{
    // ask user a question
    Console.WriteLine("1) Read data from file.");
    Console.WriteLine("2) Create file from data.");
    Console.WriteLine("3) Add records to the file.");
    Console.WriteLine("4) Search");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();
    logger.Info($"User select is {choice}");

    if (choice == "1") // Read data
    {
        int selectData = 0;

        Console.WriteLine("\tSelect data file.\n\t1) Tickets\t2) Enhancements\t3)Task");
        bool selectCheck = int.TryParse(Console.ReadLine(), out selectData);
        logger.Info($"User select is {selectData}");

        if(selectCheck)
        {
            // read data from file
            switch(selectData)
            {
                case 1: // Tickets
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach(Ticket t in tf.TicketList)
                    {
                        Console.WriteLine(t.Display());
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2: // Enhancements
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach(Enhancement e in tf.EnhancementList)
                    {
                        Console.WriteLine(e.Display());
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3: // Task
                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach(Task ta in tf.TaskList)
                    {
                        Console.WriteLine(ta.Display());
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    logger.Error($"{selectData}: It is a wrong choice.");
                    break;
            }
        }
        else
        {
            logger.Info($"Input Error.");
        }
    }
    else if (choice == "2") // create file 
    {
        int selectCreateFile = 0;

        Console.WriteLine("\tSelect create file.\n\t1) Tickets\t2) Enhancements\t3)Task");
        bool selectCheck = int.TryParse(Console.ReadLine(), out selectCreateFile);
        logger.Info($"User select is {selectCreateFile}");

        if(selectCheck)
        {
            // read data from file
            switch(selectCreateFile)
            {
                case 1: // Tickets

                // create file from data
                StreamWriter sw = new(ticketFile);
                // save header
                sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Severity");
                bool datainput = true;
                int ticketID = 1;

                while (datainput)
                {
                    Console.Write("Enter the Summary: ");
                    string summary = Console.ReadLine();

                    Console.Write("Enter the Status: ");
                    string status = Console.ReadLine();

                    Console.Write("Enter the Priority: ");
                    string priority = Console.ReadLine();

                    Console.Write("Enter the Submitter: ");
                    string submitter = Console.ReadLine();

                    Console.Write("Enter the Assigned: ");
                    string assigned = Console.ReadLine();

                    Console.Write("Enter the Watching: ");
                    string watching = Console.ReadLine();

                    Console.Write("Enter the Severity: ");
                    string severity = Console.ReadLine();

                    // save 
                    sw.WriteLine($"\n{ticketID.ToString()},{summary},{status},{priority},{submitter},{assigned},{watching},{severity}");
                    // ask a question
                    Console.WriteLine("Do you want more input data (Y/N)? Pressing any key other than 'Y' will exit.");
                    if(Console.ReadLine().ToUpper() == "Y")
                        datainput = true;
                    else
                        datainput = false;

                    ticketID++;
                }
                sw.Close();

                break;

                case 2: // Enhancements

                // create file from data
                StreamWriter swe = new(enhancementsFile);
                // save header
                swe.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Software, Cost, Reason, Estimate");
                bool dataEinput = true;
                int ticketEID = 1;

                while (dataEinput)
                {
                    Console.Write("Enter the Summary: ");
                    string summary = Console.ReadLine();

                    Console.Write("Enter the Status: ");
                    string status = Console.ReadLine();

                    Console.Write("Enter the Priority: ");
                    string priority = Console.ReadLine();

                    Console.Write("Enter the Submitter: ");
                    string submitter = Console.ReadLine();

                    Console.Write("Enter the Assigned: ");
                    string assigned = Console.ReadLine();

                    Console.Write("Enter the Watching: ");
                    string watching = Console.ReadLine();

                    Console.Write("Enter the Software: ");
                    string software = Console.ReadLine();

                    Console.Write("Enter the Cost: ");
                    string cost = Console.ReadLine();

                    Console.Write("Enter the Reason: ");
                    string reason = Console.ReadLine();

                    Console.Write("Enter the Estimate: ");
                    string estimate = Console.ReadLine();


                    // save 
                    swe.WriteLine($"\n{ticketEID.ToString()},{summary},{status},{priority},{submitter},{assigned},{watching},{software},{cost},{reason},{estimate}");
                    // ask a question
                    Console.WriteLine("Do you want more input data (Y/N)? Pressing any key other than 'Y' will exit.");
                    if(Console.ReadLine().ToUpper() == "Y")
                        dataEinput = true;
                    else
                        dataEinput = false;

                    ticketEID++;
                }
                swe.Close();

                break;

                case 3: // Task

                // create file from data
                StreamWriter swt = new(taskFile);
                // save header
                swt.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, ProjectName, DueDate");
                bool dataTinput = true;
                int ticketTID = 1;

                while (dataTinput)
                {
                    Console.Write("Enter the Summary: ");
                    string summary = Console.ReadLine();

                    Console.Write("Enter the Status: ");
                    string status = Console.ReadLine();

                    Console.Write("Enter the Priority: ");
                    string priority = Console.ReadLine();

                    Console.Write("Enter the Submitter: ");
                    string submitter = Console.ReadLine();

                    Console.Write("Enter the Assigned: ");
                    string assigned = Console.ReadLine();

                    Console.Write("Enter the Watching: ");
                    string watching = Console.ReadLine();

                    Console.Write("Enter the ProjectName: ");
                    string projectName = Console.ReadLine();

                    Console.Write("Enter the DueDate: ");
                    string dueDate = Console.ReadLine();

                    // save 
                    swt.WriteLine($"\n{ticketTID.ToString()},{summary},{status},{priority},{submitter},{assigned},{watching},{projectName},{dueDate}");
                    // ask a question
                    Console.WriteLine("Do you want more input data (Y/N)? Pressing any key other than 'Y' will exit.");
                    if(Console.ReadLine().ToUpper() == "Y")
                        dataTinput = true;
                    else
                        dataTinput = false;

                    ticketTID++;
                }
                swt.Close();

                break;
            }
        }
    }
    else if (choice == "3") // Add data
    {
        int selectAddFile = 0;

        Console.WriteLine("\tSelect read file.\n\t1) Tickets\t2) Enhancements\t3)Task");
        bool selectCheck = int.TryParse(Console.ReadLine(), out selectAddFile);
        logger.Info($"User select is {selectAddFile}");

        if(selectCheck)
        {
            // add data from file
            switch(selectAddFile)
            {
                case 1: // Tickets
                    // read data from file
                    if (File.Exists(ticketFile))
                    {
                        Ticket ti = new Ticket();

                        // read data from file
                        Console.ForegroundColor = ConsoleColor.Red;
                        foreach(Ticket t in tf.TicketList)
                        {
                            Console.WriteLine(t.Display());
                        }
                        Console.ForegroundColor = ConsoleColor.White;

                        bool datainput = true;

                        while (datainput)
                        {
                            Console.Write("Enter the Summary: ");
                            ti.Summary = Console.ReadLine();

                            Console.Write("Enter the Status: ");
                            ti.Status = Console.ReadLine();

                            Console.Write("Enter the Priority: ");
                            ti.Priority = Console.ReadLine();

                            Console.Write("Enter the Submitter: ");
                            ti.Submitter = Console.ReadLine();

                            Console.Write("Enter the Assigned: ");
                            ti.Assigned = Console.ReadLine();

                            Console.Write("Enter the Watching: ");
                            ti.Watching = Console.ReadLine();

                            Console.Write("Enter the Severity: ");
                            ti.Severity = Console.ReadLine();

                            // save 
                            tf.AddTicketList(ti);
                            // ask a question
                            Console.WriteLine("Do you want more input data (Y/N)? Pressing any key other than 'Y' will exit.");
                            if(Console.ReadLine().ToUpper() == "Y")
                                datainput = true;
                            else
                                datainput = false;
                        }
                    }
                    else
                    {
                        logger.Error($"{ticketFile} File does not exist");
                    }

                break;
                
                case 2: // Enhancements
                    // read data from file
                    if (File.Exists(enhancementsFile))
                    {
                        Enhancement en = new Enhancement();

                        Console.ForegroundColor = ConsoleColor.Green;
                        foreach(Enhancement e in tf.EnhancementList)
                        {
                            Console.WriteLine(e.Display());
                        }
                        Console.ForegroundColor = ConsoleColor.White;

                        bool datainput = true;

                        while (datainput)
                        {
                            Console.Write("Enter the Summary: ");
                            en.Summary = Console.ReadLine();

                            Console.Write("Enter the Status: ");
                            en.Status = Console.ReadLine();

                            Console.Write("Enter the Priority: ");
                            en.Priority = Console.ReadLine();

                            Console.Write("Enter the Submitter: ");
                            en.Submitter = Console.ReadLine();

                            Console.Write("Enter the Assigned: ");
                            en.Assigned = Console.ReadLine();

                            Console.Write("Enter the Watching: ");
                            en.Watching = Console.ReadLine();

                            Console.Write("Enter the Software: ");
                            en.Software = Console.ReadLine();

                            Console.Write("Enter the Cost: ");
                            en.Cost = Console.ReadLine();

                            Console.Write("Enter the Reason: ");
                            en.Reason = Console.ReadLine();

                            Console.Write("Enter the Estimate: ");
                            en.Estimate = Console.ReadLine();

                            // save 
                            tf.AddEnhancementList(en);
                            
                            // ask a question
                            Console.WriteLine("Do you want more input data (Y/N)? Pressing any key other than 'Y' will exit.");
                            if(Console.ReadLine().ToUpper() == "Y")
                                datainput = true;
                            else
                                datainput = false;
                        }
                    }
                    else
                    {
                        logger.Error($"{enhancementsFile} File does not exist");
                    }

                break;
                
                case 3: // Task
                    // read data from file
                    if (File.Exists(taskFile))
                    {
                        Task task = new Task();

                        // read data from file
                        Console.ForegroundColor = ConsoleColor.Blue;
                        foreach(Task ta in tf.TaskList)
                        {
                            Console.WriteLine(ta.Display());
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    
                        bool datainput = true;

                        while (datainput)
                        {
                            Console.Write("Enter the Summary: ");
                            task.Summary = Console.ReadLine();

                            Console.Write("Enter the Status: ");
                            task.Status = Console.ReadLine();

                            Console.Write("Enter the Priority: ");
                            task.Priority = Console.ReadLine();

                            Console.Write("Enter the Submitter: ");
                            task.Submitter = Console.ReadLine();

                            Console.Write("Enter the Assigned: ");
                            task.Assigned = Console.ReadLine();

                            Console.Write("Enter the Watching: ");
                            task.Watching = Console.ReadLine();

                            Console.Write("Enter the ProjectName: ");
                            task.ProjectName = Console.ReadLine();

                            Console.Write("Enter the DueDate: ");
                            task.DueDate = Console.ReadLine();

                            // save 
                            tf.AddTaskList(task);
                            // ask a question
                            Console.WriteLine("Do you want more input data (Y/N)? Pressing any key other than 'Y' will exit.");
                            if(Console.ReadLine().ToUpper() == "Y")
                                datainput = true;
                            else
                                datainput = false;
                        }
                        
                    }
                    else
                    {
                        logger.Error($"{taskFile} File does not exist");
                    }

                break;
            }
        }
    }
    else if (choice == "4") // Search data
    {
        int selectAddFile = 0;

        Console.WriteLine("\tSelect search file.\n\t1) Tickets\t2) Enhancements\t3)Task");
        bool selectCheck = int.TryParse(Console.ReadLine(), out selectAddFile);
        logger.Info($"User select is {selectAddFile}");

        if(selectCheck)
        {
            // add data from file
            switch(selectAddFile)
            {
                case 1: // Tickets
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write("Enter search based on status, priority or submitter: ");
                    string search = Console.ReadLine();
                    var status = tf.TicketList.Where(m=>m.Status.Contains(search));
                    var priority = tf.TicketList.Where(m=>m.Priority.Contains(search));
                    var submitter = tf.TicketList.Where(m=>m.Submitter.Contains(search));

                    Console.WriteLine($"Matches number is {status.Count()}");

                    foreach(Ticket t in status)
                    {
                        Console.WriteLine(t.Display());
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2: // Enhancements
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write("Enter search based on status, priority or submitter: ");
                    string searchE = Console.ReadLine();
                    var statusE = tf.EnhancementList.Where(m=>m.Status.Contains(searchE));
                    var priorityE = tf.EnhancementList.Where(m=>m.Priority.Contains(searchE));
                    var submitterE = tf.EnhancementList.Where(m=>m.Submitter.Contains(searchE));

                    Console.WriteLine($"Matches number is {statusE.Count()}");

                    foreach(Enhancement e in statusE)
                    {
                        Console.WriteLine(e.Display());
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3: // Task
                    Console.ForegroundColor = ConsoleColor.Blue;
                    
                    Console.Write("Enter search based on status, priority or submitter: ");
                    string searchT = Console.ReadLine();
                    var statusT = tf.TaskList.Where(m=>m.Status.Contains(searchT));
                    var priorityT = tf.TaskList.Where(m=>m.Priority.Contains(searchT));
                    var submitterT = tf.TaskList.Where(m=>m.Submitter.Contains(searchT));

                    Console.WriteLine($"Matches number is {statusT.Count()}");

                    foreach(Task ta in statusT)
                    {
                        Console.WriteLine(ta.Display());
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;  
            }
        }
    }
} while (choice == "1" || choice == "2"|| choice == "3"|| choice == "4");

logger.Info("Program end");
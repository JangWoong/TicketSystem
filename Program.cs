using NLog;

string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.Setup().LoadConfigurationFromFile(path).GetCurrentClassLogger();
logger.Info("Program started");

string ticketsFile = "Tickets.csv", enhancementsFile = "Enhancements.csv", taskFile = "Task.csv";
string choice;

do
{
    // ask user a question
    Console.WriteLine("1) Read data from file.");
    Console.WriteLine("2) Create file from data.");
    Console.WriteLine("3) Add records to the file.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();
    logger.Info($"User select is {choice}");

    if (choice == "1") // Read data
    {
        int selectReadFile = 0;

        Console.WriteLine("\tSelect data file.\n\t1) Tickets\t2) Enhancements\t3)Task");
        bool selectCheck = int.TryParse(Console.ReadLine(), out selectReadFile);
        logger.Info($"User select is {selectReadFile}");

        if(selectCheck)
        {
            // read data from file
            switch(selectReadFile)
            {
                case 1: // Tickets
                    if (File.Exists(ticketsFile))
                    {
                        // read data from file
                        StreamReader sr = new(ticketsFile);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // display data
                            Console.WriteLine(line);
                        }
                        sr.Close();
                    }
                    else
                    {
                        logger.Info("Tickets File does not exist");
                    }
                    break;
                case 2: // Enhancements
                    if (File.Exists(enhancementsFile))
                    {
                        // read data from file
                        StreamReader sr = new(enhancementsFile);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // display data
                            Console.WriteLine(line);
                        }
                        sr.Close();
                    }
                    else
                    {
                        logger.Info("Enhancements File does not exist");
                    }
                    break;
                case 3: // Task
                    if (File.Exists(taskFile))
                    {
                        // read data from file
                        StreamReader sr = new(taskFile);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // display data
                            Console.WriteLine(line);
                        }
                        sr.Close();
                    }
                    else
                    {
                        logger.Info("Task File does not exist");
                    }
                    break;
                default:
                    logger.Error($"{selectReadFile}: It is a wrong choice.");
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
                StreamWriter sw = new(ticketsFile);
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
    else if (choice == "3")
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
                    if (File.Exists(ticketsFile))
                    {
                        int ticketID = 1;

                        // read data from file
                        StreamReader sr = new(ticketsFile);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] arr = line.Split(',');
                            
                            // check the number
                            bool result  = int.TryParse(arr[0], out ticketID);

                            // display data
                            Console.WriteLine(line);
                        }
                        sr.Close();

                        StreamWriter sw = File.AppendText(ticketsFile);
                        bool datainput = true;

                        while (datainput)
                        {
                            ticketID++;

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
                        }
                        sw.Close();
                    }
                    else
                    {
                        logger.Error($"{ticketsFile} File does not exist");
                    }

                break;
                
                case 2: // Enhancements
                    // read data from file
                    if (File.Exists(enhancementsFile))
                    {
                        int ticketID = 1;

                        // read data from file
                        StreamReader sr = new(enhancementsFile);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] arr = line.Split(',');
                            
                            // check the number
                            bool result  = int.TryParse(arr[0], out ticketID);

                            // display data
                            Console.WriteLine(line);
                        }
                        sr.Close();

                        StreamWriter sw = File.AppendText(enhancementsFile);
                        bool datainput = true;

                        while (datainput)
                        {
                            ticketID++;

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
                            sw.WriteLine($"\n{ticketID.ToString()},{summary},{status},{priority},{submitter},{assigned},{watching},{software},{cost},{reason},{estimate}");
                            // ask a question
                            Console.WriteLine("Do you want more input data (Y/N)? Pressing any key other than 'Y' will exit.");
                            if(Console.ReadLine().ToUpper() == "Y")
                                datainput = true;
                            else
                                datainput = false;
                        }
                        sw.Close();
                    }
                    else
                    {
                        logger.Error($"{enhancementsFile} File does not exist");
                    }

                break;
                
                case 3: // Tickets
                    // read data from file
                    if (File.Exists(taskFile))
                    {
                        int ticketID = 1;

                        // read data from file
                        StreamReader sr = new(taskFile);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] arr = line.Split(',');
                            
                            // check the number
                            bool result  = int.TryParse(arr[0], out ticketID);

                            // display data
                            Console.WriteLine(line);
                        }
                        sr.Close();

                        StreamWriter sw = File.AppendText(taskFile);
                        bool datainput = true;

                        while (datainput)
                        {
                            ticketID++;

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
                            sw.WriteLine($"\n{ticketID.ToString()},{summary},{status},{priority},{submitter},{assigned},{watching},{projectName},{dueDate}");
                            // ask a question
                            Console.WriteLine("Do you want more input data (Y/N)? Pressing any key other than 'Y' will exit.");
                            if(Console.ReadLine().ToUpper() == "Y")
                                datainput = true;
                            else
                                datainput = false;
                        }
                        sw.Close();
                    }
                    else
                    {
                        logger.Error($"{taskFile} File does not exist");
                    }

                break;
            }
        }
    }
} while (choice == "1" || choice == "2"|| choice == "3");

logger.Info("Program end");
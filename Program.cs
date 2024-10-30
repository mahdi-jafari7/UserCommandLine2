using HW10;
using HW10.Interfaces;
using HW10.Repo;
using HW10.Services;


IUserRepository userRepository = new UserRepository();
IAuth auth = new Auth(userRepository);
IService service = new Service(userRepository, auth);

Console.WriteLine("======== User Management Command Line ========");

while (true)
{
    Console.WriteLine("\n>> ");


    var input = Console.ReadLine();
    var commandParts = input.Split(' ');
    if (commandParts.Length == 0) continue;

    var command = commandParts[0].ToLower();
    switch (command)
    {
        case "register":
            if (commandParts.Length >= 5 && commandParts[1] == "--username" && commandParts[3] == "--password")
            {
                var username = commandParts[2];
                var password = commandParts[4];
                auth.Register(username, password);
            }
            else
            {
                Console.WriteLine("Invalid command. (ex: Register --username [username] --password [password])");
            }
            break;

        case "login":
            if (commandParts.Length >= 5 && commandParts[1] == "--username" && commandParts[3] == "--password")
            {
                var username = commandParts[2];
                var password = commandParts[4];
                auth.Login(username, password);
            }
            else
            {
                Console.WriteLine("Invalid command(ex: Login --username [username] --password [password])");
            }
            break;

        case "change":
            if (auth.IsUserLoggedIn())
            {
                if (commandParts.Length >= 3 && commandParts[1] == "--status")
                {
                    if (commandParts[2].ToLower() == "available")
                    {
                        
                        service.ChangeStatus(auth.GetCurrentUser(), true);
                    }
                    else if (commandParts[2].ToLower() == "not" && commandParts[3].ToLower() == "available")
                    {
                        service.ChangeStatus(auth.GetCurrentUser(), false);

                    }
                }
                else
                {
                    Console.WriteLine("Invalid command. ex: ChangeStatus --status [available|not available]");
                }
            }
            else
            {
                Console.WriteLine("You need to log in first to change status.");
            }
            break;

        case "changepassword":
            if (auth.IsUserLoggedIn())
            {
                if (commandParts.Length >= 5 && commandParts[1] == "--old" && commandParts[3] == "--new")
                {
                    var oldPassword = commandParts[2];
                    var newPassword = commandParts[4];
                    service.ChangePassword(auth.GetCurrentUser(), oldPassword, newPassword);
                }
                else
                {
                    Console.WriteLine("Invalid command. ex: ChangePassword --old [oldPassword] --new [newPassword]");
                }
            }
            else
            {
                Console.WriteLine("You need to log in first to change password.");
            }
            break;

        case "search":
            if (auth.IsUserLoggedIn())
            {
                if (commandParts.Length >= 3 && commandParts[1] == "--username")
                {
                    var searchWord = commandParts[2];
                    service.Search(searchWord);
                }
                else
                {
                    Console.WriteLine("Invalid command. ex: Search --username [searchWord]");
                }
            }
            else
            {
                Console.WriteLine("You need to log in first to search users.");
            }
            break;

        case "logout":
            if (auth.IsUserLoggedIn())
            {
                auth.Logout();
            }
            else
            {
                Console.WriteLine("No user is currently logged in.");
            }
            break;

        case "exit":
            Console.WriteLine("Exiting the program. Goodbye!");
            return;

        default:
            Console.WriteLine("Unknown command. Please try again.");
            break;
    }
}

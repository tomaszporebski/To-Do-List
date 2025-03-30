Console.WriteLine("Hello!\n");


List<string> toDosList = new List<string>();

while (true)
{
    WhatDoYouWantToDo();

    string userInput = Console.ReadLine();
    string userInputUpper = userInput.ToUpper();

    switch (userInputUpper)
    {
        case "S":
            SeeAllTodos();
            break;
        case "A":
            AddTodo();
            break;
        case "R":
            RemoveTodo();
            break;
        case "E":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid input\n");
            break;
    }
}

void WhatDoYouWantToDo()
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
}



void RemoveTodo()
{
    if (toDosList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.\n");
        return;
    }

    bool isIndexValid = false;
    while (!isIndexValid)
    {
        Console.WriteLine("Select the index of the TODO you want to remove:");
        SeeAllTodos();

        if (int.TryParse(Console.ReadLine(), out int index))
        {
            if (index > 0 && index <= toDosList.Count)
            {
                string removedTodo = toDosList[index - 1];
                toDosList.RemoveAt(index - 1);

                Console.WriteLine($"TODO removed: {removedTodo}\n");
                isIndexValid = true;
            }
            else
            {
                Console.WriteLine("The given index does not exist\n");
            }
        }
        else
        {
            Console.WriteLine("The given index is not valid.\n");
        }

    }

}

void AddTodo()
{
    bool isDescriptionValid = false;
    while (!isDescriptionValid)
    {
        Console.WriteLine("Enter the TODO description:");
        string description = Console.ReadLine();
        if (description == "")
        {
            Console.WriteLine("The description cannot be empty\n");
            continue;
        }
        else if (toDosList.Contains(description))
        {
            Console.WriteLine("The description must be unique\n");
            continue;
        }
        else
        {
            isDescriptionValid = true;
            toDosList.Add(description);
            Console.WriteLine($"TODO successfully added: {description}\n");
        }
    }
}

void SeeAllTodos()
{
    if (toDosList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.\n");
        return;
    }
    foreach (string item in toDosList)
    {
        string index = (toDosList.IndexOf(item) + 1).ToString();
        Console.WriteLine(index + ". " + item);
    }
}
Console.ReadKey();

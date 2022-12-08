namespace AdventOfCode.Solutions.Year2022.Day07;

internal class Solution : SolutionBase
{
    public Solution() : base(07, 2022, "No Space Left On Device")
    {
    }

    protected override string SolvePartOne()
    {
        var commands = Input.SplitByNewline();

        Dictionary<int, string> commandList = new();
        for (var x = 0; x < commands.Length; x++)
        {
            commandList.Add(x, commands[x]);
        }

        ElfFile baseFile = new()
        {
            Name = "/",
            IsDirectory = true,
        };
        ElfFile currentDirectory = baseFile;

        Dictionary<string, ElfFile> directoryHash = new();

        int commandIndex = 0;
        while (commandIndex < commands.Length)
        {
            var command = commandList[commandIndex];

            if (command.StartsWith("$"))
            {
                var arguments = command.Split(' ');
                if (arguments[1] == "cd")
                {
                    var directory = arguments[2];
                    if (directory == "/")
                    {
                        currentDirectory = baseFile;
                    }
                    else if (directory == ".." && currentDirectory.Parent != null)
                    {
                        currentDirectory = currentDirectory.Parent;
                    }
                    else
                    {
                        var nextDirectory = currentDirectory.Children
                            .FirstOrDefault(_ => _.Name == directory);

                        if (nextDirectory == null)
                        {
                            throw new Exception("Unable to file child directory " + directory);
                        }

                        currentDirectory = nextDirectory;
                    }

                    commandIndex++;
                }
                else if (arguments[1] == "ls")
                {
                    var nextCommands = commandList
                        .Where(_ => _.Key > commandIndex && _.Value.StartsWith("$"));

                    var nextCommandIndex = nextCommands.Any()
                        ? nextCommands.Min(_ => _.Key)
                        : commands.Length;

                    for (var x = commandIndex + 1; x < nextCommandIndex; x++)
                    {
                        var listResult = commandList[x];
                        var fileName = listResult.Split(' ')[1];

                        if (listResult.StartsWith("dir"))
                        {
                            ElfFile newDirectory = new()
                            {
                                Name = fileName,
                                Parent = currentDirectory,
                                IsDirectory = true
                            };

                            currentDirectory.Children.Add(newDirectory);
                            directoryHash.Add(newDirectory.HashKey, newDirectory);
                        }
                        else
                        {
                            int fileSize = int.Parse(listResult.Split(' ')[0]);

                            currentDirectory.Children.Add(new()
                            {
                                Name = fileName,
                                Size = fileSize,
                                IsDirectory = false
                            });
                        }
                    }

                    commandIndex = nextCommandIndex;
                }
            }
        }

        var filteredDirectories = directoryHash
            .Where(_ => _.Value.GetSize() < 100000);

        var result = filteredDirectories.Sum(_ => _.Value.GetSize());

        return result.ToString();
    }

    protected override string SolvePartTwo()
    {
        return "";
    }

    private class ElfFile
    {
        public string Name { get; set; } = string.Empty;
        public ElfFile? Parent { get; set; }
        public List<ElfFile> Children { get; set; } = new();
        public int Size { get; set; }
        public bool IsDirectory { get; set; }

        public string HashKey
            => $"{Name}-{Parent?.Name ?? string.Empty}";

        public int GetSize()
        {
            return IsDirectory
                ? Children.Sum(_ => _.GetSize())
                : Size;
        }
    }
}
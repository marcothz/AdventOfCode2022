namespace Puzzle07
{
    internal class FileSystem
    {
        private const string ParentPath = "..";
        private const string RootPath = "/";

        public FileSystem(int totalDiskSpace)
        {
            Root = new Folder(RootPath);
            CurrentFolder = Root;
            TotalDiskSpace = totalDiskSpace;
        }

        public int AvailableDiskSpace => TotalDiskSpace - UsedDiskSpace;

        public Folder CurrentFolder { get; private set; }

        public Folder Root { get; }

        public int TotalDiskSpace { get; }

        public int UsedDiskSpace { get; private set; }

        public void AddFile(string name, int size)
        {
            if (!CurrentFolder.FileExists(name))
            {
                CurrentFolder.AddFile(new File(name, size));
            }
            else
            {
                Console.WriteLine($"File \"{name}\" already exist");
            }
        }

        public void AddFolder(string name)
        {
            if (!CurrentFolder.FolderExists(name))
            {
                CurrentFolder.AddFolder(new Folder(name));
            }
            else
            {
                Console.WriteLine($"Folder \"{name}\" already exist");
            }
        }

        public void ChangeFolder(string folderName)
        {
            if (folderName == RootPath)
            {
                CurrentFolder = Root;
            }
            else if (folderName == ParentPath)
            {
                CurrentFolder = CurrentFolder.Parent ?? Root;
            }
            else
            {
                if (!CurrentFolder.FolderExists(folderName))
                {
                    CurrentFolder.AddFolder(new Folder(folderName));
                }

                CurrentFolder = CurrentFolder.Folders.First(f => f.Name == folderName);
            }
        }

        internal int ComputeSize()
        {
            UsedDiskSpace = Root.ComputeSize();

            return UsedDiskSpace;
        }

        internal IEnumerable<Folder> GetFoldersBySize(int? minSize, int? maxSize)
        {
            var selectedFolders = new List<Folder>();

            if ((maxSize == null || Root.Size <= maxSize)
                && (minSize == null || Root.Size >= minSize))
            {
                selectedFolders.Add(Root);
            }

            selectedFolders.AddRange(Root.GetFoldersBySize(minSize, maxSize));

            return selectedFolders;
        }
    }
}
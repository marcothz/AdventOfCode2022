namespace Puzzle07
{
    internal class Folder
    {
        private readonly Dictionary<string, File> _files = new();
        private readonly Dictionary<string, Folder> _folders = new();

        public Folder(string name)
        {
            Name = name;
        }

        public IEnumerable<File> Files => _files.Values;

        public IEnumerable<Folder> Folders => _folders.Values;

        public string Name { get; }
        public Folder? Parent { get; private set; }
        public int Size { get; private set; }

        public void AddFile(File file)
        {
            _files.Add(file.Name, file);
        }

        public void AddFolder(Folder folder)
        {
            folder.Parent = this;
            _folders.Add(folder.Name, folder);
        }

        public bool FileExists(string name)
        {
            return _files.ContainsKey(name);
        }

        public bool FolderExists(string name)
        {
            return _folders.ContainsKey(name);
        }

        internal int ComputeSize()
        {
            Size = Files.Sum(f => f.Size) + Folders.Sum(f => f.ComputeSize());

            return Size;
        }

        internal IEnumerable<Folder> GetFoldersBySize(int? minSize, int? maxSize)
        {
            var selectedFolders = new List<Folder>();

            foreach (Folder folder in Folders)
            {
                if ((maxSize == null || folder.Size <= maxSize)
                    && (minSize == null || folder.Size >= minSize))
                {
                    selectedFolders.Add(folder);
                }

                selectedFolders.AddRange(folder.GetFoldersBySize(minSize, maxSize));
            }

            return selectedFolders;
        }
    }
}
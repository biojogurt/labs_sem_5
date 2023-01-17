using System.ComponentModel;
using System.Runtime.InteropServices;
using static lab_os_2.Kernel32Import;

namespace lab_os_2
{
    internal class FileManager
    {
        private static IEnumerable<WIN32_FIND_DATA> GetInternal(string path, bool isGetDirs)
        {
            IntPtr findHandle = FindFirstFile(Path.Combine(path, "*"), out WIN32_FIND_DATA findData);

            if (findHandle == INVALID_HANDLE_VALUE)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            try
            {
                do
                {
                    if (isGetDirs
                        ? (findData.dwFileAttributes & FileAttributes.Directory) != 0
                        : (findData.dwFileAttributes & FileAttributes.Directory) == 0)
                    {
                        yield return findData;
                    }
                }
                while (FindNextFile(findHandle, out findData));
            }
            finally
            {
                FindClose(findHandle);
            }
        }

        public static IEnumerable<string> GetDirectoriesNames(string path)
        {
            foreach (WIN32_FIND_DATA directory in GetInternal(path, true))
            {
                yield return directory.cFileName;
            }
        }

        public static IEnumerable<string> GetAllDirectoriesPaths(string path)
        {
            foreach (string subDir in GetDirectoriesNames(path))
            {
                if (subDir == ".." || subDir == ".")
                {
                    continue;
                }

                string relativePath = Path.Combine(path, subDir);
                yield return relativePath;

                foreach (string subDir2 in GetAllDirectoriesPaths(relativePath))
                {
                    yield return subDir2;
                }
            }
        }

        public static IEnumerable<ulong> GetFilesSizes(string path)
        {
            foreach (WIN32_FIND_DATA file in GetInternal(path, false))
            {
                yield return (file.nFileSizeHigh * (uint.MaxValue + (ulong) 1)) + file.nFileSizeLow;
            }
        }

        public static ulong GetDirectorySum(string path)
        {
            ulong sum = 0;

            foreach (ulong size in GetFilesSizes(path))
            {
                sum += size;
            }

            return sum;
        }

        public static IEnumerable<ulong> GetAllDirectoriesSizeSums(string path)
        {
            yield return GetDirectorySum(path);

            foreach (string subPath in GetAllDirectoriesPaths(path))
            {
                yield return GetDirectorySum(subPath);
            }
        }

        public static IEnumerable<ulong> GetQualifiedSums(string path, ulong minSize)
        {
            foreach (ulong size in GetAllDirectoriesSizeSums(path))
            {
                if (size > minSize)
                {
                    yield return size;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScanFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter name of disk to be scanned (e.g. 'C:\\'): ");
            var dirPath = Console.ReadLine();
            
            ScanFolders(dirPath);

            Console.ReadLine();
        }

        public static void ScanFolders(object dirPath)
        {
            var dirPath2 = dirPath.ToString();
            try
            {
                FoldersOutput(dirPath2);

                foreach (var dir in Directory.GetDirectories(dirPath2))
                {
                    var delegate1 = new ParameterizedThreadStart(ScanFolders);
                    Thread thread = new Thread(delegate1);
                    thread.Start(dir);
                }
            }
            catch (UnauthorizedAccessException err)
            {
                Console.WriteLine("no access");
            }
            //Console.WriteLine("{0} directories found.", dirs.Count);

        }

        public static void FoldersOutput(string dirPath)
        {
            Console.WriteLine(dirPath);
        }



    }
}


//foreach (var dir in dirs)
//               {
//                   var folders = new List<string>(Directory.EnumerateDirectories(dirs[i]));

//                   if (folders != null)
//                   {
//                       //dirs.AddRange(ScanFolders(folders));
//                       dirs.AddRange(folders);
//                       FoldersOutput(dirs);
//                   }
//                   i++;

//               }


//}
//        catch (InvalidOperationException IOEx)
//        {
//            Console.WriteLine(IOEx.Message);
//        }
//        catch (UnauthorizedAccessException UAEx)
//        {
//            Console.WriteLine(UAEx.Message);

//        }
//        catch (PathTooLongException PathEx)
//        {
//            Console.WriteLine(PathEx.Message);
//        }
//        catch (AccessViolationException AccessEx)
//        {
//            Console.WriteLine(AccessEx.Message);
//        }

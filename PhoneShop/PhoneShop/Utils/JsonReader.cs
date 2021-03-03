using System.IO;
using System.Reflection;

namespace PhoneShop.Utils
{
    public class JsonReader
    {
        private const string FileName = "appsettings.json";
        
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public static string ReadJsonFile()
        {
            var pathToFile = GetPathToFile();

            try
            {
                using var streamReader = File.OpenText(pathToFile);
               
                return streamReader.ReadToEnd();
            }
            catch (FileNotFoundException e)
            {
                Logger.Error($"The file was not found: '{e}'");
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                Logger.Error($"The directory was not found: '{e}'");
                throw;
            }
            catch (IOException e)
            {
                Logger.Error($"The file could not be opened: '{e}'");
                throw;
            }
        }

        private static string GetPathToFile()
        { 
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var separatorChar = Path.DirectorySeparatorChar;

            return $"{basePath}{separatorChar}{FileName}";
        }
    }
}
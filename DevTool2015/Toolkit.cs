using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace DevTool2015
{
    public class Toolkit
    {
        private string strObject, strAllObjects;
        private string ExportPath; //сюда будем выкладывать результаты разбора
        private List<NAVObject> NAVObjects;
        public string strWhereUsed; //сюда кладем результат процедуры WhereUsed
        public Toolkit()
        {
            NAVObjects = new List<NAVObject>();
        }
        /// <summary>
        /// загружаем строку с текстом объекта
        /// </summary>
        public void SetObject(string Param)
        {
            strObject = Param;
        }
        /// <summary>
        /// загружаем файл с несколькими объектами
        /// </summary>
        /// <param name="Param"></param>
        public void SetAllObjects(string Param)
        {
            strAllObjects = Param;
        }
        /// <summary>
        /// получаем директорию, в которой лежит разбираемый файл. 
        /// мы туда же будем класть файлы с результатами
        /// </summary>
        /// <param name="Path"></param>
        public void SetDirectory(string Path)
        {
            ExportPath = Path;
        }
        /// <summary>
        /// считаем, сколько в объекте процедур
        /// </summary>
        public int CountProcedures()
        {
            StreamWriter sw = new StreamWriter(ExportPath + "\\ProceduresList.txt", false, System.Text.Encoding.Default);
            //string pattern = @"PROCEDURE\W?[^\@]+\@\d+\(";
            string pattern = @"(LOCAL\s)?PROCEDURE\W?(?<name>[^\@]+)\@(?<number>\d+)\(";
            Regex newReg = new Regex(pattern);
            MatchCollection matches = newReg.Matches(strObject);
            foreach (Match mat in matches)
            {
                sw.WriteLine(mat.Value);
                //sw.WriteLine(mat.Groups["name"].Value);
                //sw.WriteLine(mat.Groups["number"].Value);
                //sw.WriteLine("\n");
            }
            sw.Close();
            return(matches.Count);
        }
        public void DivideObjects(System.ComponentModel.BackgroundWorker b)
        {
            //StreamWriter sw = new StreamWriter(ExportPath + "\\Objects.txt", false, System.Text.Encoding.Default);
            string sOneObject, sAllObj = strAllObjects;
            NAVObjects.Clear();
            b.ReportProgress(10);
            //string pattern = @"OBJECT\{[.]+\}(OBJECT|$)";
            //string pattern = @"OBJECT[(\w|\W)]+OBJECT";
            //string pattern = @"OBJECT\sTable\s[\d]*\s[\w|\s]*[\W]*\{[(\w|\W)]+\}[\W]*OBJECT[(\w|\W)]*";
            //string pattern = @"OBJECT\sTable\s[\d]*\s[\w|\s]*[\W]*\{[^(OBJECT)]+\}[\W]*OBJECT";
            string pattern = @"OBJECT\s(?<type>\w+)\s(?<number>\d+)\s(?<name>[^\{]+)\r\n\{";
            Regex newReg = new Regex(pattern);
            MatchCollection matches = newReg.Matches(sAllObj);
            b.ReportProgress(30);
            for (int j = 0; j < (matches.Count - 1); j++)
            {
                sOneObject = strAllObjects.Substring(matches[j].Index, matches[j+1].Index - matches[j].Index);
                NAVObjects.Add(new NAVObject(sOneObject));
                //_notifier.Notify((int)Math.Round((decimal)(j / matches.Count * 100)));
                b.ReportProgress(30 + (int)Math.Round((decimal)j / (decimal)matches.Count * 50));
                //sw.WriteLine(sOneObject);
                //sw.WriteLine("Конец объекта");
            }
            if (matches.Count > 0)
            {
                sOneObject = strAllObjects.Substring(matches[matches.Count - 1].Index);
                NAVObjects.Add(new NAVObject(sOneObject));
                //_notifier.Notify(100);
                
                //sw.WriteLine(sOneObject);
                //sw.WriteLine("Конец объекта");
                //sw.Close();
            }
            b.ReportProgress(80);
            NAVObjects.Sort();
            b.ReportProgress(90);
            ExportObjects();
            b.ReportProgress(100);
        }

        public void ExportObjects()
        {
            //сначала очистим папку
            DirectoryInfo dir = new DirectoryInfo(ExportPath);
            List<string> Files = new List<string>();
            foreach (FileInfo f in dir.GetFiles())
            {
                //Files.Add(f.FullName);
                File.Delete(f.FullName);
            }
            
            //а вот теперь выгружаем в нее объекты
            foreach (NAVObject NO in NAVObjects)
            {
                NO.ExportObject(ExportPath);
                /*
                using (StreamWriter sw = new StreamWriter(ExportPath + "\\" + NO.Type.ToString() + "_" + NO.Number.ToString() + "_" + NO.Name.Replace("/","_") + ".txt", false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(NO.Text);
                    sw.Close();
                }
                */
            }
        }

        public void ImportObjects(string ImportPath, System.ComponentModel.BackgroundWorker b)
        {
            NAVObjects.Clear();
            
            StreamReader sr;
            var dir = new DirectoryInfo(ImportPath);
            var Files = new List<string>();
            foreach (FileInfo f in dir.GetFiles("*.txt"))
            {
                //Files.Add(f.FullName);
                Files.Add(Path.GetFileNameWithoutExtension(f.FullName));
            }
            string pattern = @"(Table|Page|Report|Codeunit|Query|XMLport|MenuSuite)_\d+_[\w|\s]+";//изменить!!!!
            Regex newReg = new Regex(pattern);
            Match mat;
            b.ReportProgress(1);
            int i = 0;
            foreach (string f in Files)
            {
                mat = newReg.Match(f);
                if (mat.Success)
                {
                    sr = new StreamReader(ImportPath + "\\" +f + ".txt");
                    NAVObjects.Add(new NAVObject(sr.ReadToEnd())); 
                }
                b.ReportProgress((int)Math.Round((decimal)i / (decimal)Files.Count * 94));
                i += 1;
            }
            b.ReportProgress(95);
            NAVObjects.Sort();
        }

        public string GetObjectList()
        {
            string result = "";
            foreach (NAVObject NO in NAVObjects)
            {
                result += NO.GetName();
            }
            return (result);
        }
       
        public void WhereUsed(int rectype, int recnumber, System.ComponentModel.BackgroundWorker b)
        {
            string result = "";
            string strWhere;
            int j = 0;
            b.ReportProgress(1);
            foreach (NAVObject NO in NAVObjects)
            {
                strWhere = NO.WhereUsed((NAVTypes)rectype,recnumber);
                if (!string.IsNullOrEmpty(strWhere))
                    result += strWhere;
                j += 1;
                b.ReportProgress((int)Math.Round((decimal)j / (decimal)NAVObjects.Count * 100));
            }
            //return (result);
            //b.ReportProgress(100);
            strWhereUsed = result;
        }

        public string[] ProceduresList(int type, int number)
        {
            string[] result;
            NAVObject NO;
            NO = NAVObjects.Find(x => ((int)x.Type == type) && (x.Number == number));
            if (NO != null)
            {
                result = new string[NO.Procedures.Count];
                int i = 0;
                foreach (NAVProcedure Pr in NO.Procedures)
                {
                    result[i] = Pr.Name;
                    i++;
                }
            }
            else
            {
                result = new string[1];
                result[0] = "";
            }
            return (result);
        }

        public void WhereProcedureUsed(int type, int number, string proc_name, System.ComponentModel.BackgroundWorker b)
        {
            string result = "";
            string strWhere;
            int j = 0;
            b.ReportProgress(1);
            foreach (NAVObject NO in NAVObjects)
            {
                strWhere = NO.WhereProcedureUsed((NAVTypes)type, number, proc_name);
                if (!string.IsNullOrEmpty(strWhere))
                    result += strWhere;
                j += 1;
                b.ReportProgress((int)Math.Round((decimal)j / (decimal)NAVObjects.Count * 100));
            }
            strWhereUsed = result;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;


namespace DevTool2015
{
    public enum NAVTypes {Table,Page,Report,Codeunit,Query,XMLport,MenuSuite};
    public struct VarObject
    {
        public NAVTypes Type;
        public int Subtype;
        public string Name;

        public VarObject(NAVTypes pType,int pSubtype, string pName)
        {
            Subtype = pSubtype;
            Name = pName;
            Type = pType;
        }
    }

    public struct DataItem
    {
        public string Name;
        public int RecNum;
    }

    public struct Field
    {
        public int FieldNo;
        public string Name;
        public string Type;
        //еще нужно добавить триггеры
        public string[] Triggers; //попробуем название не пихать в отдельную структуру, а брать первое слово из текста, оно будет название
    }

    class NAVObject :IComparable<NAVObject>
    {
        /// <summary>
        /// 1 - table
        /// 2 - page
        /// 3 - report
        /// 4 - codeunit
        /// 5 - query
        /// 6 - xmlport
        /// 7 - menusuite
        /// </summary>
        public NAVTypes Type;
        public int Number;
        public string Name;
        protected string Text; //здесь все, что до процедур
        private string GlobalText; //весь текст объекта
        public List<NAVProcedure> Procedures;
        protected List<VarObject> VarObjects; //список переменных, здесь - глобальных (ну и пока триггеров тоже), локальные - в наследниках

        private List<DataItem> DataItems;
        int[] SourceTables;
        static List<VarObject> AllObjects;//здесь список всех объектов, чтобы искать по нему номер или имя

        public NAVObject(string pText)
        {
            Text = pText;
            GlobalText = pText; //где-то же должно храниться вообще все
            Parse();
            if (AllObjects == null)
                AllObjects = new List<VarObject>();
            AllObjects.Add(new VarObject(Type, Number, Name));
        } //добавить деструктор, который удаляет соответствующий элемент из AllObjects, если он там есть
        //хотя по идее такое никогда не понадобится

        /// <summary>
        /// нужно для потомка. Т.к. при запуске конструктора потомка нам нельзя ничего делать с этим классом
        /// </summary>
        protected NAVObject()
        { }
        
        private void Parse()
        {
            //разбираем заголовок
            {
                string pattern = @"OBJECT\s(?<type>\w+)\s(?<number>\d+)\s(?<name>[^\{]+)\r\n\{";
                Regex newReg = new Regex(pattern);
                Match mat = newReg.Match(Text);
                if (mat.Success)
                {
                    try
                    { Type = (NAVTypes)Enum.Parse(typeof(NAVTypes), mat.Groups["type"].Value); }
                    catch (Exception ex) { System.Windows.Forms.MessageBox.Show("Неизвестный тип объекта: " + ex.Message); }
                    Number = Int32.Parse(mat.Groups["number"].Value);
                    Name = mat.Groups["name"].Value;
                }
            }
            //смотрим, какие есть процедуры
            Procedures = new List<NAVProcedure>();
            {
                string pattern = @"(LOCAL\s)?PROCEDURE\W?(?<name>[^\@]+)\@(?<number>\d+)\(";
                Regex newReg = new Regex(pattern);
                MatchCollection matches = newReg.Matches(Text);
                for (int j = 0; j < (matches.Count - 1); j++)
                {
                    Procedures.Add(new NAVProcedure(Text.Substring(matches[j].Index, matches[j + 1].Index - matches[j].Index)));
                }
                if (matches.Count > 0)
                {
                    Procedures.Add(new NAVProcedure(Text.Substring(matches[matches.Count - 1].Index)));
                    Text = Text.Substring(0, matches[0].Index); //если есть процедуры, то основной текст обрезаем, чтобы не дублировался
                    //в последней процедуре окажется блок Documentation, т.к. он никак не отделен, и event'ы, если есть
                    //хорошо бы обработать ее, чтобы лишнее обрезать. Видимо, только считать кол-во begin,end,case.
                    //а еще, если в объекте есть Event's, то они тоже попадут в последнюю процедуру. В них редко бывает что-то полезное,
                    //поэтому вряд ли необходимо их разбирать
                }
                
            }
            VarObjects = new List<VarObject>();
            FindRecords();
            DataItems = new List<DataItem>();
            
            if ((Type == NAVTypes.Report) || (Type == NAVTypes.Query))
                FindDataItems();
            //ищем SourceTable
            if (Type == NAVTypes.Page)  //для страниц только одна source table
            {
                string pattern = @"(SourceTable=Table)(?<recnum>\d+);";
                Regex newReg = new Regex(pattern);
                Match mat = newReg.Match(Text);
                if (mat.Success)
                {
                    SourceTables = new int[1];
                    SourceTables[0] = int.Parse(mat.Groups["recnum"].Value);
                }
            }
            if (Type == NAVTypes.Codeunit)  //для кодеюнитов только одна source table
            {
                string pattern = @"(PROPERTIES)\W+{\W+(TableNo=)(?<recnum>\d+);";
                Regex newReg = new Regex(pattern);
                Match mat = newReg.Match(Text);
                if (mat.Success)
                {
                    SourceTables = new int[1];
                    SourceTables[0] = int.Parse(mat.Groups["recnum"].Value);
                }
            }
            if (Type == NAVTypes.XMLport) //в XMLport может быть много source table
            {
                string pattern = @"(SourceTable=Table)(?<recnum>\d+);";
                Regex newReg = new Regex(pattern);
                MatchCollection matches = newReg.Matches(Text);
                int i = 0;
                if (matches.Count > 0)
                    SourceTables = new int[matches.Count];
                foreach (Match mat in matches)
                {
                    SourceTables[i] = int.Parse(mat.Groups["recnum"].Value);
                    i++;
                }
            }
            FindPages();
            FindReports();
            FindCodeunits();
            FindQueries();
            FindXMLPorts();
            AddNumbers();

            //разбираем поля
            if (Type == NAVTypes.Table)
            {
                ParseFields();
            }
        }

        private void ParseFields()
        {
            string AllFields;// сюда вырежем кусок от FIELDS до KEYS
            //AllFields = 
        }

        public string GetName()
        {
            return(Type.ToString() + " " + Number.ToString() + " " + Name + "\r\n");
        }
        protected void FindRecords()
        {
            string pattern = @"(?<name>(""[^""]+"")|(\w+))\@\d+\s:\s(TEMPORARY\s)?Record\s(?<rectype>\d+)";
            //string pattern = @"(?<name>[\w|\s]+)\@\d+\s:\sRecord\s(?<rectype>\d+)";

            Regex newReg = new Regex(pattern);
            MatchCollection matches = newReg.Matches(Text);
            foreach (Match mat in matches)
            {
                //Records.Add(int.Parse(mat.Groups["rectype"].Value));
                VarObjects.Add(new VarObject(NAVTypes.Table, int.Parse(mat.Groups["rectype"].Value), mat.Groups["name"].Value));
            }

            //ищем те, которые прям в тексте написаны как DATABASE::"tableName"
            /*
            pattern = @"(DATABASE::)""(?<name>[\w|\s]+)""";
            newReg = new Regex(pattern);
            matches = newReg.Matches(Text);
            foreach (Match mat in matches)
            {
                VarObjects.Add(new VarObject(NAVTypes.Table, 0, mat.Groups["name"].Value));
            }*/

        }

        protected void FindPages()
        {
            string pattern = @"(?<name>(""[^""]+"")|(\w+))\@\d+\s:\sPage\s(?<pagetype>\d+)";
            Regex newReg = new Regex(pattern);
            MatchCollection matches = newReg.Matches(Text);
            foreach (Match mat in matches)
            {
                VarObjects.Add(new VarObject(NAVTypes.Page, int.Parse(mat.Groups["pagetype"].Value), mat.Groups["name"].Value));
            }
            //сюда же складываем TESTPAGE, все равно они на те же объекты ссылаются
            pattern = @"(?<name>(""[^""]+"")|(\w+))\@\d+\s:\sTestPage\s(?<pagetype>\d+)";
            newReg = new Regex(pattern);
            matches = newReg.Matches(Text);
            foreach (Match mat in matches)
            {
                VarObjects.Add(new VarObject(NAVTypes.Page, int.Parse(mat.Groups["pagetype"].Value), mat.Groups["name"].Value));
            }
            /*
            pattern = @"\b(PAGE.RUN)(MODAL)?\((PAGE::"")(?<pagename>[\w|\s]+)"""; //а если разбирать дальше, можно найти и запись, с которой запускается. Это для проверки, используется объявленный рекорд
            newReg = new Regex(pattern);
            matches = newReg.Matches(Text);
            foreach (Match mat in matches)
            {
                VarObjects.Add(new VarObject(NAVTypes.Page, 0, mat.Groups["pagename"].Value)); //вот номер мы пока не знаем, надо смотреть список объектов...
            }*/
            /*
            pattern = @"(TEST)?(PAGE::)""(?<name>[\w|\s]+)""";
            newReg = new Regex(pattern);
            matches = newReg.Matches(Text);
            foreach (Match mat in matches)
            {
                VarObjects.Add(new VarObject(NAVTypes.Page, 0, mat.Groups["name"].Value));
            }
            */
        }

        protected void FindReports()
        {
            string pattern = @"(?<name>(""[^""]+"")|(\w+))\@\d+\s:\sReport\s(?<type>\d+)";
            Regex newReg = new Regex(pattern);
            MatchCollection matches = newReg.Matches(Text);
            foreach (Match mat in matches)
            {
                VarObjects.Add(new VarObject(NAVTypes.Report, int.Parse(mat.Groups["type"].Value), mat.Groups["name"].Value));
            }
        }
        protected void FindCodeunits()
        {
            string pattern = @"(?<name>(""[^""]+"")|(\w+))\@\d+\s:\sCodeunit\s(?<type>\d+)";
            Regex newReg = new Regex(pattern);
            MatchCollection matches = newReg.Matches(Text);
            foreach (Match mat in matches)
            {
                VarObjects.Add(new VarObject(NAVTypes.Codeunit, int.Parse(mat.Groups["type"].Value), mat.Groups["name"].Value));
            }
        }
        protected void FindQueries()
        {
            string pattern = @"(?<name>(""[^""]+"")|(\w+))\@\d+\s:\sQuery\s(?<type>\d+)";
            Regex newReg = new Regex(pattern);
            MatchCollection matches = newReg.Matches(Text);
            foreach (Match mat in matches)
            {
                VarObjects.Add(new VarObject(NAVTypes.Query, int.Parse(mat.Groups["type"].Value), mat.Groups["name"].Value));
            }
        }
        protected void FindXMLPorts()
        {
            string pattern = @"(?<name>(""[^""]+"")|(\w+))\@\d+\s:\sXMLport\s(?<type>\d+)";
            Regex newReg = new Regex(pattern);
            MatchCollection matches = newReg.Matches(Text);
            foreach (Match mat in matches)
            {
                VarObjects.Add(new VarObject(NAVTypes.XMLport, int.Parse(mat.Groups["type"].Value), mat.Groups["name"].Value));
            }
        }

        /// <summary>
        /// Ищем номера для найденных в объектах датаайтемов, страниц, репортов, кодеюнитов
        /// которые упоминаются только через RUN, REPORT::, PAGE:: и т.д.
        /// </summary>
        protected void AddNumbers()
        {
            int subt;
            string n;
            for(int i = 0; i < VarObjects.Count; i++)
            {
                if (VarObjects[i].Subtype == 0)
                {
                    subt = AllObjects.Find(x => (x.Name == VarObjects[i].Name) && (x.Type == VarObjects[i].Type)).Subtype;
                    if (subt != 0)
                    {
                        VarObject t = new VarObject();
                        t.Type = VarObjects[i].Type;
                        t.Subtype = subt;
                        t.Name = VarObjects[i].Name;
                        VarObjects[i] = t;
                    }
                }
            }
            for (int i = 0; i < DataItems.Count; i++)
            {
                if (DataItems[i].Name.Trim() == "")
                {
                    n = AllObjects.Find(x => (x.Subtype == DataItems[i].RecNum) && (x.Type == 0)).Name;
                    if (n != null)
                    {
                        DataItem t;
                        t.Name = n;
                        t.RecNum = DataItems[i].RecNum;
                        DataItems[i] = t;
                    }
                }
            }
        }

        private void FindDataItems()
        {
            DataItems = new List<DataItem>();
            string pattern = @"(;DataItem;)(?<name>[^;]+);\W+(DataItemTable=Table)(?<recnum>\d+)[;]?";
            Regex newReg = new Regex(pattern);
            MatchCollection matches = newReg.Matches(Text);
            foreach (Match mat in matches)
            {
                DataItems.Add(new DataItem() { Name = mat.Groups["name"].Value, RecNum = int.Parse(mat.Groups["recnum"].Value) });
            }
        }

        public string WhereUsed(NAVTypes rectype,int recnumber)
        {
            string result = "",resultProc = "",resultDataItems = "";
            List<VarObject> resList;
            resList = VarObjects.FindAll(x => (x.Type == rectype) && (x.Subtype == recnumber));
            foreach (VarObject rec in resList)
            //foreach (VarObject rec in VarObjects)
            {
                //if (rec.Subtype == recnumber) 
                    result += (Type.ToString() + " " + Name + " " + Number.ToString() + ", name = " + rec.Name + "\r\n");
            }
            foreach (NAVProcedure NP in Procedures)
            {
                resultProc += NP.WhereUsed(rectype,recnumber);
            }
            if (!string.IsNullOrEmpty(resultProc))
                result += (Type.ToString() + " " + Name + " " + Number.ToString() + " Procedures:\r\n" + resultProc);
            if ((Type == NAVTypes.Report) && (rectype == NAVTypes.Table))
            {
                foreach (DataItem DI in DataItems)
                {
                    if (DI.RecNum == recnumber)
                    //resultDataItems += ("\tDataItem, name = " + DI.Name + "\r\n");
                    {
                        resultDataItems += ("\tDataItem, name = ");
                        if (DI.Name.Trim() == "")
                            resultDataItems += ("Table" + DI.RecNum.ToString());
                        else
                            resultDataItems += DI.Name;
                        resultDataItems += ("\r\n");
                    }
                }
                if (!string.IsNullOrEmpty(resultDataItems))
                    result += (Type.ToString() + " " + Name + " " + Number.ToString() + " DataItems\r\n" + resultDataItems);
            }
            if ((rectype == NAVTypes.Table) && ((Type == NAVTypes.Page) || (Type == NAVTypes.Codeunit) || (Type == NAVTypes.XMLport)) && (SourceTables != null))
            {
                for (int i = 0; i < SourceTables.Length; i++)
                {
                    if (SourceTables[i] == recnumber)
                        result += (Type.ToString() + " " + Name + " " + Number.ToString() + "\tSource Table \r\n");
                }
            }

            return (result);
        }

        public void ExportObject(string ExportPath)
        {
            StreamWriter sw = new StreamWriter(ExportPath + "\\" + Type.ToString() + "_" + Number.ToString() + "_" + Name.Replace("/", "_").Replace("\\","_").
                Replace("|","_").Replace(":", "_").Replace("*", "_").Replace("?", "_").Replace("\"", "_").Replace("<", "_").Replace(">", "_") + ".txt", false, Encoding.Default);
            sw.WriteLine(GlobalText);
            sw.Close();
        }

        /// <summary>
        /// переопределенная функция для сортировки коллекции. Сортируем сначала по типу, затем по номеру
        /// </summary>
        /// <param name="NO"></param>
        /// <returns></returns>
        public int CompareTo (NAVObject NO) 
        {
            if (Type < NO.Type) return -1;
            else if (Type > NO.Type) return 1;
            else return Number.CompareTo(NO.Number);
        }

        public string WhereProcedureUsed(NAVTypes type, int number, string proc_name)
        {
            string result = "", resultProc = "";
            string str_with;
            bool bFound;
            string pattern = @"((?<name>(""[^""]+"")|(\w+)).)?(" + proc_name + @")\b";
            Regex newReg = new Regex(pattern);
            MatchCollection matches;
            //сначала ищем в глобальной части объекта
            bFound = false;
            matches = newReg.Matches(Text);
            foreach (Match mat in matches)
            {
                if (mat.Groups["name"].Value == "")
                { //значит либо это сам объект, либо source table, либо dataitem, либо есть with
                  //проверяем, не находимся ли мы в самом объекте
                    if ((type == Type) && (number == Number))
                        bFound = true;
                    if (type == NAVTypes.Table)
                    {
                        //проверяем source table
                        if (SourceTables != null)
                        {
                            if (SourceTables.Contains(number))
                                bFound = true;
                        }
                        //проверяем dataitem - проверить бы, мы находимся в датаайтеме или нет
                        if (DataItems.Find(x => x.RecNum == number).Name != null)
                            bFound = true;
                    }
                    //а еще может быть WITH :(
                    //ищем самый последний, т.е. обрезаем текст процедуры до найденного вхождения (обрезаем, т.к. вхождений может быть несколько)
                    //и ищем перед ним WITH
                    //если не обрезать, то можно использовать шаблон (WITH <varobj_name> DO)[\w|\W]+?<proc_name>
                    str_with = Text.Substring(0, mat.Index);
                    string pattern1 = @"(WITH )?<varname>[\W|\w]+?( DO)";
                    Regex newReg1 = new Regex(pattern1);
                    MatchCollection matches1 = newReg1.Matches(str_with);
                    if (matches1.Count > 0) //нашли какой-то WITH
                    {
                        string var_name = matches1[matches1.Count - 1].Groups["varname"].Value; //берем последний
                                                                                                //ищем в глобальных переменных
                        if (VarObjects.Find(x => (x.Type == type) && (x.Subtype == number) && (x.Name == var_name)).Name != null)
                            bFound = true;
                    }
                }
                else //перед именем процедуры что-то есть
                {
                    if ((mat.Groups["name"].Value == "Rec") || (mat.Groups["name"].Value == "xRec"))
                    {
                        if (type == NAVTypes.Table) //Rec может быть только у таблицы
                        { 
                            //проверить, находимся ли мы в таблице с номером number
                            if ((type == Type) && (number == Number))
                            bFound = true;
                            //или в кодеюните, для которого наша таблица source table - мы сейчас полюбому находимся в OnRun 
                            //или в странице, для которой наша таблица source table 
                            if (((Type == NAVTypes.Page) || (Type == NAVTypes.Codeunit)) && (SourceTables != null) && (SourceTables[0] == number))
                                bFound = true;
                        }
                    }
                    else
                    {
                        //нужно искать соответствующую переменную, или dataitem
                        //либо переменная глобальная, тогда первая из найденных, т.к. сначала объявление глоб. переменных, а затем поля и триггеры
                        if (VarObjects.Find(x => (x.Type == type) && (x.Subtype == number) && (x.Name == mat.Groups["name"].Value)).Name != null)
                            bFound = true;
                        if ((type == NAVTypes.Table) && (DataItems.Find(x => (x.RecNum == number) && (x.Name == mat.Groups["name"].Value)).Name != null))
                            bFound = true;
                    }
                }
            }
            if (bFound)
                result += (Type.ToString() + " " + Name + " " + Number.ToString() + "\r\n");

            //затем ходим по процедурам, и ищем в каждой
            foreach (NAVProcedure NP in Procedures)
            {
                bFound = false;
                matches = newReg.Matches(NP.Text);
                foreach (Match mat in matches)
                {
                    if (mat.Groups["name"].Value == "")
                    { //значит либо это сам объект, либо source table, либо dataitem, либо есть with
                        //проверяем, не находимся ли мы в самом объекте
                        if ((type == Type) && (number == Number))
                            bFound = true;
                        if ((type == NAVTypes.Table) && (SourceTables != null))
                        {
                            //проверяем source table
                            if (SourceTables.Contains(number))
                                bFound = true;
                        }
                        //а еще может быть WITH :(
                        //ищем самый последний, т.е. обрезаем текст процедуры до найденного вхождения (обрезаем, т.к. вхождений может быть несколько)
                        //и ищем перед ним WITH
                        //если не обрезать, то можно использовать шаблон (WITH <varobj_name> DO)[\w|\W]+?<proc_name>
                        str_with = NP.Text.Substring(0, mat.Index);
                        string pattern1 = @"(WITH )?<varname>[\W|\w]+?( DO)";
                        Regex newReg1 = new Regex(pattern1);
                        MatchCollection matches1 = newReg1.Matches(str_with);
                        if (matches1.Count > 0) //нашли какой-то WITH
                        {
                            string var_name = matches1[matches1.Count - 1].Groups["varname"].Value; //берем последний
                            //ищем в глобальных переменных
                            if (VarObjects.Find(x => (x.Type == type) && (x.Subtype == number) && (x.Name == var_name)).Name != null)
                                    bFound = true;
                            //и в локальных, здесь конечно приоритетнее, но нам без разницы
                            if (NP.VarObjects.Find(x => (x.Type == type) && (x.Subtype == number) && (x.Name == var_name)).Name != null)
                                bFound = true;
                        }
                    }
                    else //перед именем процедуры что-то есть
                    {
                        if ((mat.Groups["name"].Value == "Rec") || (mat.Groups["name"].Value == "xRec"))
                        {
                            if (type == NAVTypes.Table)
                            {
                                //проверить, находимся ли мы в объекте с номером number
                                if ((type == Type) && (number == Number))
                                    bFound = true;
                                //или в странице, для которой наша таблица source table 
                                if ((Type == NAVTypes.Page) && (SourceTables != null) && (SourceTables[0] == number))
                                    bFound = true;
                            }
                        }
                        else
                        {
                            //нужно искать соответствующую переменную
                            //либо переменная глобальная, тогда первая из найденных, т.к. сначала объявление глоб. переменных, а затем поля и триггеры
                            if (VarObjects.Find(x => (x.Type == type) && (x.Subtype == number) && (x.Name == mat.Groups["name"].Value)).Name != null)
                                bFound = true; 
                            //либо локальная
                            if (NP.VarObjects.Find(x => (x.Type == type) && (x.Subtype == number) && (x.Name == mat.Groups["name"].Value)).Name != null)
                                bFound = true;
                        }
                    }
                }
                if (bFound)
                    resultProc += ("\tProcedure " + NP.Name + "\r\n");
            }
            if (!string.IsNullOrEmpty(resultProc))
                result += (Type.ToString() + " " + Name + " " + Number.ToString() + " Procedures:\r\n" + resultProc);

            return (result);
        }
    }
}
